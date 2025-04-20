public class BookingService
{
    public BookingResult ProcessBooking(Booking booking)
    {
        var calculator = BookingPriceFactory.GetCalculator(booking.CustomerType);
        BookingResult bookingResult = new BookingResult();
        bookingResult.NetPrice = calculator.CalculatePrice(booking.BasePrice);
        bookingResult.Fee = calculator.GetFee();

        return bookingResult;
    }
}