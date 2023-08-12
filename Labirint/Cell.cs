using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Клетка лабиринта
 */
[Serializable]
public struct Cell
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool _isCell { get; set; }
    public bool _isVisited { get; set; }
    public bool _justVisited { get; set; }
    public bool _paintItRed { get; set; }

    public Cell(int x, int y, bool isVisited = false, bool isCell = true, bool justVisited = false, bool paintItRed = false)
    {
        X = x;
        Y = y;
        _isCell = isCell;
        _isVisited = isVisited;
        _justVisited = justVisited;
        _paintItRed = paintItRed;
    }

    /*
     * Равны ли две клетки
     */
    public bool Equals(Cell c)
    {
        return X == c.X & Y == c.Y;
    }
}
