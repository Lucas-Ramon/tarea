using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

class ProgramaVacunacion
{
    static void Main()
    {
        // 1. Crear conjunto de 500 ciudadanos
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // 2. Crear conjunto de 75 vacunados con Pfizer
        HashSet<string> pfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            pfizer.Add($"Ciudadano {i}");
        }

        // 3. Crear conjunto de 75 vacunados con AstraZeneca
        HashSet<string> astraZeneca = new HashSet<string>();
        for (int i = 50; i < 125; i++) // solapamiento intencional para tener ciudadanos con ambas dosis
        {
            astraZeneca.Add($"Ciudadano {i}");
        }

        // 4. Operaciones de teoría de conjuntos

        // Ciudadanos vacunados (Pfizer ∪ AstraZeneca)
        HashSet<string> vacunados = new HashSet<string>(pfizer);
        vacunados.UnionWith(astraZeneca);

        // No vacunados (Total - Vacunados)
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunados);

        // Ambas dosis (Pfizer ∩ AstraZeneca)
        HashSet<string> ambasDosis = new HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astraZeneca);

        // Solo Pfizer (Pfizer - AstraZeneca)
        HashSet<string> soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astraZeneca);

        // Solo AstraZeneca (AstraZeneca - Pfizer)
        HashSet<string> soloAstraZeneca = new HashSet<string>(astraZeneca);
        soloAstraZeneca.ExceptWith(pfizer);

        // 5. Mostrar resultados
        Console.WriteLine("=== Resultados de la Campaña de Vacunación ===\n");

        Console.WriteLine($"Total ciudadanos: {ciudadanos.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {pfizer.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {astraZeneca.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstraZeneca.Count}\n");

        // (Opcional) Generar archivo de reporte en TXT
        GenerarReporte(noVacunados, ambasDosis, soloPfizer, soloAstraZeneca);
    }

    static void GenerarReporte(HashSet<string> noVacunados,
                               HashSet<string> ambasDosis,
                               HashSet<string> soloPfizer,
                               HashSet<string> soloAstraZeneca)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("=== REPORTE DE VACUNACIÓN COVID-19 ===\n");
        sb.AppendLine("Ciudadanos NO vacunados:");
        sb.AppendLine(string.Join(", ", noVacunados));
        sb.AppendLine("\nCiudadanos con AMBAS dosis:");
        sb.AppendLine(string.Join(", ", ambasDosis));
        sb.AppendLine("\nCiudadanos SOLO Pfizer:");
        sb.AppendLine(string.Join(", ", soloPfizer));
        sb.AppendLine("\nCiudadanos SOLO AstraZeneca:");
        sb.AppendLine(string.Join(", ", soloAstraZeneca));

        File.WriteAllText("ReporteVacunacion.txt", sb.ToString());
        Console.WriteLine("Reporte generado: ReporteVacunacion.txt");
    }
}

