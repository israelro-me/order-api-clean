using MediatR;
using OrderApi.DTOs;

namespace OrderApi.Application.Queries;

public record GetAllOrdersQuery : IRequest<IEnumerable<OrderResponseDto>>;