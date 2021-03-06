﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Engine;
using WindowsGame1.Engine.Actors;
using WindowsGame1.Engine.Handlers;
using WindowsGame1.Engine.Handlers.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace WindowsGame1.Engine.Game_Objects.Actors.Ships.Alliance
	{
	class ABattleship : Ship
		{
			//Sprites




		//Constructor

		public ABattleship(Vector2 spawnpoint)
		{



 affiliation = Affiliation.ALLIANCE;
 shipType = ShipType.BATTLESHIP;

			shipClass = "Alliance Battleship";
 //shipName = Resources.Names.pickAName(Affiliation.ALLIANCE);
		    spritePath = "Alliance/ABattleship/aBattleship";

//GRAPHICS


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
crew = crewCost;
maxCrew = crewCost;


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



//Physics
mass = 1000;


//THRUSTER ASSEMBLY:

this.thrusterList.Add(new Thruster(Thruster.Direction.A, 100 ));
this.thrusterList.Add(new Thruster(Thruster.Direction.F, 50 ));
this.thrusterList.Add(new Thruster(Thruster.Direction.P, 25 ));
this.thrusterList.Add(new Thruster(Thruster.Direction.S, 25 ));






shipRect = new Rectangle((int)navPack.location.X, (int)navPack.location.Y, Constants.BattleshipWidth, Constants.BattleshipLength);
PurchaseHandling.handlePurchase(this);
Lists.ShipList.Add(this);
navPack.location = spawnpoint;


		}//end of constructor

 public ABattleship()
	    {
	        
	    }


//public method






		}
	}
