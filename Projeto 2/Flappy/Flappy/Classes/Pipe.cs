using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy.Classes
{
    public class Pipe
    {

        public const int FRONT_STATE = 0;
        public const int BACK_STATE = 1;
        public static GraphicsDeviceManager graphics;
        public static Texture2D topPipeTexture;
        public static Texture2D bottomPipeTexture;
        private Rectangle topPipeRectangle;
        private Rectangle bottomPipeRectangle;
        private Random random;
        private readonly int pipeHeight;
        private readonly int pipeWidth;
        private readonly int verticalDistanceBetween;
        public static int horizontalDistanceBetween;
        private readonly int position;
        private readonly int position2;

        public Pipe()
        { 
            random = new Random();
            pipeHeight = 620;
            pipeWidth = 75;
            position = DefinePipePosition();
            verticalDistanceBetween = 200;
            horizontalDistanceBetween = 50;
            position2 = position + pipeHeight + verticalDistanceBetween;
            topPipeRectangle = new Rectangle(graphics.PreferredBackBufferWidth, position, pipeWidth, pipeHeight);
            bottomPipeRectangle = new Rectangle(graphics.PreferredBackBufferWidth, position2, pipeWidth, pipeHeight);
        }

        public void Move()
        {
            bottomPipeRectangle.X -= 5;
            topPipeRectangle.X -= 5;
        }

        public int DefinePipePosition()
        {
            return random.Next(-570, -350);
        }


        public Rectangle TopPipeRectangle
        {
            get
            {
                return topPipeRectangle;
            }
            set
            {
                this.topPipeRectangle = value;
            }
        }

        public Rectangle BottomPipeRectangle
        {
            get
            {
                return bottomPipeRectangle;
            }
            set
            {
                this.bottomPipeRectangle = value;
            }
        }

    }
}
