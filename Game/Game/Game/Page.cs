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
    public enum States { idle, walk, run, jump, fall }
    
    class Page
    {

        #region data

        //string name, state;
        public Texture2D animatedTexture;
        Rectangle lowestRectangle; // is the rectangle of the dot's.
        List<int> dots = new List<int>(); // this list is for the dot's X coordinate on the dot's rectungle.
        public List<Rectangle> rectangles = new List<Rectangle>(); // this list is for the new rectungles, each rectungle is a diffirent frame from the sprite sheet.       
        public List<Vector2> origins = new List<Vector2>(); // this list is for each origin point of the new retungles.
        public List<Vector2> flipedOrigins = new List<Vector2>(); // this list is for each origin point of the new rectangles when fliped
        public int frames = 0;
        #endregion

        #region ctor

        public Page(string name, string state )
        {
            animatedTexture = Game1.contentManager.Load<Texture2D>(name + '/' + state);
            make_transparent();
            prepare_frames();
        }

        #endregion

        void make_transparent()
        {
            Color[] colors; // this array is for the colors on the whole texture.
            colors = new Color[animatedTexture.Width * animatedTexture.Height];
            animatedTexture.GetData<Color>(colors);
            for (int i = 1; i < colors.Length; i++)
                if (colors[i] == colors[0])
                    colors[i] = Color.Transparent;
            colors[0] = Color.Transparent;
            animatedTexture.SetData<Color>(colors);
        }

        void prepare_frames()
        {
            find_dots();
            find_rectangles();
            find_origins();
        }

        void find_dots()
        {
            
            Color[] colors; // this array is for the colors on the dot's rectungle.
            colors = new Color[animatedTexture.Width];
            lowestRectangle = new Rectangle(0, animatedTexture.Height - 1, animatedTexture.Width, 1);
            animatedTexture.GetData<Color>(0, lowestRectangle, colors, 0, animatedTexture.Width);
            for (int i = 0; i < colors.Length; i++)
                if (colors[i] == Color.Black)
                    dots.Add(i);
        }

        void find_rectangles()
        {
            for (int i = 0; i < dots.Count - 2; i += 2)
            {
                rectangles.Add(new Rectangle(dots[i], 0, dots[i + 2] - dots[i], animatedTexture.Height - 1));
                frames++;
            }
        }

        void find_origins()
        {
            for (int i = 1; i < dots.Count; i+=2)
                {
                    origins.Add(new Vector2(dots[i] - dots[i-1], animatedTexture.Height - 1));
                    flipedOrigins.Add(new Vector2(dots[i+1] - dots[i], animatedTexture.Height - 1));
                }
        }

    }
}
