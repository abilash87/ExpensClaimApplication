using ExpenseClaimApplication.ExpenseClaim.ExpenseClaimServices;
using ExpenseClaimApplication.Utilities.Interfaces;
using ExpenseClaimApplication.Utilities.XmlService;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register services
builder.Services.AddScoped<IXmlService, XmlService>();
builder.Services.AddScoped<IExpenseClaimService, ExpenseClaimService>();
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
