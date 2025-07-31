using FortressAuth;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
// Add services to the container.

builder.Services.WebApiRegister();
builder.Services.InfraestructureRegister();

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
