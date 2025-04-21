public interface IFeeCalculator
{
    public double CalculatePrice(CustomerType customerType, double basePrice);
}

public class FeeCalculator : IFeeCalculator
{
    public double CalculatePrice(CustomerType customerType, double basePrice)
    {
        if (customerType == CustomerType.VIP)
            return 0;

        return basePrice * 0.05; // ค่าธรรมเนียม 5%
    }
}