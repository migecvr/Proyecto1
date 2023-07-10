using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSkynet
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            while (Menu()) ;
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Sistema SkyNet");
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Ingresar Eliminador");
            Console.WriteLine("2. Mostrar Eliminadores");
            Console.WriteLine("3. Buscar Eliminador");
            Console.WriteLine("4. Destruir SkyNet");
            Console.WriteLine("0. Salir");
            Console.ForegroundColor = ConsoleColor.Magenta;
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    IngresarEliminador();
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    MostrarEliminador();
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    BuscarEliminador();
                    break;
                case "4":
                    DestruirSkyNet();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Debe seleccionar una de las opciones");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    break;
            }
            return continuar;
        }


    }
}
