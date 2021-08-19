﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WiiPlayTanksRemake.Internals.UI;

namespace WiiPlayTanksRemake.Internals.Common.GameUI
{
    public class UIText : UIElement
    {
        public string Text { get; set; }

        public SpriteFont Font { get; set; }

        public float Scale { get; set; }

        public Color Color { get; set; }

        public UIText(string text, SpriteFont font, Color color, float scale = 1f)
        {
            Text = text;
            Font = font;
            Color = color;
            Scale = scale;
        }

        public override void Draw()
        {
            TankGame.spriteBatch.DrawString(Font, Text, new Vector2(InteractionBox.X, InteractionBox.Y), Color, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
    }
}
