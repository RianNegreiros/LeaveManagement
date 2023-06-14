using LeaveManagement.Application;
using LeaveManagement.Identity;
using LeaveManagement.Persistence;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AddSwaggerDoc(builder.Services);

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
  options.AddPolicy("CorsPolicy", builder =>
  {
    builder.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.UseAuthentication();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LeaveManagement.API v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();

void AddSwaggerDoc(IServiceCollection services)
{
  services.AddHttpContextAccessor();
  services.AddSwaggerGen(c =>
  {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
      Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
      Name = "Authorization",
      In = ParameterLocation.Header,
      Type = SecuritySchemeType.ApiKey,
      Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
          });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
      Version = "v1",
      Title = "HR Leave Management Api",

    });

  });
}