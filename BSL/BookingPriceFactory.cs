using Microsoft.Extensions.DependencyInjection;

public interface IBookingPriceFactory
{
    IBookingPrice GetCalculator(CustomerType customerType);
}

public class BookingPriceFactory : IBookingPriceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public BookingPriceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IBookingPrice GetCalculator(CustomerType customerType)
    {
        return customerType switch
        {
            CustomerType.Member => _serviceProvider.GetRequiredService<MemberBooking>(),
            CustomerType.VIP => _serviceProvider.GetRequiredService<VIPBooking>(),
            _ => _serviceProvider.GetRequiredService<GeneralBooking>(),
        };
    }
}