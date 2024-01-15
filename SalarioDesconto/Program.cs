class SalarioDesconto
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

        var Gratificacao = A * 1.20;
        var Desconto = A * 0.15;
        var SalarioFinal = (A + Gratificacao) - Desconto;

        Console.WriteLine($"Valor do Salario: {A}");
        Console.WriteLine($"Valor da Gratificação em cima do salário base: {Gratificacao}");
        Console.WriteLine($"Valor do Desconto em cima do salario base: {Desconto}");
        Console.WriteLine($"Valor do Salario Final: {SalarioFinal}");
    }
}