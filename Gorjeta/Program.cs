class Gorgeta
{
    static void Main()
    {
        float A;

        while (true)
        {
            Console.WriteLine("Digite o valor da conta: ");
            if (float.TryParse(Console.ReadLine(), out A))
            {
                break;
            }

            else
            {
                Console.WriteLine("Erro: Valor digitado invalido, digite novamente. ");
            }
        }

        var Gorgeta = A * 0.10;
        var Total = A + Gorgeta;

        Console.WriteLine($"Valor da comanda: {A}");
        Console.WriteLine($"Valor da Gorgeta: {Gorgeta}");
        Console.WriteLine($"Valor da comanda: {Total}");

    }
}