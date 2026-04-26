using MauiMinhasCompras2.Models;

namespace MauiMinhasCompras2.Views;

public partial class CadastrarProdutoView : ContentPage
{
	public CadastrarProdutoView()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto? produto_anexado = BindingContext as Produto;

            Produto p = new()
            {
                Descricao = txt_descricao.Text,
                Preco = Convert.ToDouble(txt_preco.Text),
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
            };

            if (produto_anexado == null)
            {
                await App.Db.Insert(p);
            }
            else
            {
                p.Id = produto_anexado.Id;
                await App.Db.Update(p);
            }

            await DisplayAlertAsync("Sucesso", "Dados Salvos!", "Ok");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
    }
}