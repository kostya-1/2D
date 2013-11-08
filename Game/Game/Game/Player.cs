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

        public Animate player;
        string name;
        string defaultState = "idle";
        Vector2 position = new Vector2(400, 240);
        Color color = Color.White;
        float rotation = 0f;
        Vector2 origin = new Vector2(31, 57);
        Vector2 scale = new Vector2(1f);
        SpriteEffects effects = SpriteEffects.None;
        float layer = 0f;

        bool hasJumped;
        bool onPlate;
        Vector2 velocity = new Vector2(0);

        #endregion

        #region constructor

        public Player(string name)
        {
            this.name = name;
            player = new Animate(name, defaultState, position, null, color, rotation, origin, scale, effects, layer);
        }

        #endregion

        public void update()
        {
          
            #region loop position

            if (player.position.X > Game1.width + 20 )
                player.position.X = -20;

            if (player.position.X < -20 )
                player.position.X = Game1.width + 20;

            #endregion

            #region gravity

            #region gravity for base plate

            if (player.position.Y >= Plates.basePlate.position.Y + 6)
            {
                velocity.Y = 0;
                hasJumped = false;
                onPlate = true;
            } 

            #endregion

            #region gravity for the single plate

            else if ((player.position.Y <= Plates.singlePlate.position.Y + 6 && player.position.Y >= Plates.singlePlate.position.Y) && (player.position.X >= Plates.singlePlate.position.X && player.position.X <= Plates.singlePlate.texture.Width + 20) && velocity.Y >= 0)
            {
                velocity.Y = 0;
                onPlate = true;
                hasJumped = false;

            }

            #endregion

            #region gravity for the double plate

            else if ((player.position.Y <= Plates.doublePlate.position.Y + 6 && player.position.Y >= Plates.doublePlate.position.Y) && (player.position.X >= Plates.doublePlate.position.X && player.position.X <= Plates.doublePlate.texture.Width + 20) && velocity.Y >= 0)
            {
                velocity.Y = 0;
                onPlate = true;
                hasJumped = false;

            }

            #endregion

            #region gravity for the triple plate

            else if ((player.position.Y <= Plates.triplePlate.position.Y + 6 && player.position.Y >= Plates.triplePlate.position.Y) && (player.position.X >= Plates.triplePlate.position.X && player.position.X <= Plates.triplePlate.texture.Width + 20) && velocity.Y >= 0)
            {
                velocity.Y = 0;
                onPlate = true;
                hasJumped = false;

            }

            #endregion

            else if (player.position.Y < 400 && hasJumped == false)
            {
                velocity.Y += 0.15f;
                hasJumped = true;
                onPlate = false;
            }

            #endregion

            #region left movment

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Space) && Keyboard.GetState().IsKeyUp(Keys.Up) && hasJumped == false)
            {
                player.state = "walk";
                player.effects = SpriteEffects.FlipHorizontally;
                velocity.X = -1f;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyDown(Keys.Space) && Keyboard.GetState().IsKeyUp(Keys.Up) && hasJumped == false)
            {
                player.state = "run";
                player.effects = SpriteEffects.FlipHorizontally;
                velocity.X = -3f;
            }

            #endregion

            #region right movment

            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Space) && Keyboard.GetState().IsKeyUp(Keys.Up) && hasJumped == false)
            {
                player.state = "walk";
                player.effects = SpriteEffects.None;
                velocity.X = 1f;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && Keyboard.GetState().IsKeyDown(Keys.Space) && Keyboard.GetState().IsKeyUp(Keys.Up) && hasJumped == false)
            {
                player.state = "run";
                player.effects = SpriteEffects.None;
                velocity.X = 3f;
            }


            #endregion

            #region jump

            #region jump left

            // up + left
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Space) && hasJumped == false && onPlate == true)
            {
                player.effects = SpriteEffects.FlipHorizontally;
                velocity.Y = -5f;
                velocity.X = -1f;
                hasJumped = true;
            }

            // up + left + space
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && onPlate == true)
            {
                player.effects = SpriteEffects.FlipHorizontally;
                velocity.Y = -5f;
                velocity.X = -3f;
                hasJumped = true;
            }

            #endregion

            #region jump right

            // up + left
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Space) && hasJumped == false && onPlate == true)
            {
                player.effects = SpriteEffects.None;
                velocity.Y = -5f;
                velocity.X = 1f;
                hasJumped = true;
            }

            // up + left + space
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Right) && Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && onPlate == true)
            {
                player.effects = SpriteEffects.None;
                velocity.Y = -5f;
                velocity.X = 3f;
                hasJumped = true;
            }

            #endregion

            #region jump up

            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Space) && hasJumped == false && onPlate == true)
            {
                velocity.Y = -5f;
                hasJumped = true;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false && onPlate == true)
            {
                velocity.Y = -6f;
                hasJumped = true;
            }

            #endregion
                
            else if (hasJumped)
            {
                player.state = "jump";
                velocity.Y += 0.15f;

                if (velocity.Y > 0)
                    player.state = "fall";

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    player.effects = SpriteEffects.FlipHorizontally;

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    player.effects = SpriteEffects.None;
            } 

            #endregion  
                // got bug, velocity is not 0 when u jump left, and then jump up

            #region plates

            else if (onPlate)
            {
                player.state = defaultState;
                velocity.X = 0;
            }

            else if (!onPlate)
            {
                player.state = "fall";
                hasJumped = true;
            }

            #endregion

            player.position += velocity;

        }
    }
}
