using Xunit;
using Moq;

namespace dotnet_booking_system;

public class BookingServiceTests
{
    [Fact]
    public void GeneralCustomer_ShouldPayFullPrice()
    {
        var mockfactory = new Mock<IBookingPriceFactory>();
        var mockShippingCalculator = new Mock<IShippingCalculator>();
        var mockFeeCalculator = new Mock<IFeeCalculator>();

        mockfactory.Setup(f => f.GetCalculator(CustomerType.General)).Returns(new GeneralBooking());

        var service = new BookingService(
            mockfactory.Object,
            mockShippingCalculator.Object,
            mockFeeCalculator.Object
        );

        var booking = new Booking("John", 1000, CustomerType.General);
        var result = service.ProcessBooking(booking);

        Assert.Equal(1000, result.Price);
    }

    [Fact]
    public void MemberCustomer_ShouldGet10PercentDiscount()
    {
        var mockfactory = new Mock<IBookingPriceFactory>();
        var mockShippingCalculator = new Mock<IShippingCalculator>();
        var mockFeeCalculator = new Mock<IFeeCalculator>();

        mockfactory.Setup(f => f.GetCalculator(CustomerType.Member)).Returns(new MemberBooking());

        var service = new BookingService(
            mockfactory.Object,
            mockShippingCalculator.Object,
            mockFeeCalculator.Object
        );

        var booking = new Booking("John", 1000, CustomerType.Member);
        var result = service.ProcessBooking(booking);

        Assert.Equal(900, result.Price);
    }

    [Fact]
    public void VIPCustomer_ShouldGet20PercentDiscount()
    {
        var mockfactory = new Mock<IBookingPriceFactory>();
        var mockShippingCalculator = new Mock<IShippingCalculator>();
        var mockFeeCalculator = new Mock<IFeeCalculator>();

        mockfactory.Setup(f => f.GetCalculator(CustomerType.VIP)).Returns(new VIPBooking());

        var service = new BookingService(
            mockfactory.Object,
            mockShippingCalculator.Object,
            mockFeeCalculator.Object
        );

        var booking = new Booking("Emma", 1000, CustomerType.VIP);
        var result = service.ProcessBooking(booking);

        Assert.Equal(800, result.Price);
    }

    [Fact]
    public void VIPCustomer_ShouldGetFee0()
    {
        var mockfactory = new Mock<IBookingPriceFactory>();
        var mockShippingCalculator = new Mock<IShippingCalculator>();
        var mockFeeCalculator = new Mock<IFeeCalculator>();

        mockfactory.Setup(f => f.GetCalculator(CustomerType.VIP)).Returns(new VIPBooking());

        var service = new BookingService(
            mockfactory.Object,
            mockShippingCalculator.Object,
            mockFeeCalculator.Object
        );

        var booking = new Booking("Emma", 1000, CustomerType.VIP);
        var result = service.ProcessBooking(booking);

        Assert.Equal(0, result.Fee);
    }
}
