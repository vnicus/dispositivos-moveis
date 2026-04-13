using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MauiAppHotel.Models
{
	internal class Hospedagem
	{
		Quarto quarto_selecionado = new();
		public Quarto QuartoSelecionado
		{
			get => quarto_selecionado;
			set
			{
				if (value == null)
					throw new Exception("Selecione um quarto");

				quarto_selecionado = value; ;

			}
		}
		public int QntAdultos { get; set; }
		public int QntCriancas { get; set; }
		public DateTime DataCheckin { get; set; }
		public DateTime DataCheckout { get; set; }
		public int Estadia { 
			get
			{
				return DataCheckout.Subtract(DataCheckin).Days;
			}

			// get => (DataCheckout - DataCheckin).Days;
			//Outra forma de fazer o calculo
		}
		public double ValorTotal
		{
			get
			{
				double valor_adultos = QntAdultos * QuartoSelecionado.ValorDiariaAdulto;
				double valor_criancas = QntCriancas * QuartoSelecionado.ValorDiariaAdulto;

				double valor_total = (valor_adultos + valor_criancas) * Estadia;
				return valor_total;
			}
		}
	}
}
