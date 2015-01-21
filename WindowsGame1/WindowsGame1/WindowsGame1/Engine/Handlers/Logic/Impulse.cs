using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Engine.Handlers.Logic
    {
   public class Impulse
        {
            public float force;
            public float heading;
       public float transX;
       public float transY;

        public Impulse(float f, float h)
        {
            force = f;
            heading = h;
        }
        }
    }
