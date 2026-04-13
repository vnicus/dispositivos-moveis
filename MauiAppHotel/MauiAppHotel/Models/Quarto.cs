using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models
{
	internal class Quarto
	{
		public string Descricao { get; set; } = String.Empty;
		public double ValorDiariaAdulto { get; set; }
		public double ValorDiariaCrianca { get; set; }

		public string NomeComPreco
		{
			get
			{
				return $"{Descricao} - Adulto {ValorDiariaAdulto.ToString("C")} - Criança {ValorDiariaCrianca.ToString("C")}";
			}
		}
	}
}
