using MauiAppFit.ViewModels;
using System.Diagnostics;

namespace MauiAppFit.Views;

public partial class CadastroAtividade : ContentPage
{
	public CadastroAtividade()
	{
		InitializeComponent();

		BindingContext = new CadastroAtividadeViewModel();
	}

	protected override async void OnAppearing()
	{
		var vm = (CadastroAtividadeViewModel) BindingContext;

		Debug.WriteLine("---------------------------");
		Debug.WriteLine(vm.Id);

		if(vm.Id == 0)
		{
			vm.NovaAtividade.Execute(null);
		}
	}


}