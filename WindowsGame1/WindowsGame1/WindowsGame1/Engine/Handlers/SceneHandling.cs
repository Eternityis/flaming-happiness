using System;

namespace WindowsGame1.Engine.Handlers
    {
   static class SceneHandling  //this class contains the gameloops, segregated by menu to simplify input control
        {




       public enum Scenes
        {
            Splash = 0, //Progression through menu screens is handled via currentScene++;
            MainMenu = 1,           //Returning here should reset game
            CharacterSelection = 2, //This shouldnt be accessible more than once
            Ingame = 3,             //Whenever actually playing
            Paused = 25,             //pause menu
            TESTZONE = 100            //if we need to test control configs or try weird shit do it here so we dont fuck up the rest of the code
        }

       public static Scenes currentScene = new Scenes(); //backing
       public static Boolean reDraw = true;



       public static void advanceScene()  //avoid using outside menus
       {
           Console.WriteLine("Switching from " + currentScene + " to " + (currentScene+1));  //use this to check everything is working
           currentScene++;
           reDraw = true;
           Console.WriteLine("Now arriving at " + currentScene);
       }

       public static void setScene(Scenes targetScene)  //
       {
           Console.WriteLine("Switching from " + currentScene + " to " + targetScene);  //use this to check everything is working
           currentScene = targetScene;
           reDraw = true;
           Console.WriteLine("Now arriving at " + currentScene);
       }

       public static void handleScene()
       {
           int sceneInt = (int)currentScene; //put gameloop for each scene here
           switch (currentScene)
           {
               case Scenes.Splash:
                  
                   InputHandling.handleInput();
                   break;

               case Scenes.MainMenu:
               
                  InputHandling.handleInput();
                   break;
                
                case Scenes.CharacterSelection:

                  InputHandling.handleInput();

                   break;

                case Scenes.Ingame:

                  InputHandling.handleInput();

                   break;

                case Scenes.Paused:

                  InputHandling.handleInput();

                   break;

                case Scenes.TESTZONE:

                  InputHandling.handleInput();

                   break;


           }
       }







        }
    }
