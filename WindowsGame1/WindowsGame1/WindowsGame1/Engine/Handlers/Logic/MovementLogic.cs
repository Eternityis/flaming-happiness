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

//applied to each ship each tick

       public static void applyMovementLogic(Ship ship, Vector2 location, Point target) //tells ship where to go and shit. Triggers on clicks/orders
       {
           try
           {
               double conversion =  57.2957795; //convert radians to degrees
               ship.navPack.targetHeading =  Math.Atan2(target.X - location.X, target.Y - location.Y)*conversion;  //dtermine target heading
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




////////////////////////////////////////


        public static void processMovement(Ship ship) //runs on tick
        {
            if (ship.navPack.isFacingTarget())
            {
                ship.navPack.turnDir = NavPack.TurnDir.NULL;
            }

            foreach (Thruster thruster in ship.thrusterList) //TODO account for quadrants/negatives
            {
                if (thruster.isActive)
                {
                    double detHeading = 0;
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
                    ship.navPack.impulseList.Add(new Impulse(thruster.thrust, detHeading));
                }
            }

/*
//apply forces
         //use trig to determine how much to apply to vertical vs horizontal  ie. resolve forces 
            foreach (Impulse impulse in impulseList)  //TODO haha no, trash all this and use the new compforces vector divided by mass to get directional accelerations
            {
            double finalX = 0, finalY = 0;
                if (impulse.heading > -.01 && impulse.heading < 90.01)//first quadrant
                {
                    impulse.transX =Math.Sin((90 - impulse.heading))*impulse.force;
                    impulse.transY =  Math.Cos((90 - impulse.heading))*impulse.force; //dont forget to divide by mass later!
                    finalX += impulse.transX;
                    finalY += impulse.transY;
                }

                Vector2 finalTrans = new Vector2((float)(finalX/ship.mass), (float)(finalY/ship.mass)); //vector.x or y cannot be individually modified, so avector is made.
                ship.navPack.location += finalTrans;
            }
*/
              
//TODO combine all impulses, make sure negatives work ok, start a race war
Vector2 comp = new Vector2(0,0);
            foreach (Impulse i in ship.navPack.impulseList)
            {
                comp += i.compForces;
            }
ship.navPack.impulseList.Clear();
ship.navPack.actingImpulse = new Impulse(comp);
ship.navPack.impulseList.Add(ship.navPack.actingImpulse);
            if (ship.navPack.turnDir != NavPack.TurnDir.NULL)
            {
            switch (ship.navPack.turnDir)
                {
                case NavPack.TurnDir.LEFT: //TODO check this
                    {
                        ship.navPack.heading -= ship.RotSpeed; //TODO account for going past 0
                        if (ship.RotSpeed > Math.Abs(ship.navPack.heading - ship.navPack.targetHeading)) //avoid overshooting
                        {
                            ship.navPack.heading = ship.navPack.targetHeading;
                        }
                        break;
                    }
                case NavPack.TurnDir.RIGHT:
                    {
                        ship.navPack.heading += ship.RotSpeed;
                        if (ship.RotSpeed > Math.Abs(ship.navPack.heading - ship.navPack.targetHeading)) //avoid overshooting
                        {
                            ship.navPack.heading = ship.navPack.targetHeading;
                        }
                        break;
                    }
                }
            }

            if (ship.navPack.heading < 0)
            {
                ship.navPack.heading += 360;
            }

        Console.WriteLine("Processed movement for " + ship.shipName);
        }
    }
}
