namespace tp3;

public class Circulo
{
    public double raio;

    public double CalcularArea()
    {
        return Math.PI * (raio * raio);
    }
}

public class Esfera
{
    public double raio;

    public double CalcularVolume()
    {
        return (4.0 / 3.0) * Math.PI * (raio * raio * raio);
    }
}