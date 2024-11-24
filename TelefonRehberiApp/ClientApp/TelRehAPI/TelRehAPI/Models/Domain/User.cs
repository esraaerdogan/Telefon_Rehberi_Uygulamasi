using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TelRehAPI.Models.Domain
{
  [Index(nameof(Email), IsUnique = true)] // Email alanı benzersiz
  public class User
  {
    public Guid Id { get; set; } 
    [Required(ErrorMessage = "Email alanı zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    public string Email { get; set; }

    // Şifre hash'lenmiş olarak saklanacak
    [Required(ErrorMessage = "Şifre alanı zorunludur.")]
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public User()
    {
      Id = Guid.NewGuid();
      CreatedAt = DateTime.UtcNow;
      UpdatedAt = DateTime.UtcNow;
      IsActive = true;
    }
  }
}
