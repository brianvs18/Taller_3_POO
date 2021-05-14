using System;
using Taller_3_POO.Services;

namespace Taller_3_POO
{
    class Program
    {
        static void Main(string[] args)
        {

            MenuServices menu = new MenuServices();

            menu.Iniciar();

            Console.ReadKey();
        }
    }
}
