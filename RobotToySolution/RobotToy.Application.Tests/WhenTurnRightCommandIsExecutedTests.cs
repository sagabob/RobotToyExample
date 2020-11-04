using FluentAssertions;
using NUnit.Framework;
using RobotToy.Application.Commands;
using RobotToy.Application.Interfaces;
using RobotToy.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotToy.Application.Tests
{
    [TestFixture]
    public class WhenTurnRightCommandIsExecutedTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Robot = new Robot(new TableDimensions());
            Command = new TurnRightCommand(Robot);
        }

        protected Robot Robot;
        protected IRobotCommand Command;

        [TestCase(Direction.North, Direction.East)]
        [TestCase(Direction.South, Direction.West)]
        [TestCase(Direction.West, Direction.North)]
        [TestCase(Direction.East, Direction.South)]
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
