using MVCOverrideArea;
using RazorClassLibrary3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IComonent, AComonent>();
builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

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
app.UseEndpoints(endpoints =>
{
  endpoints.MapAreaControllerRoute(
    name: "default2", areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
  endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
  endpoints.MapBlazorHub();
});



app.Run();
