// Clase que representa una persona
public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Persona(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
}

// Clase que maneja la atracción y los asientos
public class Atraccion
{
    private Queue<Persona> colaEspera;
    private List<Persona> asientosOcupados;
    private int capacidad = 30;

    public Atraccion()
    {
        colaEspera = new Queue<Persona>();
        asientosOcupados = new List<Persona>();
    }

    // Registrar persona en la cola
    public void RegistrarPersona(Persona persona)
    {
        if (asientosOcupados.Count >= capacidad)
        {
            Console.WriteLine($"🚫 Ya no hay asientos disponibles para {persona.Nombre}");
        }
        else
        {
            colaEspera.Enqueue(persona);
            Console.WriteLine($"✅ {persona.Nombre} se ha registrado en la cola.");
        }
    }

    // Asignar asientos en orden
    public void AsignarAsientos()
    {
        while (colaEspera.Count > 0 && asientosOcupados.Count < capacidad)
        {
            Persona persona = colaEspera.Dequeue();
            asientosOcupados.Add(persona);
            Console.WriteLine($"🎟️ Asiento asignado a {persona.Nombre}");
        }
    }

    // Reporte
    public void MostrarAsientosAsignados()
    {
        Console.WriteLine("\n📋 Lista de personas con asiento:");
        foreach (var persona in asientosOcupados)
        {
            Console.WriteLine($"Asiento #{persona.Id}: {persona.Nombre}");
        }
    }
}
