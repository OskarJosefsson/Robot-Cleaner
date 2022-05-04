using Robot_Cleaner.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Cleaner.Classes.RobotCleaner
{
    public class Point
    {

        public int X;

        public int Y;

        public Point()
        {

        }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }


        /// <summary>
        /// Format: "Sx,y"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Point CreateStartPoint(string input)
        {
            input = input.ReplaceSeveral(new string[] { "S" });

            string[] arr = input.Split(',');

            if (int.TryParse(arr[0], out int value) && int.TryParse(arr[1], out int value2))
            {
                int startX = value;
                int startY = value2;

                return new Point(startX, startY);
            }

            return null;
        }
    }
}
