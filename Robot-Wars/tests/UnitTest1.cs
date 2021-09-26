using System;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public bool Test1()
        {
            //test input
            string input = @"
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
";

            string expectedOutput = trimBlankCharacters(@"
1 3 N
5 1 E
");

            string output = trimBlankCharacters(RobotWars.Program.ReadInput(input));

            bool result = output == expectedOutput;

            Assert.True(result, $"Output:\n'{output}'\ndoes not match expected output:\n'{expectedOutput}'");
             
            return result;
        }

        static string trimBlankCharacters(string input)
        {
            string[] splitStrings = {Environment.NewLine, "\n", "\r\n"};
            string[] lines = input.Split(splitStrings, StringSplitOptions.RemoveEmptyEntries);

            string output = "";

            foreach (string line in lines)
            output += line.Trim() + "\n";

            output = output.TrimEnd('\n');
            
            return output;
        }
    }
}
