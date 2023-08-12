namespace Labyrinth
{
    partial class PlayMaze
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picMaze = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.solveTimer = new System.Windows.Forms.Timer(this.components);
            this.solveBtn = new System.Windows.Forms.Button();
            this.visualizationGroupBox = new System.Windows.Forms.GroupBox();
            this.staticRBrn = new System.Windows.Forms.RadioButton();
            this.dynamicRBtn = new System.Windows.Forms.RadioButton();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.pathAlgGroupBox = new System.Windows.Forms.GroupBox();
            this.waveRBtn = new System.Windows.Forms.RadioButton();
            this.handRBtn = new System.Windows.Forms.RadioButton();
            this.startBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).BeginInit();
            this.visualizationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.pathAlgGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // picMaze
            // 
            this.picMaze.Location = new System.Drawing.Point(11, 11);
            this.picMaze.Margin = new System.Windows.Forms.Padding(2);
            this.picMaze.Name = "picMaze";
            this.picMaze.Size = new System.Drawing.Size(488, 406);
            this.picMaze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMaze.TabIndex = 15;
            this.picMaze.TabStop = false;
            this.picMaze.Click += new System.EventHandler(this.picMaze_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 440);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(404, 460);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 22;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(34, 7);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 26;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(208, 10);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(0, 13);
            this.linkLabel2.TabIndex = 27;
            // 
            // solveTimer
            // 
            this.solveTimer.Interval = 500;
            this.solveTimer.Tick += new System.EventHandler(this.solveTimer_Tick);
            // 
            // solveBtn
            // 
            this.solveBtn.Location = new System.Drawing.Point(517, 210);
            this.solveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(92, 29);
            this.solveBtn.TabIndex = 16;
            this.solveBtn.TabStop = false;
            this.solveBtn.Text = "Старт";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // visualizationGroupBox
            // 
            this.visualizationGroupBox.Controls.Add(this.staticRBrn);
            this.visualizationGroupBox.Controls.Add(this.dynamicRBtn);
            this.visualizationGroupBox.Controls.Add(this.speedBar);
            this.visualizationGroupBox.Location = new System.Drawing.Point(503, 82);
            this.visualizationGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.visualizationGroupBox.Name = "visualizationGroupBox";
            this.visualizationGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.visualizationGroupBox.Size = new System.Drawing.Size(150, 110);
            this.visualizationGroupBox.TabIndex = 35;
            this.visualizationGroupBox.TabStop = false;
            this.visualizationGroupBox.Text = "Визуализация";
            // 
            // staticRBrn
            // 
            this.staticRBrn.AutoSize = true;
            this.staticRBrn.Checked = true;
            this.staticRBrn.Location = new System.Drawing.Point(14, 17);
            this.staticRBrn.Margin = new System.Windows.Forms.Padding(2);
            this.staticRBrn.Name = "staticRBrn";
            this.staticRBrn.Size = new System.Drawing.Size(89, 17);
            this.staticRBrn.TabIndex = 23;
            this.staticRBrn.TabStop = true;
            this.staticRBrn.Text = "Статическая";
            this.staticRBrn.UseVisualStyleBackColor = true;
            // 
            // dynamicRBtn
            // 
            this.dynamicRBtn.AutoSize = true;
            this.dynamicRBtn.Location = new System.Drawing.Point(14, 38);
            this.dynamicRBtn.Margin = new System.Windows.Forms.Padding(2);
            this.dynamicRBtn.Name = "dynamicRBtn";
            this.dynamicRBtn.Size = new System.Drawing.Size(101, 17);
            this.dynamicRBtn.TabIndex = 24;
            this.dynamicRBtn.Text = "Динамическая";
            this.dynamicRBtn.UseVisualStyleBackColor = true;
            this.dynamicRBtn.CheckedChanged += new System.EventHandler(this.dynamicRBtn_CheckedChanged);
            // 
            // speedBar
            // 
            this.speedBar.Enabled = false;
            this.speedBar.Location = new System.Drawing.Point(14, 59);
            this.speedBar.Margin = new System.Windows.Forms.Padding(2);
            this.speedBar.Maximum = 3;
            this.speedBar.Minimum = 1;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(101, 45);
            this.speedBar.TabIndex = 25;
            this.speedBar.Value = 1;
            this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
            // 
            // pathAlgGroupBox
            // 
            this.pathAlgGroupBox.Controls.Add(this.waveRBtn);
            this.pathAlgGroupBox.Controls.Add(this.handRBtn);
            this.pathAlgGroupBox.Location = new System.Drawing.Point(503, 11);
            this.pathAlgGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.pathAlgGroupBox.Name = "pathAlgGroupBox";
            this.pathAlgGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.pathAlgGroupBox.Size = new System.Drawing.Size(150, 67);
            this.pathAlgGroupBox.TabIndex = 34;
            this.pathAlgGroupBox.TabStop = false;
            this.pathAlgGroupBox.Text = "Алгоритм поиска";
            // 
            // waveRBtn
            // 
            this.waveRBtn.AutoSize = true;
            this.waveRBtn.Checked = true;
            this.waveRBtn.Location = new System.Drawing.Point(14, 16);
            this.waveRBtn.Margin = new System.Windows.Forms.Padding(2);
            this.waveRBtn.Name = "waveRBtn";
            this.waveRBtn.Size = new System.Drawing.Size(74, 17);
            this.waveRBtn.TabIndex = 19;
            this.waveRBtn.TabStop = true;
            this.waveRBtn.Text = "Волновой";
            this.waveRBtn.UseVisualStyleBackColor = true;
            // 
            // handRBtn
            // 
            this.handRBtn.AutoSize = true;
            this.handRBtn.Location = new System.Drawing.Point(14, 38);
            this.handRBtn.Margin = new System.Windows.Forms.Padding(2);
            this.handRBtn.Name = "handRBtn";
            this.handRBtn.Size = new System.Drawing.Size(89, 17);
            this.handRBtn.TabIndex = 20;
            this.handRBtn.Text = "Правой руки";
            this.handRBtn.UseVisualStyleBackColor = true;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(517, 243);
            this.startBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(92, 29);
            this.startBtn.TabIndex = 37;
            this.startBtn.TabStop = false;
            this.startBtn.Text = "Начать заново";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(517, 389);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(92, 28);
            this.backBtn.TabIndex = 46;
            this.backBtn.Text = "Назад";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(517, 355);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(91, 28);
            this.about.TabIndex = 47;
            this.about.Text = "О системе";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // PlayMaze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 426);
            this.Controls.Add(this.about);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.visualizationGroupBox);
            this.Controls.Add(this.pathAlgGroupBox);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.picMaze);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayMaze";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск пути";
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).EndInit();
            this.visualizationGroupBox.ResumeLayout(false);
            this.visualizationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.pathAlgGroupBox.ResumeLayout(false);
            this.pathAlgGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picMaze;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Timer solveTimer;
        private System.Windows.Forms.Button solveBtn;
        private System.Windows.Forms.GroupBox visualizationGroupBox;
        private System.Windows.Forms.RadioButton staticRBrn;
        private System.Windows.Forms.RadioButton dynamicRBtn;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.GroupBox pathAlgGroupBox;
        private System.Windows.Forms.RadioButton waveRBtn;
        private System.Windows.Forms.RadioButton handRBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button about;
    }
}

