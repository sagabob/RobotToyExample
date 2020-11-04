using FluentAssertions;
using NUnit.Framework;

namespace RobotToy.Domain.Tests
{
    [TestFixture]
    public class WhenRobotIsPositionedAtSouthEastEdgeOfTable
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


        [TestCase(Direction.East, RobotPlaceMoveTurnResult.PreventedAction, TableSize - 1, 0)]
        [TestCase(Direction.South, RobotPlaceMoveTurnResult.PreventedAction, TableSize - 1, 0)]
        [TestCase(Direction.West, RobotPlaceMoveTurnResult.SuccessfulAction, TableSize - 2, 0)]
        [TestCase(Direction.North, RobotPlaceMoveTurnResult.SuccessfulAction, TableSize - 1, 1)]
        public void ThenMoveCommandShouldReturnExpectedResult(Direction startingDirection,
            RobotPlaceMoveTurnResult actionResult, int outputX, int outputY)
        {
            var position = new Position
            {
                Direction = startingDirection,
                X = TableSize - 1,
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