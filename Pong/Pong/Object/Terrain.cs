using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Pong.Object
{
    class Terrain
    {
        private Rectangle rec;
        private Texture2D tex;

        public Terrain()
        {
            rec = new Rectangle(0, 0, 470, 300);
        }

        public void setTexture(Texture2D p_tex)
        {
            tex = p_tex;
        }

        public void Draw(ref SpriteBatch spritebatch)
        {
            spritebatch.Draw(tex,rec,Color.White);
        }

        public Rectangle GetRectangle()
        {
            return rec;
        }

   

    }
}
