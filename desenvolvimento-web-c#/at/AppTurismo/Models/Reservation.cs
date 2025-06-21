namespace AppTurismo.Models;

public class Reservation
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int VacationPackageId { get; set; }
    public DateTime BookingDate { get; set; } = DateTime.Now;

    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public Client Client { get; set; } = null!;
    public VacationPackage VacationPackage { get; set; } = null!;
}
