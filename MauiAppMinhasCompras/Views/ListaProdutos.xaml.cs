using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProdutos : ContentPage
{
	ObservableCollection<Produto> lista = new(); //sync automatico no banco
	public ListaProdutos()
	{
		InitializeComponent();

		list_produtos.ItemsSource = lista; //atualizar a list_produtos, toda vez que houver nova att no BD de Produto

       /* list_produtos.ItemsSource = new List<Models.Produto>()
        {
            new Models.Produto()
            {
                Id = 1,
                Descricao = "Caderno",
                Preco = 5.10,
                Quantidade = 5,
            },
			 new Models.Produto()
			{
				Id = 2,
				Descricao = "Jacaré",
				Preco = 11,
				Quantidade = 5,
			},
			  new Models.Produto()
			{
				Id = 3,
				Descricao = "Laranjinha",
				Preco = 55.8,
				Quantidade = 9,
			},
			new Models.Produto()
			{
				Id = 4,
				Descricao = "Ovo",
				Preco = 7,
				Quantidade = 3,
			},
		}; */
	}

	protected async override void OnAppearing()
	{
		try
		{
			lista.Clear();
			List<Produto> tmp = await App.Db.GetAll();
			tmp.ForEach(x => lista.Add(x));
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Erro", ex.Message, "Fechar");
		}
	}

    private async void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
    {
		double soma = lista.Sum(i => i.Total);

		string msg = $"O total é {soma:C}";

		await DisplayAlertAsync("Total", msg, "Ok");
    }

    private void ToolbarItem_Clicked_Adicionar(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Views.CadastroProduto());
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
			string q = e.NewTextValue;
			list_produtos.IsRefreshing = true;
			lista.Clear();
			List<Produto> tmp = await App.Db.Search(q);
            tmp.ForEach(x => lista.Add(x));
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
		finally
		{
			list_produtos.IsRefreshing = false;
		}
    }

    private async void list_produtos_Refreshing(object sender, EventArgs e)
    {
        try
        {
            list_produtos.IsRefreshing = true;
            lista.Clear();
            List<Produto> tmp = await App.Db.GetAll();
            tmp.ForEach(x => lista.Add(x));
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
        finally
        {
            list_produtos.IsRefreshing = false;
        }
    }

    private async void list_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto? p = e.SelectedItem as Produto;

            await Navigation.PushAsync(new Views.CadastroProduto
            {
                BindingContext = p,
            });
        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
	}

    private async void MenuItem_Clicked_Remover(object sender, EventArgs e)
    {
        try
        {
           MenuItem? selecionado = sender as MenuItem;
           Produto? p = selecionado?.BindingContext as Produto;

            bool confirmacao = await DisplayAlertAsync(
                "Tem certeza?",
                $"Deseja remover o item {p.Descricao}?",
                "Sim", "Cancelar"
                );

            if (confirmacao)
            {
                await App.Db.Delete(p.Id);
                lista.Remove(p);
            }

            list_produtos.IsRefreshing = true;
            lista.Clear();
            List<Produto> tmp = await App.Db.GetAll();
            tmp.ForEach(x => lista.Add(x));

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
        finally
        {
            list_produtos.IsRefreshing = false;
        }
    }
}