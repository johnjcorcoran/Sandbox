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

        public override string ToString()
        {
            return string.Format("[Rover: PointX={0}, PointY={1}, Direction={2}]", Point.X, Point.Y, Direction);
        }
    }
}

