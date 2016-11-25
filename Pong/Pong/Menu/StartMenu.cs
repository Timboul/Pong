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

        private MouseState old_state;


        public StartMenu(int x, int y, int width, int height)
        {
            // Initialisation et instanciation de la position des rectangles 
            btn_play = new Rectangle(x, y, width, height);
        }

        public void Draw(ref SpriteBatch sprite)
        {
            sprite.Begin();

            sprite.Draw(text_btn_play, btn_play, Color.White); //TEST

            sprite.End();
        }

        public void LoadContentMenu(Texture2D p_text)
        {
            text_btn_play = p_text;  
        }


        public bool UpdateMenu()
        {
            
            if (btn_play.Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 5, 5)) && Mouse.GetState().LeftButton == ButtonState.Pressed);
            return true;

            return false;
        }



        public bool MouseEvent(MouseState mouseState)
        {
            Rectangle pos = new Rectangle(mouseState.X, mouseState.Y, 5, 5);

            if (mouseState.LeftButton == ButtonState.Pressed)
                Console.Beep();

            if (mouseState.LeftButton == ButtonState.Pressed && old_state.LeftButton == ButtonState.Released && pos.Intersects(btn_play))
                return true;

            old_state = mouseState;
     
            return false;
        }


    }
}
