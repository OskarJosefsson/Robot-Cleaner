using Robot_Cleaner.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Robot_Cleaner.Classes.RobotCleaner
{
    public class RobotSettings
    {

        public Map Map { get; set; }

        public Point CurrentPosition { get; set; }

        public List<Vector> Vectors { get; set; }

        public RobotSettings(Map map, Point position, List<Vector> vectors)
        {
            Map = map;
            CurrentPosition = position;
            Vectors = vectors;
        }

        public RobotSettings()
        {

        }


        public string StringifyInput(RobotSettings settings)
        {
            string vectorString = "";
            int i = 0;

            foreach (var item in settings.Vectors)
            {

                if (i == 0)
                {
                    i++;
                    vectorString +=item.Direction+item.Length;
                }
                else
                {
                    i++;
                    vectorString += "," + item.Direction+item.Length;
                }

            }

            return new string($"[{vectorString}];S{settings.CurrentPosition.X},{settings.CurrentPosition.Y};M{settings.Map.XMin},{settings.Map.XMax},{settings.Map.YMin},{settings.Map.YMax}");
        }


    }
}
