using SQLite;

namespace MauiMinhasCompras2.Models
{
    public class Produto
    {
        string _descricao = ""; // Campo privado - onde fica armazenado o valor 

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao // Propriedade publico - Permite que outros metodos tenham o acesso ao campo 
        {
            get => _descricao;
            set
            {
                if(value == null)
                {
                    throw new Exception("Informe o nome do produto.");
                }

                _descricao = value;
            }
            
        }

        public double Quantidade { get; set; }
        public double Preco {  get; set; }
        public double Total 
        {
            get => Quantidade * Preco;
        
        }
    }
}
