namespace GameEditor.Wcf.Harness
{
    partial class AllyListViewControl
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
            this.UpdateButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MaxYearTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MinYearTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ListTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BookTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AllyNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AlliedListComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(86, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(102, 43);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 53);
            this.panel1.TabIndex = 3;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(194, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(102, 43);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MaxYearTextBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.MinYearTextBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ListTextBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BookTextBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.AllyNameTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.AlliedListComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 175);
            this.panel2.TabIndex = 4;
            // 
            // MaxYearTextBox
            // 
            this.MaxYearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxYearTextBox.Location = new System.Drawing.Point(85, 145);
            this.MaxYearTextBox.Name = "MaxYearTextBox";
            this.MaxYearTextBox.Size = new System.Drawing.Size(365, 22);
            this.MaxYearTextBox.TabIndex = 11;
            this.MaxYearTextBox.TextChanged += new System.EventHandler(this.MaxYearTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Max Year";
            // 
            // MinYearTextBox
            // 
            this.MinYearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MinYearTextBox.Location = new System.Drawing.Point(85, 117);
            this.MinYearTextBox.Name = "MinYearTextBox";
            this.MinYearTextBox.Size = new System.Drawing.Size(365, 22);
            this.MinYearTextBox.TabIndex = 9;
            this.MinYearTextBox.TextChanged += new System.EventHandler(this.MinYearTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Min Year";
            // 
            // ListTextBox
            // 
            this.ListTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListTextBox.Location = new System.Drawing.Point(85, 89);
            this.ListTextBox.Name = "ListTextBox";
            this.ListTextBox.Size = new System.Drawing.Size(365, 22);
            this.ListTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "List";
            // 
            // BookTextBox
            // 
            this.BookTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BookTextBox.Location = new System.Drawing.Point(85, 61);
            this.BookTextBox.Name = "BookTextBox";
            this.BookTextBox.Size = new System.Drawing.Size(365, 22);
            this.BookTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Book";
            // 
            // AllyNameTextBox
            // 
            this.AllyNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AllyNameTextBox.Location = new System.Drawing.Point(85, 33);
            this.AllyNameTextBox.Name = "AllyNameTextBox";
            this.AllyNameTextBox.Size = new System.Drawing.Size(365, 22);
            this.AllyNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ally Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Allied List";
            // 
            // AlliedListComboBox
            // 
            this.AlliedListComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlliedListComboBox.FormattingEnabled = true;
            this.AlliedListComboBox.Location = new System.Drawing.Point(85, 3);
            this.AlliedListComboBox.Name = "AlliedListComboBox";
            this.AlliedListComboBox.Size = new System.Drawing.Size(365, 24);
            this.AlliedListComboBox.TabIndex = 0;
            this.AlliedListComboBox.SelectedIndexChanged += new System.EventHandler(this.AlliedListComboBox_SelectedIndexChanged);
            // 
            // AllyListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AllyListViewControl";
            this.Size = new System.Drawing.Size(453, 228);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AlliedListComboBox;
        private System.Windows.Forms.TextBox MaxYearTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MinYearTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ListTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BookTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AllyNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DeleteButton;
    }
}
