namespace tp1;

public delegate decimal CalculateDiscount(decimal initialPrice);

public static class DiscountCalculator
{
    public static void Calculate()
    {
        Console.WriteLine("Digite o valor original do produto: R$ ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal initialPrice))
            Console.WriteLine("Erro. Informe um valor válido.");

        CalculateDiscount calculateDiscount = new CalculateDiscount(ApplyDiscount); // delegate explícito
        decimal finalPrice = initialPrice - calculateDiscount(initialPrice);

        Console.WriteLine("Preço inicial: R$ {0:F2}" +
                          "\nPreço após o desconto: R$ {1:F2}", initialPrice, finalPrice);
        Console.ReadKey();
    }

    private static decimal ApplyDiscount(decimal price)
    {
        decimal discount = 0.10m; // 10%
        return price * discount;
    }
}
