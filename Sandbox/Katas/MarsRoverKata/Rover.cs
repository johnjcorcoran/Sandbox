using System;

namespace Katas.MarsRover
{
    public class Rover
    {
        public Point Point { get; private set;}
        public Direction Direction { get; private set;}

        public Rover(Point startingPoint, Direction startingDirection)
        {
            Point = startingPoint;
            Direction = startingDirection;
        }

        public void Move(char[] movement)
        {
            int movementAmount = movement.Length;
            Point = new Point(0, movementAmount);
        }

        public override string ToString()
        {
            return string.Format("[Rover: PointX={0}, PointY={1}, Direction={2}]", Point.X, Point.Y, Direction);
        }
    }
}

