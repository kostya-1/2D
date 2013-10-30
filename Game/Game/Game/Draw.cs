using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game
{
    class Draw
    {
        #region data
        public Texture2D texture;
        Vector2 position;
        public Rectangle? rectungle;
        Color color;
        float rotation;
        public Vector2 origin;
        Vector2 scale;
        SpriteEffects effects;
        float layer;
        #endregion

        #region constructor

        public Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            this.texture = texture;
            this.position = position;
            this.rectungle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effects = effects;
            this.layer = layerDepth;
        }

        #endregion

        public virtual void draw()
        {
            Game1.spriteBatch.Draw(texture, position, rectungle, color, rotation, origin, scale, effects, layer);
        }
    }
}
