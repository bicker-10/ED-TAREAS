using System;
using System.Collections.Generic;
using System.Linq;

namespace TorneoFutbol
{
    public class Torneo
    {
        // Diccionario: relaciona ID del equipo con el objeto Equipo.
        private Dictionary<int, Equipo> equipos;

        // Conjunto: almacena ID únicos de jugadores.
        private HashSet<int> idsJugadores;

        // Mapa: relaciona nombre del equipo con los ID de sus jugadores.
        private Dictionary<string, HashSet<int>> mapaEquipoJugadores;

        public Torneo()
        {
            equipos = new Dictionary<int, Equipo>();
            idsJugadores = new HashSet<int>();
            mapaEquipoJugadores =
                new Dictionary<string, HashSet<int>>();
        }

        public bool RegistrarEquipo(
            int id,
            string nombre,
            string entrenador)
        {
            if (equipos.ContainsKey(id))
            {
                Console.WriteLine(
                    "\nYa existe un equipo con ese ID.");
                return false;
            }

            equipos.Add(
                id,
                new Equipo(id, nombre, entrenador));

            mapaEquipoJugadores.Add(
                nombre,
                new HashSet<int>());

            Console.WriteLine(
                "\nEquipo registrado correctamente.");

            return true;
        }

        public bool RegistrarJugador(
            int idJugador,
            string nombre,
            int edad,
            int numeroCamiseta,
            string posicion,
            int idEquipo)
        {
            if (!equipos.ContainsKey(idEquipo))
            {
                Console.WriteLine(
                    "\nEl equipo indicado no existe.");
                return false;
            }

            if (!idsJugadores.Add(idJugador))
            {
                Console.WriteLine(
                    "\nEl jugador ya se encuentra registrado.");
                return false;
            }

            Equipo equipo = equipos[idEquipo];

            bool camisetaDuplicada =
                equipo.Jugadores.Any(
                    j => j.NumeroCamiseta == numeroCamiseta);

            if (camisetaDuplicada)
            {
                idsJugadores.Remove(idJugador);

                Console.WriteLine(
                    "\nEl número de camiseta ya está utilizado en este equipo.");

                return false;
            }

            Jugador jugador = new Jugador(
                idJugador,
                nombre,
                edad,
                numeroCamiseta,
                posicion,
                equipo.NombreEquipo);

            equipo.AgregarJugador(jugador);

            mapaEquipoJugadores[equipo.NombreEquipo]
                .Add(idJugador);

            Console.WriteLine(
                "\nJugador registrado correctamente.");

            return true;
        }

        public void MostrarEquipos()
        {
            Console.WriteLine(
                "\n===== EQUIPOS REGISTRADOS =====");

            if (equipos.Count == 0)
            {
                Console.WriteLine(
                    "No existen equipos registrados.");
                return;
            }

            foreach (Equipo equipo in equipos.Values)
            {
                Console.WriteLine(equipo);
            }
        }

        public void MostrarJugadoresEquipo(int idEquipo)
        {
            if (!equipos.TryGetValue(
                    idEquipo,
                    out Equipo? equipo))
            {
                Console.WriteLine(
                    "\nEl equipo no existe.");
                return;
            }

            Console.WriteLine(
                $"\n===== JUGADORES DE {equipo.NombreEquipo.ToUpper()} =====");

            if (equipo.Jugadores.Count == 0)
            {
                Console.WriteLine(
                    "El equipo todavía no tiene jugadores.");
                return;
            }

            foreach (Jugador jugador in equipo.Jugadores)
            {
                Console.WriteLine(jugador);
            }
        }

        public void BuscarJugador(int idJugador)
        {
            foreach (Equipo equipo in equipos.Values)
            {
                Jugador? jugador =
                    equipo.Jugadores.FirstOrDefault(
                        j => j.IdJugador == idJugador);

                if (jugador != null)
                {
                    Console.WriteLine(
                        "\n===== JUGADOR ENCONTRADO =====");

                    Console.WriteLine(jugador);
                    return;
                }
            }

            Console.WriteLine(
                "\nNo se encontró el jugador.");
        }

        public void MostrarCantidadJugadoresPorEquipo()
        {
            Console.WriteLine(
                "\n===== JUGADORES POR EQUIPO =====");

            if (equipos.Count == 0)
            {
                Console.WriteLine(
                    "No existen equipos registrados.");
                return;
            }

            foreach (Equipo equipo in equipos.Values)
            {
                Console.WriteLine(
                    $"{equipo.NombreEquipo}: " +
                    $"{equipo.Jugadores.Count} jugador(es)");
            }
        }

        public void MostrarReporteGeneral()
        {
            Console.WriteLine(
                "\n========================================");
            Console.WriteLine(
                "        REPORTE GENERAL DEL TORNEO");
            Console.WriteLine(
                "========================================");

            Console.WriteLine(
                $"Equipos registrados: {equipos.Count}");

            Console.WriteLine(
                $"Jugadores registrados: {idsJugadores.Count}");

            foreach (Equipo equipo in equipos.Values)
            {
                Console.WriteLine(
                    $"\nEquipo: {equipo.NombreEquipo}");

                Console.WriteLine(
                    $"Entrenador: {equipo.Entrenador}");

                Console.WriteLine(
                    $"Cantidad de jugadores: {equipo.Jugadores.Count}");

                if (equipo.Jugadores.Count > 0)
                {
                    foreach (Jugador jugador
                             in equipo.Jugadores)
                    {
                        Console.WriteLine(
                            $"  - {jugador.Nombre} " +
                            $"| N.º {jugador.NumeroCamiseta} " +
                            $"| {jugador.Posicion}");
                    }
                }
                else
                {
                    Console.WriteLine(
                        "  Sin jugadores registrados.");
                }
            }

            Console.WriteLine(
                "\n========================================");
        }
    }
}