/*Добромыслов
 1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полёт в звёздном пространстве.
2. *Заменить кружочки картинками, используя метод DrawImage.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class Program
    {
        static void Main()
        {
            Form game = new Form();
            game.MinimumSize = new System.Drawing.Size(800, 600);
            game.MaximumSize = new System.Drawing.Size(800, 600);
            game.MaximizeBox = false;
            game.MinimizeBox = false;
            game.StartPosition = FormStartPosition.CenterScreen;
            game.Text = "Asteroids";
            Game.Init(game);
            game.Show();
            Game.Draw();

            Application.Run(game);
        }
    }
}
