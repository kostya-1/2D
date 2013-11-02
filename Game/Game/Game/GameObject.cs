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
    class GameObject:Animate
    {
        #region data

        #endregion

        #region constructor

        public GameObject(string name, string state, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
            : base(name, state, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth)
        {        }

        #endregion

        public void walk_right()
        {
            this.position.X += 1;
        }

        public void walk_left()
        {
            this.position.X -= 1;
        }

        public void run_right()
        {
            this.position.X += 2f;
        }

        public void run_left()
        {
            this.position.X -= 2f;
        }

        public bool jump(Vector2 gravity, bool hasJumped)
        {

            this.position.Y -= 1;
            return true;
        }

        public void loop_position()
        {
            if (this.position.X > 820 && this.effects == SpriteEffects.None)
                this.position.X = -20;

            if (this.position.X < -20 && this.effects == SpriteEffects.FlipHorizontally)
                this.position.X = 820;

        }

    }
}
