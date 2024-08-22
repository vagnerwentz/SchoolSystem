using Microsoft.EntityFrameworkCore;
using SchoolSystem.API.Endpoints.Professors;
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

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

builder.Services.AddTransient<StudentsService>();
builder.Services.AddTransient<ProfessorsService>();

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

app.Run();