using PetCare_Web.Data; // Để dùng PetCareContext
using Microsoft.EntityFrameworkCore; // Để dùng lệnh SQL

var builder = WebApplication.CreateBuilder(args);

// 1. Thêm dịch vụ Controller + View
builder.Services.AddControllersWithViews();

// 2. Đăng ký kết nối SQL Server (Lấy từ appsettings.json)
builder.Services.AddDbContext<PetCareContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetCareDB")));

// 3. Đăng ký Session (Để lưu trạng thái đăng nhập)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // 30 phút tự out
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Cấu hình môi trường
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 4. Kích hoạt Session (Phải đặt trước Authorization)
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();