using System;

namespace TrabalhoTesteSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            var controlador = new Controle();
            Console.WriteLine(controlador.Estado);
            Console.ReadLine();
        }
    }
}
