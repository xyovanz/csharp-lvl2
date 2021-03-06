﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Asteroid : BaseObject
    {
        Bitmap image = new Bitmap("..\\..\\img/asteroid.png");
        public int Power { get; set; }
        
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
            switch (myRandom.RandomIntNumber(0, 3))
            {
                case 0:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 1:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case 2:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
            }
        }
        
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width - Size.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height - Size.Height) Dir.Y = -Dir.Y;
        }
        
        public void Respawn()
        {
            Pos.X = myRandom.RandomIntNumber(Game.Width / 2, Game.Width - Size.Width);
            Pos.Y = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)(Game.Height - Size.Height));
        }
    }
}
