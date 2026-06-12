AgendaClinica agenda = new AgendaClinica();
int opcion;

do
{
    Console.WriteLine("\n===== SISTEMA DE AGENDA DE TURNOS - CLÍNICA =====");
    Console.WriteLine("1. Registrar paciente");
    Console.WriteLine("2. Registrar turno");
    Console.WriteLine("3. Consultar paciente");
    Console.WriteLine("4. Mostrar pacientes");
    Console.WriteLine("5. Mostrar turnos");
    Console.WriteLine("6. Mostrar matriz semanal de turnos");
    Console.WriteLine("7. Salir");
    Console.Write("Seleccione una opción: ");

    opcion = int.Parse(Console.ReadLine());

    Console.WriteLine();

    switch (opcion)
    {
        case 1:
            agenda.RegistrarPaciente();
            break;

        case 2:
            agenda.RegistrarTurno();
            break;

        case 3:
            agenda.ConsultarPaciente();
            break;

        case 4:
            agenda.MostrarPacientes();
            break;

        case 5:
            agenda.MostrarTurnos();
            break;

        case 6:
            agenda.MostrarMatrizHorarios();
            break;

        case 7:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

} while (opcion != 7);