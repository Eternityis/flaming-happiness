﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Engine.Actors;
using Microsoft.Xna.Framework;

namespace WindowsGame1.Engine.Handlers
    {
    public static class SelectionHandling
        {




        public static void checkSelectionAgainstShipRects(Point selection)
        {
Player.selectedShips.Clear();
            foreach (Ship ship in Lists.ShipList)
            {
                if (ship.affiliation == Player.affiliation) //only select own ships
                {
                    if (ship.shipRect.Contains(selection))
                    {
                        Player.selectedShips.Add(ship);
                        Console.WriteLine("Selected" + ship.shipClass);
                    }
                }
            }
        }







        }
    }
