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
            public float force;
            public float heading;
       public float transX;
       public float transY;
       public Vector2 compForces;
       public bool killMe = false;
       private const float conversion = (float)57.2957795;

       public static void sudoku(Impulse i)
       {
           i  = null;
       }

        public Impulse(float f, float h)
        {
            force = f;
            heading = h;
            Lists.impulseMasterList.Add(this); //add to master list for garbage collection when unneeded
        }

       public Impulse(Vector2 vec) //takes input of forces as avector, (the y and x components already calculated) and determines the impulses direction and force in dir
       {

           compForces = vec;
           heading = (float)Math.Atan2(vec.X, vec.Y)*conversion;
           force = 
       }



        }
    }
