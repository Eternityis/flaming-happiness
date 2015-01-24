using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Engine
    {
    static class Constants  //this class is almost TOO useful
    {
        public const int TICK = 1;
        public const int BattleshipWidth = 20;
        public const int BattleshipLength = 50;

    static double SinFast(int value)
    {
	switch (value)
	{
	    case 0:
		return 0;
	    case 1:
		return 0.841470984807897;
	    case 2:
		return 0.909297426825682;
	    case 3:
		return 0.141120008059867;
	    case 4:
		return -0.756802495307928;
	    case 5:
		return -0.958924274663138;
	    case 6:
		return -0.279415498198926;
	    case 7:
		return 0.656986598718789;
	    case 8:
		return 0.989358246623382;
	    case 9:
		return 0.412118485241757;
	    default:
		return Math.Sin(value);
	}
    }

    }
    }
