using MauiMinhasCompras2.Models;
using System.Collections.ObjectModel;

namespace MauiMinhasCompras2.Views;

public partial class ListaProdutosView : ContentPage
{
    ObservableCollection<Produto> Lista { get; set; } = new();

    public ListaProdutosView()
    {
        InitializeComponent();

        list_produtos.ItemsSource = Lista;

        /*list_produtos.ItemsSource = new List<Produto>()
        {
            new Produto()
            {
                Id = 1,
                Descricao = "Caderno",
                Preco = 5.10,
                Quantidade = 5,
            },
             new Produto()
            {
                Id = 2,
                Descricao = "Jacaré",
                Preco = 11,
                Quantidade = 5,
            },
              new Produto()
            {
                Id = 3,
                Descricao = "Laranjinha",
                Preco = 55.8,
                Quantidade = 9,
            },
            new Produto()
            {
                Id = 4,
                Descricao = "Ovo",
                Preco = 7,
                Quantidade = 3,
            },
        };*/

        BindingContext = this;
    }

    protected async override void OnAppearing()
    {
        try
        {
            Lista.Clear(); //Limpa a lista atual
            List<Produto> tmp = await App.Db.GetAll(); //Carrega a lista na var tmp com o banco de dados
            tmp.ForEach(x => Lista.Add(x)); //Salve a lista temporaria na lista principal
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
    }

    private async void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
    {
        double soma = Lista.Sum(i => i.Total);

        string msg = $"O total é {soma:C}";

        await DisplayAlertAsync("Total", msg, "Ok");
    }

    private void ToolbarItem_Clicked_Adicionar(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.CadastrarProdutoView());
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string q = e.NewTextValue;
            Lista.Clear();
            List<Produto> tmp = await App.Db.Search(q);
            tmp.ForEach(x => Lista.Add(x));
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
    }

    private async void SwipeItem_Clicked_Editar(object sender, EventArgs e)
    {
        try
        {
            SwipeItem? selecionado = sender as SwipeItem;
            Produto? p = selecionado?.BindingContext as Produto;

            await Navigation.PushAsync(new Views.CadastrarProdutoView
            {
                BindingContext = p,
            });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
    }
    private async void SwipeItem_Clicked_Remover(object sender, EventArgs e)
    {
        try
        {
            SwipeItem? selecionado = sender as SwipeItem;
            Produto? p = selecionado?.BindingContext as Produto;

            bool confirmacao = await DisplayAlertAsync(
                "Tem certeza?",
                $"Deseja remover o item {p.Descricao}?",
                "Sim", "Cancelar"
                );

            if (confirmacao)
            {
                await App.Db.Delete(p);
                Lista.Remove(p);
            }

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
    }
}