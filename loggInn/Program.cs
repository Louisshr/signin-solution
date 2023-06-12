using loggInn.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KundeContekst>(options => options.UseSqlite("Data source=kunde.db"));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<KundeContekst>();
    DBinit.Initialize(context);
}

    //app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();

app.MapFallbackToFile("index.html");
app.Run();

