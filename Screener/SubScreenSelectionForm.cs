/* Author: Luke Familo */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Screener
{
    /// <summary>
    /// Form used to specify a rectangle on the screen.
    /// 
    /// Has handles to drag the rectangle around.
    /// The rectangle is completely transparent, while the rest of the form is only slightly transparent.
    /// Window closes as soon as esc/enter are pressed, user right clicks, or the form loses focus/deactivates.
    /// </summary>
    public partial class SubScreenSelectionForm : Form
    {
        #region Fields

        /// <summary>
        /// The object that will receive the rectangle.
        /// </summary>
        private IReceivesRectangle rectangleReceiver;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates the overlay form for specifiying the frame rectangle.
        /// </summary>
        /// <param name="screener"> The screener form that is opening this. </param>
        public SubScreenSelectionForm(IReceivesRectangle receiver = null)
        {
            InitializeComponent();

            this.rectangleReceiver = receiver;
            stopDragging(null, null);
        }

        #endregion
        
        #region Callbacks

        /// <summary>
        /// Updates the center rectangle display. (called when bounds are moved and when form becomes visible.
        /// </summary>
        private void updateRect(object sender, EventArgs e)
        {
            if (!(sender is Control)) return;
            Control control = (Control)sender;

            if (!(bool)control.Tag) return;
            
            if (control != center)
            {
                Point s1 = SEHandle.Bounds.GetMidpoint(), s2 = NWHandle.Bounds.GetMidpoint();

                Point upperLeft = new Point(
                    Math.Min(s1.X, s2.X),
                    Math.Min(s1.Y, s2.Y));

                Size size = Size.Subtract(new Size(
                    Math.Max(s1.X, s2.X),
                    Math.Max(s1.Y, s2.Y)),
                    new Size(upperLeft));

                center.Bounds = new Rectangle(upperLeft, size);
                center.SendToBack();
            }
            else
            {
                NWHandle.Location = Point.Subtract(center.Location, NWHandle.Size.Multiple(0.5));
                SEHandle.Location = Point.Subtract(Point.Add(center.Location, center.Size), NWHandle.Size.Multiple(0.5));
            }
        }

        #region Dragging

        /// <summary>
        /// Stop dragging.
        /// </summary>
        private void stopDragging(object sender, MouseEventArgs e)
        { SEHandle.Tag = NWHandle.Tag = center.Tag = false; }

        /// <summary>
        /// Drags the currently selected bound (if there is one).
        /// </summary>
        private void drag(object sender, MouseEventArgs e)
        {
            // If not a control, exit method.
            if (!(sender is Control)) return;

            Control control = (Control)sender;
            if (control.Tag is bool)
            {
                if ((bool)control.Tag)
                    control.Location = Point.Subtract(MousePosition, control.Size.Multiple(0.5));
            }
        }
        
        /// <summary>
        /// Begins dragging the current bound the mouse has just pressed with the left mouse button.
        /// </summary>
        private void beginDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (sender is Control)
                    ((Control)sender).Tag = true;
            }
        }

        #endregion

        /// <summary>
        /// When being hidden, send the rectangle to the screener.
        /// When being shown, update the rectangles.
        /// </summary>
        private void VisibilityChanged(object sender, EventArgs e)
        {
            if (Visible) { Tag = true; updateRect(this, null); Tag = null; }
            else rectangleReceiver.SetRectangle(center.Bounds); 
        }

        /// <summary>
        /// If right mouse is clicked, go back to screener.
        /// </summary>
        private void Clicked(object sender, MouseEventArgs e)
        { if (e.Button == MouseButtons.Right) { Hide(); } }

        /// <summary>
        /// When esc or enter is pressed, we're finished.
        /// </summary>
        private void keyUp(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter) Hide(); }

        /// <summary>
        /// When focus is lost (or disabled due to changing to the screener form) we're finished.
        /// </summary>
        private void FocusLost(object sender, EventArgs e)
        { stopDragging(null, null); Hide(); }

        #endregion

    }
}
