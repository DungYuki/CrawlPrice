 using GetPriceUrl.Infrastructure;
using GetPriceUrl.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBrowserService, BrowserService>();
builder.Services.AddScoped<PriceCrawlService>();
builder.Services.AddScoped<UpdatePriceDbService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Infrastructure
builder.Services.AddDbContext<LaptopPriceDbContext>( op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DbLaptopPrice"));
});

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
