using Microsoft.EntityFrameworkCore;
using PhoneBookApi.Models.DataModels;
using PhoneBookApi.Repositories.IRepository;
using PhoneBookApi.Repositories.Repository;
using PhoneBookApi.Services.IService;
using PhoneBookApi.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
AddCorsPolicy(builder.Services);
AddDbContext(builder.Services);

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

void AddDbContext(IServiceCollection services)
{
    var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:PhoneBookConnectionString");
    services.AddDbContext<PhoneBookContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
}

void AddCorsPolicy(IServiceCollection services)
{
    services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    }));
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
