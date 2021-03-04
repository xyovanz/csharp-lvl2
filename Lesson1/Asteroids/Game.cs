using System;
using System.Drawing;
using System.Windows.Forms;
namespace Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static Template[] _objs;

        const int OtherSpeed = 6;
        const int PlanetSpeed = 3;
        const int PlanetsCount = 3;
        const int StarsCount = 30;
        const int AsteroidsCount = 15;
        const int SmallStarsCount = 50;
        const int maxSize = 30;
        const int minSize = 10;
        
        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game()
        {
        }

        /// <summary>Метод создания объектов в окне</summary>
        public static void Load()
        {
            Random rand = new Random();
            _objs = new Template[StarsCount + AsteroidsCount + PlanetsCount + SmallStarsCount];

            for (int i = 0; i < _objs.Length - StarsCount - PlanetsCount - AsteroidsCount; i++)
            {
                _objs[i] = new SmallStar(new Point(Convert.ToInt32(rand.NextDouble() * (double)Game.Width),
                    Convert.ToInt32(rand.NextDouble() * (double)Game.Height)), new Point(rand.Next(-OtherSpeed, -1), 0), new Size(1, 1));
            }

            for (int i = _objs.Length - StarsCount - PlanetsCount - AsteroidsCount; i < _objs.Length - PlanetsCount - AsteroidsCount; i++)
            {
                int size = rand.Next(minSize / 2, maxSize / 2);
                _objs[i] = new Star(new Point(Convert.ToInt32(rand.NextDouble() * (double)Game.Width),
                    Convert.ToInt32(rand.NextDouble() * (double)Game.Height)), new Point(rand.Next(-OtherSpeed * 2, -1), 0), new Size(size, size));
            }

            for (int i = _objs.Length - PlanetsCount - AsteroidsCount; i < _objs.Length - AsteroidsCount; i++)
            {
                int size = rand.Next(minSize * 3, maxSize * 3);
                _objs[i] = new Planet(new Point(Convert.ToInt32(rand.NextDouble() * (double)Game.Width),
                    Convert.ToInt32(rand.NextDouble() * (double)Game.Height)), new Point(rand.Next(-PlanetSpeed / 2, -1), 0), new Size(size, size));
            }

            for (int i = _objs.Length - AsteroidsCount; i < _objs.Length; i++)
            {
                int size = rand.Next(minSize, maxSize);
                _objs[i] = new Template(new Point(Convert.ToInt32(rand.NextDouble() * (double)(Game.Width - size)),
                    Convert.ToInt32(rand.NextDouble() * (double)(Game.Height - size))), new Point(rand.Next(-OtherSpeed, OtherSpeed),
                    rand.Next(-OtherSpeed, OtherSpeed)), new Size(size, size));
            }
        }
        
        static public Timer timer = new Timer { Interval = 100 };
        
        public static void Init(Form form)
        {       
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            timer.Start();
            timer.Tick += Timer_Tick;

        }
        
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (Template obj in _objs)
                obj.Draw();
            Buffer.Render();
        }
        
        public static void Update()
        {
            foreach (Template obj in _objs)
                obj.Update();
        }

    }
}
