using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WindowsGame1.Engine;
using WindowsGame1.Engine.Actors;
using WindowsGame1.Engine.Handlers;
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
            graphics.PreferredBackBufferHeight = 600;  
            graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";  //not used, we can probably remove soon, but leave for now, this is all just default xna code. Offloaded to ImageLoader.cs
            }


        protected override void Initialize()
            {
            // TODO: Add your initialization logic here
            Console.WriteLine("Initializing...");
            Screens.generateScreens(); //pregens the splash screen
            SceneHandling.currentScene = SceneHandling.Scenes.Splash; //set initial screen to splash.  It will do this by default anyway, but just to be safe.
            backgroundRect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            
            base.Initialize();
            Console.WriteLine("Initialization Complete");
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



















            base.Update(gameTime);
            }


       
 protected override void Draw(GameTime gameTime)
            {
            Console.WriteLine("Draw Loop Begin");
//GraphicsDevice.Clear(Color.White);
spriteBatch.Begin();

spriteBatch.Draw(ScreenHandling.handleScreen().screenTexture, backgroundRect, Color.White );













            spriteBatch.End();
float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds; //calculates framerate
Console.WriteLine("Framerate: " + frameRate);
            base.Draw(gameTime);
         Console.WriteLine("Draw Loop End");
       Thread.Sleep(1000); // for testing purposes.  Use to review whats been draw each frame by slowing things down.  Essentially locks to 1fps
            }
        }
    }
