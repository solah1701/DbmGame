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
            this.ArmyUnitTabPage = new System.Windows.Forms.TabPage();
            this.ArmyDetailSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ArmyDetailRightSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ArmyListViewControl = new GameEditor.Wcf.Harness.ArmyListViewControl();
            this.ArmyDetailViewControl = new GameEditor.Wcf.Harness.ArmyDetailViewControl();
            this.ArmyDetailLeftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ArmyUnitListViewControl = new GameEditor.Wcf.Harness.ArmyUnitListViewControl();
            this.ArmyAllyListViewControl = new GameEditor.Wcf.Harness.ArmyAllyListViewControl();
            this.ArmyUnitDetailViewControl = new GameEditor.Wcf.Harness.ArmyUnitDetailViewControl();
            this.AllyListViewControl = new GameEditor.Wcf.Harness.AllyListViewControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.ArmyDetailRightSplitContainer)).BeginInit();
            this.ArmyDetailRightSplitContainer.Panel1.SuspendLayout();
            this.ArmyDetailRightSplitContainer.Panel2.SuspendLayout();
            this.ArmyDetailRightSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArmyDetailLeftSplitContainer)).BeginInit();
            this.ArmyDetailLeftSplitContainer.Panel1.SuspendLayout();
            this.ArmyDetailLeftSplitContainer.Panel2.SuspendLayout();
            this.ArmyDetailLeftSplitContainer.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 718);
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
            this.MainTabControl.Size = new System.Drawing.Size(908, 690);
            this.MainTabControl.TabIndex = 2;
            // 
            // ArmyListTabPage
            // 
            this.ArmyListTabPage.Controls.Add(this.ArmyListSplitContainer);
            this.ArmyListTabPage.Location = new System.Drawing.Point(4, 25);
            this.ArmyListTabPage.Name = "ArmyListTabPage";
            this.ArmyListTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ArmyListTabPage.Size = new System.Drawing.Size(900, 661);
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
            this.ArmyListSplitContainer.Panel1.Controls.Add(this.ArmyListViewControl);
            // 
            // ArmyListSplitContainer.Panel2
            // 
            this.ArmyListSplitContainer.Panel2.Controls.Add(this.ArmyDetailViewControl);
            this.ArmyListSplitContainer.Size = new System.Drawing.Size(894, 655);
            this.ArmyListSplitContainer.SplitterDistance = 298;
            this.ArmyListSplitContainer.TabIndex = 0;
            // 
            // ArmyUnitTabPage
            // 
            this.ArmyUnitTabPage.Controls.Add(this.ArmyDetailSplitContainer);
            this.ArmyUnitTabPage.Location = new System.Drawing.Point(4, 25);
            this.ArmyUnitTabPage.Name = "ArmyUnitTabPage";
            this.ArmyUnitTabPage.Size = new System.Drawing.Size(900, 661);
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
            this.ArmyDetailSplitContainer.Panel2MinSize = 400;
            this.ArmyDetailSplitContainer.Size = new System.Drawing.Size(900, 661);
            this.ArmyDetailSplitContainer.SplitterDistance = 418;
            this.ArmyDetailSplitContainer.TabIndex = 0;
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
            this.ArmyDetailRightSplitContainer.Panel2.Controls.Add(this.AllyListViewControl);
            this.ArmyDetailRightSplitContainer.Panel2MinSize = 185;
            this.ArmyDetailRightSplitContainer.Size = new System.Drawing.Size(478, 661);
            this.ArmyDetailRightSplitContainer.SplitterDistance = 398;
            this.ArmyDetailRightSplitContainer.TabIndex = 1;
            // 
            // ArmyListViewControl
            // 
            this.ArmyListViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmyListViewControl.Location = new System.Drawing.Point(0, 0);
            this.ArmyListViewControl.Name = "ArmyListViewControl";
            this.ArmyListViewControl.Size = new System.Drawing.Size(298, 655);
            this.ArmyListViewControl.TabIndex = 0;
            // 
            // ArmyDetailViewControl
            // 
            this.ArmyDetailViewControl.ArmyId = 0;
            this.ArmyDetailViewControl.ArmyName = "";
            this.ArmyDetailViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmyDetailViewControl.Location = new System.Drawing.Point(0, 0);
            this.ArmyDetailViewControl.Name = "ArmyDetailViewControl";
            this.ArmyDetailViewControl.Notes = "";
            this.ArmyDetailViewControl.Size = new System.Drawing.Size(592, 655);
            this.ArmyDetailViewControl.TabIndex = 0;
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
            this.ArmyDetailLeftSplitContainer.Panel1.Controls.Add(this.ArmyUnitListViewControl);
            // 
            // ArmyDetailLeftSplitContainer.Panel2
            // 
            this.ArmyDetailLeftSplitContainer.Panel2.Controls.Add(this.ArmyAllyListViewControl);
            this.ArmyDetailLeftSplitContainer.Panel2MinSize = 125;
            this.ArmyDetailLeftSplitContainer.Size = new System.Drawing.Size(418, 661);
            this.ArmyDetailLeftSplitContainer.SplitterDistance = 489;
            this.ArmyDetailLeftSplitContainer.TabIndex = 1;
            // 
            // ArmyUnitListViewControl
            // 
            this.ArmyUnitListViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmyUnitListViewControl.Location = new System.Drawing.Point(0, 0);
            this.ArmyUnitListViewControl.Name = "ArmyUnitListViewControl";
            this.ArmyUnitListViewControl.Size = new System.Drawing.Size(418, 489);
            this.ArmyUnitListViewControl.TabIndex = 0;
            // 
            // ArmyAllyListViewControl
            // 
            this.ArmyAllyListViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArmyAllyListViewControl.Location = new System.Drawing.Point(0, 0);
            this.ArmyAllyListViewControl.Name = "ArmyAllyListViewControl";
            this.ArmyAllyListViewControl.Size = new System.Drawing.Size(418, 168);
            this.ArmyAllyListViewControl.TabIndex = 0;
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
            this.ArmyUnitDetailViewControl.Size = new System.Drawing.Size(478, 398);
            this.ArmyUnitDetailViewControl.TabIndex = 0;
            this.ArmyUnitDetailViewControl.UnitType = GameEditor.Wcf.Harness.WarGameServiceReference.UnitTypeEnum.Elephants;
            // 
            // AllyListViewControl
            // 
            this.AllyListViewControl.AllyName = "";
            this.AllyListViewControl.CanDelete = true;
            this.AllyListViewControl.CanUpdate = true;
            this.AllyListViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllyListViewControl.Location = new System.Drawing.Point(0, 0);
            this.AllyListViewControl.MaxYear = 0;
            this.AllyListViewControl.MinYear = 0;
            this.AllyListViewControl.Name = "AllyListViewControl";
            this.AllyListViewControl.Size = new System.Drawing.Size(478, 259);
            this.AllyListViewControl.TabIndex = 0;
            // 
            // MainPageViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 743);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(926, 790);
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
            this.ArmyDetailRightSplitContainer.Panel1.ResumeLayout(false);
            this.ArmyDetailRightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArmyDetailRightSplitContainer)).EndInit();
            this.ArmyDetailRightSplitContainer.ResumeLayout(false);
            this.ArmyDetailLeftSplitContainer.Panel1.ResumeLayout(false);
            this.ArmyDetailLeftSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArmyDetailLeftSplitContainer)).EndInit();
            this.ArmyDetailLeftSplitContainer.ResumeLayout(false);
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
        private ArmyUnitListViewControl ArmyUnitListViewControl;
        private ArmyUnitDetailViewControl ArmyUnitDetailViewControl;
        private ArmyDetailViewControl ArmyDetailViewControl;
        private System.Windows.Forms.SplitContainer ArmyDetailLeftSplitContainer;
        private ArmyAllyListViewControl ArmyAllyListViewControl;
        private System.Windows.Forms.SplitContainer ArmyDetailRightSplitContainer;
        private System.Windows.Forms.SplitContainer ArmyListSplitContainer;
        private AllyListViewControl AllyListViewControl;
        private ArmyListViewControl ArmyListViewControl;
    }
}