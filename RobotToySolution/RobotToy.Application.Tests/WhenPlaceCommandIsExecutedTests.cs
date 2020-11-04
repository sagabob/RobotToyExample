using FluentAssertions;
using NUnit.Framework;
using RobotToy.Application.Commands;
using RobotToy.Application.Interfaces;
using RobotToy.Domain;

namespace RobotToy.Application.Tests
{
    public class WhenPlaceCommandIsExecutedTests
    {
        public const int TableSize = 5;
        protected IRobotCommand Command;
        protected Robot Robot;

        [TestCase(0, 0, true)]
        [TestCase(-1, 0, false)]
        [TestCase(TableSize, 0, false)]
        [TestCase(TableSize - 1, TableSize - 1, true)]
        public void ThenRobotPositionIsUpdatedAsExpected(int inputX, int inputY,
            bool hasResult)
        {
            var position = new Position
            {
                X = inputX,
                Y = inputY,
                Direction = 0
            };

            Robot = new Robot(new TableDimensions(TableSize, TableSize));
            Command = new PlaceCommand(Robot, position);

            Command.Execute();

            if (hasResult)
            {
                Robot.CurrentPosition().X.Should().Be(inputX);
                Robot.CurrentPosition().Y.Should().Be(inputY);
            }
            else
            {
                Robot.CurrentPosition().Should().Be(null);
            }
        }
    }
}