using System;
using System.Linq;

namespace Katas.MarsRover
{
    public class Rover
    {
        public GridPoint Point { get; private set;}
        public Direction Direction { get; private set;}

        public Rover(GridPoint startingPoint, Direction startingDirection)
        {
            Point = startingPoint;
            Direction = startingDirection;
        }

        public void Move(char[] movement)
        {
            foreach (char move in movement)
            {
                switch (move)
                {
                    case 'f':
                        MoveForwards();
                        break;
                    case 'b':
                        MoveBackwards();
                        break;
                }
            }
        }

        private void MoveForwards()
        {
            switch (Direction)
            {
                case (Direction.North):
                    MoveNorth();
                    break;
                case (Direction.South):
                    MoveSouth();
                    break;
            }
        }

        private void MoveBackwards()
        {
            switch (Direction)
            {
                case (Direction.North):
                    MoveSouth();
                    break;
                case (Direction.South):
                    MoveNorth();
                    break;
            }
        }

        private void MoveNorth()
        {
            Point.MoveNorth();
        }

        private void MoveSouth()
        {
            Point.MoveSouth();
        }

        public override string ToString()
        {
            return string.Format("[Rover: PointX={0}, PointY={1}, Direction={2}]", Point.X, Point.Y, Direction);
        }
    }
}