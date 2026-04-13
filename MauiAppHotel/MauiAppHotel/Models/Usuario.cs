namespace MauiAppHotel.Models
{
    public class Usuario
    {
        string _nome = "";
        string _senha = "";
        string _email = "";

        public string Nome
        {
            get => _nome;
            set
            {
                if (value == null)
                    throw new Exception("Informe seu nome.");
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value == null)
                    throw new Exception("Informe seu E-mail.");
            }
        }
        public string Senha
        {
            get => _senha;
            set
            {
                if (value == null)
                    throw new Exception("Informe sua senha.");
            }
        }
    }
}
