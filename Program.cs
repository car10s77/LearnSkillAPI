using LearnASkill.Midlewares;
using LearnASkill.Models;
using LearnASkill.Persistance;
using LearnASkill.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace LearnASkill;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers(configure =>
        {
            configure.ReturnHttpNotAcceptable = true;

            configure.Filters.Add(
               new ProducesResponseTypeAttribute(
                   StatusCodes.Status400BadRequest));
            configure.Filters.Add(
                new ProducesResponseTypeAttribute(
                    StatusCodes.Status406NotAcceptable));
            configure.Filters.Add(
                new ProducesResponseTypeAttribute(
                    StatusCodes.Status500InternalServerError));
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<ISkillRepository, SkillRepository>();
        builder.Services.AddScoped<IGoalRepository, GoalRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        #region Data manager for In Memory collections
        //string ConnectionString = builder.Configuration.GetConnectionString("MemoryCollectionConnectionString");
        //builder.Services.AddSingleton(typeof(DataManager<Skill>), serviceProvider =>
        //{
        //    var initialSkillData = SkillsData.GetSkills();
        //    return new DataManager<Skill>(initialSkillData, ConnectionString);
        //});

        //builder.Services.AddSingleton(typeof(DataManager<Goal>), serviceProvider =>
        //{
        //    var initialGoalData = GoalData.GetGoals();
        //    return new DataManager<Goal>(initialGoalData, ConnectionString);
        //});

        //builder.Services.AddSingleton(typeof(DataManager<User>), serviceProvider =>
        //{
        //    var initialUserData = UserData.GetUsers();
        //    return new DataManager<User>(initialUserData, ConnectionString);
        //});
        #endregion

        #region Database context
        builder.Services.AddDbContext<Persistance.AppContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        );
        #endregion

        builder.Services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<GzipCompressionProvider>();

        });

        builder.Services.AddExceptionHandler<GLobalExeptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddApiVersioning(setupAction =>
        {
            setupAction.AssumeDefaultVersionWhenUnspecified = true;
            setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            setupAction.ReportApiVersions = true;
        });

        #region Authntication
        AuthenticationService.Initialize(builder.Configuration);

        builder.Services.AddSwaggerGen(setupAction =>
        {
            setupAction.AddSecurityDefinition("CityInfoApiBearerAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Description = "Input a valid token to access this API"
            });

            setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "CityInfoApiBearerAuth"
                        }
                    }, new List<string>()
                }
            });
        });

        builder.Services.AddAuthentication()
            .AddJwtBearer
            (options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Authentication:Issuer"],
                    ValidAudience = builder.Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretKey"]))
                };
            }
            );

        builder.Services.AddAuthorization();

        #endregion

        builder.Services.AddHealthChecks();


        var app = builder.Build();
        app.Urls.Add("http://*:80");

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}
        //app.


        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseExceptionHandler();

        app.UseResponseCompression();

        app.MapControllers();

        app.MapHealthChecks("/health");

        app.Run();
    }
}
