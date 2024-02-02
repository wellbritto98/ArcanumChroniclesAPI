using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using UsuariosApi.Authorization;
using UsuariosApi.Data;
using UsuariosApi.Models;
using UsuariosApi.Repository;
using UsuariosApi.Services;
using UsuariosApi.Services.BackgroundService;
using UsuariosApi.Services.CharacterService;
using UsuariosApi.Services.EmailService;
using UsuariosApi.Services.TypeOfMagicService;
using UsuariosApi.Services.Usuario;

namespace UsuariosApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var secretKey = builder.Configuration["JwtConfig:Secret"];
            var connString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            // Add services to the container.

            builder.Services.AddEntityFrameworkNpgsql()
                            .AddDbContext<ACDbContext>(options =>
                            options.UseNpgsql(connString)
                            );

            builder.Services.AddIdentity<Usuario, IdentityRole>()
                            .AddEntityFrameworkStores<ACDbContext>()
                            .AddDefaultTokenProviders();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<CharacterService>();
            builder.Services.AddScoped<EmailService>();

            builder.Services.AddCors();

            
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<TokenService>();

            builder.Services.AddSingleton<IAuthorizationHandler, IdadeAuthorization>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero


                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("IdadeMinima", policy =>
                policy.AddRequirements(new IdadeMinima(18)));
            });



            builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

            builder.Services.AddScoped<NameService>();
            builder.Services.AddScoped<RegionService>();
            builder.Services.AddScoped<CharBackgroundService>();
            builder.Services.AddScoped<TypeOfMagicService>();   
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}