using Microsoft.EntityFrameworkCore;
using ProjectGenesis.Data;
using Microsoft.AspNetCore.Identity;
using ProjectGenesis.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectGenesisDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectGenesisDb")));

//builder.Services.AddDbContext<ProjectGenesisIdentityContext>();
builder.Services.AddDbContext<ProjectGenesisIdentityContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectGenesisIdentityContextConnection")));
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//                .AddEntityFrameworkStores<ProjectGenesisIdentityContext>()
//                .AddDefaultTokenProviders();

builder.Services.AddDefaultIdentity<ProjectGenesisUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ProjectGenesisIdentityContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
