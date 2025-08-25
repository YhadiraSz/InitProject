using CRUD2.Data;
using CRUD2.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CrudContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql")));

builder.Services.AddHttpClient<ICarService, CarService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["CarApi:BaseURL"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuarios}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
