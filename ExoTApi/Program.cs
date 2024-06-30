using ExoTApi.Repositories;
using ExoTContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string MyPolicy = "MyPolicy";

builder.Services.AddCors(o => o.AddPolicy(MyPolicy, builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContextFactory<ExoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

builder.Services.AddScoped<ITacheRepository, TacheRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(MyPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
