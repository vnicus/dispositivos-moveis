using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMvvm.Mvvm.Models
{
    public class Produto
    {
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool isAtivo { get; set; }
    }
}
