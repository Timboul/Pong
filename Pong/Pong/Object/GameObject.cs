using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Pong.Object
{
    public class GameObject
    {
        protected Rectangle rec;
        protected Texture2D texture;
        protected int memoX;
        protected int memoY;

        public GameObject(int x, int y, int hauteur, int largeur)
        {
            rec = new Rectangle(x, y, largeur, hauteur);

            // Permet de reinitialiser la partie quand un point est marqué 
            memoX = x;
            memoY = y;
        }

        public void Draw(ref SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, rec, Color.White);
        }


        public void setTexture(Texture2D text)
        {
            this.texture = text;
        }

        public Rectangle getRectangle()
        {
            return rec;
        }

        public void reinitialiser()
        {
            rec.X = memoX;
            rec.Y = memoY;
        }


    }
}
