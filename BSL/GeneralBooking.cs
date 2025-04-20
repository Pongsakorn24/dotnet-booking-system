public class GeneralBooking : IBookingPrice
{
    private double fee => 15;
    public double CalculatePrice(double basePrice) => basePrice + fee;

    public double GetFee() => fee;
}