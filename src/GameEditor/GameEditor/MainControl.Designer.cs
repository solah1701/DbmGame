namespace GameEditor
{
    partial class MainControl
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
            this.CreateCheckBox = new System.Windows.Forms.CheckBox();
            this.ReadCheckBox = new System.Windows.Forms.CheckBox();
            this.UpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.DeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.BoolValueTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PressedTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CreateCheckBox
            // 
            this.CreateCheckBox.AutoSize = true;
            this.CreateCheckBox.Location = new System.Drawing.Point(75, 51);
            this.CreateCheckBox.Name = "CreateCheckBox";
            this.CreateCheckBox.Size = new System.Drawing.Size(72, 21);
            this.CreateCheckBox.TabIndex = 4;
            this.CreateCheckBox.Text = "Create";
            this.CreateCheckBox.UseVisualStyleBackColor = true;
            this.CreateCheckBox.CheckedChanged += new System.EventHandler(this.CreateCheckBox_CheckedChanged);
            // 
            // ReadCheckBox
            // 
            this.ReadCheckBox.AutoSize = true;
            this.ReadCheckBox.Location = new System.Drawing.Point(75, 83);
            this.ReadCheckBox.Name = "ReadCheckBox";
            this.ReadCheckBox.Size = new System.Drawing.Size(64, 21);
            this.ReadCheckBox.TabIndex = 5;
            this.ReadCheckBox.Text = "Read";
            this.ReadCheckBox.UseVisualStyleBackColor = true;
            this.ReadCheckBox.CheckedChanged += new System.EventHandler(this.ReadCheckBox_CheckedChanged);
            // 
            // UpdateCheckBox
            // 
            this.UpdateCheckBox.AutoSize = true;
            this.UpdateCheckBox.Location = new System.Drawing.Point(75, 115);
            this.UpdateCheckBox.Name = "UpdateCheckBox";
            this.UpdateCheckBox.Size = new System.Drawing.Size(76, 21);
            this.UpdateCheckBox.TabIndex = 6;
            this.UpdateCheckBox.Text = "Update";
            this.UpdateCheckBox.UseVisualStyleBackColor = true;
            this.UpdateCheckBox.CheckedChanged += new System.EventHandler(this.UpdateCheckBox_CheckedChanged);
            // 
            // DeleteCheckBox
            // 
            this.DeleteCheckBox.AutoSize = true;
            this.DeleteCheckBox.Location = new System.Drawing.Point(75, 147);
            this.DeleteCheckBox.Name = "DeleteCheckBox";
            this.DeleteCheckBox.Size = new System.Drawing.Size(71, 21);
            this.DeleteCheckBox.TabIndex = 7;
            this.DeleteCheckBox.Text = "Delete";
            this.DeleteCheckBox.UseVisualStyleBackColor = true;
            this.DeleteCheckBox.CheckedChanged += new System.EventHandler(this.DeleteCheckBox_CheckedChanged);
            // 
            // BoolValueTextBox
            // 
            this.BoolValueTextBox.Location = new System.Drawing.Point(309, 83);
            this.BoolValueTextBox.Name = "BoolValueTextBox";
            this.BoolValueTextBox.ReadOnly = true;
            this.BoolValueTextBox.Size = new System.Drawing.Size(100, 22);
            this.BoolValueTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bool Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Pressed";
            // 
            // PressedTextBox
            // 
            this.PressedTextBox.Location = new System.Drawing.Point(309, 115);
            this.PressedTextBox.Name = "PressedTextBox";
            this.PressedTextBox.ReadOnly = true;
            this.PressedTextBox.Size = new System.Drawing.Size(100, 22);
            this.PressedTextBox.TabIndex = 11;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PressedTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoolValueTextBox);
            this.Controls.Add(this.DeleteCheckBox);
            this.Controls.Add(this.UpdateCheckBox);
            this.Controls.Add(this.ReadCheckBox);
            this.Controls.Add(this.CreateCheckBox);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(426, 362);
            base.Size = this.Size;
            this.Controls.SetChildIndex(this.CreateCheckBox, 0);
            this.Controls.SetChildIndex(this.ReadCheckBox, 0);
            this.Controls.SetChildIndex(this.UpdateCheckBox, 0);
            this.Controls.SetChildIndex(this.DeleteCheckBox, 0);
            this.Controls.SetChildIndex(this.BoolValueTextBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.PressedTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CreateCheckBox;
        private System.Windows.Forms.CheckBox ReadCheckBox;
        private System.Windows.Forms.CheckBox UpdateCheckBox;
        private System.Windows.Forms.CheckBox DeleteCheckBox;
        private System.Windows.Forms.TextBox BoolValueTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PressedTextBox;
    }
}
