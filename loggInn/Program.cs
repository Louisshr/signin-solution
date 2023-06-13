using loggInn.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KundeContekst>(options => options.UseSqlite("Data source=kunde.db"));
builder.Services.AddScoped<IKundeRepository, KundeRepository>();
builder.Services.AddControllers();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<KundeContekst>();
    DBinit.Initialize(context);
}

//app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html");
});

app.UseStaticFiles();
app.Run();

