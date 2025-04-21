public class BookingService
{
    private IShippingCalculator _shippingCalculator;
    private readonly IFeeCalculator _feeCalculator;
    public BookingService(ShippingCalculator shippingCalculator, FeeCalculator feeCalculator)
    {
        _shippingCalculator = shippingCalculator;
        _feeCalculator = feeCalculator;
    }

    public BookingResult ProcessBooking(Booking booking)
    {
        var calculator = BookingPriceFactory.GetCalculator(booking.CustomerType);
        BookingResult bookingResult = new BookingResult();
        bookingResult.Price = calculator.CalculatePrice(booking.BasePrice);
        bookingResult.Fee = _feeCalculator.CalculatePrice(
            booking.CustomerType,
            bookingResult.Price
        );
        bookingResult.ShippingFee = _shippingCalculator.CalculateShipping(bookingResult.Price);
        bookingResult.NetPrice = bookingResult.Price + bookingResult.Fee + bookingResult.ShippingFee;
        return bookingResult;
    }
}