using System.Collections.Generic;

namespace TorneoFutbol
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string NombreEquipo { get; set; }
        public string Entrenador { get; set; }

        public List<Jugador> Jugadores { get; set; }

        public Equipo(int idEquipo, string nombreEquipo, string entrenador)
        {
            IdEquipo = idEquipo;
            NombreEquipo = nombreEquipo;
            Entrenador = entrenador;
            Jugadores = new List<Jugador>();
        }

        public void AgregarJugador(Jugador jugador)
        {
            Jugadores.Add(jugador);
        }

        public override string ToString()
        {
            return $"ID: {IdEquipo} | " +
                   $"Equipo: {NombreEquipo} | " +
                   $"Entrenador: {Entrenador} | " +
                   $"Jugadores: {Jugadores.Count}";
        }
    }
}