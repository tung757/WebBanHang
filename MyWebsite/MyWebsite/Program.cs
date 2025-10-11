
using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Implements;
using MyWebsite.Repositories.Interfaces;
using MyWebsite.Services.Implements;
using MyWebsite.Services.Interfaces;

namespace MyWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IDanhMucRepository, DanhMucRepository>();
            builder.Services.AddScoped<IDanhMucService, DanhMucService>();
            builder.Services.AddScoped<IDonHangRepository,DonHangRepository>();
            builder.Services.AddScoped<IDonHangItemRepository,DonHangItemRepository>();
            builder.Services.AddScoped<IGiamGiaRepository,GiamGiaRepository>();
            builder.Services.AddScoped<IGioHangItemRepository ,GioHangItemRepository>();
            builder.Services.AddScoped<IHinhAnhRepository, HinhAnhRepository>();
            builder.Services.AddScoped<IKhachHangRepository, KhachHangRepository>();
            builder.Services.AddScoped<ILichSuRepository, LichSuRepository>();
            builder.Services.AddScoped<IDanhGiaRepository, DanhGiaRepository>();
            builder.Services.AddScoped<IGioHangRepository, GioHangRepository>();





            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();


            app.MapControllers();

            app.Run();
        }
    }
}
