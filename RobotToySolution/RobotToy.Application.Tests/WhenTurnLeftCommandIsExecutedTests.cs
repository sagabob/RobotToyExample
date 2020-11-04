using FluentAssertions;
using NUnit.Framework;
using RobotToy.Application.Commands;
using RobotToy.Application.Interfaces;
using RobotToy.Domain;

namespace RobotToy.Application.Tests
{
    [TestFixture]
    public class WhenTurnLeftCommandIsExecutedTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Robot = new Robot(new TableDimensions());
            Command = new TurnLeftCommand(Robot);
        }

        protected Robot Robot;
        protected IRobotCommand Command;

        [TestCase(Direction.North, Direction.West)]
        [TestCase(Direction.South, Direction.East)]
        [TestCase(Direction.West, Direction.South)]
        [TestCase(Direction.East, Direction.North)]
        public void ThenRobotPositionIsUpdatedAsExpected(Direction startingDirection, Direction outputDirection)
        {
            var position = new Position
            {
                X = 0,
                Y = 0,
                Direction = startingDirection
            };

            Robot.SetPosition(position);

            Command.Execute();

            Robot.CurrentPosition().Direction.Should().Be(outputDirection);
        }
    }
}