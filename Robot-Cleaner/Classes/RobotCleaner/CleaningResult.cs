using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Cleaner.Classes.RobotCleaner
{
    public class CleaningResult
    {
        public string Message { get; set; }

        public List<Point> Route { get; set; }

        public CleaningResult()
        {

        }

        public CleaningResult(string message, List<Point> route)
        {
            Message = message;
            Route = route;
        }

        public IEnumerable<Point> GetUniquePoints ()
        {
            PointEqualityComparer pointEqualityComparer = new PointEqualityComparer();
            var uniquePoints = Route.Distinct(pointEqualityComparer);


            return uniquePoints;
        }


        public string RouteToString()
        {
            string result = "";
            foreach (var item in Route)
            {
                result += ($"{item.X.ToString()},{item.Y.ToString()};");
            }

            return result;
        }

        public string RouteToString(List<Point> resultList)
        {
            var result = "";
            foreach (var item in resultList)
            {
               result += ($"{item.X},{item.Y};");
            }

            return result;
        }


    }
}
