using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	List<Quarto> list_quartos = new List<Quarto>()
		{
			new Quarto()
			{
				Descricao = "Suite Super de Luxo",
				ValorDiariaAdulto = 110.0,
				ValorDiariaCrianca = 60,
			},
			new Quarto()
			{
				Descricao = "Suite Basic Travel",
				ValorDiariaAdulto = 50,
				ValorDiariaCrianca = 20,
			},
			new Quarto()
			{
				Descricao = "Suite de Luxo",
				ValorDiariaAdulto = 85,
				ValorDiariaCrianca = 30,
			},
			new Quarto()
			{
				Descricao = "Suite Home Sweet Home",
				ValorDiariaAdulto = 110.0,
				ValorDiariaCrianca = 60,
			},
		};
	public ContratacaoHospedagem()
	{
		InitializeComponent();

		// Abastecendo o picker(Select do xaml) com a lista de quartos
		pck_quarto.ItemsSource = list_quartos;

		//Validando a data mínima de máxima de checkin
		dtpck_checkin.MinimumDate = DateTime.Now;
		dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(3);

		dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
		dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(3);
	}
	protected override async void OnAppearing()
	{
		string? nome_usuario = await SecureStorage.Default.GetAsync("nome_usuario");

		if (nome_usuario != null)
		{
			txt_usuario_logado.Text = nome_usuario;
			txt_usuario_logado.IsVisible = true;
			btn_sair.IsVisible = true;
		}
	}

	private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
		DatePicker elemento = (DatePicker)sender;

		DateTime data_selecionada = elemento.Date.Value;

		dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
		dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(3);
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			//Montagem do Objeto com os dados da hospedagem
			Hospedagem h = new()
			{
				//                  Typecast
				QuartoSelecionado = (Quarto) pck_quarto.SelectedItem,
				DataCheckin = (DateTime) dtpck_checkin.Date,
				DataCheckout = (DateTime) dtpck_checkout.Date,
				QntAdultos = Convert.ToInt32(stp_adultos.Value),
				QntCriancas = Convert.ToInt32(stp_criancas.Value),
			};

			//Criação do nova tela, onde serão mostrados os dados de hospedagem
			HospedagemContratada hc = new();

			//Juntando o esquelo da tela com os dados da hospedagem
			hc.BindingContext = h;

            //Navigation - este metodo esta resposanvel por mudar de tela
            await Navigation.PushAsync(hc);



            // Mesma coisa da linha 72 à 77
			await Navigation.PushAsync(new HospedagemContratada()
			{
				BindingContext = new Hospedagem ()
				{
					QuartoSelecionado = (Quarto) pck_quarto.SelectedItem,
					DataCheckin = (DateTime) dtpck_checkin.Date,
					DataCheckout = (DateTime) dtpck_checkout.Date,
					QntAdultos = Convert.ToInt32(stp_adultos.Value),
					QntCriancas = Convert.ToInt32(stp_criancas.Value),
				}
			});

        }
        catch (Exception ex) {
			await DisplayAlertAsync("Deu algum erro", ex.Message, "Ok");
		}
    }

    private async void Button_Redefinir_Senha(object sender, EventArgs e)
    {
		RedefinirSenha rs = new();
        await Navigation.PushAsync(rs);
    }

    private async void Button_Login(object sender, EventArgs e)
    {
        Login lg = new();
        await Navigation.PushAsync(lg);
    }

    private async void Button_Cadastrar(object sender, EventArgs e)
    {
        Cadastro cd = new();
        await Navigation.PushAsync(cd);
    }

    private async void btn_sair_Clicked(object sender, EventArgs e)
    {
		bool confirmacao = await DisplayAlertAsync("Tem certeza?", "Deseja encerrar a sua sessão?", "Sim", "Cancelar");

		if (confirmacao)
		{
			SecureStorage.Default.Remove("nome_usuario");
			btn_sair.IsVisible = false;
			txt_usuario_logado.IsVisible = false;

		}
	}
}