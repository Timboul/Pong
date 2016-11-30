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
    class StartMenu
    {
        private Rectangle title;

        Bouton.Bouton btn_play;


        List<Bouton.Bouton> les_Boutons;

        public StartMenu(ContentManager content)
        {
            // Initialisation et instanciation de la position des rectangles 
            btn_play = new Bouton.Bouton(200, 200, 100, 60, content.Load<Texture2D>("Texture/btn_play"), Pong.GameState.PLAY);


            les_Boutons = new List<Bouton.Bouton>();
            les_Boutons.Add(btn_play);
        }

        public void Draw(ref SpriteBatch sprite)
        {
            sprite.Begin();

            foreach (Bouton.Bouton btn in les_Boutons)
                btn.Draw(ref sprite);

            sprite.End();
        }


        public Pong.GameState Action(MouseState state)
        {
            if(state.LeftButton == ButtonState.Pressed)
            {
                foreach (Bouton.Bouton btn in les_Boutons)
                {
                    if (btn.Click(new Point(state.X, state.Y)))
                        return btn.GetAction();
                }               
            }

            return Pong.GameState.MENU;
        }
   

        


    }
}
