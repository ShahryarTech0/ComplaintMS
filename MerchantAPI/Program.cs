using MediatR;
using MerchantApplication;
        // ✅ Application layer
using MerchantInfrastructure;     // ✅ Infrastructure layer
using MerchantApplication.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

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
