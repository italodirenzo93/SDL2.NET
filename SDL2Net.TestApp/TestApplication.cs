using System;
using System.Drawing;
using System.Threading.Tasks;
using SDL2Net.Input;
using SDL2Net.Video;

namespace SDL2Net.TestApp
{
    public sealed class TestApplication : SDLApplication, IObserver<string>
    {
        private readonly Window _window;
        private readonly Renderer _renderer;
        
        private static readonly Point[] _points = {
            new Point(320, 200), 
            new Point(300, 240), 
            new Point(340, 240),
            new Point(320, 200)
        };

        public TestApplication()
        {
            _window = new Window("Hello!", 100, 100, 800, 600)
            {
                Resizable = true
            };
            _renderer = new Renderer(_window);
        }

        protected override void Initialize()
        {
            //MessageBox.ShowInformation("Test", "will you break?", _window);
            Events.Subscribe(this);
            Keyboard.Keypresses.Subscribe(x => Console.WriteLine($"Scancode {x.Key} pressed. repeat? {x.IsRepeat}"));
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
            try
            {
                app.Run();
            }
            catch (SDLException ex)
            {
                Console.Error.WriteLine(ex);
                throw;
            }
        }

        public void OnCompleted()
        {
            Console.WriteLine("shutting down...");
        }

        public void OnError(Exception error)
        {
            MessageBox.ShowError("Error Event", error.Message, _window);
        }

        public void OnNext(string value)
        {
            Console.WriteLine(value);
        }
    }
}