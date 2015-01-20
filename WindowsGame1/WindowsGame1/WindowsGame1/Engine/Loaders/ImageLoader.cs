using System;
using WindowsGame1.Engine.Actors;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.Engine.Handlers
{
    class ImageLoader
    {

        public  ImageLoader(ContentManager content) //We -probably- need to add file extensions to these  <-- definitely dont do this 
        {


            Console.WriteLine("Now loading content...");
            content.RootDirectory = "Content";


            foreach (Screens screen in Lists.ScreenList) //Splash, main menu background, stuff like that
            {
                try
                {
                    screen.screenTexture = content.Load<Texture2D>("Screens/" + screen.screenName);
                    Console.WriteLine("Loaded Screen: " + screen.screenName);
                }
                catch
                {
                    Console.WriteLine("Screen: " + screen.screenName + " has failed to load!");
                    //FNF. ignoring for now.
                }
                 
            }






   
Console.WriteLine("Finished loading content!");
        }



    }
}