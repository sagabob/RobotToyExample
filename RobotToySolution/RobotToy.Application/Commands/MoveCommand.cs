using RobotToy.Application.Interfaces;
using RobotToy.Domain;
using RobotToy.Domain.Interfaces;

namespace RobotToy.Application.Commands
{
    public class MoveCommand : IRobotCommand
    {
        public MoveCommand(IRobot receiver)
        {
            Receiver = receiver;
        }

        public IRobot Receiver { get; }

        public void Execute()
        {
            Receiver.Move();
        }
    }
}