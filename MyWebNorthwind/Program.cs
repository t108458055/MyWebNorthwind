//建立IHost   //2022->webisbuilder

var builder = WebApplication.CreateBuilder(args);
// 加入 DbContext 服務
builder.Services.AddDbContext<NorDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("northwind"));
});
// Add services to the container.
//加入Cors策略(後面middleware 要使用
builder.Services.AddCors(options =>
{   //Lambda
    options.AddPolicy("allsites", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod();
    });
});
builder.Services.AddControllersWithViews(); //加入控制器(Controller)與顯示(View)
//綁定
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();//強制加密連線
app.UseStaticFiles();
// 使用Route
app.UseRouting(); 
//使用Cors Policy
app.UseCors("allsites"); //policy name  客製化(前面設定的)
app.UseAuthentication(); //認證
app.UseAuthorization(); //授權
//地圖控制器敘述
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//開始
app.Run();
