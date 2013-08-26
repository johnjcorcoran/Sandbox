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
            Point = new GridPoint(Point.X, Point.Y + 1);
        }

        private void MoveBackwards()
        {
            Point = new GridPoint(Point.X, Point.Y - 1);
        }

        public override string ToString()
        {
            return string.Format("[Rover: PointX={0}, PointY={1}, Direction={2}]", Point.X, Point.Y, Direction);
        }
    }
}