namespace GameEditor.Wcf.Harness
{
    partial class ArmyUnitListControl
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
            this.ArmyListView = new System.Windows.Forms.ListView();
            this.IdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DisciplineHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DispositionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UnitTypeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CostHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MinCountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaxCountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArmyListView
            // 
            this.ArmyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdHeader,
            this.NameHeader,
            this.DisciplineHeader,
            this.DispositionHeader,
            this.UnitTypeHeader,
            this.CostHeader,
            this.MinCountHeader,
            this.MaxCountHeader});
            this.ArmyListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmyListView.FullRowSelect = true;
            this.ArmyListView.GridLines = true;
            this.ArmyListView.Location = new System.Drawing.Point(0, 0);
            this.ArmyListView.Name = "ArmyListView";
            this.ArmyListView.Size = new System.Drawing.Size(453, 250);
            this.ArmyListView.TabIndex = 0;
            this.ArmyListView.UseCompatibleStateImageBehavior = false;
            this.ArmyListView.View = System.Windows.Forms.View.Details;
            this.ArmyListView.SelectedIndexChanged += new System.EventHandler(this.ArmyUnitListView_SelectedIndexChanged);
            // 
            // IdHeader
            // 
            this.IdHeader.Text = "Id";
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 261;
            // 
            // DisciplineHeader
            // 
            this.DisciplineHeader.Text = "Discipline";
            // 
            // DispositionHeader
            // 
            this.DispositionHeader.Text = "Disposition";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(6, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(102, 43);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add Army";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 250);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 53);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ArmyListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 250);
            this.panel2.TabIndex = 4;
            // 
            // UnitTypeHeader
            // 
            this.UnitTypeHeader.Text = "Unit Type";
            // 
            // CostHeader
            // 
            this.CostHeader.Text = "Cost";
            // 
            // MinCountHeader
            // 
            this.MinCountHeader.Text = "Min Count";
            // 
            // MaxCountHeader
            // 
            this.MaxCountHeader.Text = "Max Count";
            // 
            // ArmyUnitListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ArmyUnitListControl";
            this.Size = new System.Drawing.Size(453, 303);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ArmyListView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ColumnHeader IdHeader;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ColumnHeader DisciplineHeader;
        private System.Windows.Forms.ColumnHeader DispositionHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader UnitTypeHeader;
        private System.Windows.Forms.ColumnHeader CostHeader;
        private System.Windows.Forms.ColumnHeader MinCountHeader;
        private System.Windows.Forms.ColumnHeader MaxCountHeader;
    }
}
