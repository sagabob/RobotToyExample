using System;
using RobotToy.Application.Interfaces;
using RobotToy.Domain.Interfaces;

namespace RobotToy.Application.Commands
{
    public class ReportCommand : IRobotCommand
    {
        public ReportCommand(IRobot receiver)
        {
            Receiver = receiver;
        }

        public IRobot Receiver { get; }

        public void Execute()
        {
            if (Receiver.CurrentPosition() == null)
                return;

            Console.WriteLine("{0},{1},{2}",
                Receiver.CurrentPosition().X,
                Receiver.CurrentPosition().Y,
                Receiver.CurrentPosition().Direction.ToString().ToUpper()
            );
        }
    }
}