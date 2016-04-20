namespace GameEditor
{
    partial class GoodsListControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.GoodsListView = new System.Windows.Forms.ListView();
            this.baseControl1 = new GameEditor.BaseControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.GoodsListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.NameTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.baseControl1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 517);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(71, 18);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(297, 22);
            this.NameTextBox.TabIndex = 2;
            // 
            // GoodsListView
            // 
            this.GoodsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GoodsListView.FullRowSelect = true;
            this.GoodsListView.GridLines = true;
            this.GoodsListView.Location = new System.Drawing.Point(0, 0);
            this.GoodsListView.Name = "GoodsListView";
            this.GoodsListView.Size = new System.Drawing.Size(266, 517);
            this.GoodsListView.TabIndex = 0;
            this.GoodsListView.UseCompatibleStateImageBehavior = false;
            this.GoodsListView.View = System.Windows.Forms.View.Details;
            this.GoodsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.GoodsListView_ItemSelectionChanged);
            // 
            // baseControl1
            // 
            this.baseControl1.BackColor = System.Drawing.SystemColors.Control;
            this.baseControl1.CanCreate = false;
            this.baseControl1.CanDelete = false;
            this.baseControl1.CanRead = false;
            this.baseControl1.CanUpdate = false;
            this.baseControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.baseControl1.Location = new System.Drawing.Point(0, 477);
            this.baseControl1.Name = "baseControl1";
            this.baseControl1.Size = new System.Drawing.Size(530, 40);
            this.baseControl1.TabIndex = 0;
            // 
            // GoodsListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "GoodsListControl";
            this.Size = new System.Drawing.Size(800, 517);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label1;
        private BaseControl baseControl1;
        internal System.Windows.Forms.ListView GoodsListView;
    }
}
