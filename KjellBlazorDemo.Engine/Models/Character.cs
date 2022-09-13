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

        //offsets are not implemented yet and are hardcoded in the CSS 
        //because they are the same for all sprites at the moment
        public int offsetY { get; set; }    
        public int offsetX { get; set; }   

        public string Sprite { get; set; }

        public Character()
        {
            Id = 0;
            Name = "Fighter";
            offsetY = -40;
            offsetX = -64;
            Sprite = "Images/CharacterSprites/Fighter-F-01.png";
        }

        
    }
}
