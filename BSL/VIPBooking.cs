public class VIPBooking : IBookingPrice
{
    private double discount => 20;
    private double CalculateDiscount(double total) => discount / 100.0 * total;

    private double CalculatePriceAfterDiscount(double total) => total - CalculateDiscount(total);

    public double CalculatePrice(double basePrice) => CalculatePriceAfterDiscount(basePrice); //Price after the discount.
}