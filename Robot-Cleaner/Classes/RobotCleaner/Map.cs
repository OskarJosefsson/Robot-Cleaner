using Robot_Cleaner.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Cleaner.Classes.RobotCleaner
{

    public class Map
    {

        public int XMax { get; set; }
        public int XMin { get; set; }
        public int YMax { get; set; }
        public int YMin { get; set; }

        public Map()
        {

        }

        public Map(int xMax, int xMin, int yMax, int yMin)
        {
            XMax = xMax;
            XMin = xMin;
            YMax = yMax;
            YMin = yMin;
        }

        /// <summary>
        /// Format:"MxMin,xMax,yMin,yMax"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Map CreateMap(string input)
        {
            Map map = new Map();
            input = input.ReplaceSeveral(new[] { "M" });
            string[] arr = input.Split(',');

            if(int.TryParse(arr[0],out int XMax) 
                && int.TryParse(arr[1], out int XMin)
                && int.TryParse(arr[2], out int YMax) 
                && int.TryParse(arr[3], out int YMin))
            {
                map.XMin = XMax;
                map.XMax = XMin;
                map.YMin = YMax;
                map.YMax = YMin;
            }


            return map;
        }

    }
}
