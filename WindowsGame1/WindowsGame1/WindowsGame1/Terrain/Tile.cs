using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.Terrain
    {
    class Tile
    {

        public Boolean isPassable;

        public Texture2D Texture { get; set; }
    public Rectangle MapRectangle { get; set; }

    public Tile(Rectangle rectangle)
    {
        MapRectangle = rectangle;
    }





        }
 class GrassTile: Tile
    {

Tile.isPassable = false;




        }
    }
