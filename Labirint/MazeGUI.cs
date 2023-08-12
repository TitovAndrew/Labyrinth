using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    /*
     * Класс для отрисовки лабиринта
     */
    class MazeGUI
    {
        /*
         * Отриовка лабиринта
         */
        public static Bitmap DrawMaze(Bitmap inBm,int CellWid, int CellHgt, Maze maze, int oddW, int oddH )
        {
            inBm.Dispose();
            //создаем битмап так, чтобы захватить и финиш и стенку за ним
            Bitmap bm = new Bitmap(
                CellWid * (maze._width),
                CellHgt * (maze._height), System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

            Brush whiteBrush = new SolidBrush(Color.White);
            Brush blackBrush = new SolidBrush(maze.style.wallColor);

            using (Graphics gr = Graphics.FromImage(bm))
            {

                gr.SmoothingMode = SmoothingMode.AntiAlias;
                for (var i = 0; i < maze._cells.GetUpperBound(0) + oddW; i++)
                    for (var j = 0; j < maze._cells.GetUpperBound(1) + oddH; j++)
                    {
                        Point point = new Point(i * CellWid, j * CellWid);
                        Size size = new Size(CellWid, CellWid);
                        Rectangle rec = new Rectangle(point, size);
                        if (maze._cells[i, j]._isCell)
                        {
                            gr.FillRectangle(whiteBrush, rec);
                        }
                        else
                        {

                            gr.FillRectangle(blackBrush, rec);
                        }
                    }

                if(maze.start.X != 0 || maze.start.Y != 0)
                {
                    gr.FillRectangle(new SolidBrush(Color.Green),    //заливаем старт зеленым
                    new Rectangle(new Point(maze.start.X * CellWid, maze.start.Y * CellWid),
                    new Size(CellWid, CellWid)));

                    //Bitmap Head = (Bitmap)Bitmap.FromFile(maze.style.pokemonImg);
                    //gr.DrawImage(Head, new RectangleF(new Point(maze.start.X * CellWid, maze.start.Y * CellWid), new SizeF(CellWid, CellHgt)));
                }

                if(maze.finish.X != 0 || maze.finish.Y != 0)
                {
                    gr.FillRectangle(new SolidBrush(Color.Red),       //заливаем финиш красным
                    new Rectangle(new Point(maze.finish.X * CellWid, maze.finish.Y * CellWid),
                    new Size(CellWid, CellWid)));
                }
            }

            //picMaze.Image = bm; //отображаем 
            //inBm = bm;

            return bm;

        }


        /*
         * Отрисовка пути для агоритма правой руки (статическая)
         */
        public static Bitmap DrawSolve(Bitmap inBm, Maze inMaze, int CellWid, int CellHgt)
        {

            Brush blueBrush = new SolidBrush(Color.Blue);
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush pinkBrush = new SolidBrush(Color.Pink);
            using (Graphics gr = Graphics.FromImage(inBm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                foreach (Cell c in inMaze._visited)
                {
                    Point point = new Point(c.X * CellWid, c.Y * CellWid);
                    Size size = new Size(CellWid, CellWid);
                    Rectangle rec = new Rectangle(point, size);
                    gr.FillRectangle(pinkBrush, rec);
                }

                foreach (Cell c in inMaze._solve)
                {
                    Point point = new Point(c.X * CellWid, c.Y * CellWid);
                    Size size = new Size(CellWid, CellWid);

                    Bitmap tail = (Bitmap)Bitmap.FromFile(inMaze.style.pathImg);
                    gr.DrawImage(tail, new RectangleF(point, size));
                }

                gr.FillRectangle(new SolidBrush(Color.Green),    //заливаем старт зеленым
                   new Rectangle(new Point(inMaze.start.X * CellWid, inMaze.start.Y * CellWid),
                   new Size(CellWid, CellWid)));
                gr.FillRectangle(new SolidBrush(Color.Red),       //а финиш красным
                    new Rectangle(new Point(inMaze.finish.X * CellWid, inMaze.finish.Y * CellWid),
                    new Size(CellWid, CellWid)));
            }

            return inBm; //отображаем картинку
        }

        /*
         * Отрисовка пути для волнового алгоритма
         */
        public static Bitmap DrawWaveSolve(Bitmap inBm, Maze inMaze, int CellWid, int CellHgt)
        {


            Brush blueBrush = new SolidBrush(Color.Blue);
            Brush pinkBrush = new SolidBrush(Color.Pink);
            using (Graphics gr = Graphics.FromImage(inBm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                foreach (Cell c in inMaze._visited)
                {
                    Point point = new Point(c.X * CellWid, c.Y * CellWid);
                    Size size = new Size(CellWid, CellWid);
                    Rectangle rec = new Rectangle(point, size);
                    gr.FillRectangle(pinkBrush, rec);
                }

                foreach (Cell c in inMaze._solve)
                {
                    Point point = new Point(c.X * CellWid, c.Y * CellWid);
                    Size size = new Size(CellWid, CellWid);

                    Bitmap tail = (Bitmap)Bitmap.FromFile(inMaze.style.pathImg);
                    gr.DrawImage(tail, new RectangleF(point,size));
                }

                gr.FillRectangle(new SolidBrush(Color.Green),    //заливаем старт зеленым
                   new Rectangle(new Point(inMaze.start.X * CellWid, inMaze.start.Y * CellWid),
                   new Size(CellWid, CellWid)));
                gr.FillRectangle(new SolidBrush(Color.Red),       //а финиш красным
                    new Rectangle(new Point(inMaze.finish.X * CellWid, inMaze.finish.Y * CellWid),
                    new Size(CellWid, CellWid)));
            }

            return inBm; //отображаем картинку
        }

        /*
         * Отрисовка шага для ручного прохождения
         */
        public static Bitmap DrawStep(Bitmap inBm, Maze inMaze, int CellWid, int CellHgt, Pokemon p, int x, int y)
        {


            Brush blueBrush = new SolidBrush(Color.Blue);
            Brush pinkBrush = new SolidBrush(Color.Pink);
            Brush whiteBrush = new SolidBrush(Color.White);
            using (Graphics gr = Graphics.FromImage(inBm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                if (inMaze._cells[p.X + x, p.Y + y]._isCell || inMaze._cells[p.X + x, p.Y + y].Equals(inMaze.finish))
                {
                    Point point = new Point(p.X * CellWid, p.Y * CellWid);
                    Size size = new Size(CellWid, CellWid);
                    Rectangle rec = new Rectangle(point, size);
                    gr.FillRectangle(whiteBrush, rec);

                    Bitmap tail = (Bitmap)Bitmap.FromFile(inMaze.style.pathImg);
                    gr.DrawImage(tail, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid, CellHgt)));

                    p.X += x;
                    p.Y += y;

                    Bitmap Head = (Bitmap)Bitmap.FromFile(inMaze.style.pokemonImg);
                    gr.DrawImage(Head, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid, CellHgt)));

                }

                gr.FillRectangle(new SolidBrush(Color.Green),    //заливаем старт зеленым
                   new Rectangle(new Point(inMaze.start.X * CellWid, inMaze.start.Y * CellWid),
                   new Size(CellWid, CellWid)));
                //gr.FillRectangle(new SolidBrush(Color.Red),       //а финиш красным
                //    new Rectangle(new Point(inMaze.finish.X * CellWid, inMaze.finish.Y * CellWid),
                //    new Size(CellWid, CellWid)));
            }

            return inBm; //отображаем картинку
        }


        /*
         * Отрисовка пути для агоритма правой руки (динамическая)
         */
        public static Bitmap DrawDynamicHand(Bitmap inBm, Maze inMaze, int CellWid, int CellHgt, Pokemon p, int i, int j)
        {


            Brush blueBrush = new SolidBrush(Color.Blue);
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush pinkBrush = new SolidBrush(Color.Pink);
            using (Graphics gr = Graphics.FromImage(inBm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                //foreach (Cell c in inMaze._visited)
                //{
                p.X = inMaze._visited[i].X;
                p.Y = inMaze._visited[i].Y;
                Point point = new Point(p.X * CellWid, p.Y * CellWid);
                Size size = new Size(CellWid, CellWid);


                Rectangle rec = new Rectangle(point, size);
                //gr.FillRectangle(pinkBrush, rec);

                //if (inMaze._solve.Contains(inMaze._visited[i]))
                //{
                //    Bitmap tail = (Bitmap)Bitmap.FromFile(inMaze.style.pathImg);
                //    gr.DrawImage(tail, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid, CellHgt)));
                //}
                Bitmap tail = (Bitmap)Bitmap.FromFile(inMaze.style.pathImg);
                gr.DrawImage(tail, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid, CellHgt)));

                if ((inMaze._cells[inMaze._visited[i].X, inMaze._visited[i].Y]._paintItRed == true) && 
                    !inMaze._solve.Contains(inMaze._visited[i]) && 
                    inMaze.GetNotRedNeighbours(inMaze._visited[i]) == 0)//!inMaze._solve.Contains(inMaze._visited[i]))
                {
                    gr.FillRectangle(pinkBrush, rec);
                }
                if (!inMaze._solve.Contains(inMaze._visited[i])) 
                {
                    inMaze._cells[p.X, p.Y]._paintItRed = true;
                }
                //point = new Point(inMaze._visited[i].X * CellWid, inMaze._visited[i].Y * CellWid);
                //size = new Size(CellWid, CellWid);
                //Rectangle rec1 = new Rectangle(point, size);
                //gr.FillRectangle(pinkBrush, rec1);

                p.X = inMaze._visited[i+1].X;
                p.Y = inMaze._visited[i+1].Y;
                
                

                Bitmap Head = (Bitmap)Bitmap.FromFile(inMaze.style.pokemonImg);
                gr.DrawImage(Head, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid,CellHgt)));

                //}
                
                //foreach (Cell c in inMaze._solve)
                //{
                //    Point point = new Point(c.X * CellWid, c.Y * CellWid);
                //    Size size = new Size(CellWid, CellWid);
                //    Rectangle rec = new Rectangle(point, size);
                //    gr.FillRectangle(blueBrush, rec);
                //}

                gr.FillRectangle(new SolidBrush(Color.Green),    //заливаем старт зеленым
                   new Rectangle(new Point(inMaze.start.X * CellWid, inMaze.start.Y * CellWid),
                   new Size(CellWid, CellWid)));
                gr.FillRectangle(new SolidBrush(Color.Red),       //а финиш красным
                    new Rectangle(new Point(inMaze.finish.X * CellWid, inMaze.finish.Y * CellWid),
                    new Size(CellWid, CellWid)));
            }

            return inBm; //отображаем картинку
        }
        public static Bitmap DrawDynamicVisitedWave(Bitmap inBm, Maze inMaze, int CellWid, int CellHgt, Pokemon p, int i, int j)
        {


            Brush blueBrush = new SolidBrush(Color.Blue);
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush pinkBrush = new SolidBrush(Color.Pink);
            using (Graphics gr = Graphics.FromImage(inBm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                //foreach (Cell c in inMaze._visited)
                //{
                p.X = inMaze._visited[i].X;
                p.Y = inMaze._visited[i].Y;
                Point point = new Point(p.X * CellWid, p.Y * CellWid);
                Size size = new Size(CellWid, CellWid);


                Rectangle rec = new Rectangle(point, size);
                //gr.FillRectangle(pinkBrush, rec);

                //if (inMaze._solve.Contains(inMaze._visited[i]))
                //{
                //    Bitmap tail = (Bitmap)Bitmap.FromFile(inMaze.style.pathImg);
                //    gr.DrawImage(tail, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid, CellHgt)));
                //}
                //Bitmap tail = (Bitmap)Bitmap.FromFile(inMaze.style.pathImg);
                //gr.DrawImage(tail, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid, CellHgt)));

                //if (!inMaze._solve.Contains(inMaze._visited[i]))
                //{
                    gr.FillRectangle(pinkBrush, rec);
                //}

                //point = new Point(inMaze._visited[i].X * CellWid, inMaze._visited[i].Y * CellWid);
                //size = new Size(CellWid, CellWid);
                //Rectangle rec1 = new Rectangle(point, size);
                //gr.FillRectangle(pinkBrush, rec1);
                if (inMaze._visited.Count > 1)
                {
                    p.X = inMaze._visited[i + 1].X;
                    p.Y = inMaze._visited[i + 1].Y;

                    Bitmap Head = (Bitmap)Bitmap.FromFile(inMaze.style.pokemonImg);
                    gr.DrawImage(Head, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid, CellHgt)));
                }
                //if (inMaze._visited.Count == 2)
                //{
                //    Point point2 = new Point(p.X * CellWid, p.Y * CellWid);
                //    Size size2 = new Size(CellWid, CellWid);
                //    Rectangle rec2 = new Rectangle(point2, size2);
                //    gr.FillRectangle(pinkBrush, rec2);
                //}
                

                //}

                //foreach (Cell c in inMaze._solve)
                //{
                //    Point point = new Point(c.X * CellWid, c.Y * CellWid);
                //    Size size = new Size(CellWid, CellWid);
                //    Rectangle rec = new Rectangle(point, size);
                //    gr.FillRectangle(blueBrush, rec);
                //}

                gr.FillRectangle(new SolidBrush(Color.Green),    //заливаем старт зеленым
                   new Rectangle(new Point(inMaze.start.X * CellWid, inMaze.start.Y * CellWid),
                   new Size(CellWid, CellWid)));
                gr.FillRectangle(new SolidBrush(Color.Red),       //а финиш красным
                    new Rectangle(new Point(inMaze.finish.X * CellWid, inMaze.finish.Y * CellWid),
                    new Size(CellWid, CellWid)));
            }

            return inBm; //отображаем картинку
        }
        public static Bitmap DrawDynamicSolvedWave(Bitmap inBm, Maze inMaze, int CellWid, int CellHgt, Pokemon p, int i, int j)
        {


            Brush blueBrush = new SolidBrush(Color.Blue);
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush pinkBrush = new SolidBrush(Color.Pink);
            using (Graphics gr = Graphics.FromImage(inBm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                //foreach (Cell c in inMaze._visited)
                //{
                p.X = inMaze._solve[i].X;
                p.Y = inMaze._solve[i].Y;
                Point point = new Point(p.X * CellWid, p.Y * CellWid);
                Size size = new Size(CellWid, CellWid);


                Rectangle rec = new Rectangle(point, size);
                //gr.FillRectangle(pinkBrush, rec);

                //if (inMaze._solve.Contains(inMaze._visited[i]))
                //{
                //    Bitmap tail = (Bitmap)Bitmap.FromFile(inMaze.style.pathImg);
                //    gr.DrawImage(tail, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid, CellHgt)));
                //}
                Bitmap tail = (Bitmap)Bitmap.FromFile(inMaze.style.pathImg);
                gr.DrawImage(tail, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid, CellHgt)));

                //if (!inMaze._solve.Contains(inMaze._visited[i]))
                //{
                //    gr.FillRectangle(pinkBrush, rec);
                //}

                //point = new Point(inMaze._visited[i].X * CellWid, inMaze._visited[i].Y * CellWid);
                //size = new Size(CellWid, CellWid);
                //Rectangle rec1 = new Rectangle(point, size);
                //gr.FillRectangle(pinkBrush, rec1);

                p.X = inMaze._solve[i + 1].X;
                p.Y = inMaze._solve[i + 1].Y;

                Bitmap Head = (Bitmap)Bitmap.FromFile(inMaze.style.pokemonImg);
                gr.DrawImage(Head, new RectangleF(new Point(p.X * CellWid, p.Y * CellWid), new SizeF(CellWid, CellHgt)));

                //}

                //foreach (Cell c in inMaze._solve)
                //{
                //    Point point = new Point(c.X * CellWid, c.Y * CellWid);
                //    Size size = new Size(CellWid, CellWid);
                //    Rectangle rec = new Rectangle(point, size);
                //    gr.FillRectangle(blueBrush, rec);
                //}

                gr.FillRectangle(new SolidBrush(Color.Green),    //заливаем старт зеленым
                   new Rectangle(new Point(inMaze.start.X * CellWid, inMaze.start.Y * CellWid),
                   new Size(CellWid, CellWid)));
                gr.FillRectangle(new SolidBrush(Color.Red),       //а финиш красным
                    new Rectangle(new Point(inMaze.finish.X * CellWid, inMaze.finish.Y * CellWid),
                    new Size(CellWid, CellWid)));
            }

            return inBm; //отображаем картинку
        }
    }
}
