using GradeRank_Application.Interfaces;
using GradeRank_Application.UseCases;
using GradeRank_Domain.Mappings;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;
using GradeRank_Infrastructure.DataAccess;
using GradeRank_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Logging.AddConsole();
builder.Services.AddAutoMapper(typeof(MappingLibrary));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IHealthStatusService, HealthStatusService>();
builder.Services.AddScoped<IHealthStatusRepository, HealthStatusRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IEvaluationService, EvaluationService>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();



builder.Services.AddDbContext<GradeRankContext>(
                        (prv, options) =>
                        {
                          options.UseSqlServer(builder.Configuration.GetConnectionString("GradeRankDataBase") ?? string.Empty);

                          options.EnableSensitiveDataLogging();
                        });

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
  app.UseDeveloperExceptionPage();
  app.UseSwagger();
  app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
