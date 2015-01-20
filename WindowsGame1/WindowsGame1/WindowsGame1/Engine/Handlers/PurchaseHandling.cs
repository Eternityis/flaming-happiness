using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Engine.Actors;

namespace WindowsGame1.Engine.Handlers
    {
  public static class PurchaseHandling
        {

      public static bool handlePurchase(Ship ship)
      {
//check if player can afford    
          if (Player.wealth > ship.wealthCost && Player.materials > ship.materialCost && Player.crew > ship.crewCost)
          {
              Player.wealth -= ship.wealthCost;
              Player.materials -= ship.materialCost;
              Player.crew -= ship.crewCost;
Console.WriteLine(ship + " has been purchased by " + Player.name);
              return true;
          }


Console.WriteLine(ship + " has not been purchased by " + Player.name);
          return false;
      }













        }
    }
