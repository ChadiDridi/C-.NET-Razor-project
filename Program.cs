using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using AST1.SQLConnection;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AST1.SQLConnection.Connection>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddRazorPages();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AST1.SQLConnection.Connection>();
    dbContext.Database.Migrate();
}




app.MapRazorPages();
app.Run();
