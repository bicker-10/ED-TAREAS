using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NavegadorPila
{
    public class PaginaWeb
    {
        public string Url { get; set; }
        public DateTime FechaVisita { get; set; }

        public PaginaWeb(string url)
        {
            Url = url;
            FechaVisita = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Url} | Visitada: {FechaVisita}";
        }
    }

    public class Navegador
    {
        private Stack<PaginaWeb> historialAnterior;
        private PaginaWeb paginaActual;

        public Navegador()
        {
            historialAnterior = new Stack<PaginaWeb>();
            paginaActual = new PaginaWeb("Página de inicio");
        }

        public void VisitarPagina(string url)
        {
            if (paginaActual != null)
            {
                historialAnterior.Push(paginaActual);
            }

            paginaActual = new PaginaWeb(url);
            Console.WriteLine("\nPágina visitada correctamente.");
            Console.WriteLine($"Página actual: {paginaActual.Url}");
        }

        public void Retroceder()
        {
            if (historialAnterior.Count == 0)
            {
                Console.WriteLine("\nNo existen páginas anteriores para retroceder.");
                return;
            }

            paginaActual = historialAnterior.Pop();
            Console.WriteLine("\nSe presionó el botón Retroceder.");
            Console.WriteLine($"Página actual: {paginaActual.Url}");
        }

        public void MostrarPaginaActual()
        {
            Console.WriteLine("\nPágina actual:");
            Console.WriteLine(paginaActual);
        }

        public void MostrarHistorial()
        {
            Console.WriteLine("\nHistorial almacenado en la pila:");

            if (historialAnterior.Count == 0)
            {
                Console.WriteLine("No hay páginas anteriores registradas.");
                return;
            }

            int contador = 1;

            foreach (PaginaWeb pagina in historialAnterior)
            {
                Console.WriteLine($"{contador}. {pagina}");
                contador++;
            }
        }

        public void BuscarPagina(string url)
        {
            bool encontrada = false;

            foreach (PaginaWeb pagina in historialAnterior)
            {
                if (pagina.Url.Equals(url, StringComparison.OrdinalIgnoreCase))
                {
                    encontrada = true;
                    break;
                }
            }

            if (encontrada)
            {
                Console.WriteLine("\nLa página sí se encuentra en el historial.");
            }
            else
            {
                Console.WriteLine("\nLa página no se encuentra en el historial.");
            }
        }

        public void AnalizarTiempoEjecucion()
        {
            Stopwatch cronometro = new Stopwatch();

            cronometro.Start();
            historialAnterior.Push(new PaginaWeb("www.prueba-tiempo.com"));
            cronometro.Stop();

            long tiempoInsercion = cronometro.ElapsedTicks;

            cronometro.Restart();
            if (historialAnterior.Count > 0)
            {
                historialAnterior.Pop();
            }
            cronometro.Stop();

            long tiempoEliminacion = cronometro.ElapsedTicks;

            Console.WriteLine("\nAnálisis de tiempo de ejecución:");
            Console.WriteLine($"Inserción en pila Push(): {tiempoInsercion} ticks");
            Console.WriteLine($"Eliminación en pila Pop(): {tiempoEliminacion} ticks");
            Console.WriteLine("Las operaciones Push y Pop en una pila tienen complejidad O(1).");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Navegador navegador = new Navegador();
            int opcion;

            do
            {
                Console.WriteLine("\n======================================");
                Console.WriteLine(" SISTEMA: BOTÓN RETROCEDER NAVEGADOR");
                Console.WriteLine(" Estructura utilizada: PILA / STACK");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Visitar nueva página");
                Console.WriteLine("2. Retroceder");
                Console.WriteLine("3. Ver página actual");
                Console.WriteLine("4. Ver historial");
                Console.WriteLine("5. Buscar página en historial");
                Console.WriteLine("6. Analizar tiempo de ejecución");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                bool entradaValida = int.TryParse(Console.ReadLine(), out opcion);

                if (!entradaValida)
                {
                    Console.WriteLine("\nDebe ingresar un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("\nIngrese el nombre o URL de la página: ");
                        string url = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(url))
                        {
                            Console.WriteLine("La URL no puede estar vacía.");
                        }
                        else
                        {
                            navegador.VisitarPagina(url);
                        }
                        break;

                    case 2:
                        navegador.Retroceder();
                        break;

                    case 3:
                        navegador.MostrarPaginaActual();
                        break;

                    case 4:
                        navegador.MostrarHistorial();
                        break;

                    case 5:
                        Console.Write("\nIngrese la página que desea buscar: ");
                        string paginaBuscar = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(paginaBuscar))
                        {
                            Console.WriteLine("El dato de búsqueda no puede estar vacío.");
                        }
                        else
                        {
                            navegador.BuscarPagina(paginaBuscar);
                        }
                        break;

                    case 6:
                        navegador.AnalizarTiempoEjecucion();
                        break;

                    case 0:
                        Console.WriteLine("\nSistema finalizado correctamente.");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida.");
                        break;
                }

            } while (opcion != 0);
        }
    }
}