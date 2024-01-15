class ante_e_suc
{
    static void Main()
    {
        int A;

        while (true)
        {
            Console.WriteLine("Digite seu numero inteiro: ");

            if (int.TryParse(Console.ReadLine(), out A))
            {
                break;
            }

            else
            {
                Console.WriteLine("Erro: Número invalido, digite novamente");
            }


        }

        int antecessor = A - 1;
        int sucessor = A + 1;

        Console.WriteLine("Valores: ");
        Console.WriteLine("Valor digitado: " + A);
        Console.WriteLine("Valor antecessor: " + antecessor);
        Console.WriteLine("Valor sucessor: " + sucessor);



    }

}