public interface IShippingCalculator
{
    double CalculateShipping(double amount);
}

public class ShippingCalculator : IShippingCalculator
{
    double? threshold = 500;
    private double shppingFee => 30;
    public double CalculateShipping(double amount)
    {
        return (amount >= threshold) ? 0 : shppingFee;
    }
}