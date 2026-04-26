using MauiMinhasCompras2.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace MauiMinhasCompras2
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper? _db;// propriedade que geramos, n existe no pacote
        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string caminho_do_arquivo = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "db_mauiMinhasCompras.db3"
                    );

                    _db = new SQLiteDatabaseHelper(caminho_do_arquivo);
                }

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR"); // define todas os simbulos e tratamentos automatico de acordo com a região
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}