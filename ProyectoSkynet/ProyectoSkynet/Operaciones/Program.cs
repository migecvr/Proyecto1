using ProyectoSkynetModel.DAL;
using ProyectoSkynetModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSkynet
{
    public partial class Program
    {
        static IEliminadoresDAL eliminadoresDAL = new EliminadoresDALObjetos();
        static void MostrarEliminador()
        {
            List<Eliminador> eliminadores = eliminadoresDAL.ObtenerEliminadores();

            if (eliminadores.Count == 0)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aun no se han creado Eliminadores");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else {
                bool indicaColor = true;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lista de Eliminadores:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("(N°Serie  Tipo  PrioridadBase  Prioridad  Objetivo  AñoDestino)");

                for (int i = 0; i < eliminadores.Count; i++)
                {
                    if (indicaColor)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        indicaColor = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        indicaColor = true;
                    }
                    Eliminador actual = eliminadores[i];
                    Console.WriteLine(actual.ToString());
                }
                
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("");
        }

        static void BuscarEliminador()
        {
            bool esValido = true;

            string tipo;
            Int32 anioDestino;

            Console.WriteLine("");

            List<Eliminador> eliminadores = eliminadoresDAL.ObtenerEliminadores();

            if (eliminadores.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aun no se han creado Eliminadores");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else {

                do
                {
                    esValido = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ingrese el Tipo (T-1, T-800, T-1000, T-3000):");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    tipo = Console.ReadLine().Trim();
                    if (tipo.ToUpper() != "T-1" && tipo.ToUpper() != "T-800" && tipo.ToUpper() != "T-1000" && tipo.ToUpper() != "T-3000")
                    {
                        esValido = false;
                    }
                    else
                    {
                        tipo = tipo.ToUpper();
                    }
                } while (tipo.Equals(string.Empty) | esValido == false);


                do
                {
                    esValido = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ingrese año de destino (Mayor o igual a 1997 y menor a 3000)");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    esValido = Int32.TryParse(Console.ReadLine().Trim(), out anioDestino);
                    if (esValido)
                    {
                        if (anioDestino < 1997 | anioDestino >= 3000)
                        {
                            esValido = false;

                        }
                    }

                } while (!esValido);


                if (eliminadores.Any(e => e.Tipo.ToLower() == tipo.ToLower() && e.AnioDestino == anioDestino))
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Conincidencias Encontradas:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("(N°Serie  Tipo  PrioridadBase  Prioridad  Objetivo  AñoDestino)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    new EliminadoresDALObjetos().FiltrarEliminadores(tipo, anioDestino)
                                 .ForEach(e => Console.WriteLine(e.ToString()));
                }
                else {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se encontraron coincidencias");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                
            }

            Console.WriteLine("");

        }

        static void IngresarEliminador()
        {
            string numSerie;
            string tipo;
            int prioridadBase;
            string objetivo;
            Int32 anioDestino;

            Console.WriteLine("");
            bool esValido = true;

            do
            {
                esValido = true;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingrese Numero de Serie (Debe contener 7 caracteres)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                numSerie = Console.ReadLine().Trim();
                if (numSerie.Length != 7)
                {
                    esValido = false;
                }
            } while (numSerie.Equals(string.Empty) | esValido == false);

            do
            {
                esValido = true;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingrese el Tipo (T-1, T-800, T-1000, T-3000):");
                Console.ForegroundColor = ConsoleColor.Magenta;
                tipo = Console.ReadLine().Trim();
                if (tipo.ToUpper() != "T-1" && tipo.ToUpper() != "T-800" && tipo.ToUpper() != "T-1000" && tipo.ToUpper() != "T-3000")
                {
                    esValido = false;
                }
                else { 
                    tipo = tipo.ToUpper();
                }
            } while (tipo.Equals(string.Empty) | esValido == false);

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingrese Prioridad Base (1, 2, 3, 4, 5):");
                Console.ForegroundColor = ConsoleColor.Magenta;
                esValido = Int32.TryParse(Console.ReadLine().Trim(), out prioridadBase);
                if (esValido)
                {
                    if (prioridadBase != 1 && prioridadBase != 2 && prioridadBase != 3 && prioridadBase != 4 && prioridadBase != 5)
                    {
                        esValido = false;

                    }
                }
            } while (!esValido);

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingrese el Objetivo:");
                Console.ForegroundColor = ConsoleColor.Magenta;
                objetivo = Console.ReadLine().Trim();
                if (objetivo.ToLower() == "eliminador")
                {
                    objetivo = objetivo.ToUpper();
                }
                else {
                    objetivo = objetivo.ToLower();
                }

            } while (objetivo.Equals(string.Empty));

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingrese año de destino (Mayor o igual a 1997 y menor a 3000)");
                Console.ForegroundColor = ConsoleColor.Magenta;
                esValido = Int32.TryParse(Console.ReadLine().Trim(), out anioDestino);
                if (esValido)
                {
                    if (anioDestino < 1997 | anioDestino >= 3000)
                    {
                        esValido = false;

                    }
                }
                
            } while (!esValido);

           

            Eliminador e = new Eliminador()
            {
                NumSerie = numSerie,
                Tipo = tipo,
                PrioridadBase = prioridadBase,
                Objetivo = objetivo,
                AnioDestino = anioDestino
            };

            e.calcularPrioridad();
            eliminadoresDAL.AgregarEliminador(e);

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("El Eliminador se creó correctamente");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("N° de Serie: {0} ", e.NumSerie);
            Console.WriteLine("Tipo: {0} ", e.Tipo);
            Console.WriteLine("Prioridad Base: {0} ", e.PrioridadBase);
            Console.WriteLine("Prioridad: {0} ", e.Prioridad);
            Console.WriteLine("Objetivo: {0} ", e.Objetivo);
            Console.WriteLine("Año de Destino: {0} ", e.AnioDestino);
            Console.WriteLine("");


        }


        static void DestruirSkyNet() 
        {

            List<Eliminador> eliminadores = eliminadoresDAL.ObtenerEliminadores();

            if (eliminadores.Count == 0)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aun no se han creado Eliminadores");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
            }
            else
            {
                eliminadoresDAL.EliminarTodos();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("!!!SE HAN DESTRUIDO TODOS LOS ELIMINADORES!!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
            }
                
        }
    }
}
