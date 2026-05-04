using Microsoft.Extensions.DependencyInjection;

namespace MauiAppTempoAgora
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
            
            w.Height = 700;
            w.Width = 350;

			return w;
        }
    }
}