using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    /*
     * Класс лабиринта
     */

    [Serializable]
    public class Maze
    {
        public readonly Cell[,] _cells;
        public int _width;
        public int _height;
        public Stack<Cell> _path = new Stack<Cell>();
        public List<Cell> _solve = new List<Cell>();
        public List<Cell> _visited = new List<Cell>();
        public List<Cell> _neighbours = new List<Cell>();
        public Random rnd = new Random();
        public Cell start;
        public Cell finish;
        public Style style;

        /*
         * Конструктор для создания шаблона без входа и выхода
         */
        public Maze(int width, int height, Style style)
        {

            this.style = style;

            _width = width;
            _height = height;
            _cells = new Cell[width, height];
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    // Все клетки на границах -- стены
                    if ((i != 0 && j != 0) && (i < _width - 1 && j < _height - 1))
                    {
                        _cells[i, j] = new Cell(i, j); //то это клетка (по умолчанию)
                    }
                    else
                    {

                        _cells[i, j] = new Cell(i, j, false, false);
                    }
            _path.Push(start);
            _cells[start.X, start.Y] = start;
        }

        /*
         * Конструктор для создания шаблона со входом и выходом
         */
        public Maze(int width, int height, int sx, int sy, int fx, int fy, Style style)
        {
            start = new Cell(sx, sy, true, true);
            finish = new Cell(fx, fy, true, true);
            this.style = style;
            //finish = new Cell(0, 0, true, true);

            _width = width;
            _height = height;
            _cells = new Cell[width, height];
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    //если ячейка нечетная по х и по у и не выходит за пределы лабиринта
                    if ((i % 2 != 0 && j % 2 != 0) && (i < _width - 1 && j < _height - 1)) 
                        
                    {
                        _cells[i, j] = new Cell(i, j); //то это клетка (по умолчанию)
                    }
                    else
                    {

                        _cells[i, j] = new Cell(i, j, false, false);
                    }
            //_path.Push(start);
            //_cells[start.X, start.Y] = start;
            _path.Push(AdjustBorederCell( start));
            _cells[start.X, start.Y] = AdjustBorederCell(start);

        }

        /*
         * Получение клетки для возможных входа и выхода
         */
        public List<Cell> getBorderCells()
        {
            List<Cell> BorderCells = new List<Cell>();

            for (int i=0; i < _width;i++)
            {
                for(int j = 0; j< _height;j++)
                {
                    if(!_cells[i, j]._isCell & !CheckCorner(_cells[i, j]) & (i % 2 != 0 || j % 2 != 0))
                        BorderCells.Add(_cells[i, j]);
                }
            }
            //for (var i = 0; i < _width; i++)
            //{
            //    if (!_cells[i, _height - 2]._isCell)
            //        BorderCells.Add( _cells[i, _height - 2]);
            //    if (!_cells[i, 1]._isCell)
            //        BorderCells.Add(_cells[i, 1]);
            //}

            //for (var i = 0; i < _height; i++)
            //{
            //    if (!_cells[_width - 2,i]._isCell)
            //        BorderCells.Add(_cells[_width - 2, i]);
            //    if (!_cells[1,i]._isCell)
            //        BorderCells.Add(_cells[1,i]);
            //}

            return BorderCells;
        }

        /*
         * Проверить находится ли клетка на углу
         */
        public bool CheckCorner(Cell c)
        {
            if (c.X == 0 & (c.Y == 0 || c.Y == _height - 1))
                return true;
            else if (c.X == _width - 1 & (c.Y == 0 || c.Y == _height - 1))
                return true;
            else return false;
        }

        /*
         * Алгоритм правой руки
         */              

        public void SolveRightHandMaze()
        {
            Cell finish = AdjustBorederCell(this.finish);
            bool flag = false; //флаг достижения финиша
            foreach (Cell c in _cells)
            {
                _cells[c.X, c.Y]._justVisited = false;
                if (_cells[c.X, c.Y]._isCell == true)
                {
                    _cells[c.X, c.Y]._isVisited = false;
                }
            }
            SolveMaze();
            _visited.Clear();
            _path.Clear();
            _path.Push(start);

            while (_path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                //Cell currentCell = _path.Peek()
                if (_path.Peek().X == finish.X && _path.Peek().Y == finish.Y)
                {
                    flag = true;
                }

                if (!flag)
                {
                    _neighbours.Clear();
                    //foreach (Cell c in _cells)
                    //{
                    //    _cells[c.X, c.Y]._justVisited = false;
                    //}
                    _cells[_path.Peek().X, _path.Peek().Y]._justVisited = true;
                    GetAllNeighboursSolve(_path.Peek());
                    if (_neighbours.Count != 0)
                    {
                        if (_neighbours.Count == 1)
                        {
                            _cells[_path.Peek().X, _path.Peek().Y]._paintItRed = true;
                        }
                        Cell nextCell = ChooseRightNeighbour(_neighbours);
                        //Console.WriteLine(nextCell.X);
                        //Console.WriteLine(nextCell.Y);
                        foreach (Cell c in _cells)
                        {
                            _cells[c.X, c.Y]._justVisited = false;
                        }
                        nextCell._isVisited = true; //делаем текущую клетку посещенной
                        
                        _cells[nextCell.X, nextCell.Y]._isVisited = true; //и в общем массиве
                        _cells[_path.Peek().X, _path.Peek().Y]._justVisited = true;
                        _path.Push(nextCell); //затем добавляем её в стек
                        //foreach (Cell c in _cells)
                        //{
                        //    _cells[c.X, c.Y]._justVisited = false;
                        //}
                        //_cells[_path.Peek().X, _path.Peek().Y]._justVisited = true;
                        _visited.Add(_path.Peek());
                    }
                    else
                    {
                        _path.Pop();
                    }
                }
                else
                {
                    //_solve.Add(_path.Peek());
                    _path.Pop();
                }
            }
        }

        public void SolveMaze()
        {
            Cell finish = AdjustBorederCell(this.finish);
            bool flag = false; //флаг достижения финиша
            foreach (Cell c in _cells)
            {
                if (_cells[c.X, c.Y]._isCell == true)
                {
                    _cells[c.X, c.Y]._isVisited = false;
                }
            }

            _path.Clear();
            _path.Push(start);

            while (_path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                if (_path.Peek().X == finish.X && _path.Peek().Y == finish.Y)
                {
                    flag = true;
                }

                if (!flag)
                {
                    _neighbours.Clear();
                    GetNeighboursSolve(_path.Peek());
                    if (_neighbours.Count != 0)
                    {
                        Cell nextCell = ChooseNeighbour(_neighbours);
                        nextCell._isVisited = true; //делаем текущую клетку посещенной
                        _cells[nextCell.X, nextCell.Y]._isVisited = true; //и в общем массиве
                        _path.Push(nextCell); //затем добавляем её в стек
                        _visited.Add(_path.Peek());
                    }
                    else
                    {
                        _path.Pop();
                    }
                }
                else
                {
                    _solve.Add(_path.Peek());
                    _path.Pop();
                }
            }
            _solve.Reverse();
        }
        /*
         * Волновой Алгоритм
         */
        public void SolveWaveMaze()
        {
            Cell finish = AdjustBorederCell(this.finish);
            bool flag = false; //флаг достижения финиша
            SolveMaze();
            foreach (Cell c in _cells)
            {
                if (_cells[c.X, c.Y]._isCell == true)
                {
                    _cells[c.X, c.Y]._isVisited = false;
                }
            }
            
            _visited.Clear();
            _path.Clear();
            _path.Push(start);

            while (_path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                if (_path.Peek().X == finish.X && _path.Peek().Y == finish.Y)
                {
                    flag = true;
                }

                //if (!flag)
                //{
                    _neighbours.Clear();
                    GetNeighboursSolve(_path.Peek());
                    if (_neighbours.Count != 0)
                    {
                        Cell nextCell = ChooseNeighbour(_neighbours);
                        nextCell._isVisited = true; //делаем текущую клетку посещенной
                        _cells[nextCell.X, nextCell.Y]._isVisited = true; //и в общем массиве
                        _path.Push(nextCell); //затем добавляем её в стек
                        _visited.Add(_path.Peek());
                    }
                    else
                    {
                        _path.Pop();
                    }
                //}
                //else
                //{
                //    _solve.Add(_path.Peek());
                //    _path.Pop();
                //}
            }
        }

        /*
         * Скорректировать координаты входа и выхода для алгоритмов
         */
        private Cell AdjustBorederCell(Cell c)
        {
            if (c.X == 0)
                c.X++;
            else if (c.Y == 0)
                c.Y++;
            else if (c.X == _width - 1)
                c.X--;
            else if (c.Y == _height - 1)
                c.Y--;
            return c;
        }

        /*
         * Генерация лабиринта алгоритмом Прима
         */
        public void CreateMaze()
        {

            //_cells[start.X, start.Y] = start;
            _cells[start.X, start.Y] = AdjustBorederCell(start);
            while (_path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                _neighbours.Clear();
                GetNeighbours(_path.Peek());
                if (_neighbours.Count != 0)
                {
                    Cell nextCell = ChooseNeighbour(_neighbours);
                    //Console.WriteLine(nextCell.X);
                    //Console.WriteLine(nextCell.Y);
                    RemoveWall(_path.Peek(), nextCell);
                    nextCell._isVisited = true; //делаем текущую клетку посещенной
                    _cells[nextCell.X, nextCell.Y]._isVisited = true; //и в общем массиве
                    _path.Push(nextCell); //затем добавляем её в стек
                    
                }
                else
                {
                    _path.Pop();
                }

            }
        }

        /*
         * Генерация лабиринта алгоритмом Эллера
         */
        public void CreateEllerMaze()
        {

            //_cells[start.X, start.Y] = start;
            while (_path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                _neighbours.Clear();
                Cell currentCell = _path.Peek();
                currentCell._isVisited = true;
                _cells[currentCell.X, currentCell.Y]._isVisited = true;
                GetNeighbours(currentCell);
                //GetNeighbours(_path.Peek());
                //_path.Peek()._isVisited = true;
                if (_neighbours.Count != 0)
                {
                    Cell nextCell = ChooseNeighbour(_neighbours);
                    RemoveWall(currentCell, nextCell);
                    nextCell._isVisited = true; //делаем текущую клетку посещенной
                    _cells[nextCell.X, nextCell.Y]._isVisited = true; //и в общем массиве
                    _path.Push(nextCell); //затем добавляем её в стек

                }
                else
                {
                    _path.Pop();
                }

            }
        }

        //public void DrawGrid()
        //{
        //    Console.CursorVisible = false;
        //    for (var i = 0; i < _cells.GetUpperBound(0); i++)
        //        for (var j = 0; j < _cells.GetUpperBound(1); j++)
        //        {
        //            Console.SetCursorPosition(i, j);
        //            if (_cells[i, j]._isCell)
        //            {

        //                Console.Write(" ");
        //            }
        //            else
        //            {

        //                Console.Write("#");
        //            }
        //        }
        //    Console.SetCursorPosition(start.X, start.Y);
        //    Console.Write("i");
        //    Console.SetCursorPosition(finish.X, finish.Y);
        //    Console.Write("o");
        //}

        /*
         * Получение соседей текущей клетки для алгоритмов генерации
         */ 
        private void GetNeighbours(Cell localcell) 
        {

            int x = localcell.X;
            int y = localcell.Y;
            const int distance = 2;
            Cell[] possibleNeighbours = new[] // Список всех возможных соседeй
            {
                new Cell(x, y - distance), // Up
                new Cell(x + distance, y), // Right
                new Cell(x, y + distance), // Down
                new Cell(x - distance, y) // Left
            };
            for (int i = 0; i < 4; i++) // Проверяем все 4 направления
            {
                Cell curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X > 0 && curNeighbour.X < _width && curNeighbour.Y > 0 && curNeighbour.Y < _height)
                {// Если сосед не выходит за стенки лабиринта
                    if (_cells[curNeighbour.X, curNeighbour.Y]._isCell && !_cells[curNeighbour.X, curNeighbour.Y]._isVisited)
                    { // А также является клеткой и непосещен
                        _neighbours.Add(curNeighbour);
                    }// добавляем соседа в Лист соседей
                }
            }

        }

        /*
         * Получение соседей текущей клетки для алгоритма поиска пути
         */
        private void GetNeighboursSolve(Cell localcell) 
        {

            int x = localcell.X;
            int y = localcell.Y;
            const int distance = 1;
            Cell[] possibleNeighbours = new[] // Список всех возможных соседeй
            {
                new Cell(x, y - distance), // Up
                new Cell(x - distance, y), // Left
                new Cell(x, y + distance), // Down
                new Cell(x + distance, y) // Right
            };
            for (int i = 0; i < 4; i++) // Проверяем все 4 направления
            {
                Cell curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X > 0 && curNeighbour.X < _width && curNeighbour.Y > 0 && curNeighbour.Y < _height)
                {// Если сосед не выходит за стенки лабиринта
                    if (_cells[curNeighbour.X, curNeighbour.Y]._isCell && !_cells[curNeighbour.X, curNeighbour.Y]._isVisited)
                    { // А также является клеткой и непосещен
                        _neighbours.Add(curNeighbour);
                    }// добавляем соседа в Лист соседей
                }
            }

        }

        private void GetAllNeighboursSolve(Cell localcell)
        {
            int x = localcell.X;
            int y = localcell.Y;
            const int distance = 1;
            Cell[] possibleNeighbours = new[] // Список всех возможных соседeй
            {
                new Cell(x, y - distance), // Up
                new Cell(x - distance, y), // Left
                new Cell(x, y + distance), // Down
                new Cell(x + distance, y) // Right
            };
            for (int i = 0; i < 4; i++) // Проверяем все 4 направления
            {
                Cell curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X > 0 && curNeighbour.X < _width && curNeighbour.Y > 0 && curNeighbour.Y < _height)
                {// Если сосед не выходит за стенки лабиринта
                    if (_cells[curNeighbour.X, curNeighbour.Y]._isCell) //&& !_cells[curNeighbour.X, curNeighbour.Y]._isVisited)
                    { // А также является клеткой
                        _neighbours.Add(curNeighbour);
                    }// добавляем соседа в Лист соседей
                }
            }
        }

        public int GetNotRedNeighbours(Cell localcell)
        {
            int x = localcell.X;
            int y = localcell.Y;
            const int distance = 1;
            List<Cell> notredneighbours = new List<Cell>();
            Cell[] possibleNeighbours = new[] // Список всех возможных соседeй
            {
                new Cell(x, y - distance), // Up
                new Cell(x - distance, y), // Left
                new Cell(x, y + distance), // Down
                new Cell(x + distance, y) // Right
            };
            for (int i = 0; i < 4; i++) // Проверяем все 4 направления
            {
                Cell curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X > 0 && curNeighbour.X < _width && curNeighbour.Y > 0 && curNeighbour.Y < _height)
                {// Если сосед не выходит за стенки лабиринта
                    if (_cells[curNeighbour.X, curNeighbour.Y]._isCell &&
                        !_cells[curNeighbour.X, curNeighbour.Y]._paintItRed && !_solve.Contains(_cells[curNeighbour.X, curNeighbour.Y]))
                    { // А также является клеткой не красной и не частью пути
                        notredneighbours.Add(curNeighbour);
                    }// добавляем соседа в Лист соседей
                }
            }
            return notredneighbours.Count;
        }

        private Cell ChooseRightNeighbour(List<Cell> neighbours)
        {
            if (neighbours.Count == 1)
            {
                return neighbours[0];
            }
            if (neighbours.Count == 2)
            {
                if (_cells[neighbours[0].X,neighbours[0].Y]._justVisited == true)
                {
                    return neighbours[1];
                }
                return neighbours[0];
            }
            if (neighbours.Count == 3)
            {
                if (_cells[neighbours[0].X, neighbours[0].Y]._justVisited == true)
                {
                    return neighbours[1];
                }
                else if (_cells[neighbours[1].X, neighbours[1].Y]._justVisited == true)
                {
                    return neighbours[2];
                }
                return neighbours[0];
            }
            else
            {
                if (_cells[neighbours[0].X, neighbours[0].Y]._justVisited == true)
                {
                    return neighbours[1];
                }
                else if (_cells[neighbours[1].X, neighbours[1].Y]._justVisited == true)
                {
                    return neighbours[2];
                }
                else if (_cells[neighbours[2].X, neighbours[2].Y]._justVisited == true)
                {
                    return neighbours[3];
                }
                return neighbours[0];
            }
            //int r = rnd.Next(neighbours.Count);
            //if ((neighbours.Count > 1) && (r>=1))
            //{
            //    return neighbours[r - 1];
            //}
            //return neighbours[0];

        }

        /*
         * Выбор соседа
         */
        private Cell ChooseNeighbour(List<Cell> neighbours) 
        {

            int r = rnd.Next(neighbours.Count);
            //Console.WriteLine(r);
            //if ((neighbours.Count > 1) && (r>=1))
            //{
            //    return neighbours[r - 1];
            //}
            return neighbours[r];

        }

        /*
         * Удаление стены
         */
        private void RemoveWall(Cell first, Cell second)
        {
            int xDiff = second.X - first.X;
            int yDiff = second.Y - first.Y;
            int addX = (xDiff != 0) ? xDiff / Math.Abs(xDiff) : 0; // Узнаем направление удаления стены
            int addY = (yDiff != 0) ? yDiff / Math.Abs(yDiff) : 0;

            // Координаты удаленной стены
            _cells[first.X + addX, first.Y + addY]._isCell = true; //обращаем стену в клетку
            _cells[first.X + addX, first.Y + addY]._isVisited = true; //и делаем ее посещенной
            second._isVisited = true; //делаем клетку посещенной
            _cells[second.X, second.Y] = second;

        }
    }
}
