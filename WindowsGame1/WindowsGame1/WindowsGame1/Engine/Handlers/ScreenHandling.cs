using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Engine.Handlers
    {
   public static class ScreenHandling
        {

        public static Screens handleScreen()
        {
      foreach (Screens screen in Lists.ScreenList)
     {   
         
         if (screen.screenTexture != null && screen.relevantScene == SceneHandling.currentScene)
         {
             return screen;
         }
     }
            return null;
        }





        }
    }
