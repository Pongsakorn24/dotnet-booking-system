namespace dotnet_booking_system;

public class BookingServiceTests
{
    [Fact]
    public void GeneralCustomer_ShouldPayFullPrice()
    {
        var booking = new Booking("John", 1000, CustomerType.General);
        var service = new BookingService();

        var result = service.ProcessBooking(booking);
        Assert.Equal(1000, result.Price);
    }

[Fact]
    public void MemberCustomer_ShouldGet10PercentDiscount()
    {
        var booking = new Booking("John", 1000, CustomerType.Member);
        var service = new BookingService();

        var result = service.ProcessBooking(booking);
        Assert.Equal(900, result.Price);
    }

    [Fact]
    public void VIPCustomer_ShouldGet20PercentDiscount()
    {
        var booking = new Booking("Emma", 1000, CustomerType.VIP);
        var service = new BookingService();

        var result = service.ProcessBooking(booking);
        Assert.Equal(800, result.Price);
    }

    [Fact]
    public void VIPCustomer_ShouldGetFee0()
    {
        var booking = new Booking("Emma", 1000, CustomerType.VIP);
        var service = new BookingService();

        var result = service.ProcessBooking(booking);
        Assert.Equal(0, result.Fee);
    }
}
