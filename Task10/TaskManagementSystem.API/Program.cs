using TaskManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using TaskManagementSystem.Application.Validators;
using TaskManagementSystem.Infrastructure.Services;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TaskDbContext>(options =>
{
    options.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("Default"), b=> b.MigrationsAssembly("TaskManagementSystem.Infrastructure"));
});
builder.Services.AddTransient<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddTransient<IGenericRepository<Role>, GenericRepository<Role>>();
builder.Services.AddTransient<IGenericRepository<TaskItem>, GenericRepository<TaskItem>>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddScoped<AppContextSeeding>();
builder.Services.AddControllers()
        .AddFluentValidation(fv =>
        {
            fv.ImplicitlyValidateChildProperties = true;
            fv.RegisterValidatorsFromAssemblyContaining<UserValidator>();
            fv.RegisterValidatorsFromAssemblyContaining<RoleValidator>();
            fv.RegisterValidatorsFromAssemblyContaining<TaskValidator>();
            fv.RegisterValidatorsFromAssemblyContaining<TaskDtoValidator>();
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

using (var scope = app.Services.CreateScope())
{
    var initialiser = scope.ServiceProvider.GetRequiredService<AppContextSeeding>();
    await initialiser.InitialiseAsync();
    await initialiser.Seed();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
