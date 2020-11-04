using System;
using RobotToy.Application;
using RobotToy.Application.Commands;
using RobotToy.Domain;

namespace RobotToySolution
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Start the robot simulator, press 1 to choose input by file path, other key for console..");

            var robot = new Robot(new TableDimensions());
            var robotSimulator = new RobotSimulator(new RobotCommandFactory(), robot);

            var option = Console.ReadLine();

            if (option == "1")
            {
                robotSimulator.ProcessCommandsFromFile();
            }
            else
            {
                robotSimulator.ProcessCommandsFromConsoleInput();
            }

        }
    }
}