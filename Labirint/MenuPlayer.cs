using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrinth
{
    public partial class MenuPlayer : Form
    {
        public MenuPlayer()
        {
            InitializeComponent();
            start.Enabled = false;
            //this.login_name = log;
            if (!Directory.Exists(Environment.CurrentDirectory + "\\Mazes"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Mazes");

            try
            {
                ShowAllFiles(Environment.CurrentDirectory + "\\Mazes", "*.lab", MazesListBox);
                //ShowAllFiles(Environment.CurrentDirectory, "*.cros", NewCross_ListBox);
            }
            catch
            {
                MessageBox.Show("Системные файлы повреждены.");
                //this.Close();
                //Application.Restart();
            }
        }

        private void ShowAllFiles(string rootDirectory, string fileExtension, ListBox files)
        {
            string test = null;
            string[] f = Directory.GetFiles(rootDirectory, fileExtension); // массив путей до файлов lab
            for (int i = 0; i < f.Length; i++)
            {
                //разбиваем наш путь на части
                string[] path = f[i].Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < path.Length; j++)
                {
                    test += path[j] + "\n";
                    if (path[j].Contains("lab"))// выбираем тот кусок раздробленного пути, где содержится lab
                    {
                        string[] result = { path[j].Split('.')[0] };//удаляем все после точки у файла и выводим лишь название
                        files.Items.AddRange(result);
                    }                    
                }
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            foreach (var item in MazesListBox.SelectedItems)
            {
                string[] file_name = ((string)item).Split('\n');
                Console.WriteLine(file_name[0]);
                string[] f = Directory.GetFiles(Environment.CurrentDirectory + "\\Mazes", file_name[0] + ".lab");
                Console.WriteLine(f[0]);
                //if (file_name[1].Contains("Завершен"))
                //{
                //    DialogResult result = MessageBox.Show(
                //         "Вы полностью разгадали данный кроссворд.\nНачать разгадывать заново?",
                //         "Сообщение",
                //         MessageBoxButtons.YesNo,
                //         MessageBoxIcon.Information,
                //         MessageBoxDefaultButton.Button1);
                //    if (result == DialogResult.Yes)
                //    {
                //        try
                //        {
                //            string[] fn = f[0].Split('\\');
                //            string file_cross = fn[fn.Length - 1];
                //            System.IO.File.Delete(Environment.CurrentDirectory + "\\" + login_name + "\\" + file_cross);
                //        }
                //        catch { return; }
                //    }
                //    else
                //    {
                //        open_next = false;
                //        return;
                //    }
                //}
                try
                {
                    Form solving = new PlayMaze(f[0]);
                    solving.Show();
                    solving.BringToFront();
                    //this.Close();
                }
                catch
                {
                    MessageBox.Show("Файл лабиринта поврежден.");                    
                }
            }
            //Form form = new PlayMaze();
            //form.Show();
            //form.BringToFront();
        }

        private void MazesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            start.Enabled = true;
        }

        private void about_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\userguide\\user.html");
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку. Файл справки поврежден или не найден.");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
