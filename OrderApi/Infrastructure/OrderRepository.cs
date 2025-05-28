using Dapper;
using Dapper.SimpleSqlBuilder;
using OrderApi.Domain;

namespace OrderApi.Infrastructure;

public class OrderRepository(SqlConnectionFactory connectionFactory) : IOrderRepository
{
    private readonly SqlConnectionFactory _connectionFactory = connectionFactory;

    public async Task InsertAsync(Order order, CancellationToken cancellationToken = default)
    {
        var builder = SimpleBuilder.CreateFluent()
            .InsertInto($"Orders")
            .Columns($"Id, CustomerName, Product, TotalAmount, CreatedAt, Status")
            .Values(
                $"{order.Id}, {order.CustomerName}, {order.Product}, {order.TotalAmount}, {order.CreatedAt}, {order.Status.ToString()}");

        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(builder.Sql, builder.Parameters);
    }

    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var builder = SimpleBuilder.CreateFluent()
            .Select($"Id, CustomerName, Product, TotalAmount, CreatedAt, Status")
            .From($"Orders");

        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<Order>(builder.Sql, builder.Parameters);
    }
}