using DeepEqual.Syntax;
using Robot_Cleaner.Classes.RobotCleaner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class VectorShould
    {

        public static IEnumerable<object[]> Data =>

        new List<object[]>
        {
            new object[]
         {
             new string[] { "W1", "E2" },
             new List<Vector> { new Vector("W", 1), new Vector("E", 2) }
         }
        };



        [Theory]
        [MemberData(nameof(Data), parameters: 2)]
        public void CreateListFromArr_ShouldReturnList(string[] arr, List<Vector> expected)
        {

            //Arrange
            Vector vector = new Vector();

            //Act
            var acutal = vector.CreateListFromArr(arr);

            //Assert

            Assert.True(expected.IsDeepEqual(acutal));

        }



    }
}



