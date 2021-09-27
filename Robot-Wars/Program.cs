using System;
using System.Collections.Generic;

namespace RobotWars
{
    /// <summary>
    /// Main program which reads input
    /// </summary>
    public class Program
    {
        // Search predicate returns true if a character is space character
        private static bool isSpaceCharacter(char character)
        {
            return character == ' ';
        }

        /// <summary>
        /// Function <c>Main</c> asks for user input and passes it to <c>ReadInput</c>
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Stops asking for user input after detecting END
            const string breakWord = "END";

            Console.WriteLine($@"
Please provide input as follows:

The first line of input is the upper-right coordinates of the arena, the lower-left coordinates are assumed to be (0, 0).
 
The rest of the input is information pertaining to the robots that have been deployed. Each robot has two lines of input - the first gives the robot’s position and the second is a series of instructions telling the robot how to move within the arena.
 
The position is made up of two integers and a letter separated by spaces, corresponding to the x and y coordinates and the robot’s orientation. Each robot will finish moving sequentially, which means that the second robot won’t start to move until the first one has finished moving.

Type '{breakWord}' and press enter to submit input

Input:");
            string input = "";
            string inputLine = "";

            while (!inputLine.Contains(breakWord))
            {
                inputLine = Console.ReadLine();

                if (!inputLine.Contains(breakWord))
                    input += inputLine + Environment.NewLine;
                else
                    input += inputLine.Replace(breakWord, "") + Environment.NewLine;
            }

            Console.WriteLine("\nOutput:\n" + ReadInput(input));
        }

        /// <summary>
        /// Function <c>ReadInput</c> processes user input, creates <c>Robot</c> objects and moves/spins them around the arena
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ReadInput(string input)
        {
            //initializes empty list of robots
            List<Robot> robots = new List<Robot>();

            string[] inputLines = input.Split(new[] { Environment.NewLine, "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            //initializes default robot, placeholder
            Robot currentRobot = new Robot(new Coordinates(0, 0), new Coordinates(0, 0), Orientation.N);
            //initializes default arena boundaries, placeholder
            Coordinates boundaries = new Coordinates(0, 0);
            for (int i = 0; i < inputLines.Length; i++)
            {
                string line = inputLines[i];
                //splits line by space characters
                List<char> lineArgs = new List<Char>();
                lineArgs.AddRange(line.ToCharArray());
                lineArgs.RemoveAll(isSpaceCharacter);

                //defines arena boundaries
                if (i == 0)
                {
                    int xBoundary = int.Parse(lineArgs[0].ToString());
                    int yBoundary = int.Parse(lineArgs[1].ToString());

                    boundaries = new Coordinates(xBoundary, yBoundary);
                }
                else if (lineArgs.Count > 0)
                {
                    //if first line of pair of lines, initializes a new robot
                    if ((i % 2) == 1)
                    {
                        int xPosition = int.Parse(lineArgs[0].ToString());
                        int yPosition = int.Parse(lineArgs[1].ToString());
                        Orientation orientation = Enum.Parse<Orientation>(lineArgs[2].ToString());
                        currentRobot = new Robot(new Coordinates(xPosition, yPosition), boundaries, orientation);
                    }
                    //second line tells robot to move/spin
                    else
                    {
                        for (int k = 0; k < lineArgs.Count; k++)
                        {
                            char currentArg = lineArgs[k];

                            //if character is M then moves the robot forward
                            if (currentArg == 'M')
                                currentRobot.MoveForward();
                            //if the character is not M then it must be either L or R, so it spins the robot in that direction
                            else
                                currentRobot.Spin(Enum.Parse<Turn>(currentArg.ToString()));

                        }

                        robots.Add(currentRobot);
                    }
                }
            }

            string output = "";

            // reads final position and orientation of each robot
            foreach (Robot robot in robots)
                output += $"{robot.position.x} {robot.position.y} {robot.orientation}\n";

            return output;

        }
    }

}
