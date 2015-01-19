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









   
Console.WriteLine("Finished loading content!");
        }



    }
}