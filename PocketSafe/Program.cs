using PocketSafe.DAL;
using PocketSafe.DAL.Repositories.Abstact;
using TaskProject.DAL.Repositories;
using TaskStorageOfPeople.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<UserListService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSingleton<UserMockData>();

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
