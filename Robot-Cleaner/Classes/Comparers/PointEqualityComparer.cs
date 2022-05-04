using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Cleaner.Classes.RobotCleaner
{
    public class PointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point? x, Point? y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(Point obj)
        {
          int xHash = obj.X.GetHashCode();
          int yHash = obj.Y.GetHashCode();

            return xHash * yHash;
        }
    }
}
