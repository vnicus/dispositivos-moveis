using Microsoft.Extensions.DependencyInjection;

namespace AppJogoDaVelha
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window w = new Window(new AppShell());
            w.Width = 350;
            w.Height = 700;

            return w;
        }
    }
}