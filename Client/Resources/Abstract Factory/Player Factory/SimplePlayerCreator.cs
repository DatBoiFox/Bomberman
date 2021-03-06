﻿using Client.Models;
using System.Drawing;

namespace Client.Resources.Abstract_Factory.Player_Factory
{
    public class SimplePlayerCreator : PlayerCreatorAbstract
    {
        protected override Point GetLocation(Player player)
        {
            return new Point(player.x, player.y);
        }

        protected override Color GetPictureColor()
        {
            return Color.Blue;
        }

        protected override string GetPictureName()
        {
            return "Player";
        }

        protected override Size GetPictureSize()
        {
            return new Size(25, 25);
        }
    }
}
