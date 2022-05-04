using Robot_Cleaner.Classes.RobotCleaner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeepEqual.Syntax;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class RobotSettingsShould
    {
        public static IEnumerable<object[]> Data =>

            new List<object[]>
            {
            new object[] {
                new RobotSettings(
                    new Map(10, -10, 10, -10),
                    new Point(0, 0), 
                    new List<Vector>(){ 
                        new Vector("W", 5)  }),
                "[W5];S0,0;M-10,10,-10,10"},
            };

        [Theory]
        [MemberData(nameof(Data), parameters: 2)]
        public void StringifyInput_ShouldReturnCorrectString(RobotSettings settings, string expected)
        {
            //Act
            string actual = settings.StringifyInput(settings);

            //Assert
            Assert.True(expected.IsDeepEqual(actual));
        }
    }
}
