using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TrainingApp.DAL;
using Microsoft.Extensions.DependencyInjection;
using TrainingApp.DAL.DbConfiguration.DatabaseConfiguration;
using TrainingApp.Web.Configuration.MappingConfig;
using TrainingApp.BLL.Interfaces;
using TrainingApp.BLL.Services;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Repositories;
using TrainingApp.Web.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TrainingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<TrainingContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            ConfigureServices(builder.Services);
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new List<string> { "signin.html" }
            });
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TrainingContext>();
                dbContext.Database.Migrate();
            }
            app.Run();
        }
        private static void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IQualificationService, QualificationService>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IWorkedHoursService, WorkedHoursService>();
            services.AddScoped<IWorkedHoursRepository, WorkedHoursRepository>();
            services.AddScoped<ISubjectTypeService, SubjectTypeService>();
            services.AddScoped<ISubjectTypeRepository, SubjectTypeRepository>();
            services.AddScoped<ISubjectNameService, SubjectNameService>();
            services.AddScoped<ISubjectNameRepository, SubjectNameRepository>();
            services.AddScoped<IGetAllService, GetAllService>();

            services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
