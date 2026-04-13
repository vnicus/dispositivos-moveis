using Java.Lang;

namespace AppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        int placarX = 0;
        int placarO = 0;
        string jogadorWin = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button clicado = (Button)sender;
            clicado.Text = vez;
            clicado.IsEnabled = false;

            Ganhador(VerificarJogada(vez));

            vez = (vez == "X") ? "O" : "X";
        }

        private async void Ganhador(string Win)
        {
            
        }

        private string VerificarJogada(string vez)
        {

            //Horizontal
            if (btn10.Text == vez && btn11.Text == vez && btn12.Text == vez)
                jogadorWin = vez;

            if (btn20.Text == vez && btn21.Text == vez && btn22.Text == vez)
                jogadorWin = vez;

            if (btn30.Text == vez && btn31.Text == vez && btn32.Text == vez)
                jogadorWin = vez;


            //Vertical
            if (btn10.Text == vez && btn20.Text == vez && btn30.Text == vez)
                jogadorWin = vez;

            if (btn11.Text == vez && btn21.Text == vez && btn31.Text == vez)
                jogadorWin = vez;

            if (btn12.Text == vez && btn22.Text == vez && btn32.Text == vez)
                jogadorWin = vez;

            //Diagonal
            if (btn10.Text == vez && btn21.Text == vez && btn32.Text == vez)
                jogadorWin = vez;

            if (btn12.Text == vez && btn21.Text == vez && btn30.Text == vez)
                jogadorWin = vez;

            return jogadorWin;

        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            vez = "X";
            placarX = 0;
            placarO = 0;

        }
    }
}
