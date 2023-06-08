# TDVProjeto2 - Flappy Bird

# Grupo
Eduardo Costa 25969

Filipe Araújo 25981

Pedro Rodrigues 25982

# Estrutura
O projeto possui 5 classes:

* Bird.cs
* GameController.cs
* Pipe.cs
* Scene.cs
* Game1.cs

# Funcionamento

Este jogo é o classico jogo flappy bird.

É jogado com o rato. Cada clique faz com que o pássaro salte uma vez.

Por cada tubo que se passe, a pontuação aumenta em 1 valor

# Aprofundamento das Classes:

## Bird.cs

        private Texture2D[] texture2D;
        private Rectangle rectangle;
        public static SoundEffect wingSound;
        private readonly int initX;
        private readonly int initY;
        private readonly int initWidth;
        private readonly int initHeight;
        private bool isUp;
        private ArrayList arrayFireBalls;
        public static GraphicsDeviceManager graphics
