using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;

var builder = WebApplication.CreateBuilder(args);

// Înregistrăm contextul pentru aplicație
builder.Services.AddDbContext<CinemaAplicatieWEBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaAplicatieWEBContext") ?? throw new InvalidOperationException("Connection string 'CinemaAplicatieWEBContext' not found.")));

// Înregistrăm contextul pentru Identity
builder.Services.AddDbContext<CinemaIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaAplicatieWEBContext") ?? throw new InvalidOperationException("Connection string 'CinemaAplicatieWEBContext' not found.")));

// Configurăm Identity
builder.Services.AddDefaultIdentity<Microsoft.AspNetCore.Identity.IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CinemaIdentityContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Activăm autentificarea și autorizarea
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
