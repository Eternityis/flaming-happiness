using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Engine.Handlers.Logic;

namespace WindowsGame1.Engine.Handlers
    {
    public static class GarbageHandler
        {

       public static void collectGarbage() //call once a minute or whatever, not very often.  Memory less important than performance
        {
           foreach (Impulse i in Lists.impulseMasterList)
           {
               if (i.killMe)
               {
                   Impulse.sudoku(i);
               }
           }
Console.WriteLine("Garbage Collected");
        }





        }
    }
