using ReGoTech.ImmigrationSystem.Data;
using ReGoTech.ImmigrationSystem.Data.EntityFramework.WorkUnits;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Inbound;
using ReGoTech.ImmigrationSystem.Services.DtoValidation;
using ReGoTech.ImmigrationSystem.Data.EntityFramework;
using ReGoTech.ImmigrationSystem.Services.ModelConvertion.Contracts;
using ReGoTech.ImmigrationSystem.Services.ModelConvertion.Converters;
using ReGoTech.ImmigrationSystem.Services;
using ReGoTech.ImmigrationSystem.Models.CompositeModels;
using ReGoTech.ImmigrationSystem.Models.DataTransferObjects.Outbound;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// TODO: move to secret AppConfig
string connectionString = "Server=REGO\\SQLEXPRESS;Database=ImmigrationMaster;User Id=sa;Password=R_123456;Encrypt=True;TrustServerCertificate=True;";

// TODO: Move to secret AppConfig and cleanup a bit
builder.Services.AddAuthentication(o => {
	o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => {
	o.TokenValidationParameters = new() {
		ValidIssuer = "https://localhost:7225",
		ValidAudience = "https://localhost:7225",
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ReGoTech.net-ReGoTech.net-ReGoTech.net-ReGoTech.net-ReGoTech.net")),
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
	};
	o.Events = new JwtBearerEvents() {
		OnTokenValidated = context => {
			// Check if token is blacklisted
			if (IsTokenBlacklisted(context.SecurityToken)) {
				// Token is blacklisted, reject the request
				context.Fail("Token is blacklisted.");
			}

			return Task.CompletedTask;
		}
	};
});

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// We must add entity framework
builder.Services.AddEFWithSqlServer(connectionString);
builder.Services.AddScoped<IDtoValidator<ClientDtoIn>, ClientDtoValidator>();
builder.Services.AddScoped<IDtoValidator<LoginDtoIn>, LoginDtoValidator>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISignupModelConverter, SignUpModelConverter>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISignupModelConverter, SignUpModelConverter>();
builder.Services.AddScoped<IAccountService, AccountService>();

var passVal = new PasswordValidator();
passVal.ShouldContainLowerCaseLetters()
	   .ShouldContainUpperCaseLetters()
	   .ShouldContainNumbers()
	   .ShouldContainSpecialCharacters();

builder.Services.AddTransient(typeof(PasswordValidator), x => passVal);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

bool IsTokenBlacklisted(SecurityToken securityToken) {
	// This methods allows us to reject authenticating previously issued JWT tokens that are not expired yet (after issuing a new one)
	// TODO: Maybe implement this functionality
	return false;
}