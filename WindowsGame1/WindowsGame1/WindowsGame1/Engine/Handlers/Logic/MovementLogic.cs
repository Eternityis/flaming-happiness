using System;
using System.Collections.Generic;
using System.Linq;
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
           ship.targetHeading = (float)Math.Atan2(location.X - target.X, location.Y - target.Y);
           ship.heading = ship.targetHeading; //TODO replace with rotatino and stuff, just for testing.
           if (ship.isFacingTarget() && !ship.disabledF)
           {
               ship.thrustF = ship.mThrustF;
           }
           else if(!ship.isFacingTarget())
           {
//cannot be reached currently TODO
           }
        }


        public static void processMovement(Ship ship)
        {
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



        Console.WriteLine("Processed movement for " + ship.shipName);
        }


    }
}
