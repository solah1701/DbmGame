namespace GameEditor
{
    partial class SecondaryProducerListControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SecondaryProducerListView = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.RateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ProductComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userListControl1 = new GameEditor.UIControls.UserListControl();
            this.baseControl1 = new GameEditor.BaseControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SecondaryProducerListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.userListControl1);
            this.splitContainer1.Panel2.Controls.Add(this.RateNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.AmountNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.ProductComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.NameTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.baseControl1);
            this.splitContainer1.Size = new System.Drawing.Size(602, 467);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // SecondaryProducerListView
            // 
            this.SecondaryProducerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondaryProducerListView.FullRowSelect = true;
            this.SecondaryProducerListView.GridLines = true;
            this.SecondaryProducerListView.Location = new System.Drawing.Point(0, 0);
            this.SecondaryProducerListView.Name = "SecondaryProducerListView";
            this.SecondaryProducerListView.Size = new System.Drawing.Size(200, 467);
            this.SecondaryProducerListView.TabIndex = 0;
            this.SecondaryProducerListView.UseCompatibleStateImageBehavior = false;
            this.SecondaryProducerListView.View = System.Windows.Forms.View.Details;
            this.SecondaryProducerListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.SecondaryProducerListView_ItemSelectionChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Consumes";
            // 
            // RateNumericUpDown
            // 
            this.RateNumericUpDown.Location = new System.Drawing.Point(122, 298);
            this.RateNumericUpDown.Name = "RateNumericUpDown";
            this.RateNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.RateNumericUpDown.TabIndex = 16;
            // 
            // AmountNumericUpDown
            // 
            this.AmountNumericUpDown.Location = new System.Drawing.Point(122, 258);
            this.AmountNumericUpDown.Name = "AmountNumericUpDown";
            this.AmountNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.AmountNumericUpDown.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Amount";
            // 
            // ProductComboBox
            // 
            this.ProductComboBox.FormattingEnabled = true;
            this.ProductComboBox.Location = new System.Drawing.Point(122, 216);
            this.ProductComboBox.Name = "ProductComboBox";
            this.ProductComboBox.Size = new System.Drawing.Size(231, 24);
            this.ProductComboBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Produces";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(122, 24);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(231, 22);
            this.NameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // userListControl1
            // 
            this.userListControl1.Location = new System.Drawing.Point(122, 64);
            this.userListControl1.Name = "userListControl1";
            this.userListControl1.Size = new System.Drawing.Size(231, 120);
            this.userListControl1.TabIndex = 17;
            // 
            // baseControl1
            // 
            this.baseControl1.BackColor = System.Drawing.SystemColors.Control;
            this.baseControl1.CanCreate = false;
            this.baseControl1.CanDelete = false;
            this.baseControl1.CanRead = false;
            this.baseControl1.CanUpdate = false;
            this.baseControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.baseControl1.Location = new System.Drawing.Point(0, 427);
            this.baseControl1.Name = "baseControl1";
            this.baseControl1.Size = new System.Drawing.Size(398, 40);
            this.baseControl1.TabIndex = 0;
            // 
            // SecondaryProducerListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SecondaryProducerListControl";
            this.Size = new System.Drawing.Size(602, 467);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView SecondaryProducerListView;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label1;
        private BaseControl baseControl1;
        private System.Windows.Forms.NumericUpDown RateNumericUpDown;
        private System.Windows.Forms.NumericUpDown AmountNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ProductComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private UIControls.UserListControl userListControl1;
    }
}
