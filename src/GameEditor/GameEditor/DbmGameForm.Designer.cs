namespace GameEditor
{
    partial class DbmGameForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dbmGameControl1 = new GameEditor.DbmGameControl();
            this.unitsControl1 = new GameEditor.UnitsControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(643, 441);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dbmGameControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(748, 560);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Game";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.unitsControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(635, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Units";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dbmGameControl1
            // 
            this.dbmGameControl1.BackColor = System.Drawing.SystemColors.Control;
            this.dbmGameControl1.CanCreate = true;
            this.dbmGameControl1.CanDelete = false;
            this.dbmGameControl1.CanRead = true;
            this.dbmGameControl1.CanUpdate = true;
            this.dbmGameControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbmGameControl1.Location = new System.Drawing.Point(3, 3);
            this.dbmGameControl1.Name = "dbmGameControl1";
            this.dbmGameControl1.Size = new System.Drawing.Size(742, 554);
            this.dbmGameControl1.TabIndex = 0;
            // 
            // unitsControl1
            // 
            this.unitsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitsControl1.Location = new System.Drawing.Point(3, 3);
            this.unitsControl1.Name = "unitsControl1";
            this.unitsControl1.Size = new System.Drawing.Size(629, 406);
            this.unitsControl1.TabIndex = 0;
            // 
            // DbmGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 441);
            this.Controls.Add(this.tabControl1);
            this.Name = "DbmGameForm";
            this.Text = "DbmGameForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DbmGameControl dbmGameControl1;
        private UnitsControl unitsControl1;
    }
}