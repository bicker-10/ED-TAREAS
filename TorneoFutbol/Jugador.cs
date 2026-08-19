namespace TorneoFutbol
{
    public class Jugador
    {
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int NumeroCamiseta { get; set; }
        public string Posicion { get; set; }
        public string Equipo { get; set; }

        public Jugador(
            int idJugador,
            string nombre,
            int edad,
            int numeroCamiseta,
            string posicion,
            string equipo)
        {
            IdJugador = idJugador;
            Nombre = nombre;
            Edad = edad;
            NumeroCamiseta = numeroCamiseta;
            Posicion = posicion;
            Equipo = equipo;
        }

        public override string ToString()
        {
            return $"ID: {IdJugador} | " +
                   $"Nombre: {Nombre} | " +
                   $"Edad: {Edad} | " +
                   $"N.º camiseta: {NumeroCamiseta} | " +
                   $"Posición: {Posicion} | " +
                   $"Equipo: {Equipo}";
        }
    }
}