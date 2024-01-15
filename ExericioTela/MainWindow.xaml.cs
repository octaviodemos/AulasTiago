using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ExercicioTela
{
    public partial class MainWindow : Window
    {
        Pessoa[] pessoas = new Pessoa[8];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SexoText.Text) || string.IsNullOrWhiteSpace(AlturaText.Text))
            {
                MessageBox.Show("Digite informações válidas para sexo e altura.");
                return;
            }

            Pessoa pessoa = new Pessoa
            {
                sexo = SexoText.Text.ToLower(),
                altura = Convert.ToDouble(AlturaText.Text)
            };

            pessoasList.Add(pessoa);

            SexoText.Text = "";
            AlturaText.Text = "";
            if (pessoasList.Count == 8)
            {
                MostrarResultados();
            }
        }
        private void MostrarResultados()
        {
            int quantidadeMulheresMenos170 = pessoasList.Count(p => p.sexo == "feminino" && p.altura < 1.70);

            double alturaHomemMaisAlto = 0.0; 

           var homens = pessoasList.Where(p => p.sexo == "masculino");

            if (homens.Any())
            {
                alturaHomemMaisAlto = homens.Max(p => p.altura);
            }
            else
            {

                MessageBox.Show("Não há homens na lista.");
            }

            ResultsText.Text = $"Quantidade de mulheres com menos de 1.70m: {quantidadeMulheresMenos170}\nAltura do homem mais alto: {alturaHomemMaisAlto} metros";
        }

    }

    public class Pessoa
    {
        public string sexo { get; set; }
        public double altura { get; set; }
    }
}
