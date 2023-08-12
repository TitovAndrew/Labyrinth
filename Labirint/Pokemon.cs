using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Класс, для хранения координат покемонов
 */
namespace Labyrinth
{
    class Pokemon
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Pokemon(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
