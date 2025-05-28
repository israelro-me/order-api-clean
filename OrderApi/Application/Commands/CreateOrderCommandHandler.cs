using AutoMapper;
using MediatR;
using OrderApi.Domain;
using OrderApi.DTOs;
using OrderApi.Infrastructure;

namespace OrderApi.Application.Commands;

public class CreateOrderCommandHandler(IOrderRepository repository, IMapper mapper)
    : IRequestHandler<CreateOrderCommand, OrderResponseDto>
{
    private readonly IMapper _mapper = mapper;
    private readonly IOrderRepository _repository = repository;

    public async Task<OrderResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request.Dto);
        order.Id = Guid.NewGuid();
        order.CreatedAt = DateTime.UtcNow;
        order.Status = OrderStatus.Pending;

        await _repository.InsertAsync(order, cancellationToken);

        return _mapper.Map<OrderResponseDto>(order);
    }
}