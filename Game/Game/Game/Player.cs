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

        KeyboardState state;
        bool rightPressed;
        bool leftPressed;
        bool upPressed;
        bool spacePressed;
        bool isBot = false;
        #endregion

        #region constructor

        public Player(string name)
        {
            this.name = name;
            player = new Animate(name, defaultState, position, null, color, rotation, origin, scale, effects, layer);

            Plates.Initialize();

            Game1.EVENT_UPDATE += new update_signature(update);
        }

        #endregion

        void update()
        {
            state = Keyboard.GetState();

            if (!isBot)
            {
                rightPressed = check_right_key(state);
                leftPressed = check_left_key(state);
                upPressed = check_up_key(state);
                spacePressed = check_space_key(state);
            }

            #region loop position

            if (player.position.X > Game1.width + 20 )
                player.position.X = -20;

            if (player.position.X < -20 )
                player.position.X = Game1.width + 20;

            #endregion

            #region gravity
            if (velocity.Y >= 0)
            {
                for (int i = 0; i < Plates.plates.Count; i++)
                {
                    if (player.position.Y <= Plates.plates[i].position.Y + 12 && player.position.Y >= Plates.plates[i].position.Y + 6)
                    {
                        if (player.position.X >= Plates.plates[i].position.X)
                        {
                            if (player.position.X <= (Plates.plates[i].position.X) + (Plates.plates[i].texture.Width + 10))
                            {
                                velocity.Y = 0;
                                onPlate = true;
                                hasJumped = false;
                            }
                            else
                                onPlate = false;
                        }
                        else
                            onPlate = false;
                    }
                }
            }


            #endregion

            #region left movment

            if (leftPressed && !spacePressed && !upPressed && hasJumped == false && onPlate)
            {
                player.state = "walk";
                player.effects = SpriteEffects.FlipHorizontally;
                velocity.X = -1f;
            }

            else if (leftPressed && spacePressed && !upPressed && hasJumped == false && onPlate)
            {
                player.state = "run";
                player.effects = SpriteEffects.FlipHorizontally;
                velocity.X = -3f;
            }

            #endregion

            #region right movment

            else if (rightPressed && !spacePressed && !upPressed && hasJumped == false && onPlate)
            {
                player.state = "walk";
                player.effects = SpriteEffects.None;
                velocity.X = 1f;
            }

            else if (rightPressed && spacePressed && !upPressed && hasJumped == false && onPlate)
            {
                player.state = "run";
                player.effects = SpriteEffects.None;
                velocity.X = 3f;
            }


            #endregion

            #region jump

            #region jump left

            // up + left
            else if (upPressed && leftPressed && !spacePressed && hasJumped == false && onPlate == true)
            {
                player.effects = SpriteEffects.FlipHorizontally;
                velocity.Y = -5f;
                velocity.X = -1f;
                hasJumped = true;
            }

            // up + left + space
            else if (upPressed && leftPressed && spacePressed && hasJumped == false && onPlate == true)
            {
                player.effects = SpriteEffects.FlipHorizontally;
                velocity.Y = -5f;
                velocity.X = -3f;
                hasJumped = true;
            }

            #endregion

            #region jump right

            // up + left
            else if (upPressed && rightPressed && !spacePressed && hasJumped == false && onPlate == true)
            {
                player.effects = SpriteEffects.None;
                velocity.Y = -5f;
                velocity.X = 1f;
                hasJumped = true;
            }

            // up + left + space
            else if (upPressed && rightPressed && spacePressed && hasJumped == false && onPlate == true)
            {
                player.effects = SpriteEffects.None;
                velocity.Y = -5f;
                velocity.X = 3f;
                hasJumped = true;
            }

            #endregion

            #region jump up

            else if (upPressed && !leftPressed && !rightPressed && !spacePressed && hasJumped == false && onPlate == true)
            {
                velocity.Y = -5f;
                hasJumped = true;
            }

            else if (upPressed && !leftPressed && !rightPressed && spacePressed && hasJumped == false && onPlate == true)
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

                if (leftPressed)
                    player.effects = SpriteEffects.FlipHorizontally;

                if (rightPressed)
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

        bool check_right_key(KeyboardState state)
        {
            return state.IsKeyDown(Keys.Right);
        }
        
        bool check_left_key(KeyboardState state)
        {
            return state.IsKeyDown(Keys.Left);
        }

        bool check_up_key(KeyboardState state)
        {
            return state.IsKeyDown(Keys.Up);
        }

        bool check_space_key(KeyboardState state)
        {
            return state.IsKeyDown(Keys.Space);
        }

    }
}
