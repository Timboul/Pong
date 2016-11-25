using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Pong.Menu
{
    class StartMenu : Game
    {
        private Rectangle title;

        private Rectangle btn_play;
        private Texture2D text_btn_play;

        private Rectangle btn_option;
        private Rectangle btn_sound;

        public StartMenu()
        {
            // Initialisation et instanciation de la position des rectangles 
            btn_play = new Rectangle(50, 50, 200, 200);
        }

        public void Draw(ref SpriteBatch sprite)
        {
            sprite.Begin();

            sprite.Draw(text_btn_play, btn_play, Color.White); //TEST

            sprite.End();
        }

        public void LoadContentMenu()
        {
            text_btn_play = Content.Load<Texture2D>("btn_play"); 
        }


        public bool UpdateMenu()
        {
            if (btn_play.Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 5, 5)));
            return true;

            return false;
        }
   

    
    }
}
