using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WindowsGame1.Engine.Actors;
using Microsoft.Xna.Framework;

namespace WindowsGame1.Engine.Handlers.Logic
{
    public static class MovementLogic 
    {

//applied to each ship each tick

       public static void applyMovementLogic(Ship ship, Point location, Point target)
       {
           try
           {
               float conversion = (float) 57.2957795; //convert radians to degrees
               ship.targetHeading = (float) Math.Atan2(target.X - location.X, target.Y - location.Y)*conversion;  //dtermine target heading
               if (ship.targetHeading < 0)
                  {
                   ship.targetHeading += 360; //converts negative to positive, kind of like Pharrel Williams
                  }    
               ship.heading = ship.targetHeading; //TODO replace with rotatino and stuff, just for testing.
               //determine to turn clockwise or counterclockwise
               if (!ship.isFacingTarget() && !ship.isHeadingLocked)
              {
                  if (Math.Abs(ship.heading - ship.targetHeading) > Math.Abs(ship.heading + 360 - ship.targetHeading))
                  {
                      ship.turnDir = Ship.TurnDir.RIGHT;
                  }
                  else
                  {
                      ship.turnDir = Ship.TurnDir.LEFT;
                  }
                
              }

               else if (!ship.isFacingTarget())
               {
                   //cannot be reached currently TODO
               }
           }
           catch
           {
               Console.WriteLine("Something messed up in movement logic. " + location + "  " + target);
           }
   
        }


        public static void processMovement(Ship ship)
        {
            if (ship.isFacingTarget())
            {
                ship.turnDir = Ship.TurnDir.NULL;
            }

//calculate accelerations
            if (ship.thrustF != 0 && ship.speedF != ship.maxSpeed)
            {
                ship.accelF = ship.thrustF/ship.mass;
            }
            if (ship.thrustA != 0 && ship.speedA != ship.maxSpeed)
            {
                ship.accelA = ship.thrustA/ship.mass;
            }
            if (ship.thrustS != 0 && ship.speedS != ship.maxSpeed)
            {
                ship.accelS = ship.thrustS/ship.mass;
            }
            if (ship.thrustP != 0 && ship.speedP != ship.maxSpeed)
            {
                ship.accelP = ship.thrustP/ship.mass;
            }
//resolve opposing accelerations
            float oAccelF = ship.accelF;
            float oAccelA = ship.accelA;
            float oAccelS = ship.accelS;
            float oAccelP = ship.accelP;

            if (oAccelF > oAccelA)
            {
                ship.accelA = 0;
                ship.accelF -= oAccelA;
            }
            if (oAccelA > oAccelF)
            {
                ship.accelF = 0;
                ship.accelA -= oAccelF;
            }
           
             if (oAccelS > oAccelP)
            {
                ship.accelP = 0;
                ship.accelS -= oAccelP;
            }
            if (oAccelP > oAccelS)
            {
                ship.accelS = 0;
                ship.accelP -= oAccelS;
            }



                ship.speedF += ship.accelF;
                ship.speedA += ship.accelA;
                ship.speedS += ship.accelS;
                ship.speedP += ship.accelP;

//resolve opposing speeds
            if (ship.speedF > ship.speedA)
            {
                ship.speedF -= ship.speedA;
                ship.speedA = 0;
            }
            if (ship.speedA > ship.speedF)
            {
                ship.speedA -= ship.speedF;
                ship.speedF = 0;
            }
           
            if (ship.speedS > ship.speedP)
             {
                 ship.speedS -= ship.speedP;
                 ship.speedP = 0;
             }
            if (ship.speedP > ship.speedS)
            {
                ship.speedP -= ship.speedS;
                ship.speedS = 0;
            }


            if (ship.turnDir != Ship.TurnDir.NULL)
            {
                //handle rotation
            }


        Console.WriteLine("Processed movement for " + ship.shipName);
        }


    }
}
