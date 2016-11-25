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
   public class Raquette : GameObject
    {
        private int id;
        private int score;
      

        public Raquette(int x , int y ,int pid ) : base (x,y,50,5)
        {
            // empty body appel du contructeur parent 
            id = pid;
            score = 0;
        }


        public void move(KeyboardState state)
        {
            // On monte 
            if(id == 2)
            {
                if (state.IsKeyDown(Keys.Up))
                {
                    // Permet de limiter le déplacement 
                    if (rec.Y > 0)
                        this.rec.Y -= 5;
                }
                else   // On descent
           if (state.IsKeyDown(Keys.Down))
                {
                    // Permet de limiter le déplacement 
                    if (rec.Bottom < 300)
                        this.rec.Y += 5;
                }
            }
            else
            {
                if (state.IsKeyDown(Keys.Z))
                {
                    // Permet de limiter le déplacement 
                    if (rec.Y > 0)
                        this.rec.Y -= 5;
                }
                else   // On descent
           if (state.IsKeyDown(Keys.S))
                {
                    // Permet de limiter le déplacement 
                    if (rec.Bottom < 300)
                        this.rec.Y += 5;
                }
            }


           
        }

        public int getId()
        {
            return id;
        }

        public void incScore()
        {
            score++;
        }

        public int getScore()
        {
            return score; 
        }

    }
}
