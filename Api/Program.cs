using Infrastructure;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();

builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = "MyAuthServer",
            ValidateAudience = true,
            ValidAudience = "MyAuthClient",
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey("INeedMoreLetterForSecretKeeeeeeeeeeeey"u8.ToArray()),
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();