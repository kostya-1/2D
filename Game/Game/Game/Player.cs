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
    class Player
    {

        #region data

        public GameObject player;
        string name;
        string defaultState = "idle";
        Vector2 position = new Vector2(400, 240);
        Color color = Color.White;
        float rotation = 0f;
        Vector2 origin = new Vector2(31, 57);
        Vector2 scale = new Vector2(1f);
        SpriteEffects effects = SpriteEffects.None;
        float layer = 0f;
        int frameIndex = 0;
        Thread down;

        #endregion

        #region constructor

        public Player(string name)
        {
            this.name = name;
            player = new GameObject(name, defaultState, position, null, color, rotation, origin, scale, effects, layer);
            down = new Thread(new ThreadStart(player.move_down));
        }

        #endregion
        public void update()
        {
            //switch ()
            //
            //    default:
            //}

            //player.texture = player.states[player.state].animatedTexture;
            //player.rectungle = player.states[player.state].rectangles[frameIndex];
            //player.origin = player.states[player.state].origins[frameIndex];
            ////frameIndex = (double)(frameIndex / frameRate);
            //Thread.Sleep(150);
            //frameIndex++;
            //frameIndex %= player.states[player.state].frames;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                player.state = "walk";
                player.origin = player.states[player.state].flipedOrigins[frameIndex];
                player.effects = SpriteEffects.FlipHorizontally;
                player.walk_left();
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                player.state = "walk";
                player.effects = SpriteEffects.None;
                player.walk_right();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                player.jump();
            }

            else
            {
                player.state = defaultState;
            }

        }
    }
}
