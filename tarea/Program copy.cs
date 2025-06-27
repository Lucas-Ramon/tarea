// Clase Estudiante en C# using System;

class Estudiante
{
public int Id { get; set; }
public string Nombres { get; set; } public string Apellidos { get; set; } public string Direccion { get; set; } public string[] Telefonos { get; set; }

public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
{
Id = id;
Nombres = nombres; Apellidos = apellidos; Direccion = direccion; Telefonos = telefonos;
}

public void MostrarInformacion()
 
{
Console.WriteLine($"ID: {Id}"); Console.WriteLine($"Nombre: {Nombres} {Apellidos}"); Console.WriteLine($"Dirección: {Direccion}"); Console.WriteLine("Teléfonos:");
foreach (var telefono in Telefonos)
{
Console.WriteLine($"- {telefono}");
}
}
}

// Programa Principal class Programa
{
static void Main()
{
string[] telefonos = new string[3] { "0991234567", "0987654321", "0971112233" }; Estudiante estudiante = new Estudiante(1, "Lucas", "Cedeño", "Av. Principal y
Calle 10", telefonos);
estudiante.MostrarInformacion();
