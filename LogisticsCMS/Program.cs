using AutoMapper;
using Microsoft.Extensions.Options;
using LogisticsCMS.Mapping;
using LogisticsCMS.Services;
using LogisticsCMS.Services.AboutService;
using LogisticsCMS.Services.BrandService;
using LogisticsCMS.Services.GetInTouchSectionService;
using LogisticsCMS.Services.HowItWorkService;
using LogisticsCMS.Services.OfferService;
using LogisticsCMS.Services.ProjectSectionService;
using LogisticsCMS.Services.QuestionService;
using LogisticsCMS.Services.ShipmentService;
using LogisticsCMS.Services.ShipmentTrackingService;
using LogisticsCMS.Services.SliderService;
using LogisticsCMS.Services.TestimonialService;
using LogisticsCMS.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<GeneralMapping>()); // AutoMapper'Ä± kullanmak iÃ§in GeneralMapping profilini ekliyoruz

builder.Services.AddScoped<ISliderService, SliderService>(); // ISliderService'yi SliderService olarak kaydediyoruz

builder.Services.AddScoped<IBrandService, BrandService>(); // IBrandService'yi BrandService olarak kaydediyoruz

builder.Services.AddScoped<IOfferService, OfferService>(); // IOfferService'yi OfferService olarak kaydediyoruz

builder.Services.AddScoped<IAboutService, AboutService>(); // IAboutService'yi AboutService olarak kaydediyoruz

builder.Services.AddScoped<IGetInTouchSectionService, GetInTouchSectionService>(); // IGetInTouchSectionService'yi GetInTouchSectionService olarak kaydediyoruz

builder.Services.AddScoped<IHowItWorkService, HowItWorkService>(); // IHowItWorkService'yi HowItWorkService olarak kaydediyoruz

builder.Services.AddScoped<ITestimonialService, TestimonialService>(); // ITestimonialService'yi TestimonialService olarak kaydediyoruz

builder.Services.AddScoped<IProjectSectionService, ProjectSectionService>(); // IProjectSectionService'yi ProjectSectionService olarak kaydediyoruz

builder.Services.AddScoped<IQuestionService, QuestionService>(); // IQuestionService'yi QuestionService olarak kaydediyoruz

builder.Services.AddScoped<IShipmentService, ShipmentService>(); // IShipmentService'yi ShipmentService olarak kaydediyoruz

builder.Services.AddScoped<IShipmentTrackingService, ShipmentTrackingService>(); // IShipmentTrackingService'yi ShipmentTrackingService olarak kaydediyoruz

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); // DatabaseSettings'i appsettings.json'dan alarak yapÄ±landÄ±rÄ±yoruz

builder.Services.AddScoped<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value
); // IDatabaseSettings'i DatabaseSettings olarak kaydediyoruz

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

