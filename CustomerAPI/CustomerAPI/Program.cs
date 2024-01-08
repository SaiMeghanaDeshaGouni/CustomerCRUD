using CustomerAPI.DALService;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

//Implementing DI
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

app.UseCors();

app.UseRouting();

// Configure the HTTP request pipeline.

app.UseAuthorization();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
