﻿using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
        class Player
        {
            Vector2f playerPosition;
            Sprite playerSprite;

            public Vector2f getPosition()
            {
                return playerPosition;
            }

            public float getHeight()
            {
                return playerSprite.Texture.Size.Y * playerSprite.Scale.Y;
            }

            public float getWidth()
            {
                return playerSprite.Texture.Size.X * playerSprite.Scale.X;
            }




            public Player()
            {
                Texture playerTexture = new Texture("Pictures/player.png");
                playerSprite = new Sprite(playerTexture);

                playerPosition = new Vector2f(51, 51);
                playerSprite.Position = playerPosition;

                playerSprite.Scale = new Vector2f(0.03125f, 0.03125f);
            }

            public void move(Map map,GameTime time)
            {
                float runningSpeed = 0.1f * time.EllapsedTime.Milliseconds;

                bool Left = map.isWalckable((int)(this.getPosition().X - runningSpeed) / 50, (int)(this.getPosition().Y) / 50) && map.isWalckable((int)(this.getPosition().X - runningSpeed) / 50, (int)(this.getPosition().Y + this.getHeight()) / 50);
                bool Right = map.isWalckable((int)(this.getPosition().X + this.getWidth() + runningSpeed) / 50, (int)(this.getPosition().Y) / 50) && map.isWalckable((int)(this.getPosition().X + this.getWidth() + runningSpeed) / 50, (int)(this.getPosition().Y + this.getHeight()) / 50);
                bool Up = map.isWalckable((int)(this.getPosition().X) / 50, (int)(this.getPosition().Y - runningSpeed) / 50) && map.isWalckable((int)(this.getPosition().X + this.getWidth()) / 50, (int)(this.getPosition().Y - runningSpeed) / 50);
                bool Down = map.isWalckable((int)(this.getPosition().X) / 50, (int)(this.getPosition().Y + this.getHeight() + runningSpeed) / 50) && map.isWalckable((int)(this.getPosition().X + this.getWidth()) / 50, (int)(this.getPosition().Y + this.getHeight() + runningSpeed) / 50);


                if (Keyboard.IsKeyPressed(Keyboard.Key.A) && Left)
                    playerPosition = new Vector2f(playerPosition.X - runningSpeed, playerPosition.Y);
                if (Keyboard.IsKeyPressed(Keyboard.Key.D) && Right)
                    playerPosition = new Vector2f(playerPosition.X + runningSpeed, playerPosition.Y);
                if (Keyboard.IsKeyPressed(Keyboard.Key.W) && Up)
                    playerPosition = new Vector2f(playerPosition.X, playerPosition.Y - runningSpeed);
                if (Keyboard.IsKeyPressed(Keyboard.Key.S) && Down)
                    playerPosition = new Vector2f(playerPosition.X, playerPosition.Y + runningSpeed);

                playerSprite.Position = playerPosition;
            }

            public void draw(RenderWindow win)
            {
                win.Draw(playerSprite);
            }

        }
    }

