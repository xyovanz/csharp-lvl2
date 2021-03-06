using System.Drawing;

namespace MyGame
{
    /// <summary>Определяет столкновения двух объектов</summary>
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
