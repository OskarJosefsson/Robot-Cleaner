using Robot_Cleaner.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Robot_Cleaner.Classes.RobotCleaner
{
    public class Vector
    {
        public string Direction { get; set; }
        public int Length { get; set; }

        public Vector(string direction, int length)
        {
            Direction = direction;
            Length = length;
        }

        public Vector()
        {

        }

        public List<Vector> CreateListFromArr(string[] vectorArr)
        {
            List<Vector> list = new List<Vector>();
            foreach (var item in vectorArr)
            {
                var vector = StringToVector(item);

                if(vector != null)
                {
                    list.Add(vector);
                }
                else
                {
                    return null;
                }
                
            }

            return list;
        }

        /// <summary>
        /// Format: "[x,y,...]"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// 
        public List<Vector> CreateListFromString(string str)
        {
            str = str;
            str = str.ReplaceSeveral(new string[] { "[","]" });
            var vectorArr = str.Split(',');
            var list = CreateListFromArr(vectorArr);

            if(list != null)
            {
                return list;
            }

            else
            {
                return new List<Vector>();
            }
            
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Returns Vector if succesfull else null</returns>
        /// 
        
        public Vector StringToVector (string str)
        {
            
            string newString = "";
            if (CheckFormat(str))
            {
                string direction = Convert.ToString(str[0]);
                int length;
                

                for (int i = 1; i < str.Length; i++)
                {
                    newString += Convert.ToString(str[i]);
                }
                if(int.TryParse(newString, out int result))
                {
                    length = result;
                }
                else
                {
                    return null;
                }

                return new Vector(direction, length);
            }
            else
            {
                return null;
            }

            
        }

        private bool CheckFormat(string vector)
        {
            return (Regex.IsMatch(vector, @"^[WENSwens]{1}\d*$"));
        }
    }
}
