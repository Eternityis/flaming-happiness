using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Engine.Game_Objects
    {
    public class Thruster
        {
        public enum Direction
        {
            F, //thruster facing forward, moves you back.
A, //main thruster
S,
P
        }

public Direction direction { get; set; }

public double thrust = 0; //newtons
public double mThrust { get; set; }

public bool isFunctional  = true;
public bool isActive = false;

        public Thruster(Direction dir, double targMThrust)
        {
            direction = dir;
            mThrust = targMThrust;
        }

        }
    }
