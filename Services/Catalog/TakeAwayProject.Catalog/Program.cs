using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;
using TakeAwayProject.Catalog.Services.CategoryServices;
using TakeAwayProject.Catalog.Services.FeatureServices;
using TakeAwayProject.Catalog.Services.ProductServices;
using TakeAwayProject.Catalog.Services.SliderServices;
using TakeAwayProject.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Jwt bearer keyi
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"]; //Yetkinin nereden geleceðini belirtiyoruz.
    opt.Audience = ""; //Microservice hangi
    opt.RequireHttpsMetadata = false;
});
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//MongoDb Registration
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

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
