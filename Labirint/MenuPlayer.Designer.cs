
namespace Labyrinth
{
    partial class MenuPlayer
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
            this.MazesListBox = new System.Windows.Forms.ListBox();
            this.start = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MazesListBox
            // 
            this.MazesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MazesListBox.FormattingEnabled = true;
            this.MazesListBox.ItemHeight = 18;
            this.MazesListBox.Location = new System.Drawing.Point(12, 12);
            this.MazesListBox.Name = "MazesListBox";
            this.MazesListBox.Size = new System.Drawing.Size(519, 292);
            this.MazesListBox.TabIndex = 0;
            this.MazesListBox.SelectedIndexChanged += new System.EventHandler(this.MazesListBox_SelectedIndexChanged);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(420, 322);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(111, 35);
            this.start.TabIndex = 1;
            this.start.Text = "Начать";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 322);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(111, 35);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "Назад";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(129, 322);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(111, 35);
            this.about.TabIndex = 3;
            this.about.Text = "О системе";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // MenuPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 369);
            this.Controls.Add(this.about);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.start);
            this.Controls.Add(this.MazesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню игрока";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox MazesListBox;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button about;
    }
}