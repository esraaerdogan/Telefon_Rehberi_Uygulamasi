using System.ComponentModel.DataAnnotations;

namespace TelRehAPI.Models.DTO
{
  public class LoginRequestDto
  {
    // Kullanıcının e-posta adresi
    [Required(ErrorMessage = "Email alanı zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    public string Email { get; set; }

    // Kullanıcının şifresi
    [Required(ErrorMessage = "Şifre alanı zorunludur.")]
    public string Password { get; set; }
  }
}
