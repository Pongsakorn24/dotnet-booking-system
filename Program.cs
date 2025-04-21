using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddTransient<BookingService>();
        services.AddTransient<GeneralBooking>();
        services.AddTransient<MemberBooking>();
        services.AddTransient<VIPBooking>();


        services.AddTransient<IShippingCalculator, ShippingCalculator>();
        services.AddTransient<IFeeCalculator, FeeCalculator>();
        services.AddTransient<IBookingPriceFactory, BookingPriceFactory>();

    })
    .Build();

var _bookingService = host.Services.GetRequiredService<BookingService>();

for (int i = 0; i < 10; i++)
{
    var booking = new Booking($"Pongsakorn {i}", 1000, (CustomerType)new Random().Next(0, 3));
    var finalPrice = _bookingService.ProcessBooking(booking);

    Console.WriteLine(
        $"Final price for Customer Type: {booking.CustomerType} \n Customer Name: {booking.CustomerName} \n Price: {finalPrice.Price} \n Fee: {finalPrice.Fee} THB \n Shipping Fee: {finalPrice.ShippingFee} THB \n Net Price: {finalPrice.NetPrice} THB"
    );
    Console.WriteLine("");
}