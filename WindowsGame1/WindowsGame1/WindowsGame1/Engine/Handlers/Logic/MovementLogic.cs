using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WindowsGame1.Engine.Actors;
using WindowsGame1.Engine.Game_Objects;
using Microsoft.Xna.Framework;

namespace WindowsGame1.Engine.Handlers.Logic
{
    public static class MovementLogic 
    {

        public static List<Impulse> impulseList = new List<Impulse>(); 

//applied to each ship each tick

       public static void applyMovementLogic(Ship ship, Vector2 location, Point target) //tells ship where to go and shit. Triggers on clicks/orders
       {
           try
           {
               float conversion = (float) 57.2957795; //convert radians to degrees
               ship.navPack.targetHeading = (float) Math.Atan2(target.X - location.X, target.Y - location.Y)*conversion;  //dtermine target heading
               if (ship.navPack.targetHeading < 0)
                  {
                   ship.navPack.targetHeading += 360; //converts negative to positive, kind of like Pharrel Williams
                  }    
               ship.navPack.heading = ship.navPack.targetHeading; //TODO replace with rotatino and stuff, just for testing.
               //determine to turn clockwise or counterclockwise
               if (!ship.navPack.isFacingTarget() && !ship.navPack.isHeadingLocked)
              {
                  if (Math.Abs(ship.navPack.heading - ship.navPack.targetHeading) > Math.Abs(ship.navPack.heading + 360 - ship.navPack.targetHeading))
                  {
                      ship.navPack.turnDir = NavPack.TurnDir.RIGHT;
                  }
                  else
                  {
                      ship.navPack.turnDir = NavPack.TurnDir.LEFT;
                  }
                
              }

               else if (!ship.navPack.isFacingTarget())
               {
                   //cannot be reached currently TODO
               }
           }
           catch
           {
               Console.WriteLine("Something messed up in movement logic. " + location + "  " + target);
           }
   
        } //end applymovementlogic()







        public static void processMovement(Ship ship) //runs on tick
        {
            if (ship.navPack.isFacingTarget())
            {
                ship.navPack.turnDir = NavPack.TurnDir.NULL;
            }
/* 
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

*/ //deprecated

            foreach (Thruster thruster in ship.thrusterList) //TODO account for quadrants
            {
                if (thruster.isActive)
                {
                    float detHeading = 0;
                switch (thruster.direction)
                {

                    case Thruster.Direction.F:
                    {
                        detHeading = ship.navPack.heading + 180;
                            break;
                            }
                    case Thruster.Direction.A:
                    {
                        detHeading = ship.navPack.heading;
                                break;
                                }
                    case Thruster.Direction.S:
                    {
                        detHeading = ship.navPack.heading - 90;
                                    break;
                                    }
                    case Thruster.Direction.P:
                    {
                        detHeading = ship.navPack.heading + 90;
                            break;
                        }

                    }
                    impulseList.Add(new Impulse(thruster.thrust, detHeading));
                }
            }

//apply forces
         //use trig to determine how much to apply to vertical vs horizontal  ie. resolve forces 
            foreach (Impulse impulse in impulseList)
            {
            float finalX = 0, finalY = 0;
                if (impulse.heading > -.01 && impulse.heading < 90.01)//first quadrant
                {
                    impulse.transX =(float)Math.Sin((90 - impulse.heading))*impulse.force;
                    impulse.transY = (float) Math.Cos((90 - impulse.heading))*impulse.force; //dont forget to divide by mass later!
                    finalX += impulse.transX;
                    finalY += impulse.transY;
                }

                Vector2 finalTrans = new Vector2(finalX/ship.mass, finalY/ship.mass); //vector.x or y cannot be individually modified, so avector is made.
                ship.navPack.location += finalTrans;
            }



              
//TODO combine all impulses, make sure negatives work ok, start a race war




            if (ship.navPack.turnDir != NavPack.TurnDir.NULL)
            {
            switch (ship.navPack.turnDir)
                {
                case NavPack.TurnDir.LEFT: //TODO check this
                    {
                        ship.heading -= ship.RotSpeed; //TODO account for going past 0
                        if (ship.RotSpeed > Math.Abs(ship.heading - ship.navPack.targetHeading)) //avoid overshooting
                        {
                            ship.heading = ship.navPack.targetHeading;
                        }
                        break;
                    }
                case NavPack.TurnDir.RIGHT:
                    {
                        ship.heading += ship.RotSpeed;
                        if (ship.RotSpeed > Math.Abs(ship.heading - ship.navPack.targetHeading)) //avoid overshooting
                        {
                            ship.heading = ship.navPack.targetHeading;
                        }
                        break;
                    }
                }
            }

            if (ship.heading < 0)
            {
                ship.heading += 360;
            }

        Console.WriteLine("Processed movement for " + ship.shipName);
        }
    }
}
