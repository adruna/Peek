namespace Screener
{
    partial class ScreenerForm
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
            this.captureButton = new System.Windows.Forms.Button();
            this.captureKeyField = new System.Windows.Forms.TextBox();
            this.captureKeyLabel = new System.Windows.Forms.Label();
            this.rectangleCheckBox = new System.Windows.Forms.CheckBox();
            this.preview = new System.Windows.Forms.Panel();
            this.previewRect = new System.Windows.Forms.Panel();
            this.filePropertiesButton = new System.Windows.Forms.Button();
            this.preview.SuspendLayout();
            this.SuspendLayout();
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(212, 11);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(81, 22);
            this.captureButton.TabIndex = 0;
            this.captureButton.Text = "Allow Capture";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.ToggleCapture);
            // 
            // captureKeyField
            // 
            this.captureKeyField.BackColor = System.Drawing.SystemColors.Window;
            this.captureKeyField.Location = new System.Drawing.Point(89, 14);
            this.captureKeyField.Name = "captureKeyField";
            this.captureKeyField.ReadOnly = true;
            this.captureKeyField.Size = new System.Drawing.Size(117, 20);
            this.captureKeyField.TabIndex = 2;
            this.captureKeyField.Enter += new System.EventHandler(this.changeCaptureKey);
            this.captureKeyField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.captureKeyField.Leave += new System.EventHandler(this.dontChangeCaptureKey);
            // 
            // captureKeyLabel
            // 
            this.captureKeyLabel.AutoSize = true;
            this.captureKeyLabel.Location = new System.Drawing.Point(12, 17);
            this.captureKeyLabel.Name = "captureKeyLabel";
            this.captureKeyLabel.Size = new System.Drawing.Size(71, 13);
            this.captureKeyLabel.TabIndex = 3;
            this.captureKeyLabel.Text = "Capture Key :";
            // 
            // rectangleCheckBox
            // 
            this.rectangleCheckBox.AutoSize = true;
            this.rectangleCheckBox.Location = new System.Drawing.Point(211, 68);
            this.rectangleCheckBox.Name = "rectangleCheckBox";
            this.rectangleCheckBox.Size = new System.Drawing.Size(82, 17);
            this.rectangleCheckBox.TabIndex = 12;
            this.rectangleCheckBox.Text = "Sub Screen";
            this.rectangleCheckBox.UseVisualStyleBackColor = true;
            this.rectangleCheckBox.CheckedChanged += new System.EventHandler(this.specifyAreaChecked);
            // 
            // preview
            // 
            this.preview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.preview.Controls.Add(this.previewRect);
            this.preview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.preview.Location = new System.Drawing.Point(12, 39);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(91, 47);
            this.preview.TabIndex = 13;
            this.preview.Visible = false;
            this.preview.VisibleChanged += new System.EventHandler(this.previewVisibilityChanged);
            this.preview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openOverlay);
            // 
            // previewRect
            // 
            this.previewRect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.previewRect.Location = new System.Drawing.Point(4, 4);
            this.previewRect.Name = "previewRect";
            this.previewRect.Size = new System.Drawing.Size(43, 28);
            this.previewRect.TabIndex = 0;
            this.previewRect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openOverlay);
            // 
            // filePropertiesButton
            // 
            this.filePropertiesButton.Location = new System.Drawing.Point(210, 39);
            this.filePropertiesButton.Name = "filePropertiesButton";
            this.filePropertiesButton.Size = new System.Drawing.Size(81, 23);
            this.filePropertiesButton.TabIndex = 14;
            this.filePropertiesButton.Text = "Properties";
            this.filePropertiesButton.UseVisualStyleBackColor = true;
            this.filePropertiesButton.Click += new System.EventHandler(this.OpenProperties);
            // 
            // ScreenerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 98);
            this.Controls.Add(this.filePropertiesButton);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.rectangleCheckBox);
            this.Controls.Add(this.captureKeyLabel);
            this.Controls.Add(this.captureKeyField);
            this.Controls.Add(this.captureButton);
            this.Name = "ScreenerForm";
            this.Text = "Screener";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClose);
            this.preview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.TextBox captureKeyField;
        private System.Windows.Forms.Label captureKeyLabel;
        private System.Windows.Forms.CheckBox rectangleCheckBox;
        private System.Windows.Forms.Panel preview;
        private System.Windows.Forms.Panel previewRect;
        private System.Windows.Forms.Button filePropertiesButton;
    }
}

