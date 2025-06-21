namespace AppTurismo.Models;

public class VacationPackage
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public decimal Price { get; set; }
    public int MaxCapacity { get; set; }

    public List<Destination> Destinations { get; set; } = new();
    public List<Reservation> Reservations { get; set; } = new();

    public static event Action<string>? CapacityReached;
    public int AvailableSpots => MaxCapacity - Reservations.Count(r => !r.IsDeleted);

    public void CheckCapacity()
    {
        int active = Reservations.Count(r => !r.IsDeleted);

        if (active >= MaxCapacity) CapacityReached?.Invoke($"Pacote '{Title}' atingiu capacidade máxima");
    }
}
