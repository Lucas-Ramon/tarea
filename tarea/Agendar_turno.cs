using System;
using System.Collections.Generic;

namespace AgendaTurnosClinica
{
    // Clase Paciente
    public class Paciente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public override string ToString()
        {
            return $"{Nombre} (C.I.: {Cedula}, Edad: {Edad})";
        }
    }

    // Clase Turno
    public class Turno
    {
        public Paciente Paciente { get; set; }
        public string Fecha { get; set; }       // formato: "DD/MM/AAAA"
        public string Hora { get; set; }        // formato: "HH:MM"
        public string Especialidad { get; set; }

        public override string ToString()
        {
            return $"{Fecha} {Hora} - {Especialidad} - {Paciente}";
        }
    }

    // Clase que gestiona los turnos
    public class AgendaTurnos
    {
        private List<Turno> turnos = new List<Turno>();

        public void AgregarTurno(Turno turno)
        {
            turnos.Add(turno);
            Console.WriteLine("✔️ Turno agregado con éxito.\n");
        }

        public void MostrarTodosLosTurnos()
        {
            if (turnos.Count == 0)
            {
                Console.WriteLine("No hay turnos registrados.\n");
                return;
            }

            Console.WriteLine("\n--- Lista de Turnos ---");
            foreach (var turno in turnos)
            {
                Console.WriteLine(turno);
            }
            Console.WriteLine();
        }

        public void BuscarPorCedula(string cedula)
        {
            var encontrados = turnos.FindAll(t => t.Paciente.Cedula == cedula);

            if (encontrados.Count > 0)
            {
                Console.WriteLine($"\n--- Turnos encontrados para la cédula {cedula} ---");
                foreach (var turno in encontrados)
                {
                    Console.WriteLine(turno);
                }
            }
            else
            {
                Console.WriteLine("No se encontraron turnos para esa cédula.");
            }
            Console.WriteLine();
        }

        public void ConsultarPorFecha(string fecha)
        {
            var encontrados = turnos.FindAll(t => t.Fecha == fecha);

            if (encontrados.Count > 0)
            {
                Console.WriteLine($"\n--- Turnos para la fecha {fecha} ---");
                foreach (var turno in encontrados)
                {
                    Console.WriteLine(turno);
                }
            }
            else
            {
                Console.WriteLine("No hay turnos para esa fecha.");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AgendaTurnos agenda = new AgendaTurnos();
            string opcion;

            do
            {
                Console.WriteLine("===== AGENDA DE TURNOS - CLÍNICA =====");
                Console.WriteLine("1. Agregar turno");
                Console.WriteLine("2. Mostrar todos los turnos");
                Console.WriteLine("3. Buscar turno por cédula");
                Console.WriteLine("4. Consultar turnos por fecha");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Turno nuevo = new Turno();
                        nuevo.Paciente = new Paciente();

                        Console.Write("Cédula: ");
                        nuevo.Paciente.Cedula = Console.ReadLine();

                        Console.Write("Nombre: ");
                        nuevo.Paciente.Nombre = Console.ReadLine();

                        Console.Write("Edad: ");
                        nuevo.Paciente.Edad = int.Parse(Console.ReadLine());

                        Console.Write("Fecha (DD/MM/AAAA): ");
                        nuevo.Fecha = Console.ReadLine();

                        Console.Write("Hora (HH:MM): ");
                        nuevo.Hora = Console.ReadLine();

                        Console.Write("Especialidad: ");
                        nuevo.Especialidad = Console.ReadLine();

                        agenda.AgregarTurno(nuevo);
                        break;

                    case "2":
                        agenda.MostrarTodosLosTurnos();
                        break;

                    case "3":
                        Console.Write("Ingrese la cédula: ");
                        string cedula = Console.ReadLine();
                        agenda.BuscarPorCedula(cedula);
                        break;

                    case "4":
                        Console.Write("Ingrese la fecha (DD/MM/AAAA): ");
                        string fecha = Console.ReadLine();
                        agenda.ConsultarPorFecha(fecha);
                        break;

                    case "5":
                        Console.WriteLine("Gracias por usar el sistema. 🩺");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.\n");
                        break;
                }
            } while (opcion != "5");
        }
    }
}
