using System;
using System.Collections.Generic;

class ProgramaTorneo
{
    static void Main()
    {
        Dictionary<string, HashSet<string>> torneo = new Dictionary<string, HashSet<string>>();
        int opcion;

        do
        {
            Console.WriteLine("\n--- Menú Torneo de Fútbol ---");
            Console.WriteLine("1. Registrar equipo");
            Console.WriteLine("2. Registrar jugador en un equipo");
            Console.WriteLine("3. Consultar jugadores de un equipo");
            Console.WriteLine("4. Listar equipos");
            Console.WriteLine("5. Reporte: jugadores por equipo");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Nombre del equipo: ");
                    string equipo = Console.ReadLine();
                    if (!torneo.ContainsKey(equipo))
                        torneo[equipo] = new HashSet<string>();
                    else
                        Console.WriteLine("El equipo ya está registrado.");
                    break;

                case 2:
                    Console.Write("Equipo: ");
                    string eq = Console.ReadLine();
                    if (torneo.ContainsKey(eq))
                    {
                        Console.Write("Nombre del jugador: ");
                        string jugador = Console.ReadLine();
                        if (torneo[eq].Add(jugador))
                            Console.WriteLine("Jugador registrado ");
                        else
                            Console.WriteLine("El jugador ya existe en este equipo.");
                    }
                    else
                        Console.WriteLine("Equipo no encontrado.");
                    break;

                case 3:
                    Console.Write("Equipo: ");
                    string eqConsultar = Console.ReadLine();
                    if (torneo.ContainsKey(eqConsultar))
                        foreach (var j in torneo[eqConsultar])
                            Console.WriteLine($"- {j}");
                    else
                        Console.WriteLine(" Equipo no encontrado.");
                    break;

                case 4:
                    Console.WriteLine("Equipos registrados:");
                    foreach (var e in torneo.Keys)
                        Console.WriteLine($"- {e}");
                    break;

                case 5:
                    Console.WriteLine("\n--- Reporte Jugadores por Equipo ---");
                    foreach (var kvp in torneo)
                        Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} jugadores");
                    break;
            }

        } while (opcion != 0);
    }
}
