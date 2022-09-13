using KjellBlazorDemo.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine
{
    //todo - I think the class can't be static if we are binding it but I need to double check,
    //if it can be then it might make sense to make the class static
    public class Settings
    {
        //while these aren't technically consts, I'm upper casing them because I want them to 
        //be used as consts by anyone that is consuming this class
        public int MOVEMENT_DISTANCE = 35;

        public int CHARACTER = 0;

        public int MIN_X = 0;

        public int MAX_X = 400;

        public int MIN_Y = -10;
    }
}
