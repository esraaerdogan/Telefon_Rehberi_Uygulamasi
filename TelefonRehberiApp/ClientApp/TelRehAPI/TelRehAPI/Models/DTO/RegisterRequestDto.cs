using System.ComponentModel.DataAnnotations;

namespace TelRehAPI.Models.DTO
{
  public class RegisterRequestDto
  {
    [Required(ErrorMessage = "Email alanı zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre alanı zorunludur.")]
    [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
    public string Password { get; set; }

    [MaxLength(50, ErrorMessage = "Ad 50 karakterden fazla olamaz.")]
    public string? FirstName { get; set; }

    [MaxLength(50, ErrorMessage = "Soyad 50 karakterden fazla olamaz.")]
    public string? LastName { get; set; }
  }
}
