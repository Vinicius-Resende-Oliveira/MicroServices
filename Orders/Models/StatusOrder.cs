namespace Orders.Models
{
    public enum StatusOrder
    {
        Pending = 1,
        Approved = 2,
        Invoiced = 3,
        ShippingInformed = 4,
        Picking = 5,
        Shipped = 6,
        Delivered = 7,
        Canceled = 8
    }
}
