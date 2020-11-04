using FluentAssertions;
using NUnit.Framework;

namespace RobotToy.Domain.Tests
{
    public class WhenRobotIsPositionedAtSouthWestEdgeOfTable
    {
        public const int TableSize = 5;
        protected Robot Robot;
        protected TableDimensions TableDimensions;

        [OneTimeSetUp]
        public void Setup()
        {
            TableDimensions = new TableDimensions(TableSize, TableSize);
            Robot = new Robot(TableDimensions);
           
        }


        [TestCase(Direction.North, RobotPlaceMoveTurnResult.SuccessfulAction, 0, 1)]
        [TestCase(Direction.East, RobotPlaceMoveTurnResult.SuccessfulAction, 1, 0)]
        [TestCase(Direction.West, RobotPlaceMoveTurnResult.PreventedAction, 0, 0)]
        [TestCase(Direction.South, RobotPlaceMoveTurnResult.PreventedAction, 0, 0)]
        public void ThenMoveCommandShouldReturnExpectedResult(Direction startingDirection,
            RobotPlaceMoveTurnResult actionResult, int outputX, int outputY)
        {
            var position = new Position
            {
                Direction = startingDirection,
                X = 0,
                Y = 0
            };

            Robot.SetPosition(position);
            var moveResult = Robot.Move();
            moveResult.Should().Be(actionResult);
            Robot.CurrentPosition().X.Should().Be(outputX);
            Robot.CurrentPosition().Y.Should().Be(outputY);
        }
    }
}