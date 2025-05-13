namespace tp1;

public static class TempMonitor
{
    public static void Monitor()
    {
        TemperatureSensor tempSensor = new TemperatureSensor();
        tempSensor.TemperatureExceeded += TemperatureAlert;

        Console.WriteLine("==== Sistema de Monitoramento de Temperatura ====");

        while (true)
        {
            Console.WriteLine("\nInforme o valor do temperatura atual (ou 'sair' para encerrar): ");
            string input = Console.ReadLine() ?? throw new InvalidOperationException();

            if (input?.ToLower() == "sair") break;

            if (!double.TryParse(input, out double currentTemp)) throw new FormatException();

            tempSensor.CurrentTemperature = currentTemp;
            Console.WriteLine("A temperatura está em {0}°C.", currentTemp);
            Thread.Sleep(600);
        }
    }

    static void TemperatureAlert(object? sender, TemperatureEventArgs eventArgs)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n[{0}] Temperatura Crítica Detectada!", eventArgs.Timestamp);
        Console.ResetColor();
    }
}

public class TemperatureEventArgs(double temperature) : EventArgs
{
    public double Temperature { get; } = temperature;
    public DateTime Timestamp { get; } = DateTime.Now;
}

public class TemperatureSensor
{
    private double _currentTemperature;
    private readonly double _threshold = 100.0;

    public event EventHandler<TemperatureEventArgs>? TemperatureExceeded;

    public double CurrentTemperature
    {
        get => _currentTemperature;
        set
        {
            _currentTemperature = value;
            if (_currentTemperature > _threshold)
                OnTemperatureExceeded();
        }
    }

    protected virtual void OnTemperatureExceeded() =>
        // ? para evitar NullReferenceException
        TemperatureExceeded?.Invoke(this, new TemperatureEventArgs(_currentTemperature));
}
