using can.Models;
using can.repo.impelemtation;
using can.repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace can
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var ConnectionStrings = builder.Configuration.GetConnectionString("conn");
            builder.Services.AddDbContext<AppDbContextt>(option =>
            option.UseSqlServer(ConnectionStrings));
            builder.Services.AddScoped<IUser,Userrepo>();
            builder.Services.AddScoped<Istaff, staffrepo>();
            builder.Services.AddScoped<Iorder, orderrepo>();
            builder.Services.AddScoped<Ifootitem, footitemrepo>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
