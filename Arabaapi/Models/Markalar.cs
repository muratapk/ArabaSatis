using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Arabaapi.Models
{
    public class Markalar
    {
        [Key]
        public int  MarkaId { get; set; }
        [Required(ErrorMessage = "Marka Adını Girin:")]
        [DisplayName("Marka Adı")]
        public string  MarkaAd { get; set; } = string.Empty;
    }
}
