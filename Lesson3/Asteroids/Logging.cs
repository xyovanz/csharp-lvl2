using System.Diagnostics;

namespace MyGame
{
    /// <summary>Класс логирования действий программы</summary>
    class Logging
    {
        /// <summary>Метод записи в файл</summary>
        /// <param name="Msg">Текст сообщения</param>
        public void Log(string Msg)
        {
            using (var sw = new System.IO.StreamWriter("data.log", true))
            {
                Debug.WriteLine(Msg);
                sw.WriteLine(Msg);
            }
        }
    }
}
