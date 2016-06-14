namespace GameEditor.Wcf.Harness
{
    partial class ArmyDetailControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BookTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ListTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MinYearTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MaxYearTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NotesTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ArmyId";
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(73, 3);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.ReadOnly = true;
            this.IdTextBox.Size = new System.Drawing.Size(196, 22);
            this.IdTextBox.TabIndex = 1;
            this.IdTextBox.TabStop = false;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(73, 31);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(196, 22);
            this.NameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // BookTextBox
            // 
            this.BookTextBox.Location = new System.Drawing.Point(73, 59);
            this.BookTextBox.Name = "BookTextBox";
            this.BookTextBox.Size = new System.Drawing.Size(196, 22);
            this.BookTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "ArmyBook";
            // 
            // ListTextBox
            // 
            this.ListTextBox.Location = new System.Drawing.Point(73, 87);
            this.ListTextBox.Name = "ListTextBox";
            this.ListTextBox.Size = new System.Drawing.Size(196, 22);
            this.ListTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "ArmyList";
            // 
            // MinYearTextBox
            // 
            this.MinYearTextBox.Location = new System.Drawing.Point(73, 115);
            this.MinYearTextBox.Name = "MinYearTextBox";
            this.MinYearTextBox.Size = new System.Drawing.Size(196, 22);
            this.MinYearTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Min Year";
            // 
            // MaxYearTextBox
            // 
            this.MaxYearTextBox.Location = new System.Drawing.Point(73, 143);
            this.MaxYearTextBox.Name = "MaxYearTextBox";
            this.MaxYearTextBox.Size = new System.Drawing.Size(196, 22);
            this.MaxYearTextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Max Year";
            // 
            // NotesTextBox
            // 
            this.NotesTextBox.Location = new System.Drawing.Point(35, 41);
            this.NotesTextBox.Multiline = true;
            this.NotesTextBox.Name = "NotesTextBox";
            this.NotesTextBox.Size = new System.Drawing.Size(196, 127);
            this.NotesTextBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Notes";
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.BookTextBox);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Controls.Add(this.IdTextBox);
            this.TopPanel.Controls.Add(this.MaxYearTextBox);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.label6);
            this.TopPanel.Controls.Add(this.NameTextBox);
            this.TopPanel.Controls.Add(this.MinYearTextBox);
            this.TopPanel.Controls.Add(this.label3);
            this.TopPanel.Controls.Add(this.label5);
            this.TopPanel.Controls.Add(this.label4);
            this.TopPanel.Controls.Add(this.ListTextBox);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(776, 170);
            this.TopPanel.TabIndex = 14;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.label7);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 170);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(70, 465);
            this.LeftPanel.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NotesTextBox);
            this.panel1.Location = new System.Drawing.Point(198, 361);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 222);
            this.panel1.TabIndex = 17;
            // 
            // ArmyDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "ArmyDetailControl";
            this.Size = new System.Drawing.Size(776, 635);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BookTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ListTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MinYearTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MaxYearTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NotesTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel panel1;
    }
}
