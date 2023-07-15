using FluentValidation.AspNetCore;
using CarInsurance.Infrastructure;
using CarInsurance.Infrastructure.Services;
using FluentValidation;
using CarInsurance.Application.Validations;
using CarInsurance.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoStoreDatabaseSettings>(
    builder.Configuration.GetSection("MongoStoreDatabase"));

builder.Services.AddScoped<IInsuranceService, InsuranceMongoService>();

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateInsuranceValidator>();

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
