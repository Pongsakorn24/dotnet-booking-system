public class MemberBooking : IBookingPrice
{
    private double discount => 10;
    public double CalculateDiscount(double total) => discount / 100.0 * total;

    public double CalculatePriceAfterDiscount(double total) => total - CalculateDiscount(total);

    public double CalculatePrice(double basePrice) => CalculatePriceAfterDiscount(basePrice); //Price after the discount.
}