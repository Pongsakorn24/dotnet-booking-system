public class BookingService
{
    public BookingResult ProcessBooking(Booking booking)
    {
        var calculator = BookingPriceFactory.GetCalculator(booking.CustomerType);
        BookingResult bookingResult = new BookingResult();
        bookingResult.Price = calculator.CalculatePrice(booking.BasePrice);
        bookingResult.Fee = new FeeCalculator().CalculatePrice(
            booking.CustomerType,
            bookingResult.Price
        );
        bookingResult.ShippingFee = new ShippingCalculator().CalculateShipping(bookingResult.Price);
        bookingResult.NetPrice = bookingResult.Price + bookingResult.Fee + bookingResult.ShippingFee;
        return bookingResult;
    }
}