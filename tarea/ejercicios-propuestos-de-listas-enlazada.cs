using System;

class NodoReal
{
    public double Dato;
    public NodoReal Siguiente;

    public NodoReal(double dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

class ListaReales
{
    public NodoReal Inicio;

    public void AgregarFinal(double dato)
    {
        NodoReal nuevo = new NodoReal(dato);
        if (Inicio == null)
            Inicio = nuevo;
        else
        {
            NodoReal actual = Inicio;
            while (actual.Siguiente != null)
                actual = actual.Siguiente;
            actual.Siguiente = nuevo;
        }
    }

    public void Mostrar()
    {
        NodoReal actual = Inicio;
        while (actual != null)
        {
            Console.Write(actual.Dato + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }

    public int Contar()
    {
        int contador = 0;
        NodoReal actual = Inicio;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }

    public double Sumar()
    {
        double suma = 0;
        NodoReal actual = Inicio;
        while (actual != null)
        {
            suma += actual.Dato;
            actual = actual.Siguiente;
        }
        return suma;
    }
}

class NodoEntero
{
    public int Dato;
    public NodoEntero Siguiente;

    public NodoEntero(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

class ListaEnteros
{
    public NodoEntero Inicio;

    public void AgregarInicio(int dato)
    {
        NodoEntero nuevo = new NodoEntero(dato);
        nuevo.Siguiente = Inicio;
        Inicio = nuevo;
    }

    public int Contar()
    {
        int contador = 0;
        NodoEntero actual = Inicio;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }

    public bool EsIgual(ListaEnteros otra)
    {
        NodoEntero actual1 = this.Inicio;
        NodoEntero actual2 = otra.Inicio;

        while (actual1 != null && actual2 != null)
        {
            if (actual1.Dato != actual2.Dato)
                return false;

            actual1 = actual1.Siguiente;
            actual2 = actual2.Siguiente;
        }

        return actual1 == null && actual2 == null;
    }

    public void Mostrar()
    {
        NodoEntero actual = Inicio;
        while (actual != null)
        {
            Console.Write(actual.Dato + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

class Programa
{
    static void Main()
    {
        Console.WriteLine("======= PARTE 1: Lista de números reales y clasificación =======");
        ListaReales listaPrincipal = new ListaReales();
        ListaReales listaMenores = new ListaReales();
        ListaReales listaMayores = new ListaReales();

        Console.Write("Ingrese la cantidad de datos reales: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Ingrese el dato real #{i + 1}: ");
            double dato = double.Parse(Console.ReadLine());
            listaPrincipal.AgregarFinal(dato);
        }

        double promedio = listaPrincipal.Sumar() / listaPrincipal.Contar();

        NodoReal actual = listaPrincipal.Inicio;
        while (actual != null)
        {
            if (actual.Dato <= promedio)
                listaMenores.AgregarFinal(actual.Dato);
            else
                listaMayores.AgregarFinal(actual.Dato);
            actual = actual.Siguiente;
        }

        Console.WriteLine("\nLista principal:");
        listaPrincipal.Mostrar();

        Console.WriteLine($"Promedio: {promedio:F2}");

        Console.WriteLine("Datos <= promedio:");
        listaMenores.Mostrar();

        Console.WriteLine("Datos > promedio:");
        listaMayores.Mostrar();

        Console.WriteLine("\n======= PARTE 2: Comparación de dos listas de enteros =======");
        ListaEnteros lista1 = new ListaEnteros();
        ListaEnteros lista2 = new ListaEnteros();

        Console.Write("Ingrese cantidad de elementos para la lista 1: ");
        int n1 = int.Parse(Console.ReadLine());
        for (int i = 0; i < n1; i++)
        {
            Console.Write($"Ingrese dato #{i + 1} para lista 1: ");
            int dato = int.Parse(Console.ReadLine());
            lista1.AgregarInicio(dato);
        }

        Console.Write("Ingrese cantidad de elementos para la lista 2: ");
        int n2 = int.Parse(Console.ReadLine());
        for (int i = 0; i < n2; i++)
        {
            Console.Write($"Ingrese dato #{i + 1} para lista 2: ");
            int dato = int.Parse(Console.ReadLine());
            lista2.AgregarInicio(dato);
        }

        Console.WriteLine("\nLista 1:");
        lista1.Mostrar();
        Console.WriteLine("Lista 2:");
        lista2.Mostrar();

        if (lista1.Contar() == lista2.Contar())
        {
            if (lista1.EsIgual(lista2))
                Console.WriteLine("✔ Las listas son iguales en tamaño y contenido.");
            else
                Console.WriteLine("⚠ Las listas son iguales en tamaño, pero no en contenido.");
        }
        else
        {
            Console.WriteLine("✘ Las listas no tienen el mismo tamaño ni contenido.");
        }
    }
}
