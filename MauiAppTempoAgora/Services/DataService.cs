using MauiAppTempoAgora.Models;
using Newtonsoft.Json.Linq;

namespace MauiAppTempoAgora.Services
{
	public class DataService
	{
		public static async Task<Tempo> GetTempo(string cidade)
		{
			Tempo? t = null;

			string? chave = "151d565636418d580598f78884e6f477";
			string? uri = $"https://api.openweathermap.org/data/2.5/weather?q={cidade}&units=metric&appid={chave}";

			using (HttpClient client = new HttpClient()) // lanço de condição, usando e destruindo logo em seguida, apenas dentro do metodo
			{
				HttpResponseMessage response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{

					string json = await response.Content.ReadAsStringAsync();

					var rascunho = JObject.Parse(json);

					DateTime tempo = new();
					DateTime sunrise = tempo.AddSeconds((double)rascunho["sys"]["sunrise"]);
					DateTime sunset = tempo.AddSeconds((double)rascunho["sys"]["sunset"]);

					t = new()
					{
						Lat = (double)rascunho["coord"]["lat"],
						Lon = (double)rascunho["coord"]["lon"],
						Description = (string)rascunho["weather"][0]["main"],
						TempMax = (double)rascunho["main"]["temp_max"],
						TempMin = (double)rascunho["main"]["temp_min"],
						Temp = (double)rascunho["main"]["temp"],

						FeelsLike = (double)rascunho["main"]["feels_like"],
						Visibility = (int)rascunho["visibility"],
						Sunrise = sunrise,
						Sunset = sunset,
						Timezone = (int)rascunho["timezone"],
						Icon = (string)rascunho["weather"][0]["icon"]
					};

				}

			}

			return t;
		}
	}
}
