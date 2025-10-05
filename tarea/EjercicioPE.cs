using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Conversor
{
    static string archivoConversiones = "conversiones.json";

    // Cargar las conversiones desde el archivo JSON
    static Dictionary<string, double> CargarConversiones()
    {
        if (File.Exists(archivoConversiones))
        {
            string json = File.ReadAllText(archivoConversiones);
            return JsonSerializer.Deserialize<Dictionary<string, double>>(json);
        }
        else
        {
            return new Dictionary<string, double>();
        }
    }

    // Guardar las conversiones en el archivo JSON
    static void GuardarConversiones(Dictionary<string, double> conversiones)
    {
        string json = JsonSerializer.Serialize(conversiones, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(archivoConversiones, json);
    }

    // Convertir una unidad si existe en el diccionario
    static void ConvertirValor(Dictionary<string, double> conversiones)
    {
        Console.Write("Ingrese el tipo de unidad (ejemplo: metro, kilogramo): ");
        string unidad = Console.ReadLine().ToLower();

        if (!conversiones.ContainsKey(unidad))
        {
            Console.WriteLine("Esa unidad no está registrada en el sistema.");
            return;
        }

        Console.Write($"Ingrese la cantidad de {unidad}s a convertir: ");
        double valor = double.Parse(Console.ReadLine());

        double factor = conversiones[unidad];
        double resultado = valor * factor;

        Console.WriteLine($"\nResultado: {valor} {unidad}(s) equivalen a {resultado:F2} en la unidad equivalente.\n");
    }

    // Agregar una nueva conversión al diccionario
    static void AgregarConversion(Dictionary<string, double> conversiones)
    {
        Console.Write("Ingrese el nombre de la unidad (ejemplo: metro): ");
        string unidad = Console.ReadLine().ToLower();

        if (conversiones.ContainsKey(unidad))
        {
            Console.WriteLine("Esa unidad ya está registrada.");
            return;
        }

        Console.Write("Ingrese el factor de conversión (ejemplo: 1 metro = 3.28084 pies → ingrese 3.28084): ");
        double factor = double.Parse(Console.ReadLine());

        conversiones[unidad] = factor;
        GuardarConversiones(conversiones);

        Console.WriteLine("Conversión agregada correctamente.\n");
    }

    static void Main(string[] args)
    {
        Dictionary<string, double> conversiones = CargarConversiones();

        int opcion;
        do
        {
            Console.WriteLine("\n================ MENÚ ================");
            Console.WriteLine("1. Convertir un valor");
            Console.WriteLine("2. Agregar una nueva conversión");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ConvertirValor(conversiones);
                    break;
                case 2:
                    AgregarConversion(conversiones);
                    break;
                case 0:
                    Console.WriteLine("Saliendo del conversor...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }
}
