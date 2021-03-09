/* Добромыслов
 * 1)Добавить космический корабль, как описано в уроке.
 * 2)Доработать игру «Астероиды»:
 * - Добавить ведение журнала в консоль с помощью делегатов;
 * - *добавить это и в файл.
 * 3)Разработать аптечки, которые добавляют энергию.
 * 4)Добавить подсчет очков за сбитые астероиды. */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            Form game = new Form()
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };
            game.Width = 800;
            game.Height = 600;
            Game.Init(game);
            game.FormClosed += Game_FormClosed;
            game.Show();
            Game.Draw();
            Application.Run(game);
        }
        
        private static void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Game.Closed();
        }
    }

}
