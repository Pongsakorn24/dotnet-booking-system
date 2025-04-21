namespace dotnet_booking_system;

public class ShippingCalculatorTests
{
    [Fact]
    public void ShouldShippingCalculator_ShippingFee0()
    {
        var x = new ShippingCalculator();
        var shippingPrice = x.CalculateShipping(500);
        Assert.Equal(0, shippingPrice);
    }

    [Fact]
    public void ShouldShippingCalculator_ShippingFee30()
    {
        var x = new ShippingCalculator();
        var shippingPrice = x.CalculateShipping(499);
        Assert.Equal(30, shippingPrice);
    }
}