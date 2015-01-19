using System;

using WindowsGame1.Engine.Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.Engine.Actors //"entities" make it sound like sci fi.  "actors" encompasses that perfect mix where you arent quite sure if its an rpgmaker rip off or a porno
	{
	abstract public class Ship
	{

	public Texture2D sprite; //Single sprite for now.
	public Texture2D damagedSprite;
	public Texture2D veryDamagedSprite;
	public Texture2D deadSprite;

	public	enum Penetration
		{
LOW,
MEDIUM,
HIGH,
VERY_HIGH,
ABSOLUTE
		}

	public	enum ShipType
		{
BATTLESHIP,
CRUISER,
ESCORT,
CARRIER,
FIGHTER
		}

	public	enum Affiliation
		{
EMPIRE,
ALLIANCE
		}
public Affiliation affiliation { get; set; }
public ShipType shipType { get; set; }
   
	 public string shipClass{ get; set; } //name displayed, ie: Cruiser
	  public abstract string shipName { get; set; } //custom name, "IS Bismark"

//build cost
 public abstract int materialCost{ get; set; }
 public abstract int crewCost{ get; set; }
 public abstract int wealthCost{ get; set; }

//bools
		  public abstract bool isDead { get; set; }
		  public abstract bool isDamaged { get; set; }//display damagedSprite
		  public abstract bool isVeryDamaged{ get; set; } //display veryDamagedSprite
		  public abstract bool isShielded{ get; set; } //has shields active
		  public abstract bool isArmed{ get; set; }    //carries weapons
		  public abstract bool isDisabled{ get; set; } //cant move, shoot etc
		  public abstract bool isDisarmed{ get; set; } //fire control hit and can't shoot
		  public abstract bool isImmobillized{ get; set; } //engine hit and can't move
		  public abstract bool isSupplyDepleted{ get; set; }

//stats
		  public abstract int hp{ get; set; }
		  public abstract int shielding{ get; set; } //maximum range at which shields have a 50% chance of working
		  public abstract int supply{ get; set; }    //total 
		  public abstract int supplyPerShot{ get; set; } //base supply use per shot
		  public abstract int speed{ get; set; } //current speed
		  public abstract int maxSpeed{ get; set; } //maximum speed


		 public abstract  Vector2 location{ get; set; } //location of ship

//weapons
	//Lasers
		//forward
		  public abstract int forwardGuns{ get; set; } //number of
		  public abstract int forwardDamage{ get; set; } //damage each
		Penetration forwardPenetration{ get; set; } //penetrating power 
		//side
		  public abstract int sideGuns{ get; set; } //number of
		  public abstract int sideDamage{ get; set; } //damage each
		Penetration sidePenetration{ get; set; } //penetrating power 
	//Missiles
		  public abstract int missileRange;
		  public abstract bool isMissileAuthorized;
		  public abstract int missileDamage{ get; set; }
		  public abstract int missileStock{ get; set; }











	}
	}
