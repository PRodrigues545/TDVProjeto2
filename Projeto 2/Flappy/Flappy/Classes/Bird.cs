using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy.Classes
{
    public class Bird
    {
        private Texture2D[] texture2D;
        private Rectangle rectangle;
        public static SoundEffect wingSound;
        private readonly int initX;
        private readonly int initY;
        private readonly int initWidth;
        private readonly int initHeight;
        private bool isUp;
        public static GraphicsDeviceManager graphics;
            

        public Bird()
        {
            texture2D = new Texture2D[3];
            initWidth = 60;
            initHeight = 45;
            isUp = false;
            initX = (graphics.PreferredBackBufferWidth / 4) - (initWidth / 2);
            initY = (4 * (graphics.PreferredBackBufferHeight / 10)) - (initHeight / 2);
            rectangle = new Rectangle(initX, initY, initWidth, initHeight);
        }

        public void ResetPosition()
        {
            rectangle.X = initX;
            rectangle.Y = initY;
        }


        public bool IsOnFloor()
        {
            bool isOnFloor = false || rectangle.Y > 485;
            return isOnFloor;
        }

        public void GoUp()
        {
            rectangle.Y -= 10;
        }

        public void GoDown()
        {
            rectangle.Y += 5;
        }

        public Texture2D[] Texture2D
        {
            get
            {
                return texture2D;
            }
            set
            {
                this.texture2D = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
            set
            {
                this.rectangle = value;
            }
        }

        public bool IsUp
        {
            get
            {
                return isUp;
            }
            set
            {
                this.isUp = value;
            }
        }

    }
}
