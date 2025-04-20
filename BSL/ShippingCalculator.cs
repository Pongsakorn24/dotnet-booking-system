public interface IShippingCalculator
{
    double CalculateShipping(double amount, double? threshold);
}

public class ShippingCalculator : IShippingCalculator
{
    private double shppingFee => 30;
    public double CalculateShipping(double amount, double? threshold)
    {
        return (threshold.HasValue && amount >= threshold) ? 0 : shppingFee;
    }
}