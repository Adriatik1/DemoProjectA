using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetSection("DbConfig:ConnectionString").Get<string>();

builder.Services.AddDbContext<DemoDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<DemoDbContext>();
dbContext.Database.Migrate();

if (!dbContext.Roles.Any())
{
    string[] roleNames = new string[] { "Admin", "Moderator", "Sales", "Employee" };

    foreach(var role in roleNames)
    {
        dbContext.Roles.Add(new RoleEntity
        {
            RoleName = role
        });
    }

    dbContext.SaveChanges();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
