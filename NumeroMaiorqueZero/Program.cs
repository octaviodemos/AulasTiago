class MaiorQueZero
{
    static void Main()
    {
        int A;

        while (true)
        {
            Console.WriteLine("Digite seu número inteiro");

            if (int.TryParse(Console.ReadLine(), out A))
            {
                if (A > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Erro: Digite um número maior que zero: ");
                }
            }
            else
            {
                Console.WriteLine("Erro: Tipo de dado não aceito, digite novamente: ");
            }

        }

        int quadrado = A * A;
        int cubo = A * A * A;
       double raiz = Math.Sqrt(A);
       double raizCubo = Math.Pow(A, 1 / 3);

        Console.WriteLine($"a. O número ao quadrado: {quadrado}");
        Console.WriteLine($"b. O número ao cubo: {cubo}");
        Console.WriteLine($"c. A raiz quadrada do número: {raiz}");
        Console.WriteLine($"d. A raiz cúbica do número: {raizCubo}");

    }

}