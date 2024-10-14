using HospitalManagment.WebAPI.Contexts;
using HospitalManagment.WebAPI.Repository.Abstracts;
using HospitalManagment.WebAPI.Repository.Concretes;
using HospitalManagment.WebAPI.Servcie.Abstracts;
using HospitalManagment.WebAPI.Servcie.Concretes;
using HospitalManagment.WebAPI.Servcie.Mappers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BaseDbContext>();
builder.Services.AddScoped<IDoctorRepository,EfDoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<DoctorMapper>();
builder.Services.AddScoped<AppointmentMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
