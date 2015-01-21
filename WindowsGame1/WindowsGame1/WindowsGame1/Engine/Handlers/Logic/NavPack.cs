using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Engine.Handlers.Logic
    {
    class NavPack
    {
        public float Heading;
        public float desiredHeading;
    
        public bool isAccel;
        public bool isDecel;

        public enum TurnDir
        {
            LEFT,
            RIGHT,
            NULL
        }

        public TurnDir turnDir1206604367 { get; set; }
    }
    }
