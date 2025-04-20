public class BookingPriceFactory {
    public static IBookingPrice GetCalculator(CustomerType customerType){
        return customerType switch
        {
            CustomerType.General => new GeneralBooking(),
            CustomerType.Member => new MemberBooking(),
            CustomerType.VIP => new VIPBooking(),
            _ => throw new ArgumentException("Invalid customer type")
        };
    }
}