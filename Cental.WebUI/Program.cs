using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.BusinessLayer.Validators;
using Cental.BusinessLayer.Validators.BrandValidator;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrate;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//about service g�rd���n zaman aboutmanager s�n�f�ndan bir nesne �rne�i al ve i�lemi onunla yap 
builder.Services.AddDbContext<CentalContext>();

//Identity Konfig�rasyonu ba�lang��

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequiredLength = 8;//Minimum �ifre uzunlu�u en az 8 karakterden olu�mal�d�r!
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<CentalContext>()
  .AddErrorDescriber<CustomErrorDescriber>();

//Identity Konfig�rasyonu biti�


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<IBannerDal, EfBannerDal>();
builder.Services.AddScoped<IBannerService, BannerManager>();

builder.Services.AddScoped<IBrandDal, EfBrandDal>();
builder.Services.AddScoped<IBrandService, BrandManager>();

builder.Services.AddScoped<ICarDal, EfCarDal>();
builder.Services.AddScoped<ICarService, CarManager>();

builder.Services.AddScoped<IUserSocialDal, EfUserSocialDal>();
builder.Services.AddScoped<IUserSocialService, UserSocialManager>();

builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));



builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssemblyContaining<CreateBrandValidator>();



builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(new AuthorizeFilter());
});




builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Login/SignIn";
    cfg.LogoutPath = "/Login/Logout";
    cfg.AccessDeniedPath = "/ErrorPage/AccessDenied";
});


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
app.UseStatusCodePagesWithReExecute("/ErrorPage/NotFound404");

app.UseRouting();


app.UseAuthentication(); //sistemde kay�tl� m� de�il mi ? 
app.UseAuthorization();  //sistemde kay�tl�ysa yetkisi var m� ?

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
