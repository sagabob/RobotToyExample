using System;
using FluentAssertions;
using NUnit.Framework;
using RobotToy.Application.Commands;
using RobotToy.Domain;

namespace RobotToy.Application.Tests
{
    [TestFixture]
    public class RobotCommandFactoryTests
    {
        public const int TableSize = 5;
        protected Robot Robot;
        protected TableDimensions TableDimensions;
        protected RobotCommandFactory Factory;

        [OneTimeSetUp]
        public void Setup()
        {
            TableDimensions = new TableDimensions(TableSize, TableSize);
            Robot = new Robot(TableDimensions);
            Factory = new RobotCommandFactory();
        }

        [TestCase(null,false)]
        [TestCase("", false)]
        [TestCase("1", false)]
        [TestCase("place 0,0", false)]
        [TestCase("place 0,0, north", true)]
        [TestCase("place 0,5, north", true)] //still a valid command

        [TestCase("move", true)] 
        [TestCase("move north", false)]
        [TestCase("right", true)]
        [TestCase("left", true)]

        [TestCase("turnleft", false)]
        public void WhenCreateCommandWithInput_ThenReceiveExpectedResult(string placeCommandInput, bool expectedValidCommand)
        {
            var command = Factory.Create(placeCommandInput, Robot);

            if (!expectedValidCommand)
                command.Should().BeNull();
            else
                command.Should().NotBeNull();
        }
    }
}
