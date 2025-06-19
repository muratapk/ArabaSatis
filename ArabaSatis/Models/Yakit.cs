using System.ComponentModel.DataAnnotations;

namespace ArabaSatis.Models
{
    public class Yakit
    {
        [Key]
        public int YakitId { get; set; }
        public string YakitAdi { get; set; } = string.Empty;
        public virtual ICollection<Ilanlar>? Ilanlar { get; set; } 
        
    }
}
