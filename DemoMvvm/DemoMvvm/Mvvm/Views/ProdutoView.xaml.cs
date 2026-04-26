using DemoMvvm.Mvvm.ViewModels;

namespace DemoMvvm.Mvvm.Views;

public partial class ProdutoView : ContentPage
{
	public ProdutoView()
	{
		InitializeComponent();
		BindingContext = new ProdutoViewModel();
	}
}