using Microsoft.EntityFrameworkCore;
using CreatorsPlatform.Data;
using CreatorsPlatform.Controllers;

//使用Session資料方法:
//設置Session:HttpContext.Session.SetInt32/SetString/......(名稱, 內容);
//取得Session:HttpContext.Session.GetInt32/GetString/......(名稱, 內容);

var builder = WebApplication.CreateBuilder(args);
#region

builder.Services.AddScoped < MemberDatabase, MemberDatabase > ();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ImaginkDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("CSLocalDB")
    ));

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.Name = "DefaultName";
    options.Cookie.Path = "/";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=yhu}/{action=IMAGINK}/{id?}"
    );

app.Run();

