﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FlappyBird
{
    class Game
    {
        Board board;
        public Bird bird;
        
        protected Obstacle[] obstacles;
        protected int score { get; set; }
        public bool isPaused;
        public bool isOver;
        

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey consoleKey = new ConsoleKey();

        public Game()
        {
        }

        public void SetUp()
        {
            bird = new Bird();
            //obstacles = new Obstacle[5];
            score = 0;
            board = new Board();
            isOver = false;
            isPaused = false;
            Obstacle Obstacle1 = new Obstacle("Obstacle1", 10, 50);
            Obstacle Obstacle2 = new Obstacle("Obstacle2", 8, 70);
            Obstacle Obstacle3 = new Obstacle("Obstacle3", 14, 90);
            Obstacle Obstacle4 = new Obstacle("Obstacle4", 18, 110);
            obstacles = new Obstacle[] { Obstacle1, Obstacle2, Obstacle3, Obstacle4 };
        }

        //int x = 25;
        public void Run()
        {     
            Console.Clear();
            CheckKeyPress();

            board.DrawBoard(score);
            board.Draw(bird);       
            board.Draw(obstacles);
            for (int i = 0; i < 4; i++)
            {
                obstacles[i].xpos--;
            }
            CheckCollision();
            DeliverScore();
            Thread.Sleep(100);          
        }
        public void DeliverScore()
        {
            for(int i = 0; i < obstacles.Length; i++)
            {
                if(obstacles[i].xpos == bird.X - 4)
                {
                    score++;
                }
            }
        }
        public void CheckCollision()
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                if (bird.X == obstacles[i].xpos)
                {
                    if (bird.Y <= obstacles[i].height)
                    {
                        isOver = true;
                    }
                    else if (bird.Y >= obstacles[i].obsFloor)
                    {
                        isOver = true;
                    }
                }
            }
        }
        public void CheckKeyPress()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }

            if (consoleKey == ConsoleKey.Spacebar)
            {
                bird.Jump();
            }
            else if (consoleKey == ConsoleKey.Escape)
            {
                isOver = true;
            }
            else
            {
                bird.Fall();
            }
            consoleKey = ConsoleKey.A;
        }



    }
   
}
