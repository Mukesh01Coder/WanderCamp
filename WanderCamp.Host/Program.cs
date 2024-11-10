

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WanderCampRepository.DataAccessLayer.DatabaseContext;
using WanderCampRepository.DataAccessLayer.Interface;
using WanderCampRepository.DataAccessLayer.Repository;
using WanderCampService.BusinessLogicLayer.Interfaces;
using WanderCampService.BusinessLogicLayer.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var key = Encoding.UTF8.GetBytes("YourSecretKeyHere"); // Use a secure key

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(Options =>
    {
        Options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "YourIssuerHere",
            ValidAudience = "YourAudienceHere",
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };

    });


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


// Register your IUserService and other services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICampgroundService, CampgroundService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ICampgroundRepository, CampgroundRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.---> Middlewares
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); //---> header Strict-Transport-Security
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/hi", () => "Hello!");

// Configure the HTTP request pipeline.
//app.MapControllers();
app.MapGet("/", () => "Hello, World!");

app.Run();
