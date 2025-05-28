using OrderApi.Domain;

namespace OrderApi.Infrastructure;

public interface IOrderRepository
{
    Task InsertAsync(Order order, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default);
}