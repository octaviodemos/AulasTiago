using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ExercicioTela
{
    public partial class MainWindow : Window
    {
        Pessoa[] pessoas = new Pessoa[8];
        int pessoaatual = 0;

        int quantidadeMulheresMenos170 = 0;
        double alturaHomemMaisAlto = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sexoSelecionado = string.Empty;
            string alturaDigitada = AlturaText.Text;
            double altura;
            if (CheckFeminino.IsChecked == true)
            {
                sexoSelecionado = "Feminino";
            }

            if (CheckMasculino.IsChecked == true)
            {
                sexoSelecionado = "Masculino";
            }

            if (string.IsNullOrEmpty(alturaDigitada))
            {
                MessageBox.Show("Digite informações de altura corretas");
                AlturaText.Focus();
                return;
            }

            if (double.TryParse(alturaDigitada, out altura) == false || altura <= 0)
            {
                MessageBox.Show("Digite informações de altura corretas");
                AlturaText.Focus();
                return;
            }

            MessageBox.Show("Dados salvos");

            if (pessoaatual < 8)
            {
                pessoas[pessoaatual] = new Pessoa
                {
                    Sexo = sexoSelecionado,
                    Altura = altura
                };
            }

            CheckFeminino.IsChecked = false;
            CheckMasculino.IsChecked = false;
            AlturaText.Text = string.Empty;

            AlturaText.Focus();
            pessoaatual++;

            if (pessoaatual == 8)
            {
                MostrarResultados();
            }
        }

        private void MostrarResultados()
        {
            foreach (var pessoa in pessoas)
            {
                if (pessoa.Sexo.ToLower() == "feminino" && pessoa.Altura < 1.70)
                {
                    quantidadeMulheresMenos170++;
                }

                if (pessoa.Sexo.ToLower() == "masculino")
                {
                    if (pessoa.Altura > alturaHomemMaisAlto)
                    {
                        alturaHomemMaisAlto = pessoa.Altura;
                    }
                }
            }

            ResultsText.Text = $"Quantidade de mulheres com menos de 1.70m: {quantidadeMulheresMenos170}\nAltura do homem mais alto: {alturaHomemMaisAlto} metros";
        }
        public class Pessoa
        {
            public string Sexo { get; set; }
            public double Altura { get; set; }
        }

        private void CheckFeminino_Checked(object sender, RoutedEventArgs e)
        {
            AlturaText.Focus();
        }

        private void CheckMasculino_Checked(object sender, RoutedEventArgs e)
        {
            AlturaText.Focus();
        }

        private void AlturaText_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Button_Click(null, null);
            }
        }
    }
}
