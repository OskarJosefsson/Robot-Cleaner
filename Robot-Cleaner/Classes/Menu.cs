
using Robot_Cleaner.Classes.RobotCleaner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Robot_Cleaner
{
    public class Menu
    {
        private bool mapInput = false;
        private bool startInput = false;
        private bool routeInput = false;
        RobotSettings robotSettings = new RobotSettings();

        public void DisplayMenu()
        {
            bool correctInput = false;
            string input = "";
            while (correctInput == false)
            {

                Console.Clear();
                Console.WriteLine("Enter Mapsize (M)");
                Console.WriteLine("Enter Startingposition (S)");
                Console.WriteLine("Enter Route (R)");

                if (InputCheck())
                {
                    
                    input = robotSettings.StringifyInput(robotSettings);
                    Console.WriteLine("Clean the Route! (C)");
                }
                
                Console.WriteLine("Exit (E)");
                string menuOption = Console.ReadLine();

                if (menuOption == "M")
                {

                    mapInput = false;
                    robotSettings.Map = MapMenu(); 

                }
                else if (menuOption == "S")
                {
                    startInput = false;
                    robotSettings.CurrentPosition = StartingPositionMenu();
                }

                else if (menuOption == "R")
                {
                    routeInput = false;
                    robotSettings.Vectors = RouteMenu();
                }

                else if(menuOption == "E")
                {
                    correctInput = true;
                    Console.Clear();
                    Environment.Exit(0);
                }

                else if (menuOption == "C")
                {

                    if (InputCheck())
                    {
                        RobotCleaner rc = new RobotCleaner();
                        CleaningResult result = rc.ExecuteRoute(input);
                        DisplayResult(result);



                         mapInput = false;
                         startInput = false;
                         routeInput = false;


    }
                    else
                    {
                        Console.WriteLine("Insert all settings");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    
                }

                else
                {
                    Console.Write("Invalid menu option! Press enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void DisplayResult(CleaningResult result)
        {

                Console.WriteLine(result.Message);
                Console.WriteLine("Route taken");
                var Results = result.RouteToString();
                Console.WriteLine(Results);
                Console.WriteLine("Unique points cleaned");
                var uniquePointsList = result.GetUniquePoints();
                List<Point> uniquePoints = uniquePointsList.ToList();
                Results = result.RouteToString(uniquePoints);
                Console.WriteLine(Results);
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
                Console.Clear();

        }

        public Map MapMenu()
        {
            Map map = new Map();
            while (!mapInput)
            {
                Console.WriteLine("Enter size of area");
                try
                {
                    Console.WriteLine("Enter max x-value");
                    map.XMax = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter min x-value");
                    map.XMin = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter max y-value");
                    map.YMax = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter min y-value");
                    map.YMin = Convert.ToInt32(Console.ReadLine());
                    mapInput = true;
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Not a correct input, please enter only numbers");
                    Console.Clear();
                }

            }
            
            return map;
        }

        public Point StartingPositionMenu ()
        {
            int xStart = 0;
            int yStart = 0;

            while (!startInput)
            {
                try
                {
                    Console.WriteLine("Enter Start x-axis");
                    xStart = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Start y-axis");
                    yStart = Convert.ToInt32(Console.ReadLine());

                    startInput=true;
                    Console.Clear();
                }
                catch 
                {
                    Console.WriteLine("Not a number, please enter numbers only");
                    Console.Clear();
                }
            }



            Point start = new Point (xStart, yStart);
            Console.Clear();
            return start;

        }

        public List<Vector> RouteMenu ()
        {
            Vector vector = new Vector();
            bool another = true;
            List<Vector> route = new List<Vector>();
            
            while (another)
            {
                Console.WriteLine("Enter vector. Examples(W5, E3, N1, S3)");
                string vectorString = Console.ReadLine();
                vector = vector.StringToVector(vectorString);
                route.Add(vector);
                Console.WriteLine("Press Enter to add another vector, write S to stop");
                string answer = Console.ReadLine();

                if (answer == "S")
                {
                    another = false;
                    routeInput = true;
                    
                }

                Console.Clear();
            }

            return route;
        }

        private bool InputCheck()
        {

            if (routeInput == true && startInput == true && mapInput == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
