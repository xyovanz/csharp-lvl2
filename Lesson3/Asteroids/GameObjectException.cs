/*
 * Коды ошибок:
 * -1 - отрицательное значение
 *  0 - равно нулю
 *  1 - слишком большая скорость
 *  2 - выход за пределы формы
 * 
 */
using System;

namespace Asteroids
{
    class GameObjectException : Exception
    {
        public int Error { get; set; }
        
        public GameObjectException(string Msg, int Error) : base(Msg)
        {
            this.Error = Error;
        }
        
        public override string ToString()
        {
            return $"{base.Message}. Код ошибки: {Error}";
        }

    }
}
