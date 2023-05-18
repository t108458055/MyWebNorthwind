//建立IHost   //2022->webisbuilder
using MyWebNorthwind.Repositories;
using Serilog;
// ## 設定 Serilog 組態 載體至Hosting
Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Information() // Serilog要寫入的最低等級是Information
                        .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)    // Microsoft.AspNetCore開頭的類別等級為warning
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        //   .WriteTo.Seq("http://localhost:5341/") // 線上使用紀錄
                        .CreateLogger();
try
{
    // ## 專案網站架設部屬
    Log.Information("Starting Web Host");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog(); // Serilog 咬住 Host 
    // 加入 DbContext 服務
    builder.Services.AddDbContext<NorDBContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("northwind"));
    });
    // Add services to the container.
    //加入自定義的類別(Class)變成一個服務物件 並使用Singleton()單例模式物件 相依性插入 ref:https://learn.microsoft.com/zh-tw/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
    builder.Services.AddSingleton<DbServiceUtility>(); // 單例模式物件
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddScoped<CustomersRepository<Customers>>();
    builder.Services.AddSession(options =>
    {
        // After deployment of ASP.NET Core 2.2 application to IIS sessions using HttpContext.Session aren't working - Stack Overflow
        // https://stackoverflow.com/questions/54578613/after-deployment-of-asp-net-core-2-2-application-to-iis-sessions-using-httpconte
        options.IdleTimeout = TimeSpan.FromMinutes(15);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;

    }); // /加入Session 狀態服務 (配合瀏覽器進來第一個端點,後端準備到一個 ISession物件給你,同時送出前端Cookie(SessionID))
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
    app.UseSerilogRequestLogging(); //讓每一個Request  都使用Serilog記錄下來
    app.UseStaticFiles();
    // 使用Route
    app.UseRouting();
    //使用Cors Policy
    app.UseCors("allsites"); //policy name  客製化(前面設定的)
    app.UseAuthentication(); //認證
    app.UseAuthorization(); //授權
    app.UseSession(); //加入 Session
                      //地圖控制器敘述
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    //開始
    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host Terminated unexpectedly!!");
    return 1;
}
finally 
{
    Log.CloseAndFlush();
}
