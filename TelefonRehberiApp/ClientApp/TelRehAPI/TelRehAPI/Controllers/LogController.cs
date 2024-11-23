using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TelRehAPI.Data;
using TelRehAPI.Services;

namespace TelRehAPI.Controllers{

  [Route("api/[controller]")]
  [ApiController]
  public class LogController : ControllerBase{

    private readonly TelDbContext _context;
    private readonly ILoggingService _loggingService;

    public LogController(TelDbContext context, ILoggingService loggingService){
      _context = context;
      _loggingService = loggingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLogs(){

      try{
        var logs = await _context.LogEntries.ToListAsync();
        return Ok(logs);
      }
      catch (Exception ex){
        // Hata durumunda logging servisi ile hata kaydı oluştur
        await _loggingService.LogErrorAsync("Günlükler alınırken bir hata oluştu.", ex);
        return StatusCode(500, "Günlükler alınırken bir hata oluştu.");
      }
    }
  }
}
