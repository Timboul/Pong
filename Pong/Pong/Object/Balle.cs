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
    class Balle : GameObject
    {
        private bool Lancement; // variable pour le lancement 
        private int DirectionY;
        private int DirectionX;
        private float speed; 
        private double vitesse;

        public Balle(int x, int y, int largeur, int hauteur) : base(x, y, hauteur, largeur)
        {
            Lancement = true;
            DirectionY = -1;
            DirectionX = -1;
            speed = 1.2f;
            vitesse = 2;
        }

        public void moveBalle(ref List<Object.Raquette> LesJoueurs)
        {
            int idRaquette = -1;
        
            /********************/
            // CONTROLE 
            /********************/
         
            // Pour le lancement on par à droite 
            if (Lancement)
                rec.X-=2;

            //Lors d'une collision avec une raquette, la balle prend l'id de
            // la dernière raquêtes avec qui elle à était en contact 
            idRaquette = collidRaquetteBalle(ref LesJoueurs);


            if (idRaquette != -1)
            {
                /*
                // Test on regarde ou la balle a touché la raquête pour en déduire 
                // le sens de renvoi 
                */

                // Si on est sur la partie suprérieure de la raquête +(milieu) 
                if(LesJoueurs[idRaquette -1 ].getRectangle().Center.Y >= this.rec.Center.Y )
                    this.DirectionY = 1;
                else
                    this.DirectionY = 0;
                
                DirectionX = idRaquette;

                // augmentation de la vitesse de la balle 
                if(vitesse < 5)
                vitesse = vitesse * speed;
            }


            if (DirectionY == 1)
                rec.Y -= (int)vitesse;
            else // Descent
                     if (DirectionY == 0)
                rec.Y += (int)vitesse;

            // droite
            if (DirectionX == 1)
                rec.X += (int)vitesse;
            else // gauche 
                if (DirectionX == 2)
                rec.X -= (int)vitesse;


            // Verification collision bordure 
            if ( rec.Y <= 0) // On tape en haut 
                DirectionY = 0; // on descent 
           
               if(rec.Y >= 290) // on tape en bas 290 car 300-10 car c'est le haut droit qui compte 
                DirectionY = 1; // on monte 
        }


        /// <summary>
        /// Vérifie qu'elle raquête touche la balle 
        /// </summary>
        /// <param name="LesJoueurs">reference sur la liste des raquêtes</param>
        /// <returns>l'id de la raquête en contact avec la balle </returns>
        private int collidRaquetteBalle(ref List<Object.Raquette> LesJoueurs)
        {
            foreach (Object.Raquette joueur in LesJoueurs)
            {
                if (joueur.getRectangle().Intersects(rec))
                {
                    Lancement = false;
                    // le lancement est terminé 
                    return joueur.getId();
                }
            }
            return -1;
        }

        /// <summary>
        /// Remet la balle au milieu et reset la vitesse
        /// </summary>
        public new void reinitialiser()
        {
            this.rec.X = 160;
            this.rec.Y = 100;
            this.vitesse = 2;
        }


    }
}
