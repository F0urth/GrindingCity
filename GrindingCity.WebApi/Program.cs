using GrindingCity.WebApi.Repositories;
using GrindingCity.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
builder.Services.AddDbContext<AppDbContext>
(o => o.UseInMemoryDatabase("MyDatabase"));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBuildingRepository, BuildingRepository>();
builder.Services.AddTransient<IResourceRepository, ResourceRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();