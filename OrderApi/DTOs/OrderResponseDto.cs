namespace OrderApi.DTOs;

public class OrderResponseDto
{
    public Guid Id { get; set; }
    public required string CustomerName { get; set; }
    public required string Product { get; set; }
    public decimal TotalAmount { get; set; }
    public required string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}