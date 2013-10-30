using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Game
{
    class Animate:Draw
    {

        #region data

        string state;
        Dictionary<string, Page> states = new Dictionary<string, Page>();
        double frameIndex = 0;
        double frameRate = 3;

        #endregion

        #region ctor

        public Animate(string name, string state, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
               :base(null, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth)
        {
            this.state = state;
                foreach (States stateIndex in Enum.GetValues(typeof(States)))
                {
                    try
                    {
                        states.Add(stateIndex.ToString(), new Page(name, stateIndex.ToString()));
                    }
                    catch (Exception) { }
                }
        }

        #endregion

        public override void draw()
        {
            this.texture = states[state].animatedTexture;
            this.rectungle = states[state].rectangles[(int)frameIndex];
            this.origin = states[state].origins[(int)frameIndex];
            //frameIndex = (double)(frameIndex / frameRate);
            Thread.Sleep(150);
            frameIndex++;
            frameIndex %= states[state].frames;
            base.draw();
        }
    }
}
