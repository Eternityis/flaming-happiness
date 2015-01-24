using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace WindowsGame1.Engine.Handlers.Logic
    {
   public class Impulse
        {
            public double force;
            public double heading;
       public double transX;
       public double transY;
       public Vector2 compForces;
       private const double conversion = 57.2957795;
       private const double toRad = .0174532925;


       public static void sudoku(Impulse i) //TODO 
       {
           i  = null;
       }

        public Impulse(double f, double h)
        {
            force = f;
            heading = h;
            compForces.X = (float)(f*Math.Cos(h*toRad)); //TODO create a new vector type that accepts two doubles
            compForces.Y = (float)(f*Math.Sin(h*toRad));
            Console.WriteLine("Bob.  force: " + force + " X: "+ compForces.X + " Y: " + compForces.Y + " Y from eq: " + f*Math.Sin(h) + " Heading: " + heading);
        }

       public Impulse(Vector2 vec) //takes input of forces as avector, (the y and x components already calculated) and determines the impulses direction and force in dir
       {

           compForces = vec;  //save the component forces as a vector
           heading = Math.Atan2(vec.X, vec.Y)*conversion; //calculate heading from component forces
           force = Math.Sqrt((vec.X*vec.X + vec.Y*vec.Y)); //pythagorean to get force from components.  Multiplying is faster than using Math.Pow()
       }



       public static void solveImpulse(double x, double y, Impulse i)
       {
           i.heading = Math.Atan2(x, y)*conversion; //calculate heading from component forces
           i.force = Math.Sqrt((x*x + y*y)); //pythagorean to get force from components.  Multiplying is faster than using Math.Pow()
           i.compForces = new Vector2((float)x, (float)y);
       }

        }
    }
