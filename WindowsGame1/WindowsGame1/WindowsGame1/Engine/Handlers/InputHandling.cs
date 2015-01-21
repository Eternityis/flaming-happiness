using WindowsGame1.Engine.Actors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1.Engine.Handlers
    {
   public static class InputHandling //catches and processes input.  Called by SceneHandling
        {
           public static KeyboardState keyHandler = new KeyboardState();
            public static KeyboardState oldKeyHandler = new KeyboardState();
           public static MouseState mouseHandler = new MouseState();
            public static MouseState oldMouseHandler = new MouseState();

       public static void setInputState()
       {
           keyHandler = Keyboard.GetState();
           mouseHandler = Mouse.GetState();
       }

       public static bool inputHasChanged()
       {
           if (keyHandler == oldKeyHandler && !mouseButtonHasChanged())
           {
               return false;
           }
           return true;
       }

       public static bool buttonWasPressed(Keys key)
       {
           if (keyHandler == oldKeyHandler || !oldKeyHandler.IsKeyDown(key)   )
           {
               return false;
           }
           return true;
       }

       public static bool mouseButtonHasChanged()
       {
           if (oldMouseHandler.LeftButton == ButtonState.Pressed && mouseHandler.LeftButton == ButtonState.Released)
           {
               return true;
           }
           if (oldMouseHandler.RightButton == ButtonState.Pressed && mouseHandler.RightButton == ButtonState.Released)
           {
               return true;
           }
           return false;
       }

       public static bool leftMouseButtonHasChanged()
       {
           if (oldMouseHandler.LeftButton == ButtonState.Pressed && mouseHandler.LeftButton == ButtonState.Released)
           {
               return true;
           }
           return false;
       }

       public static bool rightMouseButtonHasChanged()
       {
           if (oldMouseHandler.RightButton == ButtonState.Pressed && mouseHandler.RightButton == ButtonState.Released)
           {
               return true;
           }
           return false;
       }


       public static void checkSelected()
       {
               Point selectedLocation = new Point(Mouse.GetState().X, Mouse.GetState().Y);
               if (leftMouseButtonHasChanged())
               {
                   SelectionHandling.checkSelectionAgainstShipRects(selectedLocation);

               }
               if (rightMouseButtonHasChanged())
               {
                   if (Player.selectedShips.Count != 0)
                   {
                       //apply movement logic to ship with selectedLocation as target
                       foreach (Ship ship in Player.selectedShips)
                       {
                           ship.targetPoint = selectedLocation; //sets clicked location as the ships target
                       }
                   }
               }
           
       }

       public static void handleInput()
       {
 
           oldKeyHandler = keyHandler;
           oldMouseHandler = mouseHandler;
           setInputState();
           switch (SceneHandling.currentScene)
               {
               case SceneHandling.Scenes.Splash:
                   if (inputHasChanged())
                       {
                       SceneHandling.advanceScene();
                       }
                   break;

               case SceneHandling.Scenes.MainMenu:  //TODO add support for menu and button clicks (add a detector)
                   if (inputHasChanged())
                       {
                       SceneHandling.advanceScene();
                       }
                   break;

               case SceneHandling.Scenes.CharacterSelection:
                   if (inputHasChanged())
                       {
                       SceneHandling.advanceScene();
                       }
                   break;

               case SceneHandling.Scenes.Ingame:
                       if (buttonWasPressed(Keys.P))
                       {
                           SceneHandling.setScene(SceneHandling.Scenes.Paused);
                       }

                   if (buttonWasPressed(Keys.OemPeriod))
                   {
                       new Game_Objects.Actors.Ships.Alliance.ABattleship(new Point(400, 400));
                   }
                   if (mouseButtonHasChanged())
                       {
                           checkSelected();
                       }
                   break;


               case SceneHandling.Scenes.Paused:
                   if (buttonWasPressed(Keys.P))
                       {
                       SceneHandling.setScene(SceneHandling.Scenes.Ingame);
                       }
                   break;

               case SceneHandling.Scenes.TESTZONE:
                   break;
               }


       }











        }
    }
