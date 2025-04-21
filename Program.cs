for (int i = 0; i < 10; i++)
{
    var booking = new Booking($"Pongsakorn {i}", 500, (CustomerType)new Random().Next(0, 3));
    var finalPrice = new BookingService().ProcessBooking(booking);

    Console.WriteLine(
        $"Final price for Customer Type: {booking.CustomerType} \n Customer Name: {booking.CustomerName} \n Price: {finalPrice.Price} \n Fee: {finalPrice.Fee} THB \n Shipping Fee: {finalPrice.ShippingFee} THB \n Net Price: {finalPrice.NetPrice} THB"
    );
    Console.WriteLine("");
}
