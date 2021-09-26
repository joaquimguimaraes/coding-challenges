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

            string expectedOutput = @"
1 3 N
5 1 E
";

            string output = RobotWars.Program.ReadInput(input);

            bool result = output == expectedOutput;

            Assert.False(result, $"Output:\n'{output}'\ndoes not match expected output:\n'{expectedOutput}'");
            Assert.True(result, $"Output:\n'{output}'\nmatches expected output:\n'{expectedOutput}'");
             
            return result;
        }
    }
}
