namespace Launcher
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dlPercentage = new System.Windows.Forms.Label();
            this.strtGameBtn = new System.Windows.Forms.PictureBox();
            this.gameVersion = new System.Windows.Forms.Label();
            this.closeLbl = new System.Windows.Forms.Label();
            this.minLbl = new System.Windows.Forms.Label();
            this.playHint = new System.Windows.Forms.Label();
            this.downloadLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.background = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.strtGameBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.ForeColor = System.Drawing.Color.DarkRed;
            this.progressBar1.Location = new System.Drawing.Point(31, 522);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(533, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // dlPercentage
            // 
            this.dlPercentage.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dlPercentage.AutoSize = true;
            this.dlPercentage.BackColor = System.Drawing.Color.Transparent;
            this.dlPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dlPercentage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dlPercentage.Location = new System.Drawing.Point(26, 492);
            this.dlPercentage.Name = "dlPercentage";
            this.dlPercentage.Size = new System.Drawing.Size(45, 25);
            this.dlPercentage.TabIndex = 2;
            this.dlPercentage.Text = "0%";
            // 
            // strtGameBtn
            // 
            this.strtGameBtn.BackColor = System.Drawing.Color.Transparent;
            this.strtGameBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.strtGameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.strtGameBtn.Image = global::Launcher.Properties.Resources.patching_btn;
            this.strtGameBtn.InitialImage = global::Launcher.Properties.Resources.patching_btn;
            this.strtGameBtn.Location = new System.Drawing.Point(614, 483);
            this.strtGameBtn.Name = "strtGameBtn";
            this.strtGameBtn.Size = new System.Drawing.Size(261, 74);
            this.strtGameBtn.TabIndex = 10;
            this.strtGameBtn.TabStop = false;
            this.strtGameBtn.Click += new System.EventHandler(this.strtGameBtn_Click_1);
            // 
            // gameVersion
            // 
            this.gameVersion.AutoSize = true;
            this.gameVersion.BackColor = System.Drawing.Color.Transparent;
            this.gameVersion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gameVersion.Location = new System.Drawing.Point(703, 10);
            this.gameVersion.Name = "gameVersion";
            this.gameVersion.Size = new System.Drawing.Size(61, 16);
            this.gameVersion.TabIndex = 19;
            this.gameVersion.Text = "ver 1.0.0";
            // 
            // closeLbl
            // 
            this.closeLbl.AutoSize = true;
            this.closeLbl.BackColor = System.Drawing.Color.Transparent;
            this.closeLbl.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.closeLbl.Location = new System.Drawing.Point(863, 8);
            this.closeLbl.Name = "closeLbl";
            this.closeLbl.Size = new System.Drawing.Size(23, 22);
            this.closeLbl.TabIndex = 27;
            this.closeLbl.Text = "X";
            this.closeLbl.Click += new System.EventHandler(this.closeLbl_Click);
            // 
            // minLbl
            // 
            this.minLbl.AutoSize = true;
            this.minLbl.BackColor = System.Drawing.Color.Transparent;
            this.minLbl.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.minLbl.Location = new System.Drawing.Point(835, 4);
            this.minLbl.Name = "minLbl";
            this.minLbl.Size = new System.Drawing.Size(22, 24);
            this.minLbl.TabIndex = 28;
            this.minLbl.Text = "_";
            this.minLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minLbl.Click += new System.EventHandler(this.minLbl_Click);
            // 
            // playHint
            // 
            this.playHint.AutoSize = true;
            this.playHint.BackColor = System.Drawing.Color.Transparent;
            this.playHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playHint.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.playHint.Location = new System.Drawing.Point(284, 499);
            this.playHint.Name = "playHint";
            this.playHint.Size = new System.Drawing.Size(280, 16);
            this.playHint.TabIndex = 29;
            this.playHint.Text = "Click \'PLAY\' buttom to launch the game.";
            // 
            // downloadLbl
            // 
            this.downloadLbl.AutoSize = true;
            this.downloadLbl.BackColor = System.Drawing.Color.Transparent;
            this.downloadLbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.downloadLbl.Location = new System.Drawing.Point(98, 499);
            this.downloadLbl.Name = "downloadLbl";
            this.downloadLbl.Size = new System.Drawing.Size(125, 16);
            this.downloadLbl.TabIndex = 30;
            this.downloadLbl.Text = "Download Process";
            this.downloadLbl.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(28, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Foreign Launcher";
            // 
            // background
            // 
            this.background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("background.BackgroundImage")));
            this.background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.background.Location = new System.Drawing.Point(-2, 41);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(900, 436);
            this.background.TabIndex = 34;
            this.background.TabStop = false;
            this.background.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Launcher.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(898, 569);
            this.Controls.Add(this.background);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downloadLbl);
            this.Controls.Add(this.playHint);
            this.Controls.Add(this.minLbl);
            this.Controls.Add(this.closeLbl);
            this.Controls.Add(this.gameVersion);
            this.Controls.Add(this.strtGameBtn);
            this.Controls.Add(this.dlPercentage);
            this.Controls.Add(this.progressBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Foreign Launcher";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.strtGameBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label dlPercentage;
        private System.Windows.Forms.PictureBox strtGameBtn;
        private System.Windows.Forms.Label gameVersion;
        private System.Windows.Forms.Label closeLbl;
        private System.Windows.Forms.Label minLbl;
        private System.Windows.Forms.Label playHint;
        public System.Windows.Forms.Label downloadLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox background;
    }
}

