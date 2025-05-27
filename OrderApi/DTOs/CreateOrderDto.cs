namespace OrderApi.DTOs;

public class CreateOrderDto
{
    public required string CustomerName { get; set; }
    public required string Product { get; set; }
    public decimal TotalAmount { get; set; }
}