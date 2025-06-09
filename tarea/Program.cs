// Clase para representar un Círculo
public class Circulo
{
    private double radio; // Almacena el radio del círculo

    // Constructor para inicializar el radio
    public Circulo(double radio)
    {
        this.radio = radio;
    }

    // CalcularArea es una función que devuelve un valor double,
    // se utiliza para calcular el área de un círculo.
    public double CalcularArea()
    {
        return Math.PI * radio * radio; // Fórmula: π * r²
    }

    // CalcularPerimetro es una función que devuelve un valor double,
    // se utiliza para calcular la circunferencia del círculo.
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio; // Fórmula: 2 * π * r
    }
}

// Clase para representar un Rectángulo
public class Rectangulo
{
    private double largo;  // Almacena el largo del rectángulo
    private double ancho;  // Almacena el ancho del rectángulo

    // Constructor para inicializar largo y ancho
    public Rectangulo(double largo, double ancho)
    {
        this.largo = largo;
        this.ancho = ancho;
    }

    // CalcularArea es una función que devuelve el área del rectángulo
    public double CalcularArea()
    {
        return largo * ancho; // Fórmula: largo * ancho
    }

    // CalcularPerimetro es una función que devuelve el perímetro del rectángulo
    public double CalcularPerimetro()
    {
        return 2 * (largo + ancho); // Fórmula: 2 * (largo + ancho)
    }
}
