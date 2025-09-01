using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario base (Español -> Inglés)
    static Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {"tiempo", "time"},
        {"persona", "person"},
        {"año", "year"},
        {"camino", "way"},
        {"forma", "way"},
        {"día", "day"},
        {"cosa", "thing"},
        {"hombre", "man"},
        {"mundo", "world"},
        {"vida", "life"},
        {"mano", "hand"},
        {"parte", "part"},
        {"niño", "child"},
        {"niña", "child"},
        {"ojo", "eye"},
        {"mujer", "woman"},
        {"lugar", "place"},
        {"trabajo", "work"},
        {"semana", "week"},
        {"caso", "case"},
        {"punto", "point"},
        {"tema", "point"},
        {"gobierno", "government"},
        {"empresa", "company"},
        {"compañía", "company"}
    };

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del traductor...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase()
    {
        Console.Write("\nIngrese una frase en español: ");
        string frase = Console.ReadLine();

        string[] palabras = frase.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.None);
        string resultado = frase;

        foreach (string palabra in palabras)
        {
            if (diccionario.ContainsKey(palabra.ToLower()))
            {
                string traduccion = diccionario[palabra.ToLower()];
                resultado = ReplaceWord(resultado, palabra, traduccion);
            }
        }

        Console.WriteLine("\nTraducción (parcial):");
        Console.WriteLine(resultado);
    }

    // Método que reemplaza palabra respetando mayúsculas y signos
    static string ReplaceWord(string frase, string original, string traduccion)
    {
        return System.Text.RegularExpressions.Regex.Replace(frase, $@"\b{original}\b", traduccion, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    }

    static void AgregarPalabra()
    {
        Console.Write("\nIngrese la palabra en español: ");
        string esp = Console.ReadLine().ToLower();

        Console.Write("Ingrese la traducción en inglés: ");
        string eng = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(esp))
        {
            diccionario.Add(esp, eng);
            Console.WriteLine($"Palabra agregada: {esp} -> {eng}");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}
