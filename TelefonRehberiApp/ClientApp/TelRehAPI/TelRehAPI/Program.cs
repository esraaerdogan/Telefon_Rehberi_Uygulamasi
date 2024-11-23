using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using AutoMapper;
using TelRehAPI.Data;
using TelRehAPI.Repositories.Implementation;
using TelRehAPI.Repositories.Interface;
using TelRehAPI.Services;

// NLog yapılandırması
var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

try
{
  Console.WriteLine("Uygulama başlatılıyor...");

  var builder = WebApplication.CreateBuilder(args);

  // NLog'u DI container'a ekle
  builder.Logging.ClearProviders();
  builder.Host.UseNLog();

  // Servisleri yapılandır
  builder.Services.AddScoped<ILoggingService, LoggingService>();
  builder.Services.AddScoped<IPersonRepository, PersonRepository>();
  builder.Services.AddControllers();
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();

  // **AutoMapper yapılandırması**
  builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

  // Veritabanı yapılandırması
  builder.Services.AddDbContext<TelDbContext>(options =>
  {
    options.UseSqlServer(builder.Configuration.GetConnectionString("TelAPIConnectionString"));
  });

  var app = builder.Build();

  // Ortam kontrolü ve Middleware yapılandırma
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }

  app.UseHttpsRedirection();

  app.UseCors(options =>
  {
    options.WithOrigins("http://localhost:4200"); // Angular uygulamasının URL'si
    options.AllowAnyMethod();
    options.AllowAnyHeader();
  });

  app.UseAuthorization();

  app.MapControllers();

  app.Run();
}
catch (Exception ex)
{
  // Hataları logla
  logger.Error(ex, "Uygulama başlatılamadı.");
  throw;
}
finally
{
  LogManager.Shutdown(); // NLog kaynaklarını serbest bırak
}
