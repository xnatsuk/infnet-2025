namespace AppTurismo.Models;

public class Client
{
    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public List<Reservation> Reservations { get; set; } = [];
}
