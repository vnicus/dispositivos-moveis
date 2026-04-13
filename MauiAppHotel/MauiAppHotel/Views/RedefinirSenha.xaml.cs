namespace MauiAppHotel.Views;

public partial class RedefinirSenha : ContentPage
{
	public RedefinirSenha()
	{
		InitializeComponent();
	}

    private void Button_Redefinir_Senha(object sender, EventArgs e)
    {

    }

    private async void OnLabelLinkTapped(object sender, TappedEventArgs e)
    {
        Login lg = new();
        await Navigation.PushAsync(lg);
    }
}