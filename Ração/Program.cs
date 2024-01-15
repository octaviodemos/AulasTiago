class Racao
{
    static void Main()
    {
        float A, B;

        while (true)
        {
            Console.WriteLine("Digite a quantidade do Saco de Ração em gramas: ");
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
            Console.WriteLine("Digite a quantidade de ração para cada gato: ");
            if (float.TryParse(Console.ReadLine(), out B))
            {
                break;
            }

            else
            {
                Console.WriteLine("Erro: Valor digitado invalido, digite novamente. ");
            }
        }

        var consumoDiario = (2 * B);
        var dias = 5 * consumoDiario;
        var resto = A - dias;

        Console.WriteLine($"Tamanho do saco de ração: {A}g");
        Console.WriteLine($"Consumo diario dos dois gatos: {consumoDiario}g");
        Console.WriteLine($"Consumo em 5 dias: {dias}g");
        Console.WriteLine($"Sobrou no saco de ração: {resto}g");


    }


}