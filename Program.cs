for (int i = 0; i < 10; i++)
{
    var booking = new Booking($"Pongsakorn {i}", 1000, (CustomerType)new Random().Next(0, 3));
    var finalPrice = new BookingService().ProcessBooking(booking);

    Console.WriteLine(
        $"Final price for Customer Type: {booking.CustomerType} \n Customer Name: {booking.CustomerName} \n Fee: {finalPrice.Fee} THB \n Net Price: {finalPrice.NetPrice} THB"
    );
    Console.WriteLine("");
}
