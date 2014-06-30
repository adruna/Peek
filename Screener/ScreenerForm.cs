using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Screener
{
    /// <summary>
    /// The main form of the application.
    /// 
    /// Listens and for the hotkey press and takes a screenshot based on user specifications.
    /// </summary>
    public partial class ScreenerForm : Form, IReceivesRectangle, IReceivesImageFileProperties
    {
        #region Constants

        public const int MOD_ALT = 0x1;
        public const int MOD_CONTROL = 0x2;
        public const int MOD_SHIFT = 0x4;
        public const int MOD_NOREPEAT = 0x4000;

        public const Keys DEFAULT_CAPTURE_KEY = Keys.P;
        public const String DEFAULT_ROOT_NAME = "result";

        #endregion

        #region External

        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int MYACTION_HOTKEY_ID = 46;

        #endregion

        #region Fields

        private bool capturing;
        private bool changingCaptureKey;
        private Keys captureKey;
        private Keys modifiers;
        private Rectangle rect;

        private SubScreenSelectionForm overlay;
        private FileProperties properties;
        #endregion

        #region Properties

        /// <summary>
        /// True if we should use the full screen for the screen shot.
        /// </summary>
        public bool FullScreen { get { return !rectangleCheckBox.Checked; } }

        /// <summary>
        /// Gets or sets the image file format to use.
        /// </summary>
        public ImageFormat FileFormat { get; set; }

        /// <summary>
        /// Gets or sets the folder directory to save in.
        /// </summary>
        public DirectoryInfo SaveDirectory { get; set; }

        /// <summary>
        /// Gets or sets the rotation/flip type to use on the image before saving.
        /// </summary>
        public RotationFlipPair FlipPair { get; set; }

        /// <summary>
        /// The root filename to use when saving.
        /// </summary>
        public String RootName { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for the screener form.
        /// </summary>
        public ScreenerForm()
        {
            InitializeComponent();

            captureKey = DEFAULT_CAPTURE_KEY;
            dontChangeCaptureKey(null, null);

            SaveDirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ScreenerResults");
            RootName = DEFAULT_ROOT_NAME;
            FileFormat = ImageFormat.Png;
            FlipPair = new RotationFlipPair();

            rect = Screen.GetBounds(Point.Empty);
            overlay = new SubScreenSelectionForm(this);
            properties = new FileProperties(this);
        }

        #endregion

        #region Overrides
        
        /// <summary>
        /// Overrides to catch the external hotkey event.
        /// </summary>
        /// <param name="m"> Message. </param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                // My hotkey has been pressed
                takeScreen();
            }
            base.WndProc(ref m);
        }

        #endregion

        #region Event Handlers

        #region FormEvents

        /// <summary>
        /// Makes sure capture is toggled off when closing (so the hotkey is turned off too).
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> Event args. </param>
        private void onClose(object sender, FormClosingEventArgs e)
        { if (capturing) ToggleCapture(null, null); }

        #endregion

        #region Control Events

        /// <summary>
        /// Toggles capturing screenshots.
        /// Changes the capture button's text, and registers or unregisters hotkey.
        /// </summary>
        /// <param name="sender"> The Sender. </param>
        /// <param name="e"> Event args.</param>
        private void ToggleCapture(object sender = null, EventArgs e = null)
        {
            if (capturing)
            {
                captureButton.Text = "Allow Capture";
                UnregisterHotKey(this.Handle, MYACTION_HOTKEY_ID);
            }
            else
            {
                captureButton.Text = "Capturing";
                int mod = MOD_NOREPEAT;
                if (modifiers.HasFlag(Keys.Shift)) mod |= MOD_SHIFT;
                if (modifiers.HasFlag(Keys.Alt)) mod |= MOD_ALT;
                if (modifiers.HasFlag(Keys.Control)) mod |= MOD_CONTROL;

                RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID,(int)mod, (int)captureKey);
            }
            
            capturing = !capturing;
        }

        /// <summary>
        /// Begin listening for the new capture key.
        /// Turns off capture if already capturing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeCaptureKey(object sender, EventArgs e)
        {
            Console.WriteLine("changing capture key");

            if (capturing) ToggleCapture(null, null);

            changingCaptureKey = true;
            captureKeyField.Clear();
        }

        /// <summary>
        /// End of changing capture key, called whether given input or not.
        /// If called when no input specified, defaults to previous hotkey.
        /// </summary>
        /// <param name="sender"> The Sender. </param>
        /// <param name="e"> Event args. </param>
        private void dontChangeCaptureKey(object sender, EventArgs e)
        {
            Console.WriteLine("end changing capture key");

            changingCaptureKey = false;
            captureKeyField.Clear();

            captureKeyField.Text = ((modifiers == Keys.None) ? "" : modifiers + " - ") + captureKey;
            
        }

        /// <summary>
        /// Key down (right now only used for the hot key field).
        /// Listens to the desired hot key when being configured. The actual listening durring capture is in an external C library.
        /// TODO: work on modifiers, in particular alerting user when hotkey is unavailable.
        /// </summary>
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (changingCaptureKey)
            {
                modifiers = e.KeyData ^ e.KeyCode;

                if (e.KeyCode == Keys.ShiftKey || e.KeyCode == (Keys.RButton | Keys.ShiftKey) || e.KeyCode == Keys.ControlKey) return;

                captureKey = e.KeyCode;
                captureButton.Focus();
            }
        }

        /// <summary>
        /// Checks to see if the preview box was just set to visible, and calculates the rectangle to display.
        /// </summary>
        private void previewVisibilityChanged(object sender = null, EventArgs e = null)
        {
            if (preview.Visible)
            {
                preview.Size = Screen.GetBounds(Point.Empty).Size.Multiple(0.05);
                previewRect.Location = rect.Location.Multiple(0.05);
                previewRect.Size = rect.Size.Multiple(0.05);
            }
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Takes the screenshot.
        /// </summary>
        private void takeScreen()
        {
            Console.WriteLine("SCREENSHOT WOO!");

            if (!Directory.Exists(SaveDirectory.FullName)) Directory.CreateDirectory(SaveDirectory.FullName);

            Rectangle bounds = (FullScreen) ? Screen.GetBounds(Point.Empty) : rect;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
                    
                }
                Stream stream = getNextStream();

                bitmap.RotateFlip(FlipPair.DrawingFlipType);
                bitmap.Save(stream, FileFormat);
                stream.Close();
            }
        }

        /// <summary>
        /// Convienence method to open up a new stream for the image to be saved in.
        /// finds "path\filename#" where # isnt already taken (starting at 1).
        /// </summary>
        /// <returns> The stream. </returns>
        public Stream getNextStream()
        {
            int count = 1;
            string name = SaveDirectory.FullName + "\\" + RootName;

            while (File.Exists(name + count +  "." + FileFormat.ToString()))
            { count++; }

            return File.OpenWrite(name + count + "." + FileFormat.ToString());
        }

        #endregion 

        #region Overlay

        /// <summary>
        /// Opens the rectangle setting overlay.
        /// </summary>
        private void openOverlay(object sender, MouseEventArgs e)
        { if (capturing) ToggleCapture(); overlay.Show(); }

        /// <summary>
        /// Controls whether to show the rectangle preview or not.
        /// </summary>
        private void specifyAreaChecked(object sender, EventArgs e)
        {
            if (preview.Visible) preview.Hide();
            else preview.Show();
        }
        #endregion

        #region File Properties

        private void OpenProperties(object sender, EventArgs e)
        { if (capturing) { ToggleCapture(); } properties.Show(); Enabled = false; }

        public void Enable()
        { Enabled = true; properties = new FileProperties(this); }

        #endregion

        #region Interface Implementation

        /// <summary>
        /// Sets the rectangle to use for the screenshot (in realation to screen coordinates).
        /// </summary>
        /// <param name="r"> The rectangle. </param>
        public void SetRectangle(Rectangle r)
        { rect = r; previewVisibilityChanged(); }

        #endregion

    }
}
