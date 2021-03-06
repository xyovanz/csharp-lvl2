using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;

        //Число объектов
        const int planetsN = 5;
        const int starsN = 30;
        const int asteroidsN = 30;
        const int smallStarsN = 100;
        //Скорости объектов
        const int smallStarSpeed = 5;
        const int starSpeed = 1;
        const int planetSpeed = 8;
        const int asteroidSpeed = 15;
        //Размеры объектов
        const int maxSize = 20;
        const int minSize = 10;
        const int starMaxSize = maxSize / 2;
        const int starMinSize = minSize / 2;
        const int planetMaxSize = maxSize * 4;
        const int planetMinSize = minSize * 4;
        //Ограничения объектов
        const int formSizeLimit = 1000;
        const int speedLimit = 30;
        
        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game()
        {
        }
        
        public static void Load()
        {
            bool exceptionExists = false;
            try
            {
                _objs = new BaseObject[starsN + planetsN + smallStarsN];

                _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));

                _asteroids = new Asteroid[asteroidsN];

                exceptionExists = false;

                for (int i = 0; i < _objs.Length - starsN - planetsN; i++)
                {
                    _objs[i] = new SmallStar(new Point(Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Width),
                        Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Height)),
                        new Point(myRandom.RandomIntNumber(-smallStarSpeed, -1), 0), new Size(1, 1));
                }

                for (int i = _objs.Length - starsN - planetsN; i < _objs.Length - planetsN; i++)
                {
                    int size = myRandom.RandomIntNumber(starMinSize, starMaxSize);
                    int widthPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Width);
                    int heightPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Height);
                    int speed = myRandom.RandomIntNumber(-starSpeed * 2, -1);

                    _objs[i] = new Star(new Point(widthPosition, heightPosition),
                                new Point(speed, 0), new Size(size, size));

                    if (size < 0)
                        throw new GameObjectException($"Размер объекта {typeof(Star)} меньше нуля", -1);
                    if (speed > 0)
                        throw new GameObjectException($"Объект {typeof(Star)} двигается не в ту сторону", 1);
                    if (speed == 0)
                        throw new GameObjectException($"Объект {typeof(Star)} стоит на месте", 0);

                }

                for (int i = _objs.Length - planetsN; i < _objs.Length; i++)
                {
                    int size = myRandom.RandomIntNumber(planetMinSize, planetMaxSize);
                    int widthPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Width);
                    int heightPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Height);
                    int speed = myRandom.RandomIntNumber(-planetSpeed, -1);

                    _objs[i] = new Planet(new Point(widthPosition, heightPosition),
                                new Point(speed, 0), new Size(size, size));

                    if (size < 0)
                        throw new GameObjectException($"Размер объекта {typeof(Planet)} меньше нуля", -1);
                    if (speed > 0)
                        throw new GameObjectException($"Объект {typeof(Planet)} двигается не в ту сторону", 1);
                    if (speed == 0)
                        throw new GameObjectException($"Объект {typeof(Planet)} стоит на месте", 0);

                }

                for (int i = 0; i < _asteroids.Length; i++)
                {
                    int size = myRandom.RandomIntNumber(minSize, maxSize);
                    int widthPosition = Convert.ToInt32(myRandom.RandomDoubleNumber()*(double)(Game.Width) - size);
                    int heightPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Height - size);
                    int speed1 = myRandom.RandomIntNumber(-asteroidSpeed, asteroidSpeed);
                    int speed2 = myRandom.RandomIntNumber(-asteroidSpeed, asteroidSpeed);

                    _asteroids[i] = new Asteroid(new Point(widthPosition, heightPosition),
                                    new Point(speed1, speed2), new Size(size, size));

                    if (size < 0)
                        throw new GameObjectException($"Размер объекта {typeof(Asteroid)} меньше нуля", -1);
                    if (widthPosition < 0 || widthPosition > Game.Width || heightPosition < 0 || heightPosition > Game.Height)
                        throw new GameObjectException($"Объект {typeof(Asteroid)} появился за пределами экрана", 2);
                    if (speed1 == 0 && speed2 == 0)
                        throw new GameObjectException($"Объект {typeof(Asteroid)} стоит на месте", 0);
                    if (Math.Abs(speed1) > speedLimit || Math.Abs(speed2) > speedLimit)
                        throw new GameObjectException($"Объект {typeof(Asteroid)} двигается со слишком большой скоростью", 1);

                }
            }
            catch (GameObjectException ex)
            {
                exceptionExists = true;
                Debug.WriteLine($"{DateTime.Now.ToString()}: {ex.ToString()}");
            }
            finally
            {
                if (exceptionExists)
                    Load();
            }
        }

        public static void LoadBad()
        {
            bool exceptionExists = false;
            try
            {
                _objs = new BaseObject[starsN + planetsN + smallStarsN];

                _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));

                _asteroids = new Asteroid[asteroidsN];

                exceptionExists = false;

                for (int i = 0; i < _objs.Length - starsN - planetsN; i++)
                {
                    _objs[i] = new SmallStar(new Point(Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Width),
                        Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Height)),
                        new Point(myRandom.RandomIntNumber(-smallStarSpeed, -1), 0), new Size(1, 1));
                }

                for (int i = _objs.Length - starsN - planetsN; i < _objs.Length - planetsN; i++)
                {
                    int size = myRandom.RandomIntNumber(-1, starMaxSize); //*от starMinSize
                    int widthPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Width + size);//*убрать size
                    int heightPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Height + size);//*убрать size
                    int speed = myRandom.RandomIntNumber(-starSpeed * 2, 2);//*до -1

                    _objs[i] = new Star(new Point(widthPosition, heightPosition),
                                new Point(speed, 0), new Size(size, size));

                    if (size < 0)
                        throw new GameObjectException($"Размер объекта {typeof(Star)} меньше нуля", -1);
                    if (speed > 0)
                        throw new GameObjectException($"Объект {typeof(Star)} двигается не в ту сторону", 1);
                    if (speed == 0)
                        throw new GameObjectException($"Объект {typeof(Star)} стоит на месте", 0);

                }

                for (int i = _objs.Length - planetsN; i < _objs.Length; i++)
                {
                    int size = myRandom.RandomIntNumber(-1, planetMaxSize);//*от planetMinSize
                    int widthPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Width + size);//*убрать size
                    int heightPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Height + size);//*убрать size
                    int speed = myRandom.RandomIntNumber(-planetSpeed, 2);//*до -1

                    _objs[i] = new Planet(new Point(widthPosition, heightPosition),
                                new Point(speed, 0), new Size(size, size));

                    if (size < 0)
                        throw new GameObjectException($"Размер объекта {typeof(Planet)} меньше нуля", -1);
                    if (speed > 0)
                        throw new GameObjectException($"Объект {typeof(Planet)} двигается не в ту сторону", 1);
                    if (speed == 0)
                        throw new GameObjectException($"Объект {typeof(Planet)} стоит на месте", 0);

                }

                for (int i = 0; i < _asteroids.Length; i++)
                {
                    int size = myRandom.RandomIntNumber(-1, maxSize);//*от minSize
                    int widthPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)(Game.Width));//*добавить - size
                    int heightPosition = Convert.ToInt32(myRandom.RandomDoubleNumber() * (double)Game.Height);//*добавить - size
                    int speed1 = myRandom.RandomIntNumber(-31, 32);//*-asteroidSpeed, asteroidSpeed
                    int speed2 = myRandom.RandomIntNumber(-31, 32);//*-asteroidSpeed, asteroidSpeed

                    _asteroids[i] = new Asteroid(new Point(widthPosition, heightPosition),
                                    new Point(speed1, speed2), new Size(size, size));

                    if (size < 0)
                        throw new GameObjectException($"Размер объекта {typeof(Asteroid)} меньше нуля", -1);
                    if (widthPosition < 0 || widthPosition > Game.Width || heightPosition < 0 || heightPosition > Game.Height)
                        throw new GameObjectException($"Объект {typeof(Asteroid)} появился за пределами экрана", 2);
                    if (speed1 == 0 && speed2 == 0)
                        throw new GameObjectException($"Объект {typeof(Asteroid)} стоит на месте", 0);
                    if (Math.Abs(speed1) > speedLimit || Math.Abs(speed2) > speedLimit)
                        throw new GameObjectException($"Объект {typeof(Asteroid)} двигается со слишком большой скоростью", 1);

                }
            }
            catch (GameObjectException ex)
            {
                exceptionExists = true;
                Debug.WriteLine($"{DateTime.Now.ToString()}: {ex.ToString()}");
            }
            finally
            {
                if (exceptionExists)
                    LoadBad();
            }
        }

        static public Timer timer = new Timer { Interval = 50 };
        
        public static void Init(Form form)
        {           
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            try
            {
                Width = form.ClientSize.Width;
                Height = form.ClientSize.Height;
                if (Width > formSizeLimit || Height > formSizeLimit)
                {
                    throw new ArgumentOutOfRangeException("Высота или ширина формы принимают значение больше 1000");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            timer.Start();
            timer.Tick += Timer_Tick;

        }

        public static void InitBad(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            try
            {
                Width = form.ClientSize.Width;
                Height = form.ClientSize.Height;
                if (Width > formSizeLimit || Height > formSizeLimit)
                {
                    throw new ArgumentOutOfRangeException("Высота или ширина формы принимают значение больше 1000");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            LoadBad();

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
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();
        }
        
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Asteroid ast in _asteroids)
            {
                ast.Update();
                if (ast.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    ast.Respawn();
                    _bullet.Respawn();
                }
            }
            _bullet.Update();
        }
    }
}

