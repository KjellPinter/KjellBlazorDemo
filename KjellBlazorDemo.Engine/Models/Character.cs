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

        public string Sprite { get; set; }



        public Character()
        {
            Id = 0;
            Name = "FooBizzle";
            offsetY = 0;
            offsetX = 0;
            Sprite = "Images/CharacterSprites/Fighter-F-01.png";
        }
    }
}
