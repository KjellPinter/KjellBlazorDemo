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
    public class Character : Asset
    {
        public int Id { get; set; }

        public Character()
        {
            Id = 0;
            Name = "Fighter";
            offsetY = -69;
            offsetX = -26; //-22 char is to far right
            Sprite = "Images/CharacterSprites/Fighter-F-01.png";
        }

        public void FaceBack()
        {
            offsetY = -6;
            offsetX = offsetX == -2 ? -52 : -2;
        }

        public void FaceForward()
        {
            offsetY = -69; //64
            offsetX = offsetX == -2 ? -52 : -2;
        }

        public void FaceLeft()
        {
            offsetY = -101;
            offsetX = offsetX == -2 ? -52 : -2;
        }

        public void FaceRight()
        {
            offsetY = -37;
            offsetX = offsetX == -2 ? -52 : -2;
        }

    }
}
