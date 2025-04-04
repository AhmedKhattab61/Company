using Company.BLL.Interfaces;
using Company.BLL.Repositories;
using Company.DAL.Data.Contexts;
using Company.DAL.Models;
using Company.PL.Mapping;
using Company.PL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Company.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Register DI for UnitOfWork


            //builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();

            builder.Services.AddDbContext<CompanyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //builder.Services.AddAutoMapper(typeof(EmployeeProfile)); // Register DI for AutoMapper
            builder.Services.AddAutoMapper(M => M.AddProfile(new EmployeeProfile())); // Register DI for AutoMapper
            builder.Services.AddAutoMapper(M => M.AddProfile(new DepartmentProfile())); // Register DI for AutoMapper


            //builder.Services.AddScoped();    // Create Object Life Time Per Request - Unreachable Object
            //builder.Services.AddTransient(); // Create Object Life Time Per Operation
            //builder.Services.AddSingleton(); // Create Object Life Time Per Application

            builder.Services.AddScoped<IScopedService, ScopedService>(); // Per Request
            builder.Services.AddTransient<ITransientService, TransientService>(); // Per Operation
            builder.Services.AddSingleton<ISingletonService, SingletonService>(); // Per Application

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                 .AddEntityFrameworkStores<CompanyDbContext>()
                 .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/SignIn";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}


class Test
{
    public void Fun01()
    {
        // Statement 01
        // Statement 02
        // await // Statement 03 => Take Time
        // Statement 04
        // Statement 05
    }
    public void Fun02()
    {
        // Statement 01
        // Statement 02
        // Statement 03
        // Statement 04
        // Statement 05
    }
}