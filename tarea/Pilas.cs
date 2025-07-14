using System;
using System.Collections.Generic;

class Program
{
    // Función para verificar si una expresión está balanceada
    public static bool EstaBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>();
        foreach (char c in expresion)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0) return false;

                char tope = pila.Pop();
                if ((c == ')' && tope != '(') ||
                    (c == '}' && tope != '{') ||
                    (c == ']' && tope != '['))
                {
                    return false;
                }
            }
        }
        return pila.Count == 0;
    }

    // Clase para representar una torre con pila de discos
    class Torre
    {
        public Stack<int> discos = new Stack<int>();
        public string nombre;

        public Torre(string nombre)
        {
            this.nombre = nombre;
        }

        public void MoverDiscoA(Torre destino)
        {
            int disco = discos.Pop();
            destino.discos.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombre} a {destino.nombre}");
        }
    }

    // Método recursivo para resolver las Torres de Hanoi
    public static void ResolverHanoi(int n, Torre origen, Torre auxiliar, Torre destino)
    {
        if (n == 1)
        {
            origen.MoverDiscoA(destino);
        }
        else
        {
            ResolverHanoi(n - 1, origen, destino, auxiliar);
            origen.MoverDiscoA(destino);
            ResolverHanoi(n - 1, auxiliar, origen, destino);
        }
    }

    // Menú principal
    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Verificar paréntesis balanceados");
            Console.WriteLine("2. Resolver Torres de Hanoi");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

            switch (opcion)
            {
                case 1:
                    Console.Write("\nIngrese la expresión matemática: ");
                    string expresion = Console.ReadLine();
                    if (EstaBalanceada(expresion))
                        Console.WriteLine("✔ Fórmula balanceada.");
                    else
                        Console.WriteLine("✘ Fórmula no balanceada.");
                    break;

                case 2:
                    Console.Write("\nIngrese la cantidad de discos: ");
                    int discos;
                    if (int.TryParse(Console.ReadLine(), out discos) && discos > 0)
                    {
                        Torre torreA = new Torre("A");
                        Torre torreB = new Torre("B");
                        Torre torreC = new Torre("C");

                        for (int i = discos; i >= 1; i--)
                        {
                            torreA.discos.Push(i);
                        }

                        Console.WriteLine("\nMovimientos:");
                        ResolverHanoi(discos, torreA, torreB, torreC);
                    }
                    else
                    {
                        Console.WriteLine("Número de discos inválido.");
                    }
                    break;

                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 3);
    }
}
