public class AgendaClinica
{
    private Paciente[] pacientes = new Paciente[50];
    private Turno[] turnos = new Turno[100];
    private string[,] matrizHorarios = new string[5, 8];

    private int contadorPacientes = 0;
    private int contadorTurnos = 0;

    private string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };
    private string[] horas = { "08:00", "09:00", "10:00", "11:00", "14:00", "15:00", "16:00", "17:00" };

    public AgendaClinica()
    {
        InicializarMatriz();
    }

    private void InicializarMatriz()
    {
        for (int i = 0; i < matrizHorarios.GetLength(0); i++)
        {
            for (int j = 0; j < matrizHorarios.GetLength(1); j++)
            {
                matrizHorarios[i, j] = "Libre";
            }
        }
    }

    public void RegistrarPaciente()
    {
        if (contadorPacientes >= pacientes.Length)
        {
            Console.WriteLine("No se pueden registrar más pacientes.");
            return;
        }

        Console.Write("Ingrese cédula: ");
        string cedula = Console.ReadLine();

        if (BuscarPacientePorCedula(cedula) != null)
        {
            Console.WriteLine("Ya existe un paciente registrado con esa cédula.");
            return;
        }

        Console.Write("Ingrese nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese edad: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese teléfono: ");
        string telefono = Console.ReadLine();

        pacientes[contadorPacientes] = new Paciente(cedula, nombre, edad, telefono);
        contadorPacientes++;

        Console.WriteLine("Paciente registrado correctamente.");
    }

    public void RegistrarTurno()
    {
        if (contadorTurnos >= turnos.Length)
        {
            Console.WriteLine("No se pueden registrar más turnos.");
            return;
        }

        Console.Write("Ingrese la cédula del paciente: ");
        string cedula = Console.ReadLine();

        Paciente paciente = BuscarPacientePorCedula(cedula);

        if (paciente == null)
        {
            Console.WriteLine("Paciente no encontrado. Primero debe registrarlo.");
            return;
        }

        MostrarDias();
        Console.Write("Seleccione el número del día: ");
        int opcionDia = int.Parse(Console.ReadLine()) - 1;

        MostrarHoras();
        Console.Write("Seleccione el número de la hora: ");
        int opcionHora = int.Parse(Console.ReadLine()) - 1;

        if (opcionDia < 0 || opcionDia >= dias.Length || opcionHora < 0 || opcionHora >= horas.Length)
        {
            Console.WriteLine("Día u hora inválidos.");
            return;
        }

        if (matrizHorarios[opcionDia, opcionHora] != "Libre")
        {
            Console.WriteLine("Ese horario ya está ocupado.");
            return;
        }

        int numeroTurno = contadorTurnos + 1;
        turnos[contadorTurnos] = new Turno(numeroTurno, paciente, dias[opcionDia], horas[opcionHora]);
        contadorTurnos++;

        matrizHorarios[opcionDia, opcionHora] = paciente.Nombre;

        Console.WriteLine("Turno registrado correctamente.");
    }

    public Paciente BuscarPacientePorCedula(string cedula)
    {
        for (int i = 0; i < contadorPacientes; i++)
        {
            if (pacientes[i].Cedula == cedula)
            {
                return pacientes[i];
            }
        }

        return null;
    }

    public void ConsultarPaciente()
    {
        Console.Write("Ingrese la cédula del paciente a buscar: ");
        string cedula = Console.ReadLine();

        Paciente paciente = BuscarPacientePorCedula(cedula);

        if (paciente != null)
        {
            Console.WriteLine("Paciente encontrado:");
            paciente.MostrarInformacion();
        }
        else
        {
            Console.WriteLine("Paciente no encontrado.");
        }
    }

    public void MostrarPacientes()
    {
        if (contadorPacientes == 0)
        {
            Console.WriteLine("No existen pacientes registrados.");
            return;
        }

        Console.WriteLine("===== LISTA DE PACIENTES =====");

        for (int i = 0; i < contadorPacientes; i++)
        {
            pacientes[i].MostrarInformacion();
        }
    }

    public void MostrarTurnos()
    {
        if (contadorTurnos == 0)
        {
            Console.WriteLine("No existen turnos registrados.");
            return;
        }

        Console.WriteLine("===== LISTA DE TURNOS =====");

        for (int i = 0; i < contadorTurnos; i++)
        {
            turnos[i].MostrarTurno();
        }
    }

    public void MostrarMatrizHorarios()
    {
        Console.WriteLine("===== MATRIZ SEMANAL DE TURNOS =====");
        Console.Write("Día/Hora\t");

        for (int h = 0; h < horas.Length; h++)
        {
            Console.Write(horas[h] + "\t");
        }

        Console.WriteLine();

        for (int i = 0; i < dias.Length; i++)
        {
            Console.Write(dias[i] + "\t");

            for (int j = 0; j < horas.Length; j++)
            {
                Console.Write(matrizHorarios[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }

    private void MostrarDias()
    {
        Console.WriteLine("===== DÍAS DISPONIBLES =====");

        for (int i = 0; i < dias.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {dias[i]}");
        }
    }

    private void MostrarHoras()
    {
        Console.WriteLine("===== HORAS DISPONIBLES =====");

        for (int i = 0; i < horas.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {horas[i]}");
        }
    }
}