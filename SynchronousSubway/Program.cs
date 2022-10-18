using SynchronousSubway.Machines;
using SynchronousSubway.Workers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IWorker, Ellie>();
builder.Services.AddSingleton<IToaster, Toaster>();
builder.Services.AddSingleton<ISauceBot, SauceBot>();
builder.Services.AddSingleton<ICoffeeMachine, CoffeeMachine>();
builder.Services.AddSingleton<IToaster, Toaster>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();