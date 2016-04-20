namespace GameEditor
{
    sealed partial class GameControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.PathButton = new System.Windows.Forms.Button();
            this.baseControl1 = new GameEditor.BaseControl();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(58, 3);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(222, 22);
            this.NameTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Path";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(58, 35);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(222, 22);
            this.PathTextBox.TabIndex = 9;
            // 
            // PathButton
            // 
            this.PathButton.Location = new System.Drawing.Point(302, 35);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(33, 23);
            this.PathButton.TabIndex = 10;
            this.PathButton.Text = "...";
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // baseControl1
            // 
            this.baseControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.baseControl1.BackColor = System.Drawing.SystemColors.Control;
            this.baseControl1.CanCreate = false;
            this.baseControl1.CanDelete = false;
            this.baseControl1.CanRead = false;
            this.baseControl1.CanUpdate = false;
            this.baseControl1.Location = new System.Drawing.Point(28, 228);
            this.baseControl1.Name = "baseControl1";
            this.baseControl1.Size = new System.Drawing.Size(493, 80);
            this.baseControl1.TabIndex = 12;
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanCreate = true;
            this.CanUpdate = true;
            this.Controls.Add(this.baseControl1);
            this.Controls.Add(this.PathButton);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(521, 311);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.NameTextBox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.PathTextBox, 0);
            this.Controls.SetChildIndex(this.PathButton, 0);
            this.Controls.SetChildIndex(this.baseControl1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Button PathButton;
        private BaseControl baseControl1;
    }
}
