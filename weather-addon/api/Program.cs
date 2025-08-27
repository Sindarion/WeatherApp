var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.WebHost.UseUrls("http://0.0.0.0:5000");
builder.WebHost.UseUrls("http://100.80.92.35:5000");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin() // Angular dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseDefaultFiles();   // serves index.html
app.UseStaticFiles();    // serves Angular assets

app.UseCors();

app.UseAuthorization();

app.MapControllers();

// fallback all other routes to index.html (Angular router support)
app.MapFallbackToFile("index.html");

app.Run();
