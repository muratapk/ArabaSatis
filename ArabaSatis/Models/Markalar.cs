using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArabaSatis.Models
{
    public class Markalar
    {
        [Key]
        public int MarkaId { get; set; }
        [Required (ErrorMessage ="Marka Adını Girin:")]
        [DisplayName("Marka Adı")]
        public string MarkaAd { get; set; }
        public virtual ICollection<SeriModel>? SeriModels { get; set; }  
        public virtual ICollection<Ilanlar>? Ilanlars { get; set; }
    }
}
