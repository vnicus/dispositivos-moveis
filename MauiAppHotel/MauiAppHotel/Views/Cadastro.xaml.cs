using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Cadastro : ContentPage
{
	public Cadastro()
	{
		InitializeComponent();
	}

    private async void Button_Cadastar(object sender, EventArgs e)
    {
        try
        {
            Usuario u = new Usuario();
            u.Nome = ent_nome.Text;
            u.Email = ent_email.Text;
            u.Senha = ent_senha.Text;

            App.lista_usuarios.Add(u);

            await DisplayAlertAsync("Sucesso", "Esta cadastrado", "Fechar");

            await Navigation.PushAsync(new Login());
        }
        catch (Exception ex) //No model de Usuario tem um "throw" 
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
    }

    private async void OnLabelLinkTapped(object sender, TappedEventArgs e)
    {
        Login lg = new();
        await Navigation.PushAsync(lg);
    }
}