using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Engine.Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1.Engine
    {
    class GameSettings  //Difficulty, Resolution and Controls should all go here.
        {
        public enum Difficulty
        {
            EASY,
            MEDIUM,
            HARD
        }

        public enum ResolutionOptions
        {
            SMALL,  //800x600
            MEDIUM, //1024x768
            LARGE   //1280x960
        }

         int x, y;


        public void setResolution(ResolutionOptions newResolution)
        {

        if (newResolution == ResolutionOptions.SMALL)
        {
            x = 800;
            y = 600;
        }
        else if (newResolution == ResolutionOptions.MEDIUM)
        {
            x = 1024;
            y = 768;
        }
        else //LARGE
        {
            x = 1280;
            y = 960;
        }
            Main.graphics.PreferredBackBufferHeight = y;
            Main.graphics.PreferredBackBufferWidth = x;
            Main.graphics.ApplyChanges();
        }


        }
    }
