
using Syncfusion.Licensing;

var builder = WebApplication.CreateBuilder(args);
SyncfusionLicenseProvider.RegisterLicense(builder.Configuration.GetConnectionString("SLicence"));
builder.Host.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(7051);
    });
});
// Add services to the container.
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddServerServices()
                .AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<SignInMiddleware<User>>();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
