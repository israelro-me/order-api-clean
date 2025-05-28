using MediatR;
using OrderApi.Application.Commands;
using OrderApi.Application.Queries;
using OrderApi.DTOs;
using OrderApi.Infrastructure;
using OrderApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateOrderCommand>());
builder.Services.AddSingleton<SqlConnectionFactory>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();
app.MapControllers();

// Add minimal API endpoint here
app.MapPost("/orders", async (
    CreateOrderDto dto,
    IMediator mediator,
    ILogger<Program> logger) =>
{
    logger.LogInformation("Received new order from {Customer}", dto.CustomerName);

    var command = new CreateOrderCommand { Dto = dto };
    var response = await mediator.Send(command);

    logger.LogInformation("Order {OrderId} created successfully", response.Id);
    return Results.Created($"/orders/{response.Id}", response);
});
app.MapGet("/orders", async (IMediator mediator, ILogger<Program> logger) =>
{
    logger.LogInformation("Fetching all orders");

    var result = (await mediator.Send(new GetAllOrdersQuery())).ToList();

    logger.LogInformation("{OrdersCount} orders fetched successfully", result.Count);
    return Results.Ok(result);
});

app.Run();