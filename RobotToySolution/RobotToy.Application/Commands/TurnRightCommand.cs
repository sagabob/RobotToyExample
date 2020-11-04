using RobotToy.Application.Interfaces;
using RobotToy.Domain.Interfaces;

namespace RobotToy.Application.Commands
{
    public class TurnRightCommand : IRobotCommand
    {
        public TurnRightCommand(IRobot receiver)
        {
            Receiver = receiver;
        }

        public IRobot Receiver { get; }

        public void Execute()
        {
            Receiver.TurnRight();
        }
    }
}