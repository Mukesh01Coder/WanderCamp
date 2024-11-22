using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WanderCampController.APILayer.Configurations;
using WanderCampRepository.DataAccessLayer.DatabaseContext;
using WanderCampRepository.DataAccessLayer.Interface;
using WanderCampRepository.DataAccessLayer.Repository;
using WanderCampService.BusinessLogicLayer.Interfaces;
using WanderCampService.BusinessLogicLayer.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Swagger services
builder.Services.AddSwaggerDocumentation();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(Options =>
    {
       
        Options.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

    });
builder.Services.AddAuthorization();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));


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


app.UseSwaggerDocumentation();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
app.MapControllers();



app.Run();
