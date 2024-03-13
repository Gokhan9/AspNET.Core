using System.ComponentModel.DataAnnotations;

namespace MeetingApps.Models
{
    public class UserInfo
    {  
        public int Id { get; set; }

        [Required(ErrorMessage ="Ad Alanı Zorunlu!")]
        public string? Name { get; set; } //null değer gelmesi gerekiyor ki "Required" Metodu hatayı gönderebilsin.
        
        [Required(ErrorMessage ="Telefon Alanı Zorunlu!")]
        public string? Phone { get; set; }
        
        [Required(ErrorMessage ="E-Mail Alanı Zorunlu!")]
        [EmailAddress(ErrorMessage ="Hatalı E-Mail Girişi!")]     
        public string? EMail { get; set; }
        
        [Required(ErrorMessage ="Katılım Durumunuzu Belirtiniz.")]
        public bool? WillAttend { get; set; }
    }
}