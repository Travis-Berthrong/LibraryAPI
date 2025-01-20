using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Areas.Identity.Data;
using LibraryAPI.Data;
using LibraryAPI.Services;
using LibraryAPI.Data.BookData;

namespace LibraryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var authConnectionString = builder.Configuration.GetConnectionString("AuthContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthContextConnection' not found.");
            var bookConnectionString = builder.Configuration.GetConnectionString("BookDataContextConnection") ?? throw new InvalidOperationException("Connection string 'BookContextConnection' not found.");
            builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(authConnectionString));
            builder.Services.AddDbContext<BookDataContext>(options => options.UseSqlServer(bookConnectionString));

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuthContext>();


            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<BookService>();
            builder.Services.AddScoped<ReservationService>();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
