namespace _10_tool_tip_
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.dayOfWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBarRED = new System.Windows.Forms.TrackBar();
            this.trackBarGREEN = new System.Windows.Forms.TrackBar();
            this.trackBarBLUE = new System.Windows.Forms.TrackBar();
            this.labelR = new System.Windows.Forms.Label();
            this.labelG = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelRGB = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarImageX = new System.Windows.Forms.TrackBar();
            this.trackBarImageY = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGREEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBLUE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImageX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImageY)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 30);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "default";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripDropDownButton1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 362);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(565, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(40, 17);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dayOfWeekToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::_10_tool_tip_.Properties.Resources.pyramids;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // dayOfWeekToolStripMenuItem
            // 
            this.dayOfWeekToolStripMenuItem.Name = "dayOfWeekToolStripMenuItem";
            this.dayOfWeekToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.dayOfWeekToolStripMenuItem.Text = "DayOfWeek";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // trackBarRED
            // 
            this.trackBarRED.Location = new System.Drawing.Point(100, 159);
            this.trackBarRED.Maximum = 255;
            this.trackBarRED.Name = "trackBarRED";
            this.trackBarRED.Size = new System.Drawing.Size(389, 45);
            this.trackBarRED.TabIndex = 4;
            // 
            // trackBarGREEN
            // 
            this.trackBarGREEN.Location = new System.Drawing.Point(100, 210);
            this.trackBarGREEN.Maximum = 255;
            this.trackBarGREEN.Name = "trackBarGREEN";
            this.trackBarGREEN.Size = new System.Drawing.Size(389, 45);
            this.trackBarGREEN.TabIndex = 5;
            // 
            // trackBarBLUE
            // 
            this.trackBarBLUE.Location = new System.Drawing.Point(100, 261);
            this.trackBarBLUE.Maximum = 255;
            this.trackBarBLUE.Name = "trackBarBLUE";
            this.trackBarBLUE.Size = new System.Drawing.Size(389, 45);
            this.trackBarBLUE.TabIndex = 6;
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Location = new System.Drawing.Point(73, 159);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(21, 13);
            this.labelR.TabIndex = 7;
            this.labelR.Text = "R: ";
            // 
            // labelG
            // 
            this.labelG.AutoSize = true;
            this.labelG.Location = new System.Drawing.Point(73, 210);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(21, 13);
            this.labelG.TabIndex = 8;
            this.labelG.Text = "G: ";
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(74, 261);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(20, 13);
            this.labelB.TabIndex = 9;
            this.labelB.Text = "B: ";
            // 
            // labelRGB
            // 
            this.labelRGB.AutoSize = true;
            this.labelRGB.Location = new System.Drawing.Point(97, 137);
            this.labelRGB.Name = "labelRGB";
            this.labelRGB.Size = new System.Drawing.Size(72, 13);
            this.labelRGB.TabIndex = 10;
            this.labelRGB.Text = "RGB (0, 0, 0) ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_10_tool_tip_.Properties.Resources.fire3;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // trackBarImageX
            // 
            this.trackBarImageX.Location = new System.Drawing.Point(40, 312);
            this.trackBarImageX.Maximum = 300;
            this.trackBarImageX.Name = "trackBarImageX";
            this.trackBarImageX.Size = new System.Drawing.Size(359, 45);
            this.trackBarImageX.TabIndex = 13;
            // 
            // trackBarImageY
            // 
            this.trackBarImageY.Location = new System.Drawing.Point(12, 86);
            this.trackBarImageY.Maximum = 300;
            this.trackBarImageY.Name = "trackBarImageY";
            this.trackBarImageY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarImageY.Size = new System.Drawing.Size(45, 220);
            this.trackBarImageY.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Size: (0,0)";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(296, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 138);
            this.panel1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 384);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarImageY);
            this.Controls.Add(this.trackBarImageX);
            this.Controls.Add(this.labelRGB);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelG);
            this.Controls.Add(this.labelR);
            this.Controls.Add(this.trackBarBLUE);
            this.Controls.Add(this.trackBarGREEN);
            this.Controls.Add(this.trackBarRED);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGREEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBLUE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImageX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImageY)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem dayOfWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private DateTimeFormat format = DateTimeFormat.ShortFormat;
        private System.Windows.Forms.TrackBar trackBarRED;
        private System.Windows.Forms.TrackBar trackBarGREEN;
        private System.Windows.Forms.TrackBar trackBarBLUE;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelRGB;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBarImageX;
        private System.Windows.Forms.TrackBar trackBarImageY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}

