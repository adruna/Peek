/* Author: Luke Familo */
namespace Screener
{
    partial class SubScreenSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NWHandle = new System.Windows.Forms.PictureBox();
            this.SEHandle = new System.Windows.Forms.PictureBox();
            this.center = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.NWHandle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SEHandle)).BeginInit();
            this.SuspendLayout();
            // 
            // NWHandle
            // 
            this.NWHandle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NWHandle.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.NWHandle.Image = global::Screener.Properties.Resources.button_round_green;
            this.NWHandle.Location = new System.Drawing.Point(12, 12);
            this.NWHandle.Name = "NWHandle";
            this.NWHandle.Size = new System.Drawing.Size(10, 10);
            this.NWHandle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NWHandle.TabIndex = 1;
            this.NWHandle.TabStop = false;
            this.NWHandle.LocationChanged += new System.EventHandler(this.updateRect);
            this.NWHandle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.beginDrag);
            this.NWHandle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag);
            this.NWHandle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stopDragging);
            // 
            // SEHandle
            // 
            this.SEHandle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SEHandle.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.SEHandle.Image = global::Screener.Properties.Resources.button_round_green;
            this.SEHandle.Location = new System.Drawing.Point(600, 302);
            this.SEHandle.Name = "SEHandle";
            this.SEHandle.Size = new System.Drawing.Size(10, 10);
            this.SEHandle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SEHandle.TabIndex = 2;
            this.SEHandle.TabStop = false;
            this.SEHandle.LocationChanged += new System.EventHandler(this.updateRect);
            this.SEHandle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.beginDrag);
            this.SEHandle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag);
            this.SEHandle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stopDragging);
            // 
            // center
            // 
            this.center.BackColor = System.Drawing.SystemColors.HotTrack;
            this.center.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.center.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.center.Location = new System.Drawing.Point(94, 115);
            this.center.Name = "center";
            this.center.Size = new System.Drawing.Size(200, 100);
            this.center.TabIndex = 3;
            this.center.LocationChanged += new System.EventHandler(this.updateRect);
            this.center.MouseDown += new System.Windows.Forms.MouseEventHandler(this.beginDrag);
            this.center.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drag);
            this.center.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stopDragging);
            // 
            // SubScreenSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(622, 324);
            this.Controls.Add(this.NWHandle);
            this.Controls.Add(this.center);
            this.Controls.Add(this.SEHandle);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubScreenSelectionForm";
            this.Opacity = 0.75D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "OverlayForm";
            this.TransparencyKey = System.Drawing.SystemColors.HotTrack;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.FocusLost);
            this.VisibleChanged += new System.EventHandler(this.VisibilityChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            this.Leave += new System.EventHandler(this.FocusLost);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Clicked);
            ((System.ComponentModel.ISupportInitialize)(this.NWHandle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SEHandle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox NWHandle;
        private System.Windows.Forms.PictureBox SEHandle;
        private System.Windows.Forms.Panel center;
    }
}