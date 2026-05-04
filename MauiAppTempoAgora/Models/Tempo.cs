using System.Text.Json.Serialization;

namespace MauiAppTempoAgora.Models
{
    public class Tempo
    {
		[JsonPropertyName("lon")]
		public double? Lon { get; set; }

		[JsonPropertyName("lat")]
		public double? Lat { get; set; }

		[JsonPropertyName("temp")]
		public double? Temp { get; set; }

		[JsonPropertyName("feels_like")]
		public double? FeelsLike { get; set; }

		[JsonPropertyName("temp_min")]
		public double? TempMin { get; set; }

		[JsonPropertyName("temp_max")]
		public double? TempMax { get; set; }
		
		[JsonPropertyName("visibility")]
		public int? Visibility { get; set; }

		[JsonPropertyName("timezone")]
		public int? Timezone { get; set; }

		[JsonPropertyName("sunrise")]
		public DateTime? Sunrise { get; set; }

		[JsonPropertyName("sunset")]
		public DateTime? Sunset { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("icon")]
		public string? Icon { get; set; }

	}
}
