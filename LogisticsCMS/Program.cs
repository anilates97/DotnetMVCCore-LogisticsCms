using AutoMapper;
using LogisticsCMS.Mapping;
using LogisticsCMS.Services;
using LogisticsCMS.Services.About;
using LogisticsCMS.Services.Brand;
using LogisticsCMS.Services.GetInTouchSection;
using LogisticsCMS.Services.HowItWork;
using LogisticsCMS.Services.Offer;
using LogisticsCMS.Services.ProjectSection;
using LogisticsCMS.Services.Question;
using LogisticsCMS.Services.Security;
using LogisticsCMS.Services.Shipment;
using LogisticsCMS.Services.ShipmentTracking;
using LogisticsCMS.Services.Slider;
using LogisticsCMS.Services.Testimonial;
using LogisticsCMS.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<GeneralMapping>());
builder.Services.AddProblemDetails();
builder
    .Services.AddOptions<AuthSettings>()
    .Bind(builder.Configuration.GetSection("AuthSettings"))
    .ValidateDataAnnotations()
    .Validate(
        settings => !string.IsNullOrWhiteSpace(settings.PasswordHash),
        "AuthSettings:PasswordHash must be provided via user-secrets or environment variables."
    )
    .ValidateOnStart();
builder
    .Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Home/Error/403";
        options.Cookie.Name = "LogisticsCMS.AdminAuth";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields =
        HttpLoggingFields.RequestMethod
        | HttpLoggingFields.RequestPath
        | HttpLoggingFields.ResponseStatusCode
        | HttpLoggingFields.Duration;
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddEventSourceLogger();

builder.Services.AddSingleton<IAdminPasswordHasher, AdminPasswordHasher>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IGetInTouchSectionService, GetInTouchSectionService>();
builder.Services.AddScoped<IHowItWorkService, HowItWorkService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IProjectSectionService, ProjectSectionService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<IShipmentTrackingService, ShipmentTrackingService>();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<DatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value
);

builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(
    sp.GetRequiredService<DatabaseSettings>().ConnectionString
));
builder.Services.AddScoped<IMongoDbContext, MongoDbContext>();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation(
    "Application starting in {Environment} environment at {TimeUtc}",
    app.Environment.EnvironmentName,
    DateTime.UtcNow
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(name: "default", pattern: "{controller=Default}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Lifetime.ApplicationStopping.Register(() =>
{
    logger.LogInformation("Application stopping at {TimeUtc}", DateTime.UtcNow);
});

app.Run();
