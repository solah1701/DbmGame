namespace GameEditor
{
    partial class GameForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gameControl1 = new GameEditor.GameControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.goodsListControl1 = new GameEditor.GoodsListControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.primaryProducerControl1 = new GameEditor.PrimaryProducerListControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.secondaryProducerControl1 = new GameEditor.SecondaryProducerListControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 708);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(931, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 708);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gameControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 679);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Game";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gameControl1
            // 
            this.gameControl1.BackColor = System.Drawing.SystemColors.Control;
            this.gameControl1.CanCreate = true;
            this.gameControl1.CanDelete = false;
            this.gameControl1.CanRead = true;
            this.gameControl1.CanUpdate = true;
            this.gameControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameControl1.Location = new System.Drawing.Point(3, 3);
            this.gameControl1.Name = "gameControl1";
            this.gameControl1.Path = "";
            this.gameControl1.Size = new System.Drawing.Size(917, 673);
            this.gameControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.goodsListControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(646, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Goods";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // goodsListControl1
            // 
            this.goodsListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goodsListControl1.Location = new System.Drawing.Point(3, 3);
            this.goodsListControl1.Name = "goodsListControl1";
            this.goodsListControl1.Size = new System.Drawing.Size(640, 416);
            this.goodsListControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.primaryProducerControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(646, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Primary Producer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // primaryProducerControl1
            // 
            this.primaryProducerControl1.Amount = 0;
            this.primaryProducerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primaryProducerControl1.Location = new System.Drawing.Point(0, 0);
            this.primaryProducerControl1.Name = "primaryProducerControl1";
            this.primaryProducerControl1.Produces = "";
            this.primaryProducerControl1.ProductionRate = 0;
            this.primaryProducerControl1.Size = new System.Drawing.Size(646, 422);
            this.primaryProducerControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.secondaryProducerControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(646, 422);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Secondary Producer";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // secondaryProducerControl1
            // 
            this.secondaryProducerControl1.Amount = 0;
            this.secondaryProducerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryProducerControl1.Location = new System.Drawing.Point(0, 0);
            this.secondaryProducerControl1.MaxConsumers = 0;
            this.secondaryProducerControl1.Name = "secondaryProducerControl1";
            this.secondaryProducerControl1.Produces = "";
            this.secondaryProducerControl1.Rate = 0;
            this.secondaryProducerControl1.Size = new System.Drawing.Size(646, 422);
            this.secondaryProducerControl1.TabIndex = 0;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 730);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameControl gameControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private GoodsListControl goodsListControl1;
        private PrimaryProducerListControl primaryProducerControl1;
        private SecondaryProducerListControl secondaryProducerControl1;
    }
}