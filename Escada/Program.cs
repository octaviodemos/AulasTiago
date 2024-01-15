using System;

class Escada
{
    static void Main()
    {
        float A, B;

        while (true)
        {
            Console.WriteLine("Digite o tamanho do degrau em cm: ");
            if (float.TryParse(Console.ReadLine(), out A))
            {
                break;
            }

            else
            {
                Console.WriteLine("Erro: Valor digitado invalido, digite novamente. ");
            }
        }

        while (true)
        {
            Console.WriteLine("Digite a altura que você quer alcançar em cm: ");
            if (float.TryParse(Console.ReadLine(), out B))
            {
                break;
            }

            else
            {
                Console.WriteLine("Erro: Valor digitado invalido, digite novamente. ");
            }
        }

        var Altura =(int)Math.Ceiling(B / A);

        Console.WriteLine($"Você tera que subir {Altura} degraus para conseguir chegar na altura de {B}cm");



    }
}