using GameEditor.Wcf.Harness.IoC;

namespace GameEditor.Wcf.Harness
{
    partial class MainPageViewForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ArmyListTabPage = new System.Windows.Forms.TabPage();
            this.ArmyUnitTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._armyUnitListViewControl1 = new GameEditor.Wcf.Harness.ArmyUnitListViewControl();
            this._armyUnitDetailViewControl1 = new GameEditor.Wcf.Harness.ArmyUnitDetailViewControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.armyListViewControl1 = new GameEditor.Wcf.Harness.ArmyListViewControl();
            this.armyDetailViewControl1 = new GameEditor.Wcf.Harness.ArmyDetailViewControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.ArmyListTabPage.SuspendLayout();
            this.ArmyUnitTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(771, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(771, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.ArmyListTabPage);
            this.MainTabControl.Controls.Add(this.ArmyUnitTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 28);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(771, 450);
            this.MainTabControl.TabIndex = 2;
            // 
            // ArmyListTabPage
            // 
            this.ArmyListTabPage.Controls.Add(this.splitContainer2);
            this.ArmyListTabPage.Location = new System.Drawing.Point(4, 25);
            this.ArmyListTabPage.Name = "ArmyListTabPage";
            this.ArmyListTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ArmyListTabPage.Size = new System.Drawing.Size(763, 421);
            this.ArmyListTabPage.TabIndex = 0;
            this.ArmyListTabPage.Text = "Army List";
            this.ArmyListTabPage.UseVisualStyleBackColor = true;
            // 
            // ArmyUnitTabPage
            // 
            this.ArmyUnitTabPage.Controls.Add(this.splitContainer1);
            this.ArmyUnitTabPage.Location = new System.Drawing.Point(4, 25);
            this.ArmyUnitTabPage.Name = "ArmyUnitTabPage";
            this.ArmyUnitTabPage.Size = new System.Drawing.Size(763, 421);
            this.ArmyUnitTabPage.TabIndex = 2;
            this.ArmyUnitTabPage.Text = "Army Unit";
            this.ArmyUnitTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._armyUnitListViewControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._armyUnitDetailViewControl1);
            this.splitContainer1.Size = new System.Drawing.Size(763, 421);
            this.splitContainer1.SplitterDistance = 254;
            this.splitContainer1.TabIndex = 0;
            // 
            // _armyUnitListViewControl1
            // 
            this._armyUnitListViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._armyUnitListViewControl1.Location = new System.Drawing.Point(0, 0);
            this._armyUnitListViewControl1.Name = "_armyUnitListViewControl1";
            this._armyUnitListViewControl1.Size = new System.Drawing.Size(254, 421);
            this._armyUnitListViewControl1.TabIndex = 0;
            // 
            // _armyUnitDetailViewControl1
            // 
            this._armyUnitDetailViewControl1.ArmyUnitDefinitionId = 0;
            this._armyUnitDetailViewControl1.ArmyUnitName = "";
            this._armyUnitDetailViewControl1.Cost = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this._armyUnitDetailViewControl1.DisciplineType = GameEditor.Wcf.Harness.WarGameServiceReference.DisciplineTypeEnum.Regular;
            this._armyUnitDetailViewControl1.DispositionType = GameEditor.Wcf.Harness.WarGameServiceReference.DispositionTypeEnum.Mounted;
            this._armyUnitDetailViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._armyUnitDetailViewControl1.GradeType = GameEditor.Wcf.Harness.WarGameServiceReference.GradeTypeEnum.Superior;
            this._armyUnitDetailViewControl1.IsAlly = false;
            this._armyUnitDetailViewControl1.IsChariot = false;
            this._armyUnitDetailViewControl1.IsDoubleElement = false;
            this._armyUnitDetailViewControl1.IsGeneral = false;
            this._armyUnitDetailViewControl1.IsMountedInfantry = false;
            this._armyUnitDetailViewControl1.Location = new System.Drawing.Point(0, 0);
            this._armyUnitDetailViewControl1.MaxCount = 0;
            this._armyUnitDetailViewControl1.MinCount = 0;
            this._armyUnitDetailViewControl1.Name = "_armyUnitDetailViewControl1";
            this._armyUnitDetailViewControl1.Size = new System.Drawing.Size(505, 421);
            this._armyUnitDetailViewControl1.TabIndex = 0;
            this._armyUnitDetailViewControl1.UnitType = GameEditor.Wcf.Harness.WarGameServiceReference.UnitTypeEnum.Elephants;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.armyListViewControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.armyDetailViewControl1);
            this.splitContainer2.Size = new System.Drawing.Size(757, 415);
            this.splitContainer2.SplitterDistance = 252;
            this.splitContainer2.TabIndex = 0;
            // 
            // armyListViewControl1
            // 
            this.armyListViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armyListViewControl1.Location = new System.Drawing.Point(0, 0);
            this.armyListViewControl1.Name = "armyListViewControl1";
            this.armyListViewControl1.Size = new System.Drawing.Size(252, 415);
            this.armyListViewControl1.TabIndex = 0;
            // 
            // armyDetailViewControl1
            // 
            this.armyDetailViewControl1.ArmyId = 0;
            this.armyDetailViewControl1.ArmyName = "";
            this.armyDetailViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armyDetailViewControl1.Location = new System.Drawing.Point(0, 0);
            this.armyDetailViewControl1.Name = "armyDetailViewControl1";
            this.armyDetailViewControl1.Notes = "";
            this.armyDetailViewControl1.Size = new System.Drawing.Size(501, 415);
            this.armyDetailViewControl1.TabIndex = 0;
            // 
            // MainPageViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 503);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPageViewForm";
            this.Text = "MainPageViewForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.ArmyListTabPage.ResumeLayout(false);
            this.ArmyUnitTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage ArmyListTabPage;
        private System.Windows.Forms.TabPage ArmyUnitTabPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ArmyUnitListViewControl _armyUnitListViewControl1;
        private ArmyUnitDetailViewControl _armyUnitDetailViewControl1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ArmyListViewControl armyListViewControl1;
        private ArmyDetailViewControl armyDetailViewControl1;
    }
}