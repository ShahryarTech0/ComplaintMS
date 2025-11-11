using MediatR;
using MerchantApplication;
using MerchantApplication.Interfaces;
        // ✅ Application layer
using MerchantInfrastructure;     // ✅ Infrastructure layer
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ✅ Load JWT key securely
var jwtKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
             ?? builder.Configuration["AppSettings:Jwt:Key"]; // fallback to appsettings.json

if (string.IsNullOrEmpty(jwtKey))
    throw new Exception("JWT secret key is missing! Set JWT_SECRET_KEY env variable or appsettings.json.");

// ✅ Configure Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});



// ✅ Add Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ✅ Add these


// ✅ Register Application Layer
builder.Services.AddApplication();



builder.Services.AddPersistence(builder.Configuration);
// ✅ Register MediatR — register all handlers in the Application assembly
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(MerchantApplication.Features.Merchants.Commands.AddMerchant.AddMerchantHandler).Assembly)
);

// ✅ Register AutoMapper (optional)
builder.Services.AddAutoMapper(typeof(MerchantApplication.AssemblyMarker));

var app = builder.Build();

// ✅ Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
