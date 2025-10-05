using System;
using System.Collections.Generic;
using System.Linq;

namespace CampanaVacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Campaña de Vacunación COVID-19 ===");
            
            const int totalCiudadanos = 500;
            const int cantidadPfizer = 75;
            const int cantidadAstraZeneca = 75;

            // Generar los conjuntos de ciudadanos
            HashSet<string> todosLosCiudadanos = GenerarCiudadanos(totalCiudadanos);
            HashSet<string> vacunadosPfizer = GenerarVacunados(cantidadPfizer, totalCiudadanos);
            HashSet<string> vacunadosAstraZeneca = GenerarVacunados(cantidadAstraZeneca, totalCiudadanos);

            // Operaciones de conjuntos
            HashSet<string> vacunados = new HashSet<string>(vacunadosPfizer.Union(vacunadosAstraZeneca));
            HashSet<string> noVacunados = new HashSet<string>(todosLosCiudadanos.Except(vacunados));
            HashSet<string> ambasDosis = new HashSet<string>(vacunadosPfizer.Intersect(vacunadosAstraZeneca));
            HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer.Except(vacunadosAstraZeneca));
            HashSet<string> soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca.Except(vacunadosPfizer));

            // Mostrar resultados generales
            Console.WriteLine($"\nTotal de ciudadanos: {totalCiudadanos}");
            Console.WriteLine($"Vacunados con Pfizer: {vacunadosPfizer.Count}");
            Console.WriteLine($"Vacunados con AstraZeneca: {vacunadosAstraZeneca.Count}");
            Console.WriteLine($"Vacunados totales: {vacunados.Count}");
            Console.WriteLine($"No vacunados: {noVacunados.Count}");
            Console.WriteLine($"Vacunados con ambas dosis: {ambasDosis.Count}");
            Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
            Console.WriteLine($"Solo AstraZeneca: {soloAstraZeneca.Count}");

            // Mostrar los grupos de ciudadanos
            ImprimirGrupo("\n--- Ciudadanos vacunados con Pfizer ---", vacunadosPfizer);
            ImprimirGrupo("\n--- Ciudadanos vacunados con AstraZeneca ---", vacunadosAstraZeneca);
            ImprimirGrupo("\n--- Ciudadanos con ambas dosis ---", ambasDosis);
            ImprimirGrupo("\n--- Ciudadanos solo con Pfizer ---", soloPfizer);
            ImprimirGrupo("\n--- Ciudadanos solo con AstraZeneca ---", soloAstraZeneca);
            ImprimirGrupo("\n--- Ciudadanos no vacunados ---", noVacunados);
        }

        // Método para generar la lista de ciudadanos
        static HashSet<string> GenerarCiudadanos(int cantidad)
        {
            HashSet<string> conjunto = new HashSet<string>();
            for (int i = 1; i <= cantidad; i++)
                conjunto.Add("Ciudadano_" + i.ToString("D3")); // Formato: Ciudadano_001
            return conjunto;
        }

        // Método para generar aleatoriamente los vacunados
        static HashSet<string> GenerarVacunados(int cantidadVacunados, int total)
        {
            HashSet<string> conjunto = new HashSet<string>();
            Random aleatorio = new Random(Guid.NewGuid().GetHashCode()); // Semilla distinta
            while (conjunto.Count < cantidadVacunados)
                conjunto.Add("Ciudadano_" + aleatorio.Next(1, total + 1).ToString("D3"));
            return conjunto;
        }

        // Método para imprimir cada grupo de ciudadanos
        static void ImprimirGrupo(string titulo, HashSet<string> grupo)
        {
            Console.WriteLine(titulo);
            int contador = 0;
            foreach (var ciudadano in grupo)
            {
                Console.Write(ciudadano + " ");
                contador++;
                if (contador % 20 == 0) Console.WriteLine(); // salto de línea cada 20
            }
            Console.WriteLine("\n");
        }
    }
}
