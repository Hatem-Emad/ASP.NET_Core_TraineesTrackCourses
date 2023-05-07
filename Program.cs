using Microsoft.EntityFrameworkCore;
using WebApplication_Core_Day09.Models;
using WebApplication_Core_Day09.RepoService;
using Microsoft.AspNetCore.Identity;
using WebApplication_Core_Day09.Data;

namespace WebApplication_Core_Day09
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			
			// Add services to the container.
			builder.Services.AddControllersWithViews();
			
			builder.Services.AddDbContext<MainDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("dbcn")));
			builder.Services.AddDbContext<Identity_Core_Day09Context>(o => 
				o.UseSqlServer(builder.Configuration.GetConnectionString("Identity_Core_Day09ContextConnection"))
			);
			builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Identity_Core_Day09Context>();
			
			builder.Services.AddScoped<IRepo<Course>, CourseService>();
			builder.Services.AddScoped<IRepo<Track>, TrackService>();
			builder.Services.AddScoped<IRepo<Trainee>, TraineeService>();

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

			app.MapRazorPages();
			app.Run();
		}
	}
}