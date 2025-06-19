using System.ComponentModel.DataAnnotations;

namespace ArabaSatis.Models
{
    public class Yorumlar
    {
        [Key]
        public int YorumId { get; set; }
        [Display(Name ="İlan Numarası")]
        public int? ilanId { get; set; }
        [Required(ErrorMessage ="Ad Soyad Boş Bıraktılmaz")]
        [Display(Name ="Adı Soyadı")]
        public string? AdSoyad {  get; set; }
        [Display(Name ="Yorumlar")]
        [Required(ErrorMessage = "Yorum Alanı Boş Bıraktılmaz")]
        public string Yorum { get; set; }

    }
}
