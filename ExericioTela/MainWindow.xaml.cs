using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
                Pessoa novaPessoa = new Pessoa
                {
                    Sexo = sexoSelecionado,
                    Altura = altura
                };
                novaPessoa.PropertyChanged += NovaPessoa_PropertyChanged;
                novaPessoa.Altura *= 2;
                pessoas[pessoaatual] = novaPessoa;
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

        private void NovaPessoa_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show("Alguem mudou");
        }

        public class Pessoa : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private string _sexo;
            private double _altura;

            public string Sexo { 
                get
                {
                    return _sexo;
                }
                set
                {
                    if (_sexo != value)
                    {
                        _sexo = value;
                        NotifyPropertyChanged();
                    }
                } 
            }
            public double Altura
            {
                get => _altura; 
                set
                {
                    _altura = value;
                    NotifyPropertyChanged();
                }
            }

            public void NotifyPropertyChanged([CallerMemberName] string propName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
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
