using System;

class Program
{
    static void Main()
    {
        Pessoa[] pessoas = new Pessoa[2];

        for (int i = 0; i < pessoas.Length; i++)
        {
            pessoas[i] = new Pessoa();

            Console.WriteLine($"Digite as informações para a pessoa {i + 1}:");
            Console.Write("Sexo (Masculino/Feminino): ");
            pessoas[i].genero = Console.ReadLine();

            while (true)
            {
                Console.Write("Altura (em metros): ");
                if (double.TryParse(Console.ReadLine(), out double altura) && altura >= 0)
                {
                    pessoas[i].altura = altura;
                    break;
                }
                else
                {
                    Console.WriteLine("Altura inválida. Digite novamente.");
                }
            }

            while (true)
            {
                Console.Write("Qual a idade? ");
                if (int.TryParse(Console.ReadLine(), out int idade))
                {
                    pessoas[i].idade = idade;
                    break;
                }
                else
                {
                    Console.WriteLine("Idade inválida. Digite novamente.");
                }
            }
        }

        int quantidadeHomensMaisVelhos = 0;
        string sexoPessoaMaisVelha = "";
        int idadeMaisVelha = int.MinValue;

        int idadeUltimaPessoa = pessoas[pessoas.Length - 1].idade;

        foreach (var pessoa in pessoas)
        {
            if (pessoa.genero.ToLower() == "masculino" && pessoa.idade > idadeUltimaPessoa)
            {
                quantidadeHomensMaisVelhos++;
            }
        }

        foreach (var pessoa in pessoas)
            if (pessoa.idade > idadeMaisVelha)
            {
                sexoPessoaMaisVelha = pessoa.genero;
                idadeMaisVelha = pessoa.idade;
            }

        Console.WriteLine($"\nQuantidade de homens com idade maior que a última pessoa: {quantidadeHomensMaisVelhos}");
        Console.WriteLine($"Sexo e idade da pessoa mais velha: {sexoPessoaMaisVelha}, {idadeMaisVelha} anos");
    }
}

public class Pessoa
{
    public string genero { get; set; }
    public double altura { get; set; }
    public int idade { get; set; }
}
