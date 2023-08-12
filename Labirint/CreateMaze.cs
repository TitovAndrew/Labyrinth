using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Labyrinth
{
    public partial class CreateMaze : Form
    {
        public CreateMaze()
        {
            InitializeComponent();
            //styleListBox.Items.AddRange(styles);
            styleComboBox.SelectedIndex = 0;
            //solveGroupBox.Enabled = true;

        }

        private int CellWid = 15, CellHgt = 15, oddW = 1, oddH = 1;
        Maze inMaze = new Maze(10, 10, new Style("Лето"));
        Bitmap inBm = new Bitmap(1, 1);
        Pokemon pokemon;
        Style style = new Style("Лето");

        //private void solveBtn_Click(object sender, EventArgs e)
        //{
        //    pokemon = new Pokemon(inMaze.start.X, inMaze.start.Y);
        //    Bitmap bm = MazeGUI.DrawMaze(inBm, CellWid, CellHgt, inMaze, oddW, oddH); //отображаем 
        //    picMaze.Image = bm;
        //    inBm = bm;

        //    if (waveRBtn.Checked)
        //    {
        //        inMaze.SolveWaveMaze();
        //        picMaze.Image = MazeGUI.DrawWaveSolve(inBm, inMaze, CellWid, CellHgt);
        //    }
        //    else if(handRBtn.Checked & staticRBrn.Checked)
        //    {
        //        inMaze.SolveRightHandMaze();
        //        picMaze.Image = MazeGUI.DrawSolve(inBm, inMaze, CellWid, CellHgt);
        //    }
        //    else if(handRBtn.Checked & dynamicRBtn.Checked)
        //    {
        //        solveBtn.Enabled = false;
        //        inMaze.SolveRightHandMaze();
        //        solveTimer.Enabled = true;
        //    }
        //    else if (manuallyRBtn.Checked)
        //    {

        //    }

        //    //solveGroupBox.Enabled = false;

        //}


        private void picMaze_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null & manuallyRBtn.Checked)
            {
                int x = mouseEventArgs.X, y = mouseEventArgs.Y;
                ConvertCoordinates(picMaze,out  x, out y, x, y);


                List<Cell> PossibleStartFinish = inMaze.getBorderCells();
                Cell click = new Cell(x / CellWid, y / CellHgt);

                //Находится ли клетка в углу
                if (inMaze.CheckCorner(click))
                {
                    DialogResult result = MessageBox.Show(
                                  "Вход или выход нельзя расположить в углу",
                                  "Сообщение",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button1);
                }
                // Подходящая клетка для входа
                else if (inMaze.start.X == 0 & inMaze.start.Y == 0 & !inMaze._cells[click.X, click.Y]._isCell)
                {

                    DialogResult result = MessageBox.Show(
                                  "Установить вход?",
                                  "Сообщение",
                                   MessageBoxButtons.YesNo
                                   //MessageBoxIcon.Information,
                                   //MessageBoxDefaultButton.Button1
                                   );

                    if (result == DialogResult.Yes)
                    {
                        inMaze.start.X = click.X;
                        inMaze.start.Y = click.Y;

                    }
                }

                // Подходящая клетка для выхода
                else if (inMaze.finish.X == 0 & inMaze.finish.Y == 0 & !inMaze._cells[click.X, click.Y]._isCell 
                    & !inMaze.start.Equals(click))
                {
                    DialogResult result = MessageBox.Show(
                                  "Установить выход?",
                                  "Сообщение",
                                   MessageBoxButtons.YesNo
                                   //MessageBoxIcon.Information,
                                   //MessageBoxDefaultButton.Button1
                                   );

                    if (result == DialogResult.Yes)
                    {
                        inMaze.finish.X = click.X;
                        inMaze.finish.Y = click.Y;
                    }

                }
                // Если вход совпал с выходом
                else if (inMaze.start.Equals(click))
                {
                    DialogResult result = MessageBox.Show(
                                  "Вход не может совпадать с выходом",
                                  "Сообщение",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button1);
                }
                // Если клетка не на границе лабиринта
                else
                {
                    DialogResult result = MessageBox.Show(
                                  "Выберите корректную клетку",
                                  "Сообщение",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button1);

                    this.TopMost = true;
                }

                Bitmap bm = MazeGUI.DrawMaze(inBm, CellWid, CellHgt, inMaze, oddW, oddH); //отображаем 
                picMaze.Image = bm;
                inBm = bm;
            }

            else if (!manuallyRBtn.Checked)
            {
                inMaze.start.X = 0;
                inMaze.start.Y = 0;

                inMaze.finish.X = 0;
                inMaze.finish.Y = 0;

                Bitmap bm = MazeGUI.DrawMaze(inBm, CellWid, CellHgt, inMaze, oddW, oddH); //отображаем 
                picMaze.Image = bm;
                inBm = bm;
            }

        }

        private void createModelBtn_Click(object sender, EventArgs e)
        {
            int wid = 0;
            int hgt = 0;


            //Добавим проверку на корректность введенных размеров
            try
            {
                wid = (int)numUpDownWidth.Value;
                hgt = (int)numUpDownHeight.Value;

                if (wid == 0 || hgt == 0)
                {
                    throw new FormatException();
                }

            }
            catch (System.FormatException)
            {
                string message = "Размерность должна быть числом, больше 0.";
                string caption = "Ошибка ввода размерности";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                numUpDownHeight.Value = 10;
                numUpDownWidth.Value = 10;

                return;
            }


            oddW = 0;
            oddH = 0;

            //Обрабатываем случай с нечетными размерами
            if (wid % 2 != 0 && wid != 0)
            {
                oddW = 1;
            }
            if (hgt % 2 != 0 && hgt != 0)
            {
                oddH = 1;
            }

            //вычисляем ширину одной ячейки, чтобы автомасштабировать полученную картинку


            CellWid = picMaze.ClientSize.Width / (wid + 2);
            CellHgt = picMaze.ClientSize.Height / (hgt + 2);

            //Установим минимальный размер ячейки
            int CellMin = 10;
            if (CellWid < CellMin)
            {
                CellWid = CellMin;
                CellHgt = CellWid;
            }
            else if (CellHgt < CellMin)
            {
                CellHgt = CellMin;
                CellWid = CellHgt;
            }
            else if (CellWid > CellHgt) CellWid = CellHgt;
            else CellHgt = CellWid;


            Maze maze = new Maze(wid, hgt, style);


            Bitmap bm = MazeGUI.DrawMaze(inBm, CellWid, CellHgt, maze, oddW, oddH); //отображаем 
            picMaze.Image = bm;
            inBm = bm;

            inMaze = maze;

            startFinishGroupBox.Enabled = true;
            parameterGroupBox.Enabled = false;
        }

        private void randomRBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                // Получаем массив возможных клеток входа и выхода
                Random rnd = new Random();
                List<Cell> PossibleStartFinish = inMaze.getBorderCells();
                int r = rnd.Next(PossibleStartFinish.Count - 1);
                Cell start = PossibleStartFinish[r];
                PossibleStartFinish.Remove(start);

                r = rnd.Next(PossibleStartFinish.Count);
                Cell finish = PossibleStartFinish[r];

                inMaze.start.X = start.X;
                inMaze.start.Y = start.Y;
                inMaze.start._isVisited = true;

                inMaze.finish.X = finish.X;
                inMaze.finish.Y = finish.Y;
                inMaze.finish._isVisited = true;

                Bitmap bm = MazeGUI.DrawMaze(inBm, CellWid, CellHgt, inMaze, oddW, oddH); //отображаем 
                picMaze.Image = bm;
                inBm = bm;
            }
            else
            {
                inMaze.start.X = 0;
                inMaze.start.Y = 0;

                inMaze.finish.X = 0;
                inMaze.finish.Y = 0;

                Bitmap bm = MazeGUI.DrawMaze(inBm, CellWid, CellHgt, inMaze, oddW, oddH); //отображаем 
                picMaze.Image = bm;
                inBm = bm;
            }
        }

        private void manuallyRBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.W & manualSolveRBtn.Checked) // вверх
        //    {
        //        picMaze.Image = MazeGUI.DrawStep(inBm, inMaze, CellWid, CellHgt, pokemon, 0, -1);
        //        //return true;
        //    }
        //    else if (keyData == Keys.S & manualSolveRBtn.Checked) //вниз
        //    {
        //        picMaze.Image = MazeGUI.DrawStep(inBm, inMaze, CellWid, CellHgt, pokemon, 0, 1);
        //        //return true;
        //    }
        //    else if (keyData == Keys.A & manualSolveRBtn.Checked) //влево
        //    {
        //        picMaze.Image = MazeGUI.DrawStep(inBm, inMaze, CellWid, CellHgt, pokemon, -1, 0);
        //        //return true;
        //    }
        //    else if (keyData == Keys.D & manualSolveRBtn.Checked) //вправо
        //    {
        //        picMaze.Image = MazeGUI.DrawStep(inBm, inMaze, CellWid, CellHgt, pokemon, 1, 0);
        //        //return true;
        //    }
            
        //    // Проверяем нашел ли пользователь выход
        //    if (manualSolveRBtn.Checked && pokemon.X == inMaze.finish.X && pokemon.Y == inMaze.finish.Y )
        //    {
        //        DialogResult result = MessageBox.Show(
        //                          "Вы нашли выход!\nНачать заново?",
        //                          "Сообщение",
        //                           MessageBoxButtons.YesNo,
        //                           MessageBoxIcon.Information,
        //                           MessageBoxDefaultButton.Button1);

        //        if (result == DialogResult.Yes)
        //        {
        //            Start();

        //        }
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        //private void solveTimer_Tick(object sender, EventArgs e)
        //{
        //    pokemon.X = inMaze._visited[0].X;
        //    pokemon.Y = inMaze._visited[0].Y;

        //    // Отрисовываем посещенные клетки
        //    if (inMaze._visited.Count != 1)/*|| (pokemon.X == inMaze.finish.X & pokemon.Y == inMaze.finish.Y))*/
        //    {
        //        picMaze.Image = MazeGUI.DrawDynamicHand(inBm, inMaze, CellWid, CellHgt, pokemon, 0, 0);
        //        inMaze._visited.RemoveAt(0);
        //    }
        //    else
        //    {
        //        solveTimer.Enabled = false;
        //        solveBtn.Enabled = true;
        //    }


        //}

        //private void speedBar_Scroll(object sender, EventArgs e)
        //{
        //    // Менияем скорость визуализаци
        //    solveTimer.Interval = 1000 / speedBar.Value;
        //}


        //private void styleListBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string selectedStyle = styleListBox.SelectedItem.ToString();
        //    style = new Style(selectedStyle);
        //}

        private void programInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = "Resources\\Site\\справка.html";
            Process.Start(Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), @"..\Resources\Site\Site\справка.html"));
        }

        private void devInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //devInfoForm devForm = new devInfoForm();
            //devForm.Show();
        }

        //private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    // Сохранить объект в локальном файле.

        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();

        //    string CombinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Resources\Saved mazes");

        //    openFileDialog1.InitialDirectory = System.IO.Path.GetFullPath(CombinedPath);
        //    openFileDialog1.Filter = "Access files (*.lab)|*.lab|Old Access files (*.lab)|*.lab";
        //    openFileDialog1.FilterIndex = 2;
        //    openFileDialog1.RestoreDirectory = true;
        //    openFileDialog1.CheckFileExists = true;

        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        var path = openFileDialog1.FileName;
        //        BinaryFormatter binFormat = new BinaryFormatter();

        //        try
        //        {
        //            if (CheckFileName(path))
        //            {
        //                using (Stream fStream = File.OpenRead(path))
        //                {
        //                    inMaze = (Maze)binFormat.Deserialize(fStream);

        //                }
        //            }
        //            else
        //            {
        //                DialogResult result = MessageBox.Show(
        //                              "Расширение некорректно!",
        //                              "Сообщение",
        //                               MessageBoxButtons.OK,
        //                               MessageBoxIcon.Error,
        //                               MessageBoxDefaultButton.Button1);
        //            }

        //            CellWid = picMaze.ClientSize.Width / (inMaze._width+ 2);
        //            CellHgt = picMaze.ClientSize.Height / (inMaze._height + 2);

        //            //Установим минимальный размер ячейки
        //            int CellMin = 10;
        //            if (CellWid < CellMin)
        //            {
        //                CellWid = CellMin;
        //                CellHgt = CellWid;
        //            }
        //            else if (CellHgt < CellMin)
        //            {
        //                CellHgt = CellMin;
        //                CellWid = CellHgt;
        //            }
        //            else if (CellWid > CellHgt) CellWid = CellHgt;
        //            else CellHgt = CellWid;

        //            Bitmap bm = MazeGUI.DrawMaze(inBm, CellWid, CellHgt, inMaze, oddW, oddH); //отображаем 
        //            picMaze.Image = bm;
        //            inBm = bm;

        //            genGroupBox.Enabled = true;
        //            nextBtn.Enabled = true;
        //            solveGroupBox.Enabled = true;
        //            parameterGroupBox.Enabled = false;
        //        }
        //        catch (FileNotFoundException)
        //        {
        //            DialogResult result = MessageBox.Show(
        //                              "Такого файла е существует",
        //                              "Сообщение",
        //                               MessageBoxButtons.OK,
        //                               MessageBoxIcon.Error,
        //                               MessageBoxDefaultButton.Button1);
        //        }
        //        catch (SerializationException)
        //        {
        //            DialogResult result = MessageBox.Show(
        //                              "Файл поврежден",
        //                              "Сообщение",
        //                               MessageBoxButtons.OK,
        //                               MessageBoxIcon.Error,
        //                               MessageBoxDefaultButton.Button1);
        //        }
                
                

        //    }

        //}

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BinaryFormatter binFormat = new BinaryFormatter();
            // Сохранить объект в локальном файле.

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            string CombinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Resources\Saved mazes");

            openFileDialog1.InitialDirectory = System.IO.Path.GetFullPath(CombinedPath);
            openFileDialog1.Filter = "Access files (*.lab)|*.accdb|Old Access files (*.lab)|*.lab";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.CheckFileExists = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                if (CheckFileName(path))
                {
                    using (Stream fStream = new FileStream(path,
                   FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        binFormat.Serialize(fStream, inMaze);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                                  "Расширение некорректно",
                                  "Сообщение",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button1);
                }
                this.Show();
            }

            
        }

    
        private void setStartFinishBtn_Click(object sender, EventArgs e)
        {

            if(manuallyRBtn.Checked || randomRBtn.Checked )
            {
                genGroupBox.Enabled = true;
                startFinishGroupBox.Enabled = false;
            }


        }

        //private void startBtn_Click(object sender, EventArgs e)
        //{
        //    Start();
        //}

        private void infoBtn_Click(object sender, EventArgs e)
        {
            string info = "Resources\\Site\\справка.html";
            Process.Start(Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), @"..\Resources\Site\Site\справка.html"));
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool flag = true;
            try
            {                
                string writePath = Environment.CurrentDirectory + "\\Mazes\\" + MazeName.Text + ".lab";
                if (File.Exists(writePath))
                {
                    MessageBox.Show("Файл с таким названием уже существует", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }
                if (flag)
                {
                    BinaryFormatter binFormat = new BinaryFormatter();
                    using (Stream fStream = new FileStream(writePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        binFormat.Serialize(fStream, inMaze);
                    }
                    MessageBox.Show("Сохранение произведено успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch 
            {
                MessageBox.Show("Введите корректное имя файла", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void styleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStyle = styleComboBox.SelectedItem.ToString();
            style = new Style(selectedStyle);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void about_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Environment.CurrentDirectory + "\\userguide\\admin.html");
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку. Файл справки поврежден или не найден.");
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {

       
            Maze maze = new Maze(inMaze._width, inMaze._height, inMaze.start.X, inMaze.start.Y, inMaze.finish.X, inMaze.finish.Y, style);

            maze.CreateEllerMaze();

            Bitmap bm = MazeGUI.DrawMaze(inBm, CellWid, CellHgt, maze, oddW, oddH); //отображаем 
            picMaze.Image = bm;
            inBm = bm;

            inMaze = maze;

            //nextBtn.Enabled = true;
            saveGroupBox.Enabled = true;
          
        }


        //private void nextBtn_Click(object sender, EventArgs e)
        //{
        //    solveGroupBox.Enabled = true;
        //    pathAlgGroupBox.Enabled = true;
        //    visualizationGroupBox.Enabled = true;
        //    genGroupBox.Enabled = false;
        //}

        /*
         * Метод для начала новой итерации игры
         */
        //private void Start()
        //{
        //    genGroupBox.Enabled = true;
        //    pathAlgGroupBox.Enabled = false;
        //    visualizationGroupBox.Enabled = false;
        //    genGroupBox.Enabled = false;
        //    parameterGroupBox.Enabled = true;

        //    picMaze.Image = null;

        //    nextBtn.Enabled = false;
        //}

        /*
         * Перевод координат в зависимости от SizeMode изображения
         */
        private void ConvertCoordinates(PictureBox pic,
            out int X0, out int Y0, int x, int y)
        {
            int pic_hgt = pic.ClientSize.Height;
            int pic_wid = pic.ClientSize.Width;
            int img_hgt = pic.Image.Height;
            int img_wid = pic.Image.Width;

            X0 = x;
            Y0 = y;
            switch (pic.SizeMode)
            {
                case PictureBoxSizeMode.AutoSize:
                case PictureBoxSizeMode.Normal:
                    // These are okay. Leave them alone.
                    break;
                case PictureBoxSizeMode.CenterImage:
                    X0 = x - (pic_wid - img_wid) / 2;
                    Y0 = y - (pic_hgt - img_hgt) / 2;
                    break;
                case PictureBoxSizeMode.StretchImage:
                    X0 = (int)(img_wid * x / (float)pic_wid);
                    Y0 = (int)(img_hgt * y / (float)pic_hgt);
                    break;
                case PictureBoxSizeMode.Zoom:
                    float pic_aspect = pic_wid / (float)pic_hgt;
                    float img_aspect = img_wid / (float)img_hgt;
                    if (pic_aspect > img_aspect)
                    {
                        // The PictureBox is wider/shorter than the image.
                        Y0 = (int)(img_hgt * y / (float)pic_hgt);

                        // The image fills the height of the PictureBox.
                        // Get its width.
                        float scaled_width = img_wid * pic_hgt / img_hgt;
                        float dx = (pic_wid - scaled_width) / 2;
                        X0 = (int)((x - dx) * img_hgt / (float)pic_hgt);
                    }
                    else
                    {
                        // The PictureBox is taller/thinner than the image.
                        X0 = (int)(img_wid * x / (float)pic_wid);

                        // The image fills the height of the PictureBox.
                        // Get its height.
                        float scaled_height = img_hgt * pic_wid / img_wid;
                        float dy = (pic_hgt - scaled_height) / 2;
                        Y0 = (int)((y - dy) * img_wid / pic_wid);
                    }
                    break;
            }
        }


        /*
         * Метод для проверки расширения файлов
         */ 
        private bool CheckFileName(string fileName)
        {
            string ext = fileName.Substring(fileName.LastIndexOf('.'));
            return ".lab" == ext;
        }

    }




}