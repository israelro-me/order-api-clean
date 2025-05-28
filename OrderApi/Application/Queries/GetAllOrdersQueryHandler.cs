using AutoMapper;
using MediatR;
using OrderApi.DTOs;
using OrderApi.Infrastructure;

namespace OrderApi.Application.Queries;

public class GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderResponseDto>>
{
    public async Task<IEnumerable<OrderResponseDto>> Handle(GetAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetAllAsync(cancellationToken);
        return orders.Select(mapper.Map<OrderResponseDto>);
    }
}