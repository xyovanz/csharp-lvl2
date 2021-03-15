using System.IO;
using System.Diagnostics;

namespace Asteroids
{
    class Logger
    {
        internal static void Log(string Msg)
        {
            using (var sw = new StreamWriter("data.log", true))
            {
                Debug.WriteLine(Msg);
                sw.WriteLine(Msg);
            }
        }
    }
}
