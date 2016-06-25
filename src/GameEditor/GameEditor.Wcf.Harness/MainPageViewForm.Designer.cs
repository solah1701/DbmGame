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
            this.ArmyListSplitContainer = new System.Windows.Forms.SplitContainer();
            this.armyListViewControl1 = new GameEditor.Wcf.Harness.ArmyListViewControl();
            this.armyDetailViewControl1 = new GameEditor.Wcf.Harness.ArmyDetailViewControl();
            this.ArmyUnitTabPage = new System.Windows.Forms.TabPage();
            this.ArmyDetailSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ArmyDetailLeftSplitContainer = new System.Windows.Forms.SplitContainer();
            this._armyUnitListViewControl1 = new GameEditor.Wcf.Harness.ArmyUnitListViewControl();
            this.armyAllyListViewControl1 = new GameEditor.Wcf.Harness.ArmyAllyListViewControl();
            this.ArmyDetailRightSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ArmyUnitDetailViewControl = new GameEditor.Wcf.Harness.ArmyUnitDetailViewControl();
            this.allyListViewControl1 = new GameEditor.Wcf.Harness.AllyListViewControl();
            this._armyUnitDetailViewControl1 = new GameEditor.Wcf.Harness.ArmyUnitDetailViewControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.ArmyListTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArmyListSplitContainer)).BeginInit();
            this.ArmyListSplitContainer.Panel1.SuspendLayout();
            this.ArmyListSplitContainer.Panel2.SuspendLayout();
            this.ArmyListSplitContainer.SuspendLayout();
            this.ArmyUnitTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArmyDetailSplitContainer)).BeginInit();
            this.ArmyDetailSplitContainer.Panel1.SuspendLayout();
            this.ArmyDetailSplitContainer.Panel2.SuspendLayout();
            this.ArmyDetailSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArmyDetailLeftSplitContainer)).BeginInit();
            this.ArmyDetailLeftSplitContainer.Panel1.SuspendLayout();
            this.ArmyDetailLeftSplitContainer.Panel2.SuspendLayout();
            this.ArmyDetailLeftSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArmyDetailRightSplitContainer)).BeginInit();
            this.ArmyDetailRightSplitContainer.Panel1.SuspendLayout();
            this.ArmyDetailRightSplitContainer.Panel2.SuspendLayout();
            this.ArmyDetailRightSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 28);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 638);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(908, 25);
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
            this.MainTabControl.Size = new System.Drawing.Size(908, 610);
            this.MainTabControl.TabIndex = 2;
            // 
            // ArmyListTabPage
            // 
            this.ArmyListTabPage.Controls.Add(this.ArmyListSplitContainer);
            this.ArmyListTabPage.Location = new System.Drawing.Point(4, 25);
            this.ArmyListTabPage.Name = "ArmyListTabPage";
            this.ArmyListTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ArmyListTabPage.Size = new System.Drawing.Size(900, 581);
            this.ArmyListTabPage.TabIndex = 0;
            this.ArmyListTabPage.Text = "Army List";
            this.ArmyListTabPage.UseVisualStyleBackColor = true;
            // 
            // ArmyListSplitContainer
            // 
            this.ArmyListSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmyListSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.ArmyListSplitContainer.Name = "ArmyListSplitContainer";
            // 
            // ArmyListSplitContainer.Panel1
            // 
            this.ArmyListSplitContainer.Panel1.Controls.Add(this.armyListViewControl1);
            // 
            // ArmyListSplitContainer.Panel2
            // 
            this.ArmyListSplitContainer.Panel2.Controls.Add(this.armyDetailViewControl1);
            this.ArmyListSplitContainer.Size = new System.Drawing.Size(894, 575);
            this.ArmyListSplitContainer.SplitterDistance = 298;
            this.ArmyListSplitContainer.TabIndex = 0;
            // 
            // armyListViewControl1
            // 
            this.armyListViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armyListViewControl1.Location = new System.Drawing.Point(0, 0);
            this.armyListViewControl1.Name = "armyListViewControl1";
            this.armyListViewControl1.Size = new System.Drawing.Size(298, 575);
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
            this.armyDetailViewControl1.Size = new System.Drawing.Size(592, 575);
            this.armyDetailViewControl1.TabIndex = 0;
            // 
            // ArmyUnitTabPage
            // 
            this.ArmyUnitTabPage.Controls.Add(this.ArmyDetailSplitContainer);
            this.ArmyUnitTabPage.Location = new System.Drawing.Point(4, 25);
            this.ArmyUnitTabPage.Name = "ArmyUnitTabPage";
            this.ArmyUnitTabPage.Size = new System.Drawing.Size(900, 581);
            this.ArmyUnitTabPage.TabIndex = 2;
            this.ArmyUnitTabPage.Text = "Army Unit";
            this.ArmyUnitTabPage.UseVisualStyleBackColor = true;
            // 
            // ArmyDetailSplitContainer
            // 
            this.ArmyDetailSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmyDetailSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ArmyDetailSplitContainer.Name = "ArmyDetailSplitContainer";
            // 
            // ArmyDetailSplitContainer.Panel1
            // 
            this.ArmyDetailSplitContainer.Panel1.Controls.Add(this.ArmyDetailLeftSplitContainer);
            // 
            // ArmyDetailSplitContainer.Panel2
            // 
            this.ArmyDetailSplitContainer.Panel2.Controls.Add(this.ArmyDetailRightSplitContainer);
            this.ArmyDetailSplitContainer.Size = new System.Drawing.Size(900, 581);
            this.ArmyDetailSplitContainer.SplitterDistance = 418;
            this.ArmyDetailSplitContainer.TabIndex = 0;
            // 
            // ArmyDetailLeftSplitContainer
            // 
            this.ArmyDetailLeftSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmyDetailLeftSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ArmyDetailLeftSplitContainer.Name = "ArmyDetailLeftSplitContainer";
            this.ArmyDetailLeftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ArmyDetailLeftSplitContainer.Panel1
            // 
            this.ArmyDetailLeftSplitContainer.Panel1.Controls.Add(this._armyUnitListViewControl1);
            // 
            // ArmyDetailLeftSplitContainer.Panel2
            // 
            this.ArmyDetailLeftSplitContainer.Panel2.Controls.Add(this.armyAllyListViewControl1);
            this.ArmyDetailLeftSplitContainer.Size = new System.Drawing.Size(418, 581);
            this.ArmyDetailLeftSplitContainer.SplitterDistance = 408;
            this.ArmyDetailLeftSplitContainer.TabIndex = 1;
            // 
            // _armyUnitListViewControl1
            // 
            this._armyUnitListViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._armyUnitListViewControl1.Location = new System.Drawing.Point(0, 0);
            this._armyUnitListViewControl1.Name = "_armyUnitListViewControl1";
            this._armyUnitListViewControl1.Size = new System.Drawing.Size(418, 408);
            this._armyUnitListViewControl1.TabIndex = 0;
            // 
            // armyAllyListViewControl1
            // 
            this.armyAllyListViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armyAllyListViewControl1.Location = new System.Drawing.Point(0, 0);
            this.armyAllyListViewControl1.Name = "armyAllyListViewControl1";
            this.armyAllyListViewControl1.Size = new System.Drawing.Size(418, 169);
            this.armyAllyListViewControl1.TabIndex = 0;
            // 
            // ArmyDetailRightSplitContainer
            // 
            this.ArmyDetailRightSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmyDetailRightSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ArmyDetailRightSplitContainer.Name = "ArmyDetailRightSplitContainer";
            this.ArmyDetailRightSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ArmyDetailRightSplitContainer.Panel1
            // 
            this.ArmyDetailRightSplitContainer.Panel1.Controls.Add(this.ArmyUnitDetailViewControl);
            // 
            // ArmyDetailRightSplitContainer.Panel2
            // 
            this.ArmyDetailRightSplitContainer.Panel2.Controls.Add(this.allyListViewControl1);
            this.ArmyDetailRightSplitContainer.Size = new System.Drawing.Size(478, 581);
            this.ArmyDetailRightSplitContainer.SplitterDistance = 408;
            this.ArmyDetailRightSplitContainer.TabIndex = 1;
            // 
            // ArmyUnitDetailViewControl
            // 
            this.ArmyUnitDetailViewControl.ArmyUnitDefinitionId = 0;
            this.ArmyUnitDetailViewControl.ArmyUnitName = "";
            this.ArmyUnitDetailViewControl.Cost = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.ArmyUnitDetailViewControl.DisciplineType = GameEditor.Wcf.Harness.WarGameServiceReference.DisciplineTypeEnum.Regular;
            this.ArmyUnitDetailViewControl.DispositionType = GameEditor.Wcf.Harness.WarGameServiceReference.DispositionTypeEnum.Mounted;
            this.ArmyUnitDetailViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmyUnitDetailViewControl.GradeType = GameEditor.Wcf.Harness.WarGameServiceReference.GradeTypeEnum.Superior;
            this.ArmyUnitDetailViewControl.IsAlly = false;
            this.ArmyUnitDetailViewControl.IsChariot = false;
            this.ArmyUnitDetailViewControl.IsDoubleElement = false;
            this.ArmyUnitDetailViewControl.IsGeneral = false;
            this.ArmyUnitDetailViewControl.IsMountedInfantry = false;
            this.ArmyUnitDetailViewControl.Location = new System.Drawing.Point(0, 0);
            this.ArmyUnitDetailViewControl.MaxCount = 0;
            this.ArmyUnitDetailViewControl.MinCount = 0;
            this.ArmyUnitDetailViewControl.Name = "ArmyUnitDetailViewControl";
            this.ArmyUnitDetailViewControl.Size = new System.Drawing.Size(478, 408);
            this.ArmyUnitDetailViewControl.TabIndex = 0;
            this.ArmyUnitDetailViewControl.UnitType = GameEditor.Wcf.Harness.WarGameServiceReference.UnitTypeEnum.Elephants;
            // 
            // allyListViewControl1
            // 
            this.allyListViewControl1.AllyName = null;
            this.allyListViewControl1.CanUpdate = false;
            this.allyListViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allyListViewControl1.Location = new System.Drawing.Point(0, 0);
            this.allyListViewControl1.MaxYear = 0;
            this.allyListViewControl1.MinYear = 0;
            this.allyListViewControl1.Name = "allyListViewControl1";
            this.allyListViewControl1.Size = new System.Drawing.Size(478, 169);
            this.allyListViewControl1.TabIndex = 0;
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
            this._armyUnitDetailViewControl1.Size = new System.Drawing.Size(706, 321);
            this._armyUnitDetailViewControl1.TabIndex = 0;
            this._armyUnitDetailViewControl1.UnitType = GameEditor.Wcf.Harness.WarGameServiceReference.UnitTypeEnum.Elephants;
            // 
            // MainPageViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 663);
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
            this.ArmyListSplitContainer.Panel1.ResumeLayout(false);
            this.ArmyListSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArmyListSplitContainer)).EndInit();
            this.ArmyListSplitContainer.ResumeLayout(false);
            this.ArmyUnitTabPage.ResumeLayout(false);
            this.ArmyDetailSplitContainer.Panel1.ResumeLayout(false);
            this.ArmyDetailSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArmyDetailSplitContainer)).EndInit();
            this.ArmyDetailSplitContainer.ResumeLayout(false);
            this.ArmyDetailLeftSplitContainer.Panel1.ResumeLayout(false);
            this.ArmyDetailLeftSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArmyDetailLeftSplitContainer)).EndInit();
            this.ArmyDetailLeftSplitContainer.ResumeLayout(false);
            this.ArmyDetailRightSplitContainer.Panel1.ResumeLayout(false);
            this.ArmyDetailRightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArmyDetailRightSplitContainer)).EndInit();
            this.ArmyDetailRightSplitContainer.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer ArmyDetailSplitContainer;
        private ArmyUnitListViewControl _armyUnitListViewControl1;
        private ArmyUnitDetailViewControl ArmyUnitDetailViewControl;
        private ArmyListViewControl armyListViewControl1;
        private ArmyDetailViewControl armyDetailViewControl1;
        private System.Windows.Forms.SplitContainer ArmyDetailLeftSplitContainer;
        private ArmyAllyListViewControl armyAllyListViewControl1;
        private System.Windows.Forms.SplitContainer ArmyDetailRightSplitContainer;
        private AllyListViewControl allyListViewControl1;
        private ArmyUnitDetailViewControl _armyUnitDetailViewControl1;
        private System.Windows.Forms.SplitContainer ArmyListSplitContainer;
    }
}