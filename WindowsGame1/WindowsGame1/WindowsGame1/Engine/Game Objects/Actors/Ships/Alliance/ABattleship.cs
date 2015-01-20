using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Engine;
using WindowsGame1.Engine.Actors;
using WindowsGame1.Engine.Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.Engine.Game_Objects.Actors.Ships.Alliance
	{
	class ABattleship : Ship
		{
			//Sprites




		//Constructor

		public ABattleship(Point spawnpoint)
		{



 affiliation = Affiliation.ALLIANCE;
 shipType = ShipType.BATTLESHIP;

			shipClass = "Alliance Battleship";
 //shipName = Resources.Names.pickAName(Affiliation.ALLIANCE);

//build cost
 materialCost = 100;
crewCost = 100;
wealthCost = 100;

//bools
isDead = false;
isDamaged = false;
isVeryDamaged = false;
isShielded = false;
isArmed = true;
isDisabled = false;
isDisarmed = false;
isImmobillized =false;
isSupplyDepleted = false;
isFireAtWill = Player.shipsSpawnFireAtWill;

//stats
hp = 1000;
shielding = 500; //maximum range at which shields have a 50% chance of working
supply = 500;    //total 
supplyPerShot = 1; //base supply use per shot
speed = 0; //current speed
maxSpeed = 10; //maximum speed
crew = crewCost;
			maxCrew = crewCost;

location = spawnpoint;

//weapons
	//Lasers
		//forward
forwardGuns = 10; //number of
forwardDamage = 20; //damage each
forwardPenetration = Penetration.VERY_HIGH; //penetrating power 
		//side
sideGuns = 4; //number of
sideDamage = 10; //damage each
sidePenetration = Penetration.MEDIUM;//penetrating power 
	//Missiles
 missileRange = 400;
			isMissileAuthorized = Player.shipsSpawnMissileAuthorized;
missileDamage = 40;
maxMissileStock = 12;
missileStock = maxMissileStock;

//Combat Settings
isHeadingLocked = false;



//Physics
		    mass = 1000;


shipRect = new Rectangle((int)location.X, (int)location.Y, Constants.BattleshipWidth, Constants.BattleshipLength);
PurchaseHandling.handlePurchase(this);
Lists.ShipList.Add(this);


		}//end of constructor

		









		}
	}
