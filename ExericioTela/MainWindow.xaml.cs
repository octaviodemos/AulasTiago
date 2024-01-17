using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

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

        private void info(object sender, RoutedEventArgs e)
        {
            string sexoSelecionado = string.Empty;

            if (CheckFeminino.IsChecked == true)
            {
                sexoSelecionado = "Feminino";
            }

            if (CheckMasculino.IsChecked == true)
            {
                sexoSelecionado = "Masculino";
            }

            if (string.IsNullOrEmpty(AlturaText.Text))
            {
                MessageBox.Show("Digite informações de altura corretas");
                return;
            }

            pessoas[pessoaatual] = new Pessoa
            {
                Sexo = sexoSelecionado,
                Altura = Convert.ToDouble(AlturaText.Text)
            };

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
    }
}
