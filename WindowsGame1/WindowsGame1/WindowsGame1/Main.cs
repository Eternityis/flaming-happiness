using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WindowsGame1.Engine;
using WindowsGame1.Engine.Actors;
using WindowsGame1.Engine.Handlers;
using WindowsGame1.Engine.Handlers.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
    {

    public class Main : Microsoft.Xna.Framework.Game
        {
      public static GraphicsDeviceManager graphics;
      public Rectangle backgroundRect;
      public  SpriteBatch spriteBatch;  //not used and can probably remove soon, but leave for now, this is all just default xna code. I offloaded this to a seperate class.

        public Main()
            {
            graphics = new GraphicsDeviceManager(this);  //Resolution must be 4:3 or tiles wont be square, this is easy to fix but it makes more sense to just lock the res options honestly.
            graphics.IsFullScreen = false;         //not all screens are 4:3, and not enabling full screen totally presents that moonrune rpgmaker aesthetic we all know and love
            graphics.PreferredBackBufferHeight = 720;  
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";  //not used, we can probably remove soon, but leave for now, this is all just default xna code. Offloaded to ImageLoader.cs
            IsMouseVisible = true;
            }


        protected override void Initialize()
            {
            // TODO: Add your initialization logic here
            Console.WriteLine("Initializing...");
            Screens.generateScreens(); //pregens the splash screen
            Ship.generateShipClassList(); //pregens classes for sprite loading
            SceneHandling.currentScene = SceneHandling.Scenes.Splash; //set initial screen to splash.  It will do this by default anyway, but just to be safe.
            backgroundRect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            
            base.Initialize();
            Console.WriteLine("Initialization Complete");
          //  Console.WriteLine("Remember, (ง ° ل͜ °)ง ᴛʜᴇ ᴜɴsᴇᴇɴ ᴅᴏɴɢᴇʀ ɪs ᴛʜᴇ ᴅᴇᴀᴅʟɪᴇsᴛ (ง ° ل͜ °)ง");
            }


        protected override void LoadContent()  //This section is shit and should be offloaded to ImageLoader.cs otherwise things get really fucking messy
            {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            new ImageLoader(Content);

            // TODO: use this.Content to load your game content here <-- dont believe their lies
            }

        protected override void UnloadContent()
            {
            // TODO: Unload any non ContentManager content here  <-- Nah
            }


        protected override void Update(GameTime gameTime)
            {

            // TODO: Gameloop
            SceneHandling.handleScene();  //the individual gameloops for the different menus etc should go in their own section of processScene()
            InputHandling.setInputState();
            foreach (Ship ship in Lists.ShipList) //handle moving ships around
            {
                MovementLogic.processMovement(ship);
            }


















            base.Update(gameTime);
            }


       
 protected override void Draw(GameTime gameTime)
            {
            Console.WriteLine("Draw Loop Begin");
//GraphicsDevice.Clear(Color.White);
spriteBatch.Begin();

     try
     {
         spriteBatch.Draw(ScreenHandling.handleScreen().screenTexture, backgroundRect, Color.White);

     }
     catch
     {
         Console.WriteLine("screen draw error");
     }
     
    foreach (Ship ship in Lists.ShipList)
     {
         spriteBatch.Draw(Ship.sprite, ship.shipRect, null, Color.White, ship.heading/(float)57.2957795, new Vector2(0,0) , SpriteEffects.None, 0);
        Console.WriteLine("ship target heading is "+ ship.targetHeading);
     }


Vector2 target = new Vector2(0, 0);
Vector2 location = new Vector2(0, 0);
     float targetHeading;
     float conversion = (float)57.2957795; //convert radians to degrees
     targetHeading = (float)Math.Atan2(target.X - location.X, target.Y - location.Y)*conversion; //TODO testing the formula
     if (targetHeading < 0)
     {
         targetHeading += 360;
     }
Console.WriteLine(targetHeading);










            spriteBatch.End();
float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds; //calculates framerate
Console.WriteLine("Framerate: " + frameRate);
            base.Draw(gameTime);
         Console.WriteLine("Draw Loop End");
    //   Thread.Sleep(1000); // for testing purposes.  Use to review whats been draw each frame by slowing things down.  Essentially locks to 1fps
            }
        }
    }
