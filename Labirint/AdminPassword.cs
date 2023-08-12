using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrinth
{
    public partial class AdminPassword : Form
    {
        public AdminPassword()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            if (password.Text == "admin")
            {
                Form form = new CreateMaze();
                form.Show();
                form.BringToFront();
                this.Close();
            } 
            else
            {
                DialogResult result = MessageBox.Show(
                                  "Введите корректный пароль администратора!",
                                  "Сообщение",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button1);
            }
        }
    }
}
