using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Restaurant.Auth.DataAccess;
using Restaurant.Auth.DataAccess.Repositories;
using Restaurant.Auth.Service.Infrastructure;
using Restaurant.Auth.UseCases.Abstractions;
using Restaurant.Auth.UseCases.Users.Commands.AddUser;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(basePath, xmlFile);
    options.UseAllOfForInheritance();
    options.UseOneOfForPolymorphism();
    options.UseInlineDefinitionsForEnums();

    options.SelectDiscriminatorNameUsing(subType => "$type");
    options.SelectDiscriminatorValueUsing(subType => subType.BaseType!
                .GetCustomAttributes<JsonDerivedTypeAttribute>()
                .FirstOrDefault(attribute => attribute.DerivedType == subType)?
                .TypeDiscriminator?.ToString());

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter access token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
          },
          new List<string>()
        }
    });
});

// Configure authentication

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        builder.Configuration["Authentication:Secret"]!)),
                });

// Configutre DI

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddUserCommand).Assembly));

builder.Services.AddAutoMapper(typeof(Restaurant.Auth.UseCases.Config.MappingProfiles).Assembly,
                               typeof(Restaurant.Auth.DataAccess.MappigProfiles).Assembly);

builder.Services.AddScoped<IMainRepository, MainRepository>();
builder.Services.AddScoped<IAuthUserAccessor, AuthUserAccessor>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var connectionString = string.Format(builder.Configuration["ConnectionString"]!, builder.Configuration["localhost"]);
builder.Services.AddDbContext<UmContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Restaurant.Auth.Service"))
                   .UseSnakeCaseNamingConvention());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
