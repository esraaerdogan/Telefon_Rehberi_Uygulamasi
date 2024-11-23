using TelRehAPI.Data;
using TelRehAPI.Models.Domain;
using System;
using System.Threading.Tasks;

namespace TelRehAPI.Services{
  public interface ILoggingService{
    Task LogAsync(string logLevel, string logger, string message, string exception = null);
    Task LogInfoAsync(string message);
    Task LogWarningAsync(string message);
    Task LogErrorAsync(string message, Exception ex);
  }

  public class LoggingService : ILoggingService{
    private readonly TelDbContext _context;
    public LoggingService(TelDbContext context){   _context = context;  }

    public async Task LogAsync(string logLevel, string logger, string message, string exception = null){
      var logEntry = new LogEntry{
        LogDate = DateTime.UtcNow,
        LogLevel = logLevel,
        Logger = logger,
        Message = message,
        Exception = exception
      };

      await _context.LogEntries.AddAsync(logEntry);
      await _context.SaveChangesAsync(); 
    }

    public async Task LogInfoAsync(string message){
      var logEntry = new LogEntry{
        LogDate = DateTime.UtcNow,
        LogLevel = "Info",
        Logger = "LoggingService",
        Message = message
      };

      await _context.LogEntries.AddAsync(logEntry);
      await _context.SaveChangesAsync();
    }

    public async Task LogWarningAsync(string message){
      var logEntry = new LogEntry{
        LogDate = DateTime.UtcNow,
        LogLevel = "Warning",
        Logger = "LoggingService",
        Message = message
      };

      await _context.LogEntries.AddAsync(logEntry);
      await _context.SaveChangesAsync();
    }

    public async Task LogErrorAsync(string message, Exception ex){
      var logEntry = new LogEntry{
        LogDate = DateTime.UtcNow,
        LogLevel = "Error",
        Logger = "LoggingService",
        Message = message,
        Exception = ex.ToString()
      };

      await _context.LogEntries.AddAsync(logEntry);
      await _context.SaveChangesAsync();
    }
  }
}
