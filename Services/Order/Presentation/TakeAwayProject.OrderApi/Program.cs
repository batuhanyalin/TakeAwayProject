using TakeAwayProject.Application.Features.CQRS.Handlers.AddressHandlers;
using TakeAwayProject.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using TakeAwayProject.Application.Interfaces;
using TakeAwayProject.Domain.Entities;
using TakeAwayProject.Persistence.Context;
using TakeAwayProject.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));



#region AddressHandlers
builder.Services.AddScoped<GetAddressByIdQueryResultHandler>();
builder.Services.AddScoped<GetAddressQueryResultHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();
#endregion

#region OrderDetailHandlers
builder.Services.AddScoped<GetOrderDetailByIdQueryResultHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryResultHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
