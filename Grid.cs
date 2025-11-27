using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snack_Game
{
    internal class Grid
    {
        public int Length;
        public int Width;
        public Object[,] Array;
        public Grid(int length, int width)
        {
            Length = length;
            Width = width;
            Array = new Object[Length, Width];

        }
    }
}
