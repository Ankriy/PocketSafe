using PocketSafe.Domain.Models;
using PocketSafe.DAL.Repositories.Mock;
using PocketSafe.DAL.Repositories.Mock.Data;
using PocketSafe.PostgresMigrate;
using TaskProject.DAL.Repositories;
using TaskStorageOfPeople.Logic;
using PocketSafe.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using PocketSafe.DAL.EF;
using PocketSafe.DAL.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();

builder.Services.AddScoped<UserListService>();
builder.Services.AddScoped<TaskListService>();

var dbType = builder.Configuration["DbConfig:Type"];
switch (dbType)
{
    case "Postgres":
        var connectionString = "host=localhost; port=5432; database=PocketSaveDB; username=postgres; password=123;"; // builder.Configuration.GetConnectionString("NpgsqlConnectionString");
        PostgresMigrator.Migrate(connectionString);

        builder.Services.AddScoped<IUserRepository, UserPostgreeRepository>(x=> new UserPostgreeRepository(connectionString));
        builder.Services.AddScoped<ITaskRepository, TaskPostgreeRepository>(x => new TaskPostgreeRepository(connectionString));
        break;
    case "Mock":
        builder.Services.AddSingleton<UserMockData>();
        builder.Services.AddSingleton<TaskMockData>();

        builder.Services.AddScoped<IUserRepository, UserMockRepository>();
        builder.Services.AddScoped<ITaskRepository, TaskMockRepository>();
        break;
    case "EF":
        var connectionStringEF = "host=localhost; port=5432; database=PocketSaveDB; username=postgres; password=123;";  //builder.Configuration.GetConnectionString("NpgsqlConnectionString");
        PostgresMigrator.Migrate(connectionStringEF);

        builder.Services.AddDbContext<PostgreeContext>(
            options => options.UseNpgsql(connectionStringEF));


        builder.Services.AddScoped<ITaskRepository, TaskEFPostgreeRepository>();
        builder.Services.AddScoped<IUserRepository, UserEFPostgreeRepository>();
        break;
}



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=TableUsers}/{id?}");

app.Run();
