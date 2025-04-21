public class BookingService
{
    public BookingResult ProcessBooking(Booking booking)
    {
        var calculator = BookingPriceFactory.GetCalculator(booking.CustomerType);
        BookingResult bookingResult = new BookingResult();
        bookingResult.Price = calculator.CalculatePrice(booking.BasePrice);
        bookingResult.Fee = calculator.GetFee();
        bookingResult.ShippingFee = new ShippingCalculator().CalculateShipping(bookingResult.Price);
        bookingResult.NetPrice = bookingResult.Price + bookingResult.Fee + bookingResult.ShippingFee;
        return bookingResult;
    }
}