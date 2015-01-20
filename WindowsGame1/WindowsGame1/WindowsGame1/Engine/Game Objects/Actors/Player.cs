using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using WindowsGame1.Engine.Game_Objects;


namespace WindowsGame1.Engine.Actors
    {
       public static  class Player
        {

            public static Ship.Affiliation affiliation = AffiliationClass.Affiliation.ALLIANCE; //TESTING

             public static string name; //name ot be displayed

             public static int materials; //resources in stock
             public static int wealth;
             public static int crew;


//Settings
             public static bool shipsSpawnMissileAuthorized = false;
             public static bool shipsSpawnFireAtWill = true;

             public static List<Ship> selectedShips = new List<Ship>();









        }
    }
