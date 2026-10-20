namespace Callbacks
{ 
    internal class Program
    {
        //exercicio 3.1 callbacks
        static void Repetir(int vezes, Action acao)
        {
            for (int i = 0; i < vezes; i++)
            {
                acao();
            }
     
        }
        static void DizerOla()
        {
            Console.WriteLine("Olá!");
        }

        static void BaterPalmas()
        {
            Console.WriteLine("Bate Palmas!");
        }

        //exercicio 3.2 callbacks
        static void VerificarIdade(int idade,Action<int> seMaior, Action<int> seMenor)
        {
            if (idade >= 18)
            {
                seMaior(idade);
            }
            else
            {
                seMenor(idade);
            }
        }
        static void PodeVotar(int idade) 
        {
            Console.WriteLine("Pode votar!");
        
        }
        static void FaltamAnos(int idade)
        {
            int faltam = 18 - idade;
            Console.WriteLine($"Faltam {faltam} anos para votar!");
        }

        //exercicio 3.3 callbacks
        static List<int>Transformar(List<int> numeros, Func<int, int> regra) 
        {
            List<int> resultado = new List<int>();
            foreach (int num in numeros)
            {
                resultado.Add(regra(num));
            }
            return resultado;

        }
        static int Dobro(int num)
        {
            return num * 2;
        }

        //exercicio 3.4 callbacks
        static void Temporizador(int segundos,Action<int> aCadaSegundo,Action aoTerminar) 
        {
            for (int restante = segundos; restante > 0; restante--)
            {
                aCadaSegundo(restante);
                Thread.Sleep(1000);

            }
            aoTerminar();

        }



        static void Main(string[] args)
        {
            //exercicio 3.1 callbacks

            Console.WriteLine("--- DizerOla (2 vezes)");
            Repetir(2, DizerOla);

            Console.WriteLine("--- BaterPalmas (3 vezes)");
            Repetir(3, BaterPalmas);

            Console.WriteLine("--- Lambda (4 vezes)");
            Repetir(4, () => Console.WriteLine("Golo!"));

            //exercicio 3.2 callbacks

            Console.WriteLine("Qual a sua idade?");
            int idade = int.Parse(Console.ReadLine());

            VerificarIdade(idade, PodeVotar, FaltamAnos);

            //exercicio 3.3 callbacks
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };

            List<int> Dobrados = Transformar(numeros, Dobro);
            Console.WriteLine("Dobro: " + string.Join(", ", Dobrados) );

            List<int> Quadrados = Transformar(numeros, num => num * num);
            Console.WriteLine("Quadrados: " + string.Join(", ", Quadrados) );

            List<int> MaisDez = Transformar(numeros, num => num + 10);
            Console.WriteLine("Mais 10: " + string.Join(", ", MaisDez) );

            //exercicio 3.4 callbacks

            Console.WriteLine("Ovos cozidos");
            Temporizador(
                5,
                restante => Console.WriteLine($"Restam {restante} segundos..."),
                () => Console.WriteLine("Ding! Ovos cozidos!")
            );

            Console.WriteLine("Pausa");
            Temporizador(
                3,
                restante => Console.WriteLine("."),
                () => Console.WriteLine("\nVolta ao trabalho!")
            );









        }









    }

}