using System;
using System.Drawing;
using System.Collections.Generic;

namespace MyGame
{
    class Star : BaseObject
    {
        List<Bitmap> bitMapList = new List<Bitmap>() {
            new Bitmap("..\\..\\img/stars/star1.png"),
            new Bitmap("..\\..\\img/stars/star2.png"),
            new Bitmap("..\\..\\img/stars/star3.png"),
            new Bitmap("..\\..\\img/stars/star4.png"),
            new Bitmap("..\\..\\img/stars/star5.png"),
            new Bitmap("..\\..\\img/stars/star6.png"),
            new Bitmap("..\\..\\img/stars/star7.png")
        };

        int starNum = 0;
        
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        
        public override void Draw()
        {
            starNum++;
            if (starNum == bitMapList.Count)
                starNum = 0;
            Game.Buffer.Graphics.DrawImage(bitMapList[starNum], Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0 - Size.Width) Pos.X = Game.Width + Size.Width;

        }
    }
}
