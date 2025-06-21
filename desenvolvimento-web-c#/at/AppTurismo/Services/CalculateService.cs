namespace AppTurismo.Services;

public static class CalculateService
{
    public static Func<int, int, decimal> CalculateReservationTotal = (days, value) => days * value;
}
