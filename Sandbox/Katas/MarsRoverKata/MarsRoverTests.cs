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

        [TestCase(0, 0, Direction.North)]
        [TestCase(1, 2, Direction.East)]
        [TestCase(2, 1, Direction.South)]
        public void RoverRemainsAtStartingPointAndInitialDirectionWhenNotIssuedMoveCommands(
            int x, int y, Direction startingDirection)
        {
            InitialiseRoverAt(x, y, startingDirection);
            Assert.That(_rover, IsAt.Position(x, y, startingDirection));
        }

        [TestCase(0, 0, "f", 1)]
        [TestCase(0, 0, "ff", 2)]
        [TestCase(1, 1, "f", 2)]
        [TestCase(1, 1, "ff", 3)]
        public void RoverMovesNorthWhenMovedForwardWhileFacingNorth(
            int startPointX, int startPointY, string movement, int finalPointY)
        {
            InitialiseRoverAt(startPointX, startPointY, Direction.North);
            MoveRover(movement);
            Assert.That(_rover, IsAt.Position(startPointX, finalPointY, Direction.North));
        }

        private void InitialiseRoverAt(int x, int y, Direction direction)
        {
            _rover = new Rover(new GridPoint(x, y), direction);
        }

        private void MoveRover(string movement)
        {
            _rover.Move(movement.ToCharArray());
        }
    }

    internal static class IsAt
    {
        public static RoverConstraint Position(int x, int y, Direction direction)
        {
            return new RoverConstraint(new Rover(new GridPoint (x, y), direction));
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
                && actual.Direction == expected.Direction;
        }
    }
}