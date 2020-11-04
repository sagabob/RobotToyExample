using RobotToy.Domain.Interfaces;

namespace RobotToy.Application.Interfaces
{
    public interface IRobotCommandFactory
    {
        IRobotCommand Create(string inputLine, IRobot receiver);
    }
}