using System;
using System.Collections.Generic;
using WindowsGame1.Engine.Actors;
using WindowsGame1.Engine.Handlers.Logic;
using Microsoft.Xna.Framework;

namespace WindowsGame1.Engine
{
    internal static class Lists //arrays are for  gays
    {
        public static List<String> NameList = new List<string>();
        public static List<Screens> ScreenList = new List<Screens>(); 
        public static List<Ship> ShipList = new List<Ship>();
        public static List<Ship> ShipClassList = new List<Ship>(); 
        public static List<Impulse> impulseMasterList = new List<Impulse>(); 

    }
}