using System;

namespace Katas.MarsRover
{
    public enum CompassPoint
    {
        North,
        East,
        South,
        West
    }

    public class Direction
    {
        public CompassPoint CompassPoint { get; private set; }

        public Direction(CompassPoint compassPoint)
        {
            CompassPoint = compassPoint;
        }

        public void TurnRight()
        {
            if (CompassPoint == CompassPoint.West)
            {
                CompassPoint = CompassPoint.North;
            }
            else
            {
                CompassPoint = CompassPoint + 1;
            }
        }

        public void TurnLeft()
        {
            if (CompassPoint == CompassPoint.North)
            {
                CompassPoint = CompassPoint.West;
            }
            else
            {
                CompassPoint = CompassPoint - 1;
            }
        }
    }
}

