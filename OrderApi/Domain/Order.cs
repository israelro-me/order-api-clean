namespace OrderApi.Domain;

// Domain/Order.cs
public class Order
{
    public Guid Id { get; set; }
    public required string CustomerName { get; set; }
    public required string Product { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public OrderStatus Status { get; set; }
}