using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Program;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            List<Cachorro> cachorros = LoadCachorros();

            foreach (Cachorro cachorro in cachorros)
            {
                Console.WriteLine(cachorro);
                Console.WriteLine(cachorro.EmiteSom());
            }

            Console.ReadLine();
            InserirCachorro(new Cachorro()
            {
                Nome = "Rex",
                Raca = "Vira Lata",
                Peso = 10,
                Altura = 0.5,
                Cor = "Preto",
                Id = 2
            });
        }

        private static void InserirCachorro(Cachorro cachorro)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=AulaDB;Integrated Security=False;User Id=tiago;Password=24122412;"))
            {
                conn.Open(); //abre a conexão
                SqlCommand command = conn.CreateCommand(); //cria um comando
                string sql = $@"
INSERT INTO [dbo].[Cachorros]
           ([Id]
           ,[Nome]
           ,[Raca]
           ,[Peso]
           ,[Altura]
           ,[Cor])
     VALUES
           ({cachorro.Id}
           ,'{cachorro.Nome}'
           ,'{cachorro.Raca}'
           ,{cachorro.Peso}
           ,{cachorro.Altura.ToString().Replace(",", ".")}
           ,'{cachorro.Cor}')
";
                command.CommandText = sql; //define o texto do comando
                int qtd = command.ExecuteNonQuery(); //retorna linhas afetadas
                Console.WriteLine("Linhas afetadas:" + qtd);
            }
        }

        public static List<Cachorro> LoadCachorros()
        {
            List<Cachorro> cachorros = new List<Cachorro>();

            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=AulaDB;Integrated Security=False;User Id=tiago;Password=24122412;"))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                string sql = $@"
SELECT [Id]
      ,[Nome]
      ,[Raca]
      ,[Peso]
      ,[Altura]
      ,[Cor]
  FROM [dbo].[Cachorros]
";
                command.CommandText = sql;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nome = reader.GetString(1);
                    string raca = reader.GetString(2);
                    float peso = (float)reader.GetDouble(3);
                    double altura = reader.GetDouble(4);
                    string cor = reader.GetString(5);

                    cachorros.Add(new Cachorro()
                    {
                        Id = id,
                        Nome = nome,
                        Raca = raca,
                        Peso = peso,
                        Altura = altura,
                        Cor = cor
                    });

                }

            }
            return cachorros;
        }

        public class Animal
        {
            public int Id { get; set; }
            public string Classe { get; set; }
            public float Peso { get; set; }
            public double Altura { get; set; }
            public virtual string Cor { get; set; }

            public virtual string EmiteSom()
            {
                return $"Sou um bixinho, tenho um peso {Peso} e tenho uma altura de {Altura}";
            }

            public override string ToString()
            {
                return $"ANIMAL: {Classe}";
            }
        }

        public class Cachorro : Animal
        {
            public string Nome { get; set; }
            public string Raca { get; set; }

            public Cachorro()
            {
                Classe = "Mamifero";
            }

            public override string EmiteSom()
            {

                return base.EmiteSom() + $", sou um cachorro chamado {Nome}, huahuahuehua";
            }

            public override string ToString()
            {
                return base.ToString() + $" Nome: {Nome} Raca: {Raca}";
            }

        }

        public class Peixe : Animal
        {
            public string Tipo { get; set; }

            public Peixe()
            {
                Classe = "Peixe";
            }

            public override string EmiteSom()
            {
                return base.EmiteSom() + " GURP GURP";
            }
        }
    }

}

