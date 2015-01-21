using System;
using WindowsGame1.Engine.Game_Objects;
using WindowsGame1.Engine.Game_Objects.Actors.Ships.Alliance;
using WindowsGame1.Engine.Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.Engine.Actors
	//"entities" make it sound like sci fi.  "actors" encompasses that perfect mix where you arent quite sure if its an rpgmaker rip off or a porno
{
	public abstract class Ship : AffiliationClass
	{

//Graphics
		static public Texture2D sprite { get; set; } //Single sprite for now.
         public string spritePath{get; set;}
		static public Texture2D damagedSprite { get; set; }
		static public Texture2D veryDamagedSprite { get; set; }
		static public Texture2D deadSprite { get; set; }
		static public Texture2D engineGlow { get; set; }
		static public Texture2D thrusterglow { get; set; }
		public Rectangle shipRect { get; set; }

		public enum Penetration
		{
			LOW,
			MEDIUM,
			HIGH,
			VERY_HIGH,
			ABSOLUTE
		}

		public enum ShipType
		{
			BATTLESHIP,
			CRUISER,
			ESCORT,
			CARRIER,
			FIGHTER
		}

		public enum TurnDir
		{
			LEFT,
			RIGHT,
			NULL
		}

public TurnDir turnDir { get; set; }


		public ShipType shipType { get; set; }

		public string shipClass { get; set; } //name displayed, ie: Cruiser
		public string shipName { get; set; } //custom name, "IS Bismark"
public string folderName { get; set; }
public string fileName { get; set; }

//build cost
		public int materialCost { get; set; }
		public int crewCost { get; set; }
		public int wealthCost { get; set; }

//bools
		public bool isDead { get; set; }
		public bool isDamaged { get; set; } //display damagedSprite
		public bool isVeryDamaged { get; set; } //display veryDamagedSprite
		public bool isShielded { get; set; } //has shields active
		public bool isArmed { get; set; } //carries weapons
		public bool isDisabled { get; set; } //cant move, shoot etc
		public bool isDisarmed { get; set; } //fire control hit and can't shoot
		public bool isImmobillized { get; set; } //engine hit and can't move
		public bool isSupplyDepleted { get; set; }

//stats
		public int hp { get; set; }
		public int shielding { get; set; } //maximum range at which shields have a 50% chance of working


//Supply
		public int supply { get; set; } //total 
		public int supplyPerShot { get; set; } //base supply use per shot
		public int missileStock { get; set; }
		public int maxMissileStock { get; set; }
		public int crew { get; set; }
		public int maxCrew { get; set; }



//Spawning
		public Vector2 location { get; set; } //location of ship

//Movement
		public int speed { get; set; } //current speed
		public int maxSpeed { get; set; } //maximum speed forward
		public float heading { get; set; } //direction the ship is facing
		public float targetHeading{get; set; }
		//Physics based movement
		public struct Impulse
		{
			public int force;
			public int duration;
			public int heading;
		}

		public Point targetPoint { get; set; }
		public int mass { get; set; }

		public float thrustF { get; set; } //current
		public float thrustP { get; set; }
		public float thrustS { get; set; }
		public float thrustA { get; set; }
		public float mThrustF { get; set; } //maximum
		public float mThrustP { get; set; }
		public float mThrustS { get; set; }
		public float mThrustA { get; set; }
		public bool disabledF { get; set; } //is controllable
		public bool disabledP { get; set; }
		public bool disabledS { get; set; }
		public bool disabledA { get; set; }
		public float accelF { get; set; }//current
		public float accelP { get; set; }
		public float accelS { get; set; }
		public float accelA { get; set; }
		public float mAccelF { get; set; }//max
		public float mAccelP { get; set; }
		public float mAccelS { get; set; }
		public float mAccelA { get; set; }
		public float speedF { get; set; }//max
		public float speedP { get; set; }
		public float speedS { get; set; }
		public float speedA { get; set; }
	
	

		public float RotSpeed { get; set; } //rotational speed
		public float MRotSpeed { get; set; } //maximum

		


//weapons
		//Lasers
		//forward
		public int forwardGuns { get; set; } //number of
		public int forwardDamage { get; set; } //damage each
		public Penetration forwardPenetration { get; set; } //penetrating power 
		//side
		public int sideGuns { get; set; } //number of
		public int sideDamage { get; set; } //damage each
		public Penetration sidePenetration { get; set; } //penetrating power 
		//Missiles
		public int missileRange { get; set; }
		public bool isMissileAuthorized { get; set; }
		public int missileDamage { get; set; }


//Combat Settings
		public bool isHeadingLocked { get; set; }
		//wont turn when moving, reduces speed all directions but forward by 60%
		public bool isFireAtWill { get; set; }
		public bool isReducedSpeed { get; set; } //Ship moves at 75% speed


//public methods

		public bool isFacingTarget()
		{
			return (heading == targetHeading);
		}

		public static void generateShipClassList()
		{
			Lists.ShipClassList.Add(new ABattleship());
		}







	}




}








