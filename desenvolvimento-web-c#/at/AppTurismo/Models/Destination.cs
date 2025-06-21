using System.Diagnostics.CodeAnalysis;

namespace AppTurismo.Models;

public class Destination
{
    public Destination()
    {
    }

    [SetsRequiredMembers]
    public Destination(string? name, string? country)
    {
        Name = name;
        Country = country;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
}
