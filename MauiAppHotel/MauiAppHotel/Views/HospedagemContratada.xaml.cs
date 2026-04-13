namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{

	bool usuario_logado = false;

	public HospedagemContratada()
	{
		InitializeComponent();
	}
	
	protected override async void OnAppearing()
	{
		string? email_usuario = await SecureStorage.Default.GetAsync("nome_usuario");

		if(email_usuario != null)
			usuario_logado = true;
	}

	private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ContratacaoHospedagem());
    }

	private async void Button_Clicked_Avacnar(object sender, EventArgs e)
	{
		if (!usuario_logado)
			await Navigation.PushAsync(new ContratacaoHospedagem());
		else
			await DisplayAlertAsync("Opa", "Você já esta logado, Hora de pagar!", "Ok");
	}
}