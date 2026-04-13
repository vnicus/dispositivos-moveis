using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Entrar(object sender, EventArgs e)
    {
        try
        {
            // Dados digitados pelo o usuario
            Usuario u = new Usuario();
            u.Email = ent_email.Text;
            u.Senha = ent_senha.Text;

            // LINQ - usado para fazer consultas mais complexas
            bool userExists = App.lista_usuarios.Any(i => (i.Senha == u.Senha && i.Email == u.Email));
            // Na linha acima, faz uma verificação se existe um obj usuario que atentas as condições, percorrento o arry/list inteiro.

            if (userExists)
            {
                await DisplayAlertAsync("Sucesso", "Login realizado com sucesso.", "Fechar");
                await SecureStorage.Default.SetAsync("nome_usuario", u.Email); //Guarda o dados em um local criptografado no dispositivo
            }
            else
            {
                throw new Exception("E-mail ou Senha incorretos, tente novamente.");
            }

        } catch (ArgumentNullException ex) 
        {
			await DisplayAlertAsync("Erro", "Display Alart não preecheido corretamente", "Fechar");

		}
		catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Fechar");
        }
    }

    private async void OnLabelLinkTapped(object sender, TappedEventArgs e)
    {
        Cadastro cd = new();
        await Navigation.PushAsync(cd);
    }
}