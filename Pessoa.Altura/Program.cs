using System;

class Program
{
    static void Main()
    {
        Pessoa[] pessoas = new Pessoa[8];
        
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

            Console.Write("Qual a idade? ");
            if (int.TryParse(Console.ReadLine(), out int idade))
            {
                pessoas[i].idade = idade;
                break;
            }
            else
            {
                Console.WriteLine("Idade inválida. Digite novamente. ");
            }
        }

        int quantidadeMulheresMenos170 = 0;
        double alturaHomemMaisAlto = double.MaxValue;

        foreach (var pessoa in pessoas)
        {
            if (pessoa.genero.ToLower() == "feminino" && pessoa.altura < 1.70)
            {
                quantidadeMulheresMenos170++;
            }

            if (pessoa.genero.ToLower() == "masculino" && pessoa.altura > alturaHomemMaisAlto)
            {
                alturaHomemMaisAlto = pessoa.altura;
            }
        }

        Console.WriteLine($"\nQuantidade de mulheres com menos de 1.70m: {quantidadeMulheresMenos170}");
        Console.WriteLine($"Altura do homem mais alto: {alturaHomemMaisAlto} metros");
    }
}

public class Pessoa
{
    public string genero { get; set; }
    public double altura { get; set; }
    public int idade { get; set; }
}
