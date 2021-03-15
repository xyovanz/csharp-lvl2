/* Добромыслов
 * 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
 * 3. Сделать так, чтобы при столкновениях пули с астероидом они регенерировались в разных концах экрана.
 * 4. Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) 
 * больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
 * 5. *Создать собственное исключение GameObjectException, которое появляется при попытке создать объект 
 * с неправильными характеристиками (например, отрицательные размеры, слишком большая скорость или позиция). */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
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
            //Game.InitBad(game); //ломаем все
            game.FormClosed += Game_FormClosed;
            game.Show();
            Game.Draw();
            Application.Run(game);
        }
        
        private static void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Game.timer.Stop();
        }
    }

}
