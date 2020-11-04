using RobotToy.Application.Interfaces;
using RobotToy.Domain;
using RobotToy.Domain.Interfaces;

namespace RobotToy.Application.Commands
{
    public class PlaceCommand : IRobotCommand
    {
        private readonly Position _position;

        public PlaceCommand(IRobot receiver, Position position)
        {
            Receiver = receiver;
            _position = position;
        }

        public IRobot Receiver { get; }

        public void Execute()
        {
            Receiver.SetPosition(_position);
        }
    }
}