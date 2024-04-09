using PIS.Memory;
using PIS.Interface;
using WebKurs;
using PIS.Service;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using PIS.Models;
using PIS.Memory.PIS.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ITourRepository, TourRepository>();
builder.Services.AddSingleton<ICityRepository, CityRepository>();
builder.Services.AddSingleton<IAttractionRepository, AttractionRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IAuthenticationService,AuthenticationService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ISessionService, SessionService>();
builder.Services.AddSingleton<ITourService, TourService>();
builder.Services.AddSingleton<IAttractionService, AttractionService>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<ICityService, CityService>();
builder.Services.AddSingleton<ISearchService, SearchService>();
builder.Services.AddSingleton<IReviewRepository, ReviewRepository>();
builder.Services.AddSingleton<IReviewService, ReviewService>();
builder.Services.AddSingleton<IAdminService, AdminService>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IEmailRepository, EmailRepository>();
builder.Services.AddSingleton<IMailingService, MailingService>();
builder.Services.AddSingleton<IMailingRepository, MailingRepository>();
builder.Services.AddSingleton<IChatService, ChatService>();
builder.Services.AddSingleton<IMessageRepository, MessageRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<SessionService>();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Ensure session cookie is accessible only via HTTP
    options.Cookie.IsEssential = true; // Indicate if the session cookie is essential for the application
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

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
