﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Asteroid : BaseObject, ICloneable, IComparable, IComparable<Asteroid>
    {
        Bitmap image = new Bitmap("..\\..\\img/asteroid.png");
        public int Power { get; set; } = 3;

        public static event Action<string> asteroidCreation;
        public static event Action<string> asteroidRecreation;
        
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = Size.Width / 2;
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
            asteroidCreation?.Invoke($"{DateTime.Now}: Cоздан астероид в позиции ({Pos.X}, {Pos.Y}), размера {Size.Width}");
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
        
        public void Recreate()
        {
            Pos.X = myRandom.RandomIntNumber(Game.Width / 2, Game.Width - Size.Width);
            Pos.Y = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)(Game.Height - Size.Height));
            asteroidRecreation?.Invoke($"{DateTime.Now}: Астероид был уничтожен и создан в коорданитах ({Pos.X}, {Pos.Y})");
        }

        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y),
                new Size(Size.Width, Size.Height))
            { Power = Power };
            return asteroid;
        }
        
        int IComparable.CompareTo(object obj)
        {
            if (obj is Asteroid temp)
            {
                if (Power > temp.Power)
                    return 1;
                if (Power < temp.Power)
                    return -1;
                else
                    return 0;
            }
            throw new ArgumentException("Parameter is not а Asteroid!");
        }
        
        int IComparable<Asteroid>.CompareTo(Asteroid obj)
        {
            if (Power > obj.Power)
                return 1;
            if (Power < obj.Power)
                return -1;
            return 0;
        }

    }
}
