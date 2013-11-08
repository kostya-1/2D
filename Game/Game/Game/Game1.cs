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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static ContentManager contentManager;
        public static int height;
        public static int width;
        Player moshe;
        Draw clouds1;
        Draw clouds2;
        Texture2D clouds1Texture;
        Texture2D clouds2Texture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferHeight = 480;
            graphics.PreferredBackBufferWidth = 800;

            height = graphics.PreferredBackBufferHeight;
            width = graphics.PreferredBackBufferWidth;

            Content.RootDirectory = "Content";
            contentManager = this.Content;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            string name = "moshe";
            moshe = new Player(name);

            #region background

            clouds1Texture = Content.Load<Texture2D>("background/clouds1");
            clouds2Texture = Content.Load<Texture2D>("background/clouds2");

            clouds1 = new Draw(clouds1Texture, new Vector2(0,-150), null, Color.White, 0, new Vector2(0, 0), new Vector2(1f), SpriteEffects.None, 0);
            clouds2 = new Draw(clouds2Texture, new Vector2(-800,-150), null, Color.White, 0, new Vector2(0, 0), new Vector2(1f), SpriteEffects.None, 0);
            #endregion

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            moshe.update();

            //scrolling background
            clouds1.position.X += 0.3f;
            clouds2.position.X += 0.15f;

            if (clouds1.position.X > graphics.PreferredBackBufferWidth)
                clouds1.position.X = -(graphics.PreferredBackBufferWidth);
            if (clouds2.position.X > graphics.PreferredBackBufferWidth)
                clouds2.position.X = -(graphics.PreferredBackBufferWidth);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            clouds1.draw();
            clouds2.draw();
            Plates.basePlate.draw();
            Plates.singlePlate.draw();
            Plates.doublePlate.draw();
            Plates.triplePlate.draw();
            moshe.player.draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
