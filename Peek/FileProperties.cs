/* Author: Luke Familo */
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Screener
{
    /// <summary>
    /// A file properties form for the user to specify how to save screenshots with the Screener Form.
    /// </summary>
    public partial class FileProperties : Form
    {

        #region Fields

        private IReceivesImageFileProperties receiver;
        private static List<ImageFormat> fileFormats = new List<ImageFormat>() { ImageFormat.Png, ImageFormat.Jpeg, ImageFormat.Gif, ImageFormat.Bmp, ImageFormat.Tiff };

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the root file name (shortcut to calling <code>receiver.RootName</code>
        /// </summary>
        public String RootName
        {
            get
            {
                return receiver.RootName;
            }
            set
            {
                receiver.RootName = value;
            }
        }

        /// <summary>
        /// Gets or sets the save directory (shortcut to calling <code>receiver.SaveDirectory</code>
        /// </summary>
        public DirectoryInfo SaveDirectory
        {
            get
            {
                return receiver.SaveDirectory;
            }
            set
            {
                receiver.SaveDirectory = value;
            }
        }

        /// <summary>
        /// Gets or sets the flip pair (shortcut to calling <code>receiver.FlipPair</code>
        /// </summary>
        public RotationFlipPair FlipPair
        {
            get
            {
                return receiver.FlipPair;
            }
            set
            {
                receiver.FlipPair = value;
            }
        }

        /// <summary>
        /// Gets or sets the file format (shortcut to calling <code>receiver.FileFormat</code>
        /// </summary>
        public ImageFormat FileFormat
        {
            get
            {
                return receiver.FileFormat;
            }
            set
            {
                receiver.FileFormat = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a file properties form for the user to specify how to save screenshots with the Screener Form.
        /// </summary>
        /// <param name="receiver"> Object to recive the input from this form. (screener). </param>
        public FileProperties(IReceivesImageFileProperties receiver)
        {
            InitializeComponent();
            this.receiver = receiver;

            #region Initialize Controls

            // Set the root name text field to the current root name.
            rootNameField.Text = RootName;

            // Set the directory text field to the currently selected directory.
            directoryField.Text = SaveDirectory.FullName;

            // Populate the file type selector with all the file types, and then set it to the currently selected filetype.
            fileTypeSelect.Items.AddRange(fileFormats.ToArray());
            fileTypeSelect.SelectedIndex = fileFormats.IndexOf(FileFormat);

            //Populate the flip selection box with all the flip types, and then set it to the currently selected flip type.
            flipSelectionBox.Items.AddRange(Enum.GetValues(typeof(FlipType)).ToSimpleArray<object>());
            flipSelectionBox.SelectedItem = FlipPair.Flip;

            // Populate the rotation selectio box with all the rotation values, and then set it to the currently selected rotation.
            for (int i = 0; i < 360; i += 90)
            {
                rotationSelection.Items.Add(i);
            }
            rotationSelection.SelectedItem = FlipPair.Rotation;

            #endregion
        }

        #endregion

        #region Save Directory

        /// <summary>
        /// Opens a file dialog for the user to select the folder in which to save.
        /// </summary>
        private void OpenFileDialog(object sender, EventArgs eventArgs)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();

            if (Directory.Exists(folderDialog.SelectedPath))
            {
                directoryField.Text = folderDialog.SelectedPath;
                SaveDirectory = new DirectoryInfo(directoryField.Text);
            }
        }

        #endregion

        #region FlipPair

        /// <summary>
        /// Sets the rotation property in the <code>FlipPair</code> to the selected value whenever it is changed.
        /// Then redraws the rotation preview.
        /// </summary>
        private void RotationChanged(object sender = null, EventArgs eventArgs = null)
        {
            FlipPair.Rotation = (int)rotationSelection.SelectedItem;

            rotationPreviewAffected.Image = (Image)rotationPreviewUnAffected.Image.Clone();
            rotationPreviewAffected.Image.RotateFlip(FlipPair.DrawingFlipType);
            rotationPreviewAffected.Invalidate();
        }

        /// <summary>
        /// Sets the flip type property in the <code>FlipPair</code> to the selected value whenever it is changed.
        /// Then redraws the rotation preview.
        /// </summary>
        private void FlipChanged(object sender, EventArgs eventArgs)
        {
            FlipPair.Flip = (FlipType)flipSelectionBox.SelectedItem;

            rotationPreviewAffected.Image = (Image)rotationPreviewUnAffected.Image.Clone();
            rotationPreviewAffected.Image.RotateFlip(FlipPair.DrawingFlipType);
            rotationPreviewAffected.Invalidate();
        }

        #endregion

        #region FileType

        /// <summary>
        /// Sets the file type property to the selected value whenever it is changed.
        /// </summary>
        private void FileTypeChanged(object sender = null, EventArgs eventArgs = null)
        {
            FileFormat = fileFormats[fileTypeSelect.SelectedIndex];
        }

        #endregion

        #region RootName

        /// <summary>
        /// Sets the root file name property to the input fields text whenever it is changed.
        /// </summary>
        private void RootNameChanged(object sender, EventArgs eventArgs)
        {
            RootName = rootNameField.Text;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Draws an arrow from the unaffected to the affected rotation previews.
        /// </summary>
        protected override void OnPaint(PaintEventArgs eventArgs)
        {
            base.OnPaint(eventArgs);

            Pen pen = new Pen(Color.Black, 5);
            pen.StartCap = LineCap.NoAnchor;
            pen.EndCap = LineCap.ArrowAnchor;
            eventArgs.Graphics.DrawLine(pen, 
                rotationPreviewUnAffected.Right + 5,
                rotationPreviewUnAffected.Top + rotationPreviewUnAffected.Height / 2,
                rotationPreviewAffected.Left - 5,
                rotationPreviewAffected.Top + rotationPreviewAffected.Height / 2
            );
        }

        /// <summary>
        /// When closing, also enable the receiver.
        /// </summary>
        protected override void OnClosed(EventArgs eventArgs)
        {
            base.OnClosed(eventArgs);
            receiver.Enable();
        }

        #endregion
    }
}