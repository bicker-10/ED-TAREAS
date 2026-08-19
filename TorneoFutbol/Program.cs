using System;

namespace TorneoFutbol
{
    class Program
    {
        static void Main(string[] args)
        {
            Torneo torneo = new Torneo();

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine(
                    "=========================================");
                Console.WriteLine(
                    "     TORNEO DE FÚTBOL - SISTEMA");
                Console.WriteLine(
                    "=========================================");

                Console.WriteLine("1. Registrar equipo");
                Console.WriteLine("2. Registrar jugador");
                Console.WriteLine("3. Mostrar equipos");
                Console.WriteLine("4. Mostrar jugadores de un equipo");
                Console.WriteLine("5. Buscar jugador");
                Console.WriteLine("6. Cantidad de jugadores por equipo");
                Console.WriteLine("7. Reporte general");
                Console.WriteLine("8. Salir");

                Console.WriteLine(
                    "=========================================");

                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(
                        Console.ReadLine(),
                        out opcion))
                {
                    opcion = 0;
                }

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        RegistrarEquipo(torneo);
                        break;

                    case 2:
                        RegistrarJugador(torneo);
                        break;

                    case 3:
                        torneo.MostrarEquipos();
                        break;

                    case 4:
                        MostrarJugadoresEquipo(torneo);
                        break;

                    case 5:
                        BuscarJugador(torneo);
                        break;

                    case 6:
                        torneo.MostrarCantidadJugadoresPorEquipo();
                        break;

                    case 7:
                        torneo.MostrarReporteGeneral();
                        break;

                    case 8:
                        Console.WriteLine(
                            "Programa finalizado correctamente.");
                        break;

                    default:
                        Console.WriteLine(
                            "Opción no válida.");
                        break;
                }

                if (opcion != 8)
                {
                    Console.WriteLine(
                        "\nPresione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcion != 8);
        }

        static void RegistrarEquipo(Torneo torneo)
        {
            Console.WriteLine(
                "===== REGISTRO DE EQUIPO =====");

            int id = LeerEntero(
                "ID del equipo: ");

            Console.Write(
                "Nombre del equipo: ");

            string nombre =
                Console.ReadLine() ?? "";

            Console.Write(
                "Nombre del entrenador: ");

            string entrenador =
                Console.ReadLine() ?? "";

            torneo.RegistrarEquipo(
                id,
                nombre,
                entrenador);
        }

        static void RegistrarJugador(Torneo torneo)
        {
            Console.WriteLine(
                "===== REGISTRO DE JUGADOR =====");

            int id =
                LeerEntero("ID del jugador: ");

            Console.Write(
                "Nombre del jugador: ");

            string nombre =
                Console.ReadLine() ?? "";

            int edad =
                LeerEntero("Edad: ");

            int camiseta =
                LeerEntero("Número de camiseta: ");

            Console.Write(
                "Posición: ");

            string posicion =
                Console.ReadLine() ?? "";

            int idEquipo =
                LeerEntero("ID del equipo: ");

            torneo.RegistrarJugador(
                id,
                nombre,
                edad,
                camiseta,
                posicion,
                idEquipo);
        }

        static void MostrarJugadoresEquipo(
            Torneo torneo)
        {
            int idEquipo =
                LeerEntero(
                    "Ingrese el ID del equipo: ");

            torneo.MostrarJugadoresEquipo(
                idEquipo);
        }

        static void BuscarJugador(
            Torneo torneo)
        {
            int idJugador =
                LeerEntero(
                    "Ingrese el ID del jugador: ");

            torneo.BuscarJugador(
                idJugador);
        }

        static int LeerEntero(
            string mensaje)
        {
            int valor;

            while (true)
            {
                Console.Write(mensaje);

                if (int.TryParse(
                        Console.ReadLine(),
                        out valor))
                {
                    return valor;
                }

                Console.WriteLine(
                    "Ingrese un número válido.");
            }
        }
    }
}