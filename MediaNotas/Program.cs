class MediaNotas
{
    static void Main()
    {
        float A, B, C;

        while (true)
        { 
        
            Console.WriteLine("Diigite as suas notas para calcular a média: (Média para passar de ano, 6.0)");
            if  ((float.TryParse(Console.ReadLine(), out A)) &&
                (float.TryParse(Console.ReadLine(), out B)) &&
                (float.TryParse(Console.ReadLine(), out C)))
            {
                break;
            }

            else
            {
                Console.WriteLine("Erro: Numero digitado invalido, digite novamente. ");
            }
        }

        float Media = (A + B + C) / 3;

        var Aprovado = Media >= 6;

        var Reprovado = Media < 6;


        if (Aprovado)
        {
            Console.WriteLine("PARABÉNS, FOI APROVADO!");
        }

        else
        {
            Console.WriteLine("PUTS, RODOU AMIGÃO");
        }

    }

}