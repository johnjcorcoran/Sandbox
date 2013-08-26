using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

//Develop an api that moves a rover around on a grid.
//You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
//The rover receives a character array of commands.
//Implement commands that move the rover forward/backward (f,b).
//Implement commands that turn the rover left/right (l,r).
//Implement wrapping from one edge of the grid to another. (planets are spheres after all)
//Implement obstacle detection before each move to a new square. 
//    If a given sequence of commands encounters an obstacle, 
//    the rover moves up to the last possible point and reports the obstacle.
//Example: The rover is on a 100x100 grid at location (0, 0) and facing NORTH. 
//    The rover is given the commands "ffrff" and should end up at (2, 2)

namespace Katas.MarsRover
{
    [TestFixture]
    public class MarsRoverTests
    {
        private Rover _rover;

        [TestCase(0, 0, CompassPoint.North)]
        [TestCase(1, 2, CompassPoint.East)]
        [TestCase(2, 1, CompassPoint.South)]
        public void RoverRemainsAtStartingPointAndInitialDirectionWhenNotIssuedMoveCommands(
            int x, int y, CompassPoint startDirection)
        {
            InitialiseRoverAt(x, y, startDirection);
            Assert.That(_rover, IsAt.Position(x, y, startDirection));
        }

        [TestCase(0, 5, "fb", 5)]
        [TestCase(1, 5, "bf", 5)]
        [TestCase(2, 5, "ffb", 6)]
        [TestCase(3, 5, "bbf", 4)]
        public void RoverCanMoveForwardsAndBackwardsFacingNorth(
            int startPointX, int startPointY, string movement, int finalPointY)
        {
            InitialiseRoverAt(startPointX, startPointY, CompassPoint.North);
            MoveRover(movement);
            Assert.That(_rover, IsAt.Position(startPointX, finalPointY, CompassPoint.North));
        }

        [TestCase(0, 5, "f", 4)]
        [TestCase(0, 5, "b", 6)]
        [TestCase(0, 5, "ffb", 4)]
        [TestCase(0, 5, "bbf", 6)]
        public void RoverCanMoveForwardsAndBackwardsFacingSouth(
            int startPointX, int startPointY, string movement, int finalPointY)
        {
            InitialiseRoverAt(startPointX, startPointY, CompassPoint.South);
            MoveRover(movement);
            Assert.That(_rover, IsAt.Position(startPointX, finalPointY, CompassPoint.South));
        }

        [TestCase(5, 5, "f", 6)]
        [TestCase(5, 5, "b", 4)]
        [TestCase(5, 5, "ffb", 6)]
        [TestCase(5, 5, "bbf", 4)]
        public void RoverCanMoveForwardsAndBackwardsFacingEast(
            int startPointX, int startPointY, string movement, int finalPointX)
        {
            InitialiseRoverAt(startPointX, startPointY, CompassPoint.East);
            MoveRover(movement);
            Assert.That(_rover, IsAt.Position(finalPointX, startPointY, CompassPoint.East));
        }

        [TestCase(5, 5, "f", 4)]
        [TestCase(5, 5, "b", 6)]
        public void RoverCanMoveForwardsAndBackwardsFacingWest(
            int startPointX, int startPointY, string movement, int finalPointX)
        {
            InitialiseRoverAt(startPointX, startPointY, CompassPoint.West);
            MoveRover(movement);
            Assert.That(_rover, IsAt.Position(finalPointX, startPointY, CompassPoint.West));
        }

        [TestCase(CompassPoint.North, CompassPoint.East)]
        [TestCase(CompassPoint.East, CompassPoint.South)]
        [TestCase(CompassPoint.South, CompassPoint.West)]
        [TestCase(CompassPoint.West, CompassPoint.North)]
        public void RoverCanTurnRight(CompassPoint startDirection, CompassPoint endDirection)
        {
            InitialiseRoverAt(0, 0, startDirection);
            MoveRover("r");
            Assert.That(_rover, IsAt.Position(0, 0, endDirection));
        }

        [TestCase(CompassPoint.North, CompassPoint.West)]
        [TestCase(CompassPoint.East, CompassPoint.North)]
        [TestCase(CompassPoint.South, CompassPoint.East)]
        [TestCase(CompassPoint.West, CompassPoint.South)]
        public void RoverCanTurnLeft(CompassPoint startDirection, CompassPoint endDirection)
        {
            InitialiseRoverAt(0, 0, startDirection);
            MoveRover("l");
            Assert.That(_rover, IsAt.Position(0, 0, endDirection));
        }

        [TestCase(CompassPoint.North, "rl", CompassPoint.North)]
        [TestCase(CompassPoint.North, "rrl", CompassPoint.East)]
        [TestCase(CompassPoint.North, "rrrl", CompassPoint.South)]
        [TestCase(CompassPoint.North, "rrrrl", CompassPoint.West)]
        [TestCase(CompassPoint.North, "llllr", CompassPoint.East)]
        public void RoverCanTurnRightAndLeft(CompassPoint startDirection, string movement, CompassPoint endDirection)
        {
            InitialiseRoverAt(0, 0, startDirection);
            MoveRover(movement);
            Assert.That(_rover, IsAt.Position(0, 0, endDirection));
        }


        private void InitialiseRoverAt(int x, int y, CompassPoint direction)
        {
            _rover = new Rover(new GridPoint(x, y), new Direction(direction));
        }

        private void MoveRover(string movement)
        {
            _rover.Move(movement.ToCharArray());
        }
    }

    internal static class IsAt
    {
        public static RoverConstraint Position(int x, int y, CompassPoint direction)
        {
            return new RoverConstraint(new Rover(new GridPoint (x, y), new Direction(direction)));
        }
    }

    internal class RoverConstraint : Constraint
    {
        private readonly Rover _expected;

        public RoverConstraint(Rover expected)
        {
            _expected = expected;
        }

        public override bool Matches(object actual)
        {
            base.actual = actual;
            bool valuesMatch = false;
            if (actual is Rover)
            {
                valuesMatch = TestValuesForEquality(_expected, (Rover)actual);
            }
            return valuesMatch;
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WriteExpectedValue(_expected);
        }

        private static bool TestValuesForEquality(Rover expected, Rover actual)
        {
            return actual.Point.X == expected.Point.X
                && actual.Point.Y == expected.Point.Y
                && actual.Direction.CompassPoint == expected.Direction.CompassPoint;
        }
    }
}