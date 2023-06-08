using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy.Classes
{
    public class GameController
    {
        public const int PLAYING_STATE = 0;
        public const int LOSE_STATE = 1;


        private MouseState mouseState;
        private int upDistance;
        private int horizontalDistanceCounter;
        private ArrayList arrayPipes;
        private int gameState;

        public GameController()
        {
            gameState = 0;
            mouseState = new MouseState();
            upDistance = 0;
            arrayPipes = new ArrayList();
            horizontalDistanceCounter = 0;
        }

        public void MovePipes()
        {
            foreach(Pipe pipe in arrayPipes.ToArray()) 
            {
                //mover
                pipe.Move();

                //tirar
                if(pipe.TopPipeRectangle.Right < 0)
                {
                    arrayPipes.Remove(pipe);
                }
            }
        }

        public void AddPipes()
        {
            horizontalDistanceCounter++;
            if (horizontalDistanceCounter >= Pipe.horizontalDistanceBetween)
            {
                arrayPipes.Add(new Pipe());
                horizontalDistanceCounter = 0;
            }
        }

        public void RaiseBirdOnClick(Bird bird)
        {
            if (mouseState.LeftButton == ButtonState.Released && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                bird.IsUp = true;
                Bird.wingSound.Play();
            }
            mouseState = Mouse.GetState();
            if (upDistance < 10 && bird.IsUp)
            {
                upDistance++;
                bird.GoUp();
            }
            else
            {
                upDistance = 0;
                bird.IsUp = false;
                bird.GoDown();
            }
        }

        public void LoseForImpactPipe(Bird bird)
        {
            foreach (Pipe pipe in arrayPipes.ToArray())
            {
                if (bird.Rectangle.Intersects(pipe.TopPipeRectangle) || bird.Rectangle.Intersects(pipe.BottomPipeRectangle))
                {
                    hitSound.Play();
                    dieSound.Play();
                    gameState = LOSE_STATE;
                }
            }
        }





        public ArrayList ArrayPipes
        {
            get
            {
                return arrayPipes;
            }
            set
            {
                this.arrayPipes = value;
            }
        }

        public int GameState
        {
            get 
            { 
                return gameState; 
            }
            set 
            {
                this.gameState = value; 
            }
        }
    }
}
