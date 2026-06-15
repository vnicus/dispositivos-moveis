using MauiAppFit.ViewModels;
using System.Diagnostics;

namespace MauiAppFit.Views;

public partial class ListaAtividades : ContentPage
{
	public ListaAtividades()
	{
        BindingContext = new ListaAtividadesViewModel();
        InitializeComponent();
        
    }

    protected override void OnAppearing()
    {
        var vm = (ListaAtividadesViewModel)BindingContext;
		vm.AtualizarLista.Execute(null);
        Debug.WriteLine("-----------------------------");
        Debug.WriteLine("Está chamando AtualizarLista quando abre a tela.");
    }
}