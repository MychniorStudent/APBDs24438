using AnimalManager.Interfaces;
using AnimalManager.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IAnimalRepository,AnimalRepository>();
builder.Services.AddSingleton<IDBRepository, DBRepository>();
builder.Services.AddControllers();
// Add services to the container.
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
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseHttpsRedirection();
app.Run();
