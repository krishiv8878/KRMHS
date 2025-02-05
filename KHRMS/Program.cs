using KHRMS.Services;
using KHRMS.Infrastructure;
using KHRMS.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IDesignationService, DesignationService>();
builder.Services.AddScoped<IAssetsMasterService, AssetsMasterService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IProjectMasterService, ProjectMasterService>();
builder.Services.AddScoped<IUserRegistrationService, UserRegistrationService>();
builder.Services.AddScoped<IRoleMasterService, RoleMasterService>();
builder.Services.AddScoped<IEmployeeRoleMappingService, EmployeeRoleMappingService>();
builder.Services.AddScoped<IAttendanceRequestService, AttendanceRequestService>();

builder.Services.AddControllers(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corspolice", builder =>
{
    builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
}));

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

app.UseCors("corspolice");

app.Run();
