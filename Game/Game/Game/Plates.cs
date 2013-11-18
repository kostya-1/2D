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
    static class Plates
    {

        public static List<Draw> plates = new List<Draw>();
        static Draw basePlate = new Draw(Game1.contentManager.Load<Texture2D>("plates/base"), new Vector2(-20, (Game1.height - 30)), null, Color.White, 0f, new Vector2(0, 0), new Vector2(1f), SpriteEffects.None, 0f);
        static Draw singlePlate = new Draw(Game1.contentManager.Load<Texture2D>("plates/single"), new Vector2(30, (Game1.height - 130)), null, Color.White, 0f, new Vector2(0, 0), new Vector2(1f), SpriteEffects.None, 0f);
        static Draw doublePlate = new Draw(Game1.contentManager.Load<Texture2D>("plates/double"), new Vector2(200, (Game1.height - 200)), null, Color.White, 0f, new Vector2(0, 0), new Vector2(1f), SpriteEffects.None, 0f);
        static Draw triplePlate = new Draw(Game1.contentManager.Load<Texture2D>("plates/triple"), new Vector2(460, (Game1.height - 100)), null, Color.White, 0f, new Vector2(0, 0), new Vector2(1f), SpriteEffects.None, 0f);

        public static void Initialize()
        {
            plates.Add(basePlate);
            plates.Add(singlePlate);
            plates.Add(doublePlate);
            plates.Add(triplePlate);
        }
    }
}
