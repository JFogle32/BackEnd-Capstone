using MyCloset.Repositories;
using MyCloset.Models;    // Assuming this is the namespace where your User model and repository reside

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add your User repository to the DI container.
builder.Services.AddTransient<IUserRepository, UsersRepository>();
builder.Services.AddTransient<IClothesRepository, ClothesRepository>();
builder.Services.AddTransient<IShoesRepository, ShoesRepository>();
builder.Services.AddTransient<IGadgetsRepository, GadgetsRepository>();





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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
