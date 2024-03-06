using Microsoft.EntityFrameworkCore;
using CreatorsPlatform.Data;

//使用Session資料方法:
//設置Session:HttpContext.Session.SetInt32/SetString/......(名稱, 內容);
//取得Session:HttpContext.Session.GetInt32/GetString/......(名稱, 內容);

var builder = WebApplication.CreateBuilder(args);
#region
//////////依賴注入開始

builder.Services.AddHttpContextAccessor();
// 註冊DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("CSLocalDB")
    ));

// 註冊MVC服務
builder.Services.AddControllersWithViews();

// 註冊Session服務
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.Name = "DefaultName";
    options.Cookie.Path = "/";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//////////依賴注入結束
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}





// 使用靜態資源中間件
app.UseStaticFiles();

// 使用Session中間件
app.UseSession();

// 使用路由中間件
app.UseRouting();

// 使用授權中間件
app.UseAuthentication();
app.UseAuthorization();

// 建立名稱default的單一路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HotGuy}/{action=EX2_1}/{id?}"
    );

app.Run();

