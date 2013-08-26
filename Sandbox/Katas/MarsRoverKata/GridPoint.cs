using System;

namespace Katas.MarsRover
{
    public class GridPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public GridPoint (int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

