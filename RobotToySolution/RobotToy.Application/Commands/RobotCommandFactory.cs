using System;
using RobotToy.Application.Interfaces;
using RobotToy.Domain;
using RobotToy.Domain.Interfaces;

namespace RobotToy.Application.Commands
{
    public class RobotCommandFactory : IRobotCommandFactory
    {
        public IRobotCommand Create(string inputLine, IRobot receiver)
        {
            if (string.IsNullOrEmpty(inputLine))
                return null;

            IRobotCommand parsedCommand = null;
            var upperCaseInput = inputLine.ToUpper().Trim();

            if (upperCaseInput.StartsWith("PLACE"))
                parsedCommand = ParsePositionCommand(upperCaseInput, receiver);
            else if (upperCaseInput == "MOVE")
                parsedCommand = new MoveCommand(receiver);
            else if (upperCaseInput == "LEFT")
                parsedCommand = new TurnLeftCommand(receiver);
            else if (upperCaseInput == "RIGHT")
                parsedCommand = new TurnRightCommand(receiver);
            else if (upperCaseInput == "REPORT") parsedCommand = new ReportCommand(receiver);


            return parsedCommand;
        }

        private PlaceCommand ParsePositionCommand(string inputLine, IRobot receiver)
        {
            var commandArgs = inputLine.Replace("PLACE", "").Trim();
            var parameters = commandArgs.Split(",", StringSplitOptions.RemoveEmptyEntries);

            if (parameters.Length != 3)
                return null;

            if (!int.TryParse(parameters[0], out var xCoordinate))
                return null;

            if (!int.TryParse(parameters[1], out var yCoordinate))
                return null;

            if (!Enum.TryParse(parameters[2], true, out Direction direction))
                return null;

            var position = new Position
            {
                Direction = direction,
                X = xCoordinate,
                Y = yCoordinate
            };

            return new PlaceCommand(receiver, position);
        }
    }
}