using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1.Engine.Handlers.Logic
	{
	public class NavPack
	{




		public bool isHeadingLocked { get; set; }

	
		public bool isAccel;
		public bool isDecel;

//Spawning
		public Vector2 location { get; set; } //location of ship

//Movement
		public int speed { get; set; } //current speed
		public int maxSpeed { get; set; } //maximum speed forward
		public float heading { get; set; } //direction the ship is facing
		public float targetHeading{get; set; }
		//Physics based movement


		public Point targetPoint { get; set; }



List<Impulse> impulseList = new List<Impulse>(); 

		public enum TurnDir
		{
			LEFT,
			RIGHT,
			NULL
		}

		public TurnDir turnDir { get; set; }




		public bool isFacingTarget()
		{
			return (heading == targetHeading);
		}


		public NavPack()
		{
			heading = 0;
			targetHeading = 0;
			isAccel = false;
			isDecel = false;
			turnDir = TurnDir.NULL;
		}

		public NavPack(Vector2 loc)
		{
			heading = 0;
			targetHeading = 0;
			isAccel = false;
			isDecel = false;
			turnDir = TurnDir.NULL;
		    location = loc;
		}

	}
}
