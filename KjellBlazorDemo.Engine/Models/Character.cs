using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int offsetY { get; set; }    
        public int offsetX { get; set; }   

        public Character()
        {
            //setting this intentionally to invalid value so it's obvious when it's not actually respecting the settings
            Id = 0;
            Name = "";
            offsetY = 0;
            offsetX = 0;
        }
    }
}
