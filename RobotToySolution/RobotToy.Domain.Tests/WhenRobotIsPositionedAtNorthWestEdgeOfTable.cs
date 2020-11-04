using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotToy.Domain.Tests
{
    public class WhenRobotIsPositionedAtNorthWestEdgeOfTable
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


        [TestCase(Direction.East, RobotPlaceMoveTurnResult.SuccessfulAction, 1, TableSize - 1)]
        [TestCase(Direction.South, RobotPlaceMoveTurnResult.SuccessfulAction, 0 , TableSize - 2)]
        [TestCase(Direction.West, RobotPlaceMoveTurnResult.PreventedAction, 0,TableSize - 1)]
        [TestCase(Direction.North, RobotPlaceMoveTurnResult.PreventedAction, 0, TableSize - 1)]
        public void ThenMoveCommandShouldReturnExpectedResult(Direction startingDirection,
            RobotPlaceMoveTurnResult actionResult, int outputX, int outputY)
        {
            var position = new Position
            {
                Direction = startingDirection,
                X = 0,
                Y = TableSize - 1
            };

            Robot.SetPosition(position);
            var moveResult = Robot.Move();
            moveResult.Should().Be(actionResult);
            Robot.CurrentPosition().X.Should().Be(outputX);
            Robot.CurrentPosition().Y.Should().Be(outputY);
        }
    }
}
