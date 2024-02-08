﻿using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static ExercicioTela.MainWindow;

namespace ExercicioTela
{
    public partial class MainWindow : Window
    {
        List<Pessoa> pessoas = new List<Pessoa>();

        public MainWindow()
        {
            InitializeComponent();

            CarregaPessoas();
        }

        public static void InserirPessoa(Pessoa pessoa)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Sexatura;Integrated Security=False;User Id=sa;Password=super990025;"))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                string sql = $@"
        INSERT INTO [dbo].[Pessoas]
                   ([Sexo]
                   ,[Altura])
             VALUES
                   ('{pessoa.Sexo}'
                   ,{pessoa.Altura.ToString().Replace(",", ".")})
        ";
                command.CommandText = sql; //define o texto do comando
                int qtd = command.ExecuteNonQuery(); //retorna linhas afetadas
                Console.WriteLine("Linhas afetadas:" + qtd);

            }

        }

        public List<Pessoa> LoadPessoas()
        {

            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Sexatura;Integrated Security=False;User Id=sa;Password=super990025;"))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                string sql = $@"
        SELECT  Id
                ,Sexo
                ,Altura
        FROM Pessoas;
        ";
                command.CommandText = sql;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string sexo = reader.GetString(1);
                    double altura = reader.GetDouble(2);

                    pessoas.Add(new Pessoa()
                    {
                        Id = id,
                        Sexo = sexo,
                        Altura = altura,
                    });
                }

            }
            return pessoas;
        }

        public static void RemoverPessoa(Pessoa pessoa)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Sexatura;Integrated Security=False;User Id=sa;Password=super990025;"))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                string sql = $@"
            DELETE 
            FROM [dbo].[Pessoas] 
            WHERE Id = {pessoa.Id}
            ";
                command.CommandText = sql;
                int qtd = command.ExecuteNonQuery();
                Console.WriteLine("Linhas afetadas:" + qtd);
            }
        }

        public static void Removertudo()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Sexatura;Integrated Security=False;User Id=sa;Password=super990025;"))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                string sql = $@"
                DELETE 
                FROM [dbo].[Pessoas]
                ";
                command.CommandText = sql;
                int qtd = command.ExecuteNonQuery();
                Console.WriteLine("Linhas afetadas:" + qtd);
            }
        }

        private void CarregaPessoas()
        {
            pessoas.Clear();
            ParcialListBox.ItemsSource = null;
            ParcialListBox.ItemsSource = LoadPessoas();
        }

        private void CheckFeminino_Checked(object sender, RoutedEventArgs e)
        {
            AlturaText.Focus();
        }

        private void CheckMasculino_Checked(object sender, RoutedEventArgs e)
        {
            AlturaText.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sexoSelecionado = string.Empty;
            string alturaDigitada = AlturaText.Text;
            double altura;

            if (CheckFeminino.IsChecked == true)
            {
                sexoSelecionado = "feminino";
            }

            if (CheckMasculino.IsChecked == true)
            {
                sexoSelecionado = "masculino";
            }

            if (CheckFeminino.IsChecked == false && CheckMasculino.IsChecked == false)
            {
                MessageBox.Show("Selecione o sexo da pessoa que está cadastrando");
                return;
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

            Pessoa novaPessoa = new Pessoa
            {
                Sexo = sexoSelecionado,
                Altura = altura
            };

            InserirPessoa(novaPessoa);
            //pessoas.Add(novaPessoa);

            MessageBox.Show("Dados salvos");

            CheckFeminino.IsChecked = false;
            CheckMasculino.IsChecked = false;
            AlturaText.Text = string.Empty;
            CarregaPessoas();
            MostrarResultados();
            AlturaText.Focus();

        }

        public class Pessoa : INotifyPropertyChanged
        {
            private int _id;
            private string _sexo;
            private double _altura;

            public int Id { get; set; }
            public string Sexo
            {
                get { return _sexo; }
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
                get { return _altura; }
                set
                {
                    if (_altura != value)
                    {
                        _altura = value;
                        NotifyPropertyChanged();
                    }
                }
            }

            public string MostrandoPessoas => $"{Sexo}, {Altura}m";

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void NotifyPropertyChanged([CallerMemberName] string propName = "")
            {
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void MostrarResultados()
        {
            int totalMulheresMenos170 = 0;
            float alturaHomemMaisAlto = 0;

            foreach (var pessoa in pessoas)
            {
                if (pessoas != null)
                {
                    if (pessoa.Sexo.ToLower() == "feminino" && pessoa.Altura < 1.70)
                    {
                        totalMulheresMenos170++;
                    }
                    if (pessoa.Sexo.ToLower() == "masculino")
                    {
                        if (pessoa.Altura > alturaHomemMaisAlto)
                        {
                            alturaHomemMaisAlto = (float)pessoa.Altura;
                        }
                    }
                }
            }

            ResultsText.Text = $"Quantidade de mulheres com menos de 1.70m: {totalMulheresMenos170}\nAltura do homem mais alto: {alturaHomemMaisAlto} metros";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MostrarResultados();
        }

        private void AlturaText_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Button_Click(null, null);
            }
        }

        private void ZerarDados()
        {
            CheckFeminino.IsChecked = false;
            CheckMasculino.IsChecked = false;
            AlturaText.Text = string.Empty;
            ParcialListBox.ItemsSource = null;
            ResultsText.Text = string.Empty;
        }

        private void Reiniciar(object sender, RoutedEventArgs e)
        {
            ZerarDados();
            Removertudo();

            MessageBox.Show("Reniciado, pode preencher os dados novamente");
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (ParcialListBox.SelectedItem != null)
            {
                Pessoa pessoaSelecionada = (Pessoa)ParcialListBox.SelectedItem;

                pessoas.Remove(pessoaSelecionada);
                RemoverPessoa(pessoaSelecionada);

                Console.WriteLine($"Pessoa removida: {pessoaSelecionada.Sexo}, {pessoaSelecionada.Altura}m");

                CarregaPessoas();
                MostrarResultados();

                MessageBox.Show("Dados deletados");
            }
            else
            {
                MessageBox.Show("Selecione uma pessoa para deletar.");
            }
        }
    }
}
