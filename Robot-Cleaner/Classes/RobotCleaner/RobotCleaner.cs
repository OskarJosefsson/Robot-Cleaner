﻿
using Robot_Cleaner.Classes.Extensions;
using Robot_Cleaner.Classes.RobotCleaner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Cleaner.Classes.RobotCleaner
{
    public class RobotCleaner
    {
        private List<Point> visitedPoints = new List<Point>();

        public RobotSettings Settings { get; set; }

        public RobotCleaner()
        {

        }

        public CleaningResult ExecuteRoute(string input)
        {
            InputHandler(input);
            if(Settings.Vectors != null)
            {
                foreach (var vector in Settings.Vectors)
                {
                    visitedPoints.Add(new Point(Settings.CurrentPosition.X, Settings.CurrentPosition.Y));

                    for (int i = 0; i < vector.Length; i++)
                    {
                        if (BoundryCheck(Settings.CurrentPosition, Settings.Map))
                        {
                            Move(vector.Direction);
                        }

                        else
                        {
                            return new CleaningResult($"Out of bounds after ({Settings.CurrentPosition.X},{Settings.CurrentPosition.Y}) while going in the {vector.Direction} direction", visitedPoints);
                        }

                    }
                }
            }


            return new CleaningResult("Route completed successfully", visitedPoints);
        }

        private void InputHandler(string input)
        {
            //[W5,E3];S0,0;M-10,10,-10,10
            Map map = new Map();
            Point start = new Point();
            Vector vector = new Vector();
            var inputArr = input.Split(';');
            Settings = new RobotSettings(map.CreateMap(inputArr[2]), start.CreateStartPoint(inputArr[1]), vector.CreateListFromString(inputArr[0]));

        }

        private void Move(string vector)
        {
            Point newPoint;

            switch (vector.ToUpper())
            {
                case "N":
                    Settings.CurrentPosition.Y += 1;

                         newPoint = new Point(Settings.CurrentPosition.X, Settings.CurrentPosition.Y);
                    visitedPoints.Add(newPoint);
                    break;

                case "S":

                    Settings.CurrentPosition.Y -= 1;

                    newPoint  = new Point(Settings.CurrentPosition.X, Settings.CurrentPosition.Y);
                    visitedPoints.Add(newPoint);
                    

                    break;

                case "W":

                       Settings.CurrentPosition.X -= 1;

                       newPoint = new Point(Settings.CurrentPosition.X, Settings.CurrentPosition.Y);
                       visitedPoints.Add(newPoint);
                    

                    break;

                case "E":

                    Settings.CurrentPosition.X += 1;

                     newPoint = new Point(Settings.CurrentPosition.X, Settings.CurrentPosition.Y);
                     visitedPoints.Add(newPoint);
                    
                    break;
            }
        }

        private bool BoundryCheck (Point p, Map map)
        {
            if(p.X == Settings.Map.XMax || p.X == Settings.Map.XMin || p.Y == Settings.Map.YMax || p.Y == Settings.Map.YMin)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



    }






}