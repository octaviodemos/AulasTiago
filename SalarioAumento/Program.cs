class AumentoSalario
{
    static void Main()
    {
        float A;

        while (true)
        {
            Console.WriteLine("Digite o seu salário atual: ");
            if (float.TryParse(Console.ReadLine(), out A))
            {
                break;
            }

            else
            {
                Console.WriteLine("Erro: Valor digitado invalido, digite novamente. ");
            }
        }

        var SalarioNovo = A * 1.25;
        Console.WriteLine($"Seu salario com um aumento de 25% ira ficar: {SalarioNovo}");
    }
}