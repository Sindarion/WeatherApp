var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseDefaultFiles();   // serves index.html
app.UseStaticFiles();    // serves Angular assets

app.UseAuthorization();

app.MapControllers();

// fallback all other routes to index.html (Angular router support)
app.MapFallbackToFile("index.html");

app.Run();
