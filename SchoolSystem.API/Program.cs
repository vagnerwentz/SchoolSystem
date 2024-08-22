using System.Configuration;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SchoolSystem.API.Endpoints.Professors;
using SchoolSystem.API.Endpoints.StudentPerformances;
using SchoolSystem.API.Endpoints.Students;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Infrastructure;
using SchoolSystem.Infrastructure.Repositories;
using SchoolSystem.Service.Commands.Students.CreateStudent;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(
    cfg => cfg
        .RegisterServicesFromAssembly(typeof(CreateStudentCommand).Assembly));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("SchoolSystemPostgreSQL")));
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("SchoolSystemMongoDB");
    return new MongoClient(connectionString);
});

builder.Services.AddSingleton(sp =>
{
    var mongoClient = sp.GetRequiredService<IMongoClient>();
    return mongoClient.GetDatabase("SchoolSystem");
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IStudentPerformanceRepository, StudentPerformanceRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddTransient<StudentsService>();
builder.Services.AddTransient<ProfessorsService>();
builder.Services.AddTransient<StudentPerformancesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterStudentEndpoints();
app.RegisterProfessorEndpoints();
app.RegisterStudentPerformancesEndpoints();

app.Run();