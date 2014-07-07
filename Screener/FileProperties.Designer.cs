/* Author: Luke Familo */
namespace Screener
{
    partial class FileProperties
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
            this.fileTypeSelect = new System.Windows.Forms.ComboBox();
            this.rotationSelection = new System.Windows.Forms.ComboBox();
            this.directoryField = new System.Windows.Forms.TextBox();
            this.rootNameField = new System.Windows.Forms.TextBox();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.fileTypeLable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flipSelectionBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rotationPreviewAffected = new System.Windows.Forms.PictureBox();
            this.rotationPreviewUnAffected = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rotationPreviewAffected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationPreviewUnAffected)).BeginInit();
            this.SuspendLayout();
            // 
            // fileTypeSelect
            // 
            this.fileTypeSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.fileTypeSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.fileTypeSelect.FormattingEnabled = true;
            this.fileTypeSelect.Location = new System.Drawing.Point(225, 66);
            this.fileTypeSelect.Name = "fileTypeSelect";
            this.fileTypeSelect.Size = new System.Drawing.Size(93, 21);
            this.fileTypeSelect.TabIndex = 3;
            this.fileTypeSelect.SelectedIndexChanged += new System.EventHandler(this.FileTypeChanged);
            // 
            // rotationSelection
            // 
            this.rotationSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.rotationSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.rotationSelection.FormattingEnabled = true;
            this.rotationSelection.Location = new System.Drawing.Point(225, 93);
            this.rotationSelection.Name = "rotationSelection";
            this.rotationSelection.Size = new System.Drawing.Size(93, 21);
            this.rotationSelection.TabIndex = 4;
            this.rotationSelection.SelectedIndexChanged += new System.EventHandler(this.RotationChanged);
            // 
            // directoryField
            // 
            this.directoryField.BackColor = System.Drawing.SystemColors.Window;
            this.directoryField.Location = new System.Drawing.Point(80, 40);
            this.directoryField.MaxLength = 50;
            this.directoryField.Name = "directoryField";
            this.directoryField.ReadOnly = true;
            this.directoryField.Size = new System.Drawing.Size(238, 20);
            this.directoryField.TabIndex = 2;
            this.directoryField.Click += new System.EventHandler(this.OpenFileDialog);
            // 
            // rootNameField
            // 
            this.rootNameField.Location = new System.Drawing.Point(80, 14);
            this.rootNameField.MaxLength = 50;
            this.rootNameField.Name = "rootNameField";
            this.rootNameField.Size = new System.Drawing.Size(238, 20);
            this.rootNameField.TabIndex = 1;
            this.rootNameField.TextChanged += new System.EventHandler(this.RootNameChanged);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(12, 43);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(49, 13);
            this.directoryLabel.TabIndex = 16;
            this.directoryLabel.Text = "Directory";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 17);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(61, 13);
            this.nameLabel.TabIndex = 15;
            this.nameLabel.Text = "Root Name";
            // 
            // fileTypeLable
            // 
            this.fileTypeLable.AutoSize = true;
            this.fileTypeLable.Location = new System.Drawing.Point(12, 69);
            this.fileTypeLable.Name = "fileTypeLable";
            this.fileTypeLable.Size = new System.Drawing.Size(50, 13);
            this.fileTypeLable.TabIndex = 17;
            this.fileTypeLable.Text = "File Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Rotation";
            // 
            // flipSelectionBox
            // 
            this.flipSelectionBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.flipSelectionBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.flipSelectionBox.FormattingEnabled = true;
            this.flipSelectionBox.Location = new System.Drawing.Point(225, 120);
            this.flipSelectionBox.Name = "flipSelectionBox";
            this.flipSelectionBox.Size = new System.Drawing.Size(93, 21);
            this.flipSelectionBox.TabIndex = 19;
            this.flipSelectionBox.SelectedIndexChanged += new System.EventHandler(this.FlipChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Flip";
            // 
            // rotationPreviewAffected
            // 
            this.rotationPreviewAffected.Image = global::Screener.Properties.Resources.RotationPallet;
            this.rotationPreviewAffected.Location = new System.Drawing.Point(171, 96);
            this.rotationPreviewAffected.Name = "rotationPreviewAffected";
            this.rotationPreviewAffected.Size = new System.Drawing.Size(48, 47);
            this.rotationPreviewAffected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rotationPreviewAffected.TabIndex = 22;
            this.rotationPreviewAffected.TabStop = false;
            // 
            // rotationPreviewUnAffected
            // 
            this.rotationPreviewUnAffected.Image = global::Screener.Properties.Resources.RotationPallet;
            this.rotationPreviewUnAffected.Location = new System.Drawing.Point(80, 96);
            this.rotationPreviewUnAffected.Name = "rotationPreviewUnAffected";
            this.rotationPreviewUnAffected.Size = new System.Drawing.Size(48, 47);
            this.rotationPreviewUnAffected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rotationPreviewUnAffected.TabIndex = 21;
            this.rotationPreviewUnAffected.TabStop = false;
            // 
            // FileProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 153);
            this.Controls.Add(this.rotationPreviewAffected);
            this.Controls.Add(this.rotationPreviewUnAffected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flipSelectionBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileTypeLable);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.fileTypeSelect);
            this.Controls.Add(this.rotationSelection);
            this.Controls.Add(this.directoryField);
            this.Controls.Add(this.rootNameField);
            this.Name = "FileProperties";
            this.Text = "FileProperties";
            ((System.ComponentModel.ISupportInitialize)(this.rotationPreviewAffected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationPreviewUnAffected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fileTypeSelect;
        private System.Windows.Forms.ComboBox rotationSelection;
        private System.Windows.Forms.TextBox directoryField;
        private System.Windows.Forms.TextBox rootNameField;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label fileTypeLable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox flipSelectionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox rotationPreviewAffected;
        private System.Windows.Forms.PictureBox rotationPreviewUnAffected;
    }
}