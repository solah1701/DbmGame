namespace GameEditor
{
    partial class UnitsControl
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
            this.UnitListView = new System.Windows.Forms.ListView();
            this.baseControl1 = new GameEditor.BaseControl();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AttackNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.DefenceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.MoveNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.RangeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.SpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.StaminaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.LevelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.MoraleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.CostNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.UpkeepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.BuildNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttackNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefenceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaminaNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoraleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpkeepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuildNumericUpDown)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.UnitListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BuildNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.UpkeepNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.CostNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.MoraleNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.LevelNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.StaminaNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.SpeedNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.RangeNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.MoveNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.DefenceNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.AttackNumericUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.NameTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.baseControl1);
            this.splitContainer1.Size = new System.Drawing.Size(551, 400);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 0;
            // 
            // UnitListView
            // 
            this.UnitListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnitListView.FullRowSelect = true;
            this.UnitListView.GridLines = true;
            this.UnitListView.Location = new System.Drawing.Point(0, 0);
            this.UnitListView.Name = "UnitListView";
            this.UnitListView.Size = new System.Drawing.Size(183, 400);
            this.UnitListView.TabIndex = 0;
            this.UnitListView.UseCompatibleStateImageBehavior = false;
            this.UnitListView.View = System.Windows.Forms.View.Details;
            this.UnitListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.UnitListView_ItemSelectionChanged);
            // 
            // baseControl1
            // 
            this.baseControl1.BackColor = System.Drawing.SystemColors.Control;
            this.baseControl1.CanCreate = false;
            this.baseControl1.CanDelete = false;
            this.baseControl1.CanRead = false;
            this.baseControl1.CanUpdate = false;
            this.baseControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.baseControl1.Location = new System.Drawing.Point(0, 360);
            this.baseControl1.Name = "baseControl1";
            this.baseControl1.Size = new System.Drawing.Size(364, 40);
            this.baseControl1.TabIndex = 0;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(88, 3);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(273, 22);
            this.NameTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // AttackNumericUpDown
            // 
            this.AttackNumericUpDown.Location = new System.Drawing.Point(88, 31);
            this.AttackNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.AttackNumericUpDown.Name = "AttackNumericUpDown";
            this.AttackNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.AttackNumericUpDown.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Attack";
            // 
            // DefenceNumericUpDown
            // 
            this.DefenceNumericUpDown.Location = new System.Drawing.Point(88, 59);
            this.DefenceNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.DefenceNumericUpDown.Name = "DefenceNumericUpDown";
            this.DefenceNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.DefenceNumericUpDown.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Defence";
            // 
            // MoveNumericUpDown
            // 
            this.MoveNumericUpDown.Location = new System.Drawing.Point(88, 87);
            this.MoveNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.MoveNumericUpDown.Name = "MoveNumericUpDown";
            this.MoveNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.MoveNumericUpDown.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Move";
            // 
            // RangeNumericUpDown
            // 
            this.RangeNumericUpDown.Location = new System.Drawing.Point(88, 115);
            this.RangeNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.RangeNumericUpDown.Name = "RangeNumericUpDown";
            this.RangeNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.RangeNumericUpDown.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Range";
            // 
            // SpeedNumericUpDown
            // 
            this.SpeedNumericUpDown.Location = new System.Drawing.Point(88, 143);
            this.SpeedNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.SpeedNumericUpDown.Name = "SpeedNumericUpDown";
            this.SpeedNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.SpeedNumericUpDown.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Speed";
            // 
            // StaminaNumericUpDown
            // 
            this.StaminaNumericUpDown.Location = new System.Drawing.Point(88, 171);
            this.StaminaNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.StaminaNumericUpDown.Name = "StaminaNumericUpDown";
            this.StaminaNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.StaminaNumericUpDown.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Stamina";
            // 
            // LevelNumericUpDown
            // 
            this.LevelNumericUpDown.Location = new System.Drawing.Point(88, 199);
            this.LevelNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.LevelNumericUpDown.Name = "LevelNumericUpDown";
            this.LevelNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.LevelNumericUpDown.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Level";
            // 
            // MoraleNumericUpDown
            // 
            this.MoraleNumericUpDown.Location = new System.Drawing.Point(88, 227);
            this.MoraleNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.MoraleNumericUpDown.Name = "MoraleNumericUpDown";
            this.MoraleNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.MoraleNumericUpDown.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Morale";
            // 
            // CostNumericUpDown
            // 
            this.CostNumericUpDown.Location = new System.Drawing.Point(88, 255);
            this.CostNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.CostNumericUpDown.Name = "CostNumericUpDown";
            this.CostNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.CostNumericUpDown.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Cost";
            // 
            // UpkeepNumericUpDown
            // 
            this.UpkeepNumericUpDown.Location = new System.Drawing.Point(88, 283);
            this.UpkeepNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.UpkeepNumericUpDown.Name = "UpkeepNumericUpDown";
            this.UpkeepNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.UpkeepNumericUpDown.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = "Upkeep";
            // 
            // BuildNumericUpDown
            // 
            this.BuildNumericUpDown.Location = new System.Drawing.Point(88, 311);
            this.BuildNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.BuildNumericUpDown.Name = "BuildNumericUpDown";
            this.BuildNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.BuildNumericUpDown.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 313);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 17);
            this.label12.TabIndex = 30;
            this.label12.Text = "Build";
            // 
            // UnitsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UnitsControl";
            this.Size = new System.Drawing.Size(551, 400);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttackNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefenceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaminaNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoraleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpkeepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuildNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView UnitListView;
        private BaseControl baseControl1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown BuildNumericUpDown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown UpkeepNumericUpDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown CostNumericUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown MoraleNumericUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown LevelNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown StaminaNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown SpeedNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown RangeNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown MoveNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown DefenceNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown AttackNumericUpDown;
        private System.Windows.Forms.Label label3;
    }
}
