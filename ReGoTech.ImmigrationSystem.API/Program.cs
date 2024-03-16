using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Services.DtoValidation;
using ReGoTech.ImmigrationSystem.Data.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// TODO: move to secret AppConfig
string connectionString = "Server=REGO\\SQLEXPRESS;Database=ImmigrationMaster;User Id=sa;Password=R_123456;Encrypt=True;TrustServerCertificate=True;";   

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEFWithSqlServer(connectionString);
builder.Services.AddScoped<IDtoValidator<ClientDtoIn>, ClientDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
