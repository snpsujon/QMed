using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.RegisterServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<EFContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DevConnection")));
//builder.Services.AddDbContext<IdentityContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"), sqlServerOptionsAction: sqlOptions =>
//    {
//        sqlOptions.EnableRetryOnFailure(
//            maxRetryCount: 5, // Adjust this as needed
//            maxRetryDelay: TimeSpan.FromSeconds(30),
//            errorNumbersToAdd: null);
//    }));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("https://quickmed.techstdio.com", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
            .AllowCredentials();
}));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<EFContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<DapperContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CTF API v1");
    if (app.Environment.IsProduction())
    {
        c.RoutePrefix = string.Empty;
    }
}); app.UseSwaggerUI();
app.UseCors("corsapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
