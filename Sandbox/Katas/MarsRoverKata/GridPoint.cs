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

        public void MoveForwardFacing(CompassPoint direction)
        {
            switch (direction)
            {
                case (CompassPoint.North):
                    MoveNorth();
                    break;
                case (CompassPoint.East):
                    MoveEast();
                    break;
                case (CompassPoint.South):
                    MoveSouth();
                    break;
                case (CompassPoint.West):
                    MoveWest();
                    break;
            }
        }

        public void MoveBackwardFacing(CompassPoint direction)
        {
            switch (direction)
            {
                case (CompassPoint.North):
                    MoveSouth();
                    break;
                case (CompassPoint.East):
                    MoveWest();
                    break;
                case (CompassPoint.South):
                    MoveNorth();
                    break;
                case (CompassPoint.West):
                    MoveEast();
                    break;
            }
        }

        public void MoveNorth()
        {
            Y++;
        }

        public void MoveSouth()
        {
            Y--;
        }

        public void MoveEast()
        {
            X++;
        }

        public void MoveWest()
        {
            X--;
        }
    }
}

