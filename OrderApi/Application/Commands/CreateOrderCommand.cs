using MediatR;
using OrderApi.DTOs;

namespace OrderApi.Application.Commands;

public class CreateOrderCommand : IRequest<OrderResponseDto>
{
    public required CreateOrderDto Dto { get; set; }
}