using FluentAssertions;
using NUnit.Framework;
using RobotToy.Application.Commands;
using RobotToy.Application.Interfaces;
using RobotToy.Domain;

namespace RobotToy.Application.Tests
{
    [TestFixture]
    public class WhenMoveCommandIsExecutedTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Robot = new Robot(new TableDimensions());
            Command = new MoveCommand(Robot);
        }

        protected Robot Robot;
        protected IRobotCommand Command;

        [TestCase(Direction.North, 0, 0, 0, 1)]
        [TestCase(Direction.South, 0, 0, 0, 0)]
        [TestCase(Direction.West, 0, 0, 0, 0)]
        [TestCase(Direction.East, 0, 0, 1, 0)]
        public void ThenRobotPositionIsUpdatedAsExpected(Direction startingDirection, int inputX, int inputY,
            int outputX, int outputY)
        {
            var position = new Position
            {
                X = inputX,
                Y = inputY,
                Direction = startingDirection
            };

            Robot.SetPosition(position);

            Command.Execute();

            Robot.CurrentPosition().X.Should().Be(outputX);
            Robot.CurrentPosition().Y.Should().Be(outputY);
        }
    }
}