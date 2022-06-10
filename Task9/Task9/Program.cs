using Microsoft.EntityFrameworkCore;
using Task9.Data;
using FluentValidation.AspNetCore;
using Task9.Models;
using FluentValidation;
using Task9.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<TaskContext>(options =>
{
    options.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddTransient<TaskService, TaskService>();
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
{
    fv.ImplicitlyValidateChildProperties = true;
    fv.RegisterValidatorsFromAssemblyContaining<UserValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<RoleValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<TaskValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<TaskVMValidator>();
});


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

AppContextSeeding.Seed(app).Wait();
app.Run();

