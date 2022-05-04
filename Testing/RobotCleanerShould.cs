using DeepEqual.Syntax;
using Robot_Cleaner.Classes.RobotCleaner;
using System.Collections.Generic;
using Xunit;

namespace Testing
{
    
    public class RobotCleanerShould
    {
        
        public static IEnumerable<object[]> Data =>
    
            new List<object[]>
    {
            new object[] 
            { "[W5];S0,0;M-10,10,-10,10",
                "Route completed successfully",
                new List<Point>()
                { new Point(0,0),
                    new Point(-1, 0), 
                    new Point(-2, 0), 
                    new Point(-3, 0), 
                    new Point(-4, 0), 
                    new Point(-5, 0) 
                } 
            },

            new object[] 
            { 

                "[E5];S0,0;M-1,1,-1,1",
                "Out of bounds after (1,0) while going in the E direction",
                new List<Point>
                { new Point(0, 0),
                  new Point(1, 0)}},
            
            };

        [Theory]
        [MemberData(nameof(Data), parameters:3)]
        public void ExecuteRoute_ShouldReturnACorrectCleaningResult(string input,string message, List<Point> list)
        {
            //Arrange
            CleaningResult cleaningResult = new CleaningResult(message,list);
           
            RobotCleaner rc = new RobotCleaner();

            //Act
            CleaningResult testResult = rc.ExecuteRoute(input);

            //Assert
            Assert.True(cleaningResult.IsDeepEqual(testResult));
        }


    }
}