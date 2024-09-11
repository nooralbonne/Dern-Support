using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Repositories.Interfaces;
using Dern_Support.Repositories.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DernSupportDbContext>(options => options.UseSqlServer(connectionString));

        // Register Identity services
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<DernSupportDbContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager<SignInManager<ApplicationUser>>();

        // Register services
        builder.Services.AddScoped<IUserAccount, UserAccountServices>();
        builder.Services.AddScoped<ITechnician, TechnicianServices>();
        builder.Services.AddScoped<ISupportRequest, SupportRequestServices>();
        builder.Services.AddScoped<IPayment, PaymentServices>();
        builder.Services.AddScoped<IKnowledgeBase, KnowledgeBaseServices>();
        builder.Services.AddScoped<IJobHistory, JobHistoryServices>();
        builder.Services.AddScoped<IJob, JobServices>();
        builder.Services.AddScoped<IFeedback, FeedbackServices>();
        builder.Services.AddScoped<ICustomer, CustomerServices>();
        builder.Services.AddScoped<IInventory, InventoryServices>();
        builder.Services.AddScoped<IJobInventory, JobInventoryServices>();

        // Register the IUser and IdentitiUserService
        builder.Services.AddScoped<IUser, IdentitiUserService>();
        builder.Services.AddScoped<JwtTokenService>();

        // Register JWT authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
        });

        // Swagger configuration
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("DernSupportAPI", new OpenApiInfo
            {
                Title = "Dern Support",
                Version = "v1",
                Description = "Small IT technical support company that repairs computer systems for businesses and individual customers."
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Please enter user token below."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        var app = builder.Build();

        // Use Swagger and Swagger UI
        app.UseSwagger(options =>
        {
            options.RouteTemplate = "api/{documentName}/swagger.json";
        });

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/api/DernSupportAPI/swagger.json", "Dern Support API");
            options.RoutePrefix = "";
        });

        // Enable Authentication & Authorization middleware
        app.UseAuthentication(); // Ensure this is called before UseAuthorization
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
