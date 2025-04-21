public class BookingService
{
    private IBookingPriceFactory _bookingPriceFactory;
    private IShippingCalculator _shippingCalculator;
    private readonly IFeeCalculator _feeCalculator;

    public BookingService(
        IBookingPriceFactory bookingPriceFactory,
        IShippingCalculator shippingCalculator,
        IFeeCalculator feeCalculator
    )
    {
        _bookingPriceFactory = bookingPriceFactory;
        _shippingCalculator = shippingCalculator;
        _feeCalculator = feeCalculator;
    }

    public BookingResult ProcessBooking(Booking booking)
    {
        BookingResult bookingResult = new BookingResult();

        var calculator = _bookingPriceFactory.GetCalculator(booking.CustomerType);
        bookingResult.Price = calculator.CalculatePrice(booking.BasePrice);
        bookingResult.Fee = _feeCalculator.CalculatePrice(
            booking.CustomerType,
            bookingResult.Price
        );
        bookingResult.ShippingFee = _shippingCalculator.CalculateShipping(bookingResult.Price);
        bookingResult.NetPrice =
            bookingResult.Price + bookingResult.Fee + bookingResult.ShippingFee;
        return bookingResult;
    }
}
