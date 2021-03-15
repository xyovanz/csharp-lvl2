/* Добромыслов
 * 5)* Добавить в пример Lesson3 обобщенный делегат.  */

using System;

namespace App01
{
    class Source
    {
        public event Action<object> Run;

        public void Start()
        {
            Console.WriteLine("Бежим");
            Run?.Invoke(this);
        }
    }
    class Observer1
    {
        public void Go(object o)
        {
            Console.WriteLine($"Первый объект {o} побежал");
        }
    }
    class Observer2
    {
        public void Go(object o)
        {
            Console.WriteLine($"Второй объект {o} побежал");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Source s = new Source();
            Observer1 o1 = new Observer1();
            Observer2 o2 = new Observer2();
            Action<object> d1 = o1.Go;
            s.Run += d1;
            s.Run += o2.Go;
            s.Start();
            s.Run -= d1;
            s.Start();

            Console.ReadKey();
        }
    }
}
