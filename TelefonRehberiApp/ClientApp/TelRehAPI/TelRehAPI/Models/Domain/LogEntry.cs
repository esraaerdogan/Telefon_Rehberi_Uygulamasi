namespace TelRehAPI.Models.Domain
{
  public class LogEntry
  {

    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    public string LogLevel { get; set; }
    public string Logger { get; set; }
    public string Message { get; set; }
    public string? Exception { get; set; }  // Nullable yapıldı


  }
}
