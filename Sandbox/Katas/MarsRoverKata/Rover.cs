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
                        Point.MoveForwardFacing(Direction.CompassPoint);
                        break;
                    case 'b':
                        Point.MoveBackwardFacing(Direction.CompassPoint);
                        break;
                    case 'r':
                        Direction.TurnRight();
                        break;
                    case 'l':
                        Direction.TurnLeft();
                        break;
                }
            }
        }  

        public override string ToString()
        {
            return string.Format("[Rover: PointX={0}, PointY={1}, Direction={2}]", Point.X, Point.Y, Direction);
        }
    }
}