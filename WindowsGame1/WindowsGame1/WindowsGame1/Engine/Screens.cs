using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using WindowsGame1.Engine.Handlers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Net;

namespace WindowsGame1.Engine
    {
  public  class Screens
    {
        public string screenName; //display
        public Texture2D screenTexture; //assigned by image loader based on name, don't touch or try to add to constructor
        public Boolean isActive = false;
        public SceneHandling.Scenes relevantScene;





        public static void generateScreens()  //preload all screens, this is gonna get long so maybe offload later?
        {
            new Screens("splash", SceneHandling.Scenes.Splash,  true  );
            new Screens("mainmenu", SceneHandling.Scenes.MainMenu,  false  );
            new Screens("ingame", SceneHandling.Scenes.Ingame, false);
        }

        public Screens(string newName, SceneHandling.Scenes newScene, bool newActive)
        {
            screenName = newName;
            relevantScene = newScene;
            Lists.ScreenList.Add(this);
            isActive = newActive; //should this screen be marked as the active one?
        }

 
    }
    }
