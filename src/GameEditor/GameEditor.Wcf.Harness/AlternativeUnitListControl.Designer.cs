namespace GameEditor.Wcf.Harness
{
    partial class AlternativeUnitListControl
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
            this.AddButton = new System.Windows.Forms.Button();
            this.AlternativeUnitListView = new System.Windows.Forms.ListView();
            this.IdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MinHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaxHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(3, 263);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(151, 53);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add Alternative Unit";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AlternativeUnitListView
            // 
            this.AlternativeUnitListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlternativeUnitListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdHeader,
            this.NameHeader,
            this.MinHeader,
            this.MaxHeader});
            this.AlternativeUnitListView.Location = new System.Drawing.Point(3, 3);
            this.AlternativeUnitListView.Name = "AlternativeUnitListView";
            this.AlternativeUnitListView.Size = new System.Drawing.Size(471, 254);
            this.AlternativeUnitListView.TabIndex = 2;
            this.AlternativeUnitListView.UseCompatibleStateImageBehavior = false;
            this.AlternativeUnitListView.View = System.Windows.Forms.View.Details;
            this.AlternativeUnitListView.SelectedIndexChanged += new System.EventHandler(this.AlternativeUnitListView_SelectedIndexChanged);
            // 
            // IdHeader
            // 
            this.IdHeader.Text = "Id";
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            // 
            // MinHeader
            // 
            this.MinHeader.Text = "Minimum";
            // 
            // MaxHeader
            // 
            this.MaxHeader.Text = "Maximum";
            // 
            // AlternativeUnitListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AlternativeUnitListView);
            this.Name = "AlternativeUnitListControl";
            this.Size = new System.Drawing.Size(477, 393);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListView AlternativeUnitListView;
        private System.Windows.Forms.ColumnHeader IdHeader;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ColumnHeader MinHeader;
        private System.Windows.Forms.ColumnHeader MaxHeader;
    }
}
