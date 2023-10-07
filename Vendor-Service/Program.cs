
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Vendor.DataEnities;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Vendor.DataEntities;
using Vendor.DataEnities.Interface;
using Vendor.DataEnities.Services;         
using AutoMapper;
using Vendor.BusinessEntities.Models;
using Vendor.DataEntities.Models;
using Vendor.BusinessService.Interfaces;
using Vendor.BusinessService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vendor API", Version = "v1" });
});
builder.Services.AddDbContext<VendorContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27)));
});

builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<Vendors, VendorsDTO>();
});
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IVendorService, VendorServices>();
//builder.Services.AddScoped<>(IProductRepo,ProductRepo);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable Swagger UI for API documentation
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vendor API v1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();