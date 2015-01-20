using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Engine.Game_Objects
	{
   public abstract class AffiliationClass  //Factions
		{
	public	enum Affiliation
		{
EMPIRE,
ALLIANCE
		}
public Affiliation affiliation { get; set; }
		}
	}
