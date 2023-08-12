namespace Labyrinth
{
    partial class CreateMaze
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
            this.createModelBtn = new System.Windows.Forms.Button();
            this.numUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.setStartFinishBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.picMaze = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.randomRBtn = new System.Windows.Forms.RadioButton();
            this.manuallyRBtn = new System.Windows.Forms.RadioButton();
            this.solveTimer = new System.Windows.Forms.Timer(this.components);
            this.primRBtn = new System.Windows.Forms.RadioButton();
            this.ellerRBtn = new System.Windows.Forms.RadioButton();
            this.genGroupBox = new System.Windows.Forms.GroupBox();
            this.startFinishGroupBox = new System.Windows.Forms.GroupBox();
            this.parameterGroupBox = new System.Windows.Forms.GroupBox();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveGroupBox = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.MazeName = new System.Windows.Forms.TextBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).BeginInit();
            this.genGroupBox.SuspendLayout();
            this.startFinishGroupBox.SuspendLayout();
            this.parameterGroupBox.SuspendLayout();
            this.saveGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // createModelBtn
            // 
            this.createModelBtn.Location = new System.Drawing.Point(29, 140);
            this.createModelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.createModelBtn.Name = "createModelBtn";
            this.createModelBtn.Size = new System.Drawing.Size(100, 28);
            this.createModelBtn.TabIndex = 1;
            this.createModelBtn.Text = "Подтвердить";
            this.createModelBtn.UseVisualStyleBackColor = true;
            this.createModelBtn.Click += new System.EventHandler(this.createModelBtn_Click);
            // 
            // numUpDownHeight
            // 
            this.numUpDownHeight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDownHeight.Location = new System.Drawing.Point(70, 27);
            this.numUpDownHeight.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDownHeight.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numUpDownHeight.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numUpDownHeight.Name = "numUpDownHeight";
            this.numUpDownHeight.ReadOnly = true;
            this.numUpDownHeight.Size = new System.Drawing.Size(45, 20);
            this.numUpDownHeight.TabIndex = 3;
            this.numUpDownHeight.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // numUpDownWidth
            // 
            this.numUpDownWidth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDownWidth.Location = new System.Drawing.Point(70, 64);
            this.numUpDownWidth.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDownWidth.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numUpDownWidth.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numUpDownWidth.Name = "numUpDownWidth";
            this.numUpDownWidth.ReadOnly = true;
            this.numUpDownWidth.Size = new System.Drawing.Size(45, 20);
            this.numUpDownWidth.TabIndex = 4;
            this.numUpDownWidth.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Высота";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ширина";
            // 
            // setStartFinishBtn
            // 
            this.setStartFinishBtn.Location = new System.Drawing.Point(29, 73);
            this.setStartFinishBtn.Margin = new System.Windows.Forms.Padding(2);
            this.setStartFinishBtn.Name = "setStartFinishBtn";
            this.setStartFinishBtn.Size = new System.Drawing.Size(100, 28);
            this.setStartFinishBtn.TabIndex = 10;
            this.setStartFinishBtn.Text = "Расставить";
            this.setStartFinishBtn.UseVisualStyleBackColor = true;
            this.setStartFinishBtn.Click += new System.EventHandler(this.setStartFinishBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(29, 75);
            this.createBtn.Margin = new System.Windows.Forms.Padding(2);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(100, 28);
            this.createBtn.TabIndex = 14;
            this.createBtn.Text = "Сгенерировать";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // picMaze
            // 
            this.picMaze.Location = new System.Drawing.Point(11, 67);
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
            // randomRBtn
            // 
            this.randomRBtn.AutoSize = true;
            this.randomRBtn.Location = new System.Drawing.Point(4, 25);
            this.randomRBtn.Margin = new System.Windows.Forms.Padding(2);
            this.randomRBtn.Name = "randomRBtn";
            this.randomRBtn.Size = new System.Drawing.Size(103, 17);
            this.randomRBtn.TabIndex = 32;
            this.randomRBtn.TabStop = true;
            this.randomRBtn.Text = "Автоматически";
            this.randomRBtn.UseVisualStyleBackColor = true;
            this.randomRBtn.CheckedChanged += new System.EventHandler(this.randomRBtn_CheckedChanged);
            // 
            // manuallyRBtn
            // 
            this.manuallyRBtn.AutoSize = true;
            this.manuallyRBtn.Location = new System.Drawing.Point(4, 47);
            this.manuallyRBtn.Margin = new System.Windows.Forms.Padding(2);
            this.manuallyRBtn.Name = "manuallyRBtn";
            this.manuallyRBtn.Size = new System.Drawing.Size(67, 17);
            this.manuallyRBtn.TabIndex = 33;
            this.manuallyRBtn.TabStop = true;
            this.manuallyRBtn.Text = "Вручную";
            this.manuallyRBtn.UseVisualStyleBackColor = true;
            this.manuallyRBtn.CheckedChanged += new System.EventHandler(this.manuallyRBtn_CheckedChanged);
            // 
            // primRBtn
            // 
            this.primRBtn.AutoSize = true;
            this.primRBtn.Checked = true;
            this.primRBtn.Location = new System.Drawing.Point(4, 24);
            this.primRBtn.Margin = new System.Windows.Forms.Padding(2);
            this.primRBtn.Name = "primRBtn";
            this.primRBtn.Size = new System.Drawing.Size(111, 17);
            this.primRBtn.TabIndex = 36;
            this.primRBtn.TabStop = true;
            this.primRBtn.Text = "Алгоритм Прима";
            this.primRBtn.UseVisualStyleBackColor = true;
            // 
            // ellerRBtn
            // 
            this.ellerRBtn.AutoSize = true;
            this.ellerRBtn.Location = new System.Drawing.Point(4, 45);
            this.ellerRBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ellerRBtn.Name = "ellerRBtn";
            this.ellerRBtn.Size = new System.Drawing.Size(114, 17);
            this.ellerRBtn.TabIndex = 37;
            this.ellerRBtn.Text = "Алгоритм Эллера";
            this.ellerRBtn.UseVisualStyleBackColor = true;
            // 
            // genGroupBox
            // 
            this.genGroupBox.Controls.Add(this.primRBtn);
            this.genGroupBox.Controls.Add(this.ellerRBtn);
            this.genGroupBox.Controls.Add(this.createBtn);
            this.genGroupBox.Enabled = false;
            this.genGroupBox.Location = new System.Drawing.Point(503, 314);
            this.genGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.genGroupBox.Name = "genGroupBox";
            this.genGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.genGroupBox.Size = new System.Drawing.Size(160, 127);
            this.genGroupBox.TabIndex = 38;
            this.genGroupBox.TabStop = false;
            this.genGroupBox.Text = "Алгоритм генерации";
            // 
            // startFinishGroupBox
            // 
            this.startFinishGroupBox.Controls.Add(this.randomRBtn);
            this.startFinishGroupBox.Controls.Add(this.manuallyRBtn);
            this.startFinishGroupBox.Controls.Add(this.setStartFinishBtn);
            this.startFinishGroupBox.Enabled = false;
            this.startFinishGroupBox.Location = new System.Drawing.Point(503, 199);
            this.startFinishGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.startFinishGroupBox.Name = "startFinishGroupBox";
            this.startFinishGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.startFinishGroupBox.Size = new System.Drawing.Size(160, 111);
            this.startFinishGroupBox.TabIndex = 39;
            this.startFinishGroupBox.TabStop = false;
            this.startFinishGroupBox.Text = "Расставить вход и выход";
            // 
            // parameterGroupBox
            // 
            this.parameterGroupBox.Controls.Add(this.styleComboBox);
            this.parameterGroupBox.Controls.Add(this.label3);
            this.parameterGroupBox.Controls.Add(this.label1);
            this.parameterGroupBox.Controls.Add(this.numUpDownHeight);
            this.parameterGroupBox.Controls.Add(this.label2);
            this.parameterGroupBox.Controls.Add(this.numUpDownWidth);
            this.parameterGroupBox.Controls.Add(this.createModelBtn);
            this.parameterGroupBox.Location = new System.Drawing.Point(503, 11);
            this.parameterGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.parameterGroupBox.Name = "parameterGroupBox";
            this.parameterGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.parameterGroupBox.Size = new System.Drawing.Size(160, 184);
            this.parameterGroupBox.TabIndex = 40;
            this.parameterGroupBox.TabStop = false;
            this.parameterGroupBox.Text = "Параметры лабиринта";
            // 
            // styleComboBox
            // 
            this.styleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Items.AddRange(new object[] {
            "Лето",
            "Осень",
            "Зима",
            "Весна"});
            this.styleComboBox.Location = new System.Drawing.Point(70, 100);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(59, 21);
            this.styleComboBox.TabIndex = 8;
            this.styleComboBox.SelectedIndexChanged += new System.EventHandler(this.styleComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Тема";
            // 
            // saveGroupBox
            // 
            this.saveGroupBox.Controls.Add(this.saveButton);
            this.saveGroupBox.Controls.Add(this.MazeName);
            this.saveGroupBox.Enabled = false;
            this.saveGroupBox.Location = new System.Drawing.Point(503, 446);
            this.saveGroupBox.Name = "saveGroupBox";
            this.saveGroupBox.Size = new System.Drawing.Size(160, 98);
            this.saveGroupBox.TabIndex = 42;
            this.saveGroupBox.TabStop = false;
            this.saveGroupBox.Text = "Сохранение";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(29, 54);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 44;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // MazeName
            // 
            this.MazeName.Location = new System.Drawing.Point(7, 19);
            this.MazeName.Name = "MazeName";
            this.MazeName.Size = new System.Drawing.Size(140, 20);
            this.MazeName.TabIndex = 43;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(11, 516);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(100, 28);
            this.backBtn.TabIndex = 45;
            this.backBtn.Text = "Назад";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(117, 516);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(100, 28);
            this.about.TabIndex = 46;
            this.about.Text = "О системе";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // CreateMaze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 549);
            this.Controls.Add(this.about);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.saveGroupBox);
            this.Controls.Add(this.parameterGroupBox);
            this.Controls.Add(this.startFinishGroupBox);
            this.Controls.Add(this.genGroupBox);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.picMaze);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateMaze";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создать лабиринт";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).EndInit();
            this.genGroupBox.ResumeLayout(false);
            this.genGroupBox.PerformLayout();
            this.startFinishGroupBox.ResumeLayout(false);
            this.startFinishGroupBox.PerformLayout();
            this.parameterGroupBox.ResumeLayout(false);
            this.parameterGroupBox.PerformLayout();
            this.saveGroupBox.ResumeLayout(false);
            this.saveGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button createModelBtn;
        private System.Windows.Forms.NumericUpDown numUpDownHeight;
        private System.Windows.Forms.NumericUpDown numUpDownWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setStartFinishBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.PictureBox picMaze;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.RadioButton randomRBtn;
        private System.Windows.Forms.RadioButton manuallyRBtn;
        private System.Windows.Forms.Timer solveTimer;
        private System.Windows.Forms.RadioButton primRBtn;
        private System.Windows.Forms.RadioButton ellerRBtn;
        private System.Windows.Forms.GroupBox genGroupBox;
        private System.Windows.Forms.GroupBox startFinishGroupBox;
        private System.Windows.Forms.GroupBox parameterGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox saveGroupBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox MazeName;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button about;
    }
}

