using BuisnessLogic.Service;
using DataAccess.Repository;
using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EmployeesLayersDI;
using Serilog;
using CarAgent.middleware;
using CarAgent.Middlewares;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("M:\\logging\\loggingFile.txt").CreateLogger();
builder.Logging.ClearProviders();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog(dispose: true);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepositorycs, CompanyRepositorycs>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<DBAgentContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine));

var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);




var app = builder.Build();
//app.Use(async (context, next) =>
//{
//    app.Logger.LogCritical("function" + context.Request.Path);
//    await next();

//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseBeforeSearchMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSearchMiddleware();
app.Run();
