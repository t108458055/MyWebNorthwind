//�إ�IHost   //2022->webisbuilder

var builder = WebApplication.CreateBuilder(args);
// �[�J DbContext �A��
builder.Services.AddDbContext<NorDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("northwind"));
});
// Add services to the container.
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
//�a�ϱ���ԭz
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//�}�l
app.Run();
