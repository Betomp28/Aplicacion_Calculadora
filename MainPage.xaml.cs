

using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ExaamenCalculadora
{
    public partial class MainPage : ContentPage
    {
        private decimal numero1 = 0;
        private decimal numero2 = 0;
        private string operador = "";
        private bool pruebaOperador = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void AgregarNumero(string valor)
        {
            if (char.IsDigit(valor[0]) || valor[0] == '.')
            {
                if (pruebaOperador)
                {
                    if (valor == ".")
                    {
                        calculoCalculadora.Text += "0.";
                    }
                    else
                    {
                        calculoCalculadora.Text += valor;
                    }
                    pruebaOperador = false;
                }
                else
                {
                    string textoActual = calculoCalculadora.Text;
                    if (valor == ".")
                    {
                        if (!textoActual.Contains("."))
                        {
                            textoActual += valor;
                        }
                    }
                    else
                    {
                        textoActual += valor;
                    }
                    calculoCalculadora.Text = textoActual;
                }
            }
            else
            {
                string textoActual = calculoCalculadora.Text;
                textoActual += " " + valor + " ";
                calculoCalculadora.Text = textoActual;
                pruebaOperador = true;
                operador = valor;
            }
        }

        private void Limpiar()
        {
            calculoCalculadora.Text = "";
            numero1 = 0;
            numero2 = 0;
            operador = "";
            resultado.Text = "0";
            pruebaOperador = false;
        }

        private void BtLimpiar_Clicked(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtDividir_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("/");
            operador = "/";
        }

        private void BtMultiplicar_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("x");
            operador = "x";
        }

        private void BTborrar_Clicked(object sender, EventArgs e)
        {
            string textoActual = calculoCalculadora.Text;
            if (!string.IsNullOrEmpty(textoActual))
            {
                textoActual = textoActual.Substring(0, textoActual.Length - 1);
                calculoCalculadora.Text = textoActual;
            }
        }

        private void BtNum7_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("7");
        }

        private void BtNum8_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("8");
        }

        private void BtNum9_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("9");
        }

        private void BtRestar_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("-");
            operador = "-";
        }

        private void BtNum4_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("4");
        }

        private void BtNum5_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("5");
        }

        private void BtNum6_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("6");
        }

        private void BtSumar_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("+");
            operador = "+";
        }

        private void BtNum1_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("1");
        }

        private void BtNum2_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("2");
        }

        private void BtNum3_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("3");
        }

        private void BtIgual_Clicked(object sender, EventArgs e)
        {
            try
            {
                string textoActual = calculoCalculadora.Text;
                string[] partes = textoActual.Split(' ');

                decimal resultado = decimal.Parse(partes[0]);

                foreach (string parte in partes.Skip(1).Take(partes.Length - 2))
                {
                    if (parte == "+" || parte == "-" || parte == "*" || parte == "/")
                    {
                        string operador = parte;
                        decimal numero = decimal.Parse(partes[Array.IndexOf(partes, parte) + 1]);

                        switch (operador)
                        {
                            case "+":
                                resultado += numero;
                                break;
                            case "-":
                                resultado -= numero;
                                break;
                            case "*":
                                resultado *= numero;
                                break;
                            case "/":
                                resultado /= numero;
                                break;
                        }
                        
                    }
                }

                this.resultado.Text = resultado.ToString();
                numero1 = resultado;
                calculoCalculadora.Text = resultado.ToString();
                pruebaOperador = false;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        private void BtNum0_Clicked(object sender, EventArgs e)
        {
            AgregarNumero("0");
        }

        private void BtPunto_Clicked(object sender, EventArgs e)
        {
            AgregarNumero(".");
        }

        private void BtPorcentaje_Clicked(object sender, EventArgs e)
        {
            try
            {
                string textoActual = calculoCalculadora.Text;
                decimal number = decimal.Parse(textoActual);
                number /= 100;
                this.resultado.Text = number.ToString();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

     
    }
}