using Dern_Support.Data;
using Dern_Support.Repositories.Interfaces;
using Dern_Support.Repositories.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddControllersWithViews() // For MVC with views
            .AddRazorRuntimeCompilation(); // Enable runtime compilation for Razor views
        builder.Services.AddRazorPages(); // For Razor Pages

        // Database configuration
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DernSupportDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Register Identity services
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<DernSupportDbContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager<SignInManager<ApplicationUser>>();

        // Register application services
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

        // Register user and JWT services
        builder.Services.AddScoped<IUser, IdentitiUserService>();
        builder.Services.AddScoped<JwtTokenService>();

        // Configure JWT authentication
        var jwtSettings = builder.Configuration.GetSection("JWT");
        var secretKey = jwtSettings["SecretKey"];

        if (string.IsNullOrEmpty(secretKey))
        {
            throw new ArgumentNullException("JWT SecretKey is missing or empty.");
        }

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            // Optional: Log the token during validation
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                    Console.WriteLine($"Validating Token: {token}");
                    return Task.CompletedTask;
                }
            };
        });

        // Configure Swagger
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

        // Add CORS configuration
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });

        // Configure WebSocket options
        builder.Services.AddWebSockets(options =>
        {
            options.KeepAliveInterval = TimeSpan.FromMinutes(2);
        });

        var app = builder.Build();


        // Middleware setup
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // Use Swagger and Swagger UI
        app.UseSwagger(options =>
        {
            options.RouteTemplate = "api/{documentName}/swagger.json";
        });

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/api/DernSupportAPI/swagger.json", "Dern Support API");
            options.RoutePrefix = "swagger"; // Swagger UI path
        });

        // Middleware to prevent caching of sensitive pages
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Add("Cache-Control", "no-store, no-cache, must-revalidate, post-check=0, pre-check=0");
            context.Response.Headers.Add("Pragma", "no-cache");
            context.Response.Headers.Add("Expires", "-1");

            await next();
        });

        // Seed roles
        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await SeedRoles(roleManager);
        }

        // Middleware configuration
        app.UseHttpsRedirection();
        app.UseStaticFiles(); // Serves static files from wwwroot

        app.UseRouting();

        // Enable CORS middleware
        app.UseCors("AllowAll");

        // Enable Authentication & Authorization middleware
        app.UseAuthentication();
        app.UseAuthorization();

        // Enable WebSocket middleware
        app.UseWebSockets();

        // Map endpoints for Razor Pages and MVC controllers
        app.MapRazorPages(); // For Razor Pages
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        await app.RunAsync();
    }

    private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = { "Admin", "User", "Technician" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
