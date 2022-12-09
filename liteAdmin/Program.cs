using BusinessLogic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));


builder.Services.AddScoped<IAssociation,Associationrepo>();
builder.Services.AddScoped<IParticipants,Participantsrepo>();
builder.Services.AddScoped<IParticipantType,ParticipantTypeRepo>();
builder.Services.AddScoped<IAdaptor,AdaptorRepo>();
builder.Services.AddScoped<IAdaptorType,AdaptorTypeRepo>();
builder.Services.AddScoped<ITransactionCodes,TransactionCodesRepo>();
builder.Services.AddScoped<ITransactionCodeMapping,TransactionCodeMappingRepo>();
builder.Services.AddScoped<IUserRoles,UserRolesRepo>();
builder.Services.AddScoped<ITransactionFields,TransactionFieldsRepo>();
builder.Services.AddScoped<ITransactionIdentifier,TransactionIdentifierRepo>();
builder.Services.AddScoped<ITransactionRoutings,TransactionRoutingsRepo>();
builder.Services.AddScoped<ITransactionRouter,TransactionRouterRepo>();
builder.Services.AddScoped<ISafConfiguration,SafConfigurationRepo>();
builder.Services.AddScoped<ISafLog,SafLogRepo>();
builder.Services.AddScoped<IRuntimeFieldsCustomization,RuntimeFieldsCustomizationRepo>();
builder.Services.AddScoped<Iusers,UsersRepo>();
builder.Services.AddScoped<IEncodingType,EncodingTypeRepo>();
builder.Services.AddScoped<IInternalFields,InternalFieldsRepo>();
builder.Services.AddScoped<IGeneralConfigurations,GeneralConfigurationsRepo>();
builder.Services.AddScoped<IMessageFormatconfiguration,MessageFormatconfigurationRepo>();
builder.Services.AddScoped<IModules,ModulesRepo>();
builder.Services.AddScoped<IApplicationPages,ApplicationPagesRepo>();
builder.Services.AddScoped<IPageAction,PageActionRepo>();
builder.Services.AddScoped<IResponseCodeMapping,ResponseCodeMappingRepo>();
builder.Services.AddScoped<IResponseCodes,ResponseCodesRepo>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(60 * 1);
    option.LoginPath = "/Home/index";
    option.AccessDeniedPath = "/Login/index";
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);//You can set Time
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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
app.UseSession();
app.UseAuthorization();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=loginView}/{id?}");

app.Run();
