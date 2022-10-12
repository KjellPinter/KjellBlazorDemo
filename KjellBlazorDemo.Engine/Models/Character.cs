using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KjellBlazorDemo.Engine.Models
{
    /// <summary>
    /// This class deal swith character attributes.
    /// TODO: Move offsets to json file so different sprite sheets can be plugged in
    /// </summary>
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
            Name = "Fighter";
            offsetY = -65;
            offsetX = -22;
            Sprite = "Images/CharacterSprites/Fighter-F-01.png";
        }

        public void FaceBack()
        {
            offsetY = -5;
            offsetX = offsetX == -2 ? -46 : -2;
        }

        public void FaceForward()
        {
            offsetY = -64;
            offsetX = offsetX == -2 ? -46 : -2;
        }

        public void FaceLeft()
        {
            offsetY = -100;
            offsetX = offsetX == -2 ? -46 : -2;
        }

        public void FaceRight()
        {
            offsetY = -35;
            offsetX = offsetX == -2 ? -46 : -2;
        }

    }
}
