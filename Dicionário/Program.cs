class NumerosInteiros
{
    static void Main(string[] args)
    {
        int A;

        while (true)
        {
            Console.WriteLine("Digite a quantidade de números que você irá armazenar: ");
            if (int.TryParse(Console.ReadLine(), out A))
            {
                break;
            }

            else
            {
                Console.WriteLine("Erro: Valor digitado invalido, digite novamente. ");
            }
        }

        int[] Numeros = new int[A];

        for (int i = 0; i < A; i++)
        {
            while (true)
            {
                Console.WriteLine($"Digite o número {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out Numeros[i]))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Erro: Valor digitado inválido, digite novamente. ");
                }
            }
        }

        Console.WriteLine($"Dos números que você digitou esses são os pares:");
        foreach (int i in Numeros)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}