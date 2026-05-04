using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try 
            {
                if (txt_cidade.Text != "") 
                {
                    Tempo? t = await DataService.GetTempo(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = $"Latitude: {t.Lat} " +
                            $"                    \nLongitude: {t.Lon} " +
                            $"                    \nTemperatura: {t.Temp} \n";

						lbl_previsao.Text = dados_previsao;

                        string mapa = "https://embed.windy.com/embed.html?type=map&location=coordinates" +
                            "           &metricRain=mm&metricTemp=°C&metricWind=km/h&zoom=5&overlay=win" +
                            $"           d&product=ecmwf&level=surface&lat={t.Lat.ToString().Replace(",", ".")}&lon={t.Lon.ToString().Replace(",", ".")}";

                        wv_mapa.Source= mapa;

					}
                }
                else
                    throw new Exception("Informe a cidade");
            }
            catch (Exception ex) 
            {
                await DisplayAlertAsync("Erro", $"{ex.Message}", "Ok");
            }
        }
    }
}
