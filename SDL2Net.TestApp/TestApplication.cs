using System.Drawing;

namespace SDL2Net.TestApp
{
    public class TestApplication : SDLApplication
    {
        private readonly SDLWindow _window;
        private readonly SDLRenderer _renderer;
        
        private static readonly Point[] _points = {
            new Point(320, 200), 
            new Point(300, 240), 
            new Point(340, 240),
            new Point(320, 200)
        };

        public TestApplication()
        {
            _window = new SDLWindow("Hello!", 100, 100, 800, 600);
            _renderer = new SDLRenderer(_window);
        }

        protected override void Update(uint elapsed)
        {
            _renderer.DrawColor = Color.Black;
            _renderer.Clear();
            _renderer.DrawColor = Color.Gold;
            //_renderer.DrawLine(300, 400, 500, 100);
            _renderer.DrawLines(_points);
            _renderer.Present();
        }

        public override void Dispose()
        {
            _renderer.Dispose();
            _window.Dispose();
            base.Dispose();
        }

        public static void Main(string[] args)
        {
            using var app = new TestApplication();
            app.Run();
        }
    }
}