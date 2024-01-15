class troca
{
    static void Main()
    {
        int A, B, temp;

        Console.WriteLine("Digite o Valor de A: ");
        A = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o Valor de B: ");
        B = int.Parse(Console.ReadLine());

        temp = A;
        A = B;
        B = temp;

        Console.WriteLine("Valores com a troca efetudada:");
        Console.WriteLine("A: " + A);
        Console.WriteLine("B: " + B);
    }
}




    