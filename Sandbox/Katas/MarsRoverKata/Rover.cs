using System;

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
            int movementAmount = movement.Length;
            Point = new GridPoint(Point.X, MoveY(movementAmount));
        }

        private int MoveY(int amount)
        {
            return Point.Y + amount;
        }

        public override string ToString()
        {
            return string.Format("[Rover: PointX={0}, PointY={1}, Direction={2}]", Point.X, Point.Y, Direction);
        }
    }
}

