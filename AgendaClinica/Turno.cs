public class Turno
{
    public int NumeroTurno { get; set; }
    public Paciente Paciente { get; set; }
    public string Dia { get; set; }
    public string Hora { get; set; }

    public Turno(int numeroTurno, Paciente paciente, string dia, string hora)
    {
        NumeroTurno = numeroTurno;
        Paciente = paciente;
        Dia = dia;
        Hora = hora;
    }

    public void MostrarTurno()
    {
        Console.WriteLine($"Turno #{NumeroTurno} | Paciente: {Paciente.Nombre} | Día: {Dia} | Hora: {Hora}");
    }
}