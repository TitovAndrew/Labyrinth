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
    public partial class Authorization : Form
    {
        public static bool isAdmin;

        public Authorization()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            isAdmin = comboBox1.SelectedIndex == 0 ? true : false;             
        }

        private void entry_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAdmin)
                {
                    Form form = new AdminPassword();
                    form.Show();
                    form.BringToFront();
                }
                else if (!(isAdmin))
                {
                    Form form = new MenuPlayer();
                    form.Show();
                    form.BringToFront();
                }
            }
            catch
            {
                DialogResult result = MessageBox.Show(
                                  "Выберите роль!",
                                  "Сообщение",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button1);
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            Form form = new DevInfo();
            form.Show();
            form.BringToFront();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            //сюда html страницу
        }
    }
}
