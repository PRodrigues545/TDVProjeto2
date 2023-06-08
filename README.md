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

Classe usada para fazer o passaro

![variaveis](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/573695c7-ba2d-43ab-bdb8-9a14009cd9b8)

Estas variaveis são usadas para a animação, o som das asas, a posição inicial do passaro e as suas dimensões.

.

![construtor passaro](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/40c3e4c6-d59b-4096-9430-aaefeb2a14f7)

.

![Reset](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/3ce1dab5-6dad-4a39-a3f9-059f10d347b6)

Esta função é usada para dar reset á posição do passaro, usada quando o jogador perde

.

![EstaNoChao](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/95dd4eb9-1e6c-4fcf-ab1b-b9585e3dd3da)

Esta função é usada para saber se o passaro esta em contacto com o chao

.

![Subir e Descer](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/f8b3ebb1-24fe-4dcc-80f9-c2822867c7ee)

Estas 2 funções sao usadas para fazer subir ou descer o passaro


## Scene.cs

Classe usada para fazer o fundo e o chão

![variaveis scene](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/9bfb638e-572a-4897-9c6e-0a8afb88b941)

Estas variaveis são usadas para tratar das animações do fundo e do chão

.

![scene construtor](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/4db28244-f8fb-45b2-b850-ac2b5ab836d0)

.

![mover fundo](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/3c3a5d76-459e-4867-8c94-d984adcf0caa)

Funções usadas para fazer a animação do fundo


## Pipe.cs

Classe usada para fazer os tubos

![variaveis pipe](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/5bcb9f6c-a5a4-4e23-999b-08d20722a846)

Estas variaveis sao usadas para a textura dos tubos, se estao ou nao atras do passaro, o seu tamanho, a sua posiçao e a distancia entre tubos

.

![construtor pipe](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/a47dfd77-964d-4a2f-846f-721d1872eb07)

.

![funçoes pipe](https://github.com/PRodrigues545/TDVProjeto2/assets/117277133/0f311cb9-bdcb-45e9-a38a-7163e4e9a893)

Gerar aleatoriamente a posição dos tubos e move-los quando sao estanciados novos tubos

.

## GameController.cs


