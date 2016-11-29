using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Pong : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        enum GameState { PLAY, PAUSE, QUIT, MENU };
        GameState State;

        Menu.StartMenu mainMenu;

        Object.Terrain terrain;
        Object.Balle balle;
        Object.Raquette joueur1;
        Object.Raquette joueur2;
        List<Object.Raquette> LesJoueurs;
        SpriteFont affichScore;


        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 470;
            graphics.PreferredBackBufferHeight = 300;
            IsMouseVisible = true; // test only
            
            graphics.ApplyChanges();

            State = GameState.MENU;
            mainMenu = new Menu.StartMenu(0,0 ,70,50);

            terrain = new Object.Terrain();
            balle = new Object.Balle(160, 100, 10, 10);
            joueur1 = new Object.Raquette(10, 100, 1);
            joueur2 = new Object.Raquette(460, 100, 2);

            LesJoueurs = new List<Object.Raquette>();
            LesJoueurs.Add(joueur1);
            LesJoueurs.Add(joueur2);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            LoadMenu();

            LoadGamePlay();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            /*
             * Actions en fonction du gameState  
             */
            Mouse.WindowHandle = Window.Handle;
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                State = GameState.QUIT;


            if(State == GameState.MENU) {

                //if (mainMenu.MouseEvent(Mouse.GetState()))
                //    State = GameState.PLAY;

               var stat = Mouse.GetState();
                

                System.Diagnostics.Debug.WriteLine(stat.X);
                System.Diagnostics.Debug.WriteLine(Mouse.GetState().LeftButton);

            }

            if (State == GameState.PLAY) {

                if (Keyboard.GetState().IsKeyDown(Keys.P)) State = GameState.PAUSE;

                UpdatePlay();
            }
            

            if (State == GameState.PAUSE)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    State = GameState.PLAY;
            }

            if(State == GameState.QUIT)
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if(State == GameState.MENU) { DrawMenu(); }
            
            if (State == GameState.PLAY) { DrawPlay(); }

            base.Draw(gameTime);
        }


        #region PLAY
        /// <summary>
        /// Dessine le jeux lorsque le gamestate = PLAY
        /// </summary>
        public void DrawPlay()
        {
            spriteBatch.Begin(); // début dessin 

            terrain.Draw(ref spriteBatch);

            balle.Draw(ref spriteBatch);

            joueur1.Draw(ref spriteBatch);
            joueur2.Draw(ref spriteBatch);

            spriteBatch.DrawString(affichScore, joueur1.getScore().ToString() + "|" + joueur2.getScore().ToString(),
               new Vector2(graphics.PreferredBackBufferWidth / 2, 5), Color.White);

            spriteBatch.End(); // Fin dessin 
        }


        /// <summary>
        /// Contient toutes les actions lorsque le jeux est en mode Play
        /// </summary>
        public void UpdatePlay()
        {
            sortieBalle();
            scoreMax(); // vérif que le score max est pas atteint
            balle.moveBalle(ref LesJoueurs);
            joueur1.move(Keyboard.GetState());
            joueur2.move(Keyboard.GetState());
        }
        #endregion

        #region LOADER

        private void LoadGamePlay()
        {
            terrain.setTexture(Content.Load<Texture2D>("Texture/TerrainPong"));
            balle.setTexture(Content.Load<Texture2D>("Texture/Balle"));

            Texture2D raquette = Content.Load<Texture2D>("Texture/raquette");
            joueur1.setTexture(raquette);
            joueur2.setTexture(raquette);

            affichScore = Content.Load<SpriteFont>("Texture/score");
        }

        private void LoadMenu()
        {
            mainMenu.LoadContentMenu(Content.Load<Texture2D>("Texture/btn_play"));  // chargement texture menu 
        }

        #endregion




        #region MENU

        /// <summary>
        /// Dessine le menu 
        /// </summary>
        private void DrawMenu()
        {
            mainMenu.Draw(ref spriteBatch);
        }


        private void MenuUpdate()
        {
            //TODO Update action here 
        }


        #endregion



        /// <summary>
        /// Vérifie si la balle est out 
        /// Si oui sette le score 
        /// et réinitialise le jeu 
        /// </summary>
        /// <returns></returns>
        private void sortieBalle()
        {
            // Cas balle sort terrain coté J1 
            if (balle.getRectangle().X < 0) // donner le point au j2
            {
                joueur2.incScore();
                reinitialiserJeu();
                return;
            }

            // Cas balle sort terrain coté J2
            if (balle.getRectangle().X > 470)
            {
                joueur1.incScore();
                reinitialiserJeu();
                return; 
            }
               
            return;
        }

        /// <summary>
        /// Reinitialise toutes les positions des objets du jeu
        /// </summary>
        private void reinitialiserJeu()
        {
            joueur1.reinitialiser();
            joueur2.reinitialiser();
            balle.reinitialiser();
        }
      
        /// <summary>
        /// Arrête le jeux lorsque l'un des 2 joueurs atteint le score de 10 
        /// </summary>
        private void scoreMax()
        {
            if(joueur1.getScore() == 10 || joueur2.getScore() == 10)
                State = GameState.MENU;     
        }


    }
}
