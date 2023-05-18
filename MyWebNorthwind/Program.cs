//�إ�IHost   //2022->webisbuilder

using MyWebNorthwind.Repositories;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);
// �[�J DbContext �A��
builder.Services.AddDbContext<NorDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("northwind"));
});
// Add services to the container.
//�[�J�۩w�q�����O(Class)�ܦ��@�ӪA�Ȫ��� �èϥ�Singleton()��ҼҦ����� �̩ۨʴ��J ref:https://learn.microsoft.com/zh-tw/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
builder.Services.AddSingleton<DbServiceUtility>(); // ��ҼҦ�����
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<CustomersRepository<Customers>>();
builder.Services.AddSession( options => {    
    // After deployment of ASP.NET Core 2.2 application to IIS sessions using HttpContext.Session aren't working - Stack Overflow
   // https://stackoverflow.com/questions/54578613/after-deployment-of-asp-net-core-2-2-application-to-iis-sessions-using-httpconte
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

}); // /�[�JSession ���A�A�� (�t�X�s�����i�ӲĤ@�Ӻ��I,��ݷǳƨ�@�� ISession���󵹧A,�P�ɰe�X�e��Cookie(SessionID))
//�[�JCors����(�᭱middleware �n�ϥ�
builder.Services.AddCors(options =>
{   //Lambda
    options.AddPolicy("allsites", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod();
    });
});
builder.Services.AddControllersWithViews(); //�[�J���(Controller)�P���(View)
//�j�w
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();//�j��[�K�s�u
app.UseStaticFiles();
// �ϥ�Route
app.UseRouting();
//�ϥ�Cors Policy
app.UseCors("allsites"); //policy name  �Ȼs��(�e���]�w��)
app.UseAuthentication(); //�{��
app.UseAuthorization(); //���v
app.UseSession(); //�[�J Session
//�a�ϱ���ԭz
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//�}�l
app.Run();
