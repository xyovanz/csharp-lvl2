using System;
using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// Шаблонный объект - астероид
    /// </summary>
    class Template
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        Bitmap image = new Bitmap("..\\..\\img/asteroid.png");
        protected Random random = new Random();

        public Template(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width - Size.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height - Size.Height) Dir.Y = -Dir.Y;
        }
    }
}
