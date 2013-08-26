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

        public void MoveForwardFacing(Direction direction)
        {
            switch (direction)
            {
                case (Direction.North):
                    MoveNorth();
                    break;
                case (Direction.East):
                    MoveEast();
                    break;
                case (Direction.South):
                    MoveSouth();
                    break;
                case (Direction.West):
                    MoveWest();
                    break;
            }
        }

        public void MoveBackwardFacing(Direction direction)
        {
            switch (direction)
            {
                case (Direction.North):
                    MoveSouth();
                    break;
                case (Direction.East):
                    MoveWest();
                    break;
                case (Direction.South):
                    MoveNorth();
                    break;
                case (Direction.West):
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

