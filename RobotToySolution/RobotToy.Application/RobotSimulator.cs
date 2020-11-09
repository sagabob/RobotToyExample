using System;
using System.IO;
using RobotToy.Application.Commands;
using RobotToy.Application.Interfaces;
using RobotToy.Domain.Interfaces;

namespace RobotToy.Application
{
    public class RobotSimulator
    {
        private readonly IRobotCommandFactory _commandFactory;
        private readonly IRobot _robot;
        public RobotSimulator(IRobotCommandFactory commandFactory, IRobot robot)
        {
            _commandFactory = commandFactory;
            _robot = robot;
        }

        public void ProcessCommandsFromConsoleInput()
        {
            string input;
            var isRobotReceivedPlaceCommand = false;
            Console.WriteLine("Please enter commands...");
            do
            {
                input = Console.ReadLine();
                var command = _commandFactory.Create(input, _robot);

                if (!(command is PlaceCommand) && !isRobotReceivedPlaceCommand)
                    continue;

                isRobotReceivedPlaceCommand = true;
                command?.Execute();
            } while (!string.IsNullOrEmpty(input));
        }

        public void ProcessCommandsFromFile()
        {
            Console.Write("Please enter the full path to the file containing commands (eg: C:/TestFile.txt)");

            var isRobotReceivedPlaceCommand = false;
            bool fileExists;
            do
            {
                var filePath = Console.ReadLine();
                fileExists = File.Exists(filePath);

                if (!fileExists)
                {
                    Console.Write($"File {filePath} does not exist. Please provide");
                }
                else
                {
                    foreach (var inputCommand in File.ReadAllLines(filePath))
                    {
                        var command = _commandFactory.Create(inputCommand, _robot);
                        if (!(command is PlaceCommand) && !isRobotReceivedPlaceCommand)
                            continue;

                        isRobotReceivedPlaceCommand = true;
                        command?.Execute();
                    }
                    
                    Console.ReadKey();
                }
            } while (!fileExists);
        }
    }
}