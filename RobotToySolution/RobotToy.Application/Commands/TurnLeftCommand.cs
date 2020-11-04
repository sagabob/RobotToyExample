using RobotToy.Application.Interfaces;
using RobotToy.Domain.Interfaces;

namespace RobotToy.Application.Commands
{
    public class TurnLeftCommand : IRobotCommand
    {
        public TurnLeftCommand(IRobot receiver)
        {
            Receiver = receiver;
        }

        public IRobot Receiver { get; }

        public void Execute()
        {
            Receiver.TurnLeft();
        }
    }
}