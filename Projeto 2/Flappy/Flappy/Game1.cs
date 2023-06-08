using Flappy.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flappy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Scene scene;
        Bird bird;
        GameController gameController;
        MouseState previousMouseState;
        SpriteFont scoreFont;
        private int indexFrame;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this) 
            {
                PreferredBackBufferWidth = 1080,
                PreferredBackBufferHeight = 650,
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            Scene.graphics = graphics;
            Bird.graphics = graphics;
            Pipe.graphics = graphics;
            scene = new Scene();
            bird = new Bird();
            gameController = new GameController();
            previousMouseState = new MouseState();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //carregar imagens
            scene.BackgroundTexture = Content.Load<Texture2D>("background");
            scene.FloorTexture = Content.Load<Texture2D>("floor");
            bird.Texture2D[0] = Content.Load<Texture2D>("bird1");
            bird.Texture2D[1] = Content.Load<Texture2D>("bird2");
            bird.Texture2D[2] = Content.Load<Texture2D>("bird3");
            Pipe.topPipeTexture = Content.Load<Texture2D>("toppipe");
            Pipe.bottomPipeTexture = Content.Load<Texture2D>("bottompipe");

            //carregar sons
            Bird.wingSound = Content.Load<SoundEffect>("wing");
            GameController.hitSound = Content.Load<SoundEffect>("hit");
            GameController.dieSound = Content.Load<SoundEffect>("die");

            //fontes
            scoreFont = Content.Load<SpriteFont>("scorefont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (gameController.GameState)
            {
                case GameController.PLAYING_STATE:
                    scene.Move();
                    indexFrame = gameController.GetWingsBirdFrame(gameTime, bird);
                    gameController.RaiseBirdOnClick(bird);
                    gameController.AddPipes();
                    gameController.MovePipes();
                    gameController.VerifyLoseForImpactPipe(bird);
                    gameController.VerifyLoseForImpactFloor(bird);
                    gameController.VerifyIncreaseScore(bird);
                    if (previousMouseState.RightButton == ButtonState.Released && Mouse.GetState().RightButton == ButtonState.Pressed)
                    {
                        gameController.GameState = GameController.PAUSE_STATE;
                    }
                    previousMouseState = Mouse.GetState();
                    break;
                case GameController.LOSE_STATE:
                    if(previousMouseState.LeftButton == ButtonState.Released && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        gameController.GameState = GameController.PLAYING_STATE;
                        gameController.ArrayPipes.Clear();
                        bird.ResetPosition();
                        gameController.Score = 0;
                    }
                    previousMouseState = Mouse.GetState();
                    break;
                case GameController.PAUSE_STATE:
                    if (previousMouseState.LeftButton == ButtonState.Released && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        gameController.GameState = GameController.PLAYING_STATE;

                    }
                    previousMouseState = Mouse.GetState();
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //desenhar o fundo
            spriteBatch.Draw(scene.BackgroundTexture, scene.BackgroundRectangle, Color.White);
            spriteBatch.Draw(scene.BackgroundTexture, scene.BackgroundRectangle2, Color.White);

            //desenhar tubos
            foreach (Pipe pipe in gameController.ArrayPipes)
            {
                spriteBatch.Draw(Pipe.topPipeTexture, pipe.TopPipeRectangle, Color.White);
                spriteBatch.Draw(Pipe.bottomPipeTexture, pipe.BottomPipeRectangle, Color.White);
            }

            //desenhar o solo
            spriteBatch.Draw(scene.FloorTexture, scene.FloorRectangle, Color.White);
            spriteBatch.Draw(scene.FloorTexture, scene.FloorRectangle2, Color.White);

            //passaro
            spriteBatch.Draw(bird.Texture2D[indexFrame], bird.Rectangle, Color.White);
             
            //score
            spriteBatch.DrawString(scoreFont, gameController.Score.ToString(), new Vector2((graphics.PreferredBackBufferWidth / 2) - 
                (scoreFont.MeasureString(gameController.Score.ToString()).X / 2), 10), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}