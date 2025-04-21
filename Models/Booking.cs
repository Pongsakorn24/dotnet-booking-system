public enum CustomerType
{
    General,
    Member,
    VIP
}

public class Booking
{
    public string CustomerName { get; set; }
    public double BasePrice { get; set; }
    public CustomerType CustomerType { get; set; }

    public Booking(string name, double price, CustomerType type)
    {
        CustomerName = name;
        BasePrice = price;
        CustomerType = type;
    }
}

public class BookingResult
{
    public double Price { get; set; }

    public double NetPrice { get; set; }

    public double Fee { get; set; }

    public double ShippingFee { get; set; }
}