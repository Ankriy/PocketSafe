using PocketSafe.DAL;
using PocketSafe.DAL.Repositories.Abstact;
using PocketSafe.DAL.Repositories.Mock;
using PocketSafe.PostgresMigrate;
using TaskProject.DAL.Repositories;
using TaskStorageOfPeople.Logic;

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
        var connectionString = builder.Configuration.GetConnectionString("NpgsqlConnectionString");
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
