using Microsoft.EntityFrameworkCore;
using SmartAppointmentBackend.Data;
using SmartAppointmentBackend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SmartAppointmentBackend.Services;
using SmartAppointmentBackend.Observers;



var builder = WebApplication.CreateBuilder(args);

var key = Encoding.UTF8.GetBytes("MySuperSecureJWTKey_withmorethan32bits_123456789!"); // Change this key to a strong one

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IAppointmentSubject, AppointmentSubject>();
builder.Services.AddScoped<IAppointmentObserver, EmailNotificationObserver>(); // if used directly

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllers(); // ✅ For pure Web APIs

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();


// Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
   // app.UseHttpsRedirection(); 
}


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseCors("AllowAll");
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllers(); // Required for [ApiController] routing

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
