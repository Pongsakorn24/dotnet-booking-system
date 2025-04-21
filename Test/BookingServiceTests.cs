using Xunit;
using Moq;

namespace dotnet_booking_system;

public class BookingServiceTests
{
    [Fact]
    public void GeneralCustomer_ShouldPayFullPrice()
    {
        var mockShippingCalculator = new Mock<ShippingCalculator>();
        var mockFeeCalculator = new Mock<FeeCalculator>();

        var service = new BookingService(mockShippingCalculator.Object, mockFeeCalculator.Object);

        var booking = new Booking("John", 1000, CustomerType.General);
        var result = service.ProcessBooking(booking);

        Assert.Equal(1000, result.Price);
    }

    [Fact]
    public void MemberCustomer_ShouldGet10PercentDiscount()
    {
        var mockShippingCalculator = new Mock<ShippingCalculator>();
        var mockFeeCalculator = new Mock<FeeCalculator>();

        var service = new BookingService(mockShippingCalculator.Object, mockFeeCalculator.Object);

        var booking = new Booking("John", 1000, CustomerType.Member);
        var result = service.ProcessBooking(booking);

        Assert.Equal(900, result.Price);
    }

    [Fact]
    public void VIPCustomer_ShouldGet20PercentDiscount()
    {
        var mockShippingCalculator = new Mock<ShippingCalculator>();
        var mockFeeCalculator = new Mock<FeeCalculator>();

        var service = new BookingService(mockShippingCalculator.Object, mockFeeCalculator.Object);

        var booking = new Booking("Emma", 1000, CustomerType.VIP);
        var result = service.ProcessBooking(booking);

        Assert.Equal(800, result.Price);
    }

    [Fact]
    public void VIPCustomer_ShouldGetFee0()
    {
        var mockShippingCalculator = new Mock<ShippingCalculator>();
        var mockFeeCalculator = new Mock<FeeCalculator>();

        var service = new BookingService(mockShippingCalculator.Object, mockFeeCalculator.Object);

        var booking = new Booking("Emma", 1000, CustomerType.VIP);
        var result = service.ProcessBooking(booking);

        Assert.Equal(0, result.Fee);
    }
}
