using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Entity Framework Core services.
builder.Services.AddDbContext<PoliziaMunicipaleContext.Data.PoliziaMunicipaleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PoliziaMunicipaleContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
