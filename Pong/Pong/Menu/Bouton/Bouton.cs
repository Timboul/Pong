using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Pong.Menu.Bouton
{
    class Bouton
    {
        private Rectangle rec;
        private Texture2D tex;
        private Pong.GameState action;

        public Bouton(int x, int y, int width, int height, Texture2D p_tex, Pong.GameState p_action)
        {
            rec = new Rectangle(x, y, width, height);
            tex = p_tex;
            action = p_action;
        }


        public bool Click(Point p)
        {
            if (rec.Contains(p))
                return true;

            return false;
        }

        public Pong.GameState GetAction(){ return action; }



        public void Draw(ref SpriteBatch sp) { sp.Draw(tex, rec, Color.White); }



    }
}
