using FluentAssertions;
using NUnit.Framework;

namespace RobotToy.Domain.Tests
{
    [TestFixture]
    public class WhenRobotHasNotBeenPositionedOnTheTableTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Robot = new Robot(new TableDimensions());
        }

        protected Robot Robot;

        [Test]
        public void ThenMoveActionShouldReturnNotPlacedOnTable()
        {
            var moveResult = Robot.Move();
            moveResult.Should().Be(RobotPlaceMoveTurnResult.NotPlacedOnTable);
        }

        [Test]
        public void ThenTurnLeftActionShouldReturnNotPlacedOnTable()
        {
            var moveResult = Robot.TurnLeft();
            moveResult.Should().Be(RobotPlaceMoveTurnResult.NotPlacedOnTable);
        }

        [Test]
        public void ThenTurnRightActionShouldReturnNotPlacedOnTable()
        {
            var moveResult = Robot.TurnRight();
            moveResult.Should().Be(RobotPlaceMoveTurnResult.NotPlacedOnTable);
        }
    }
}