using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabaSatis.Models
{
    public class Ilanlar
    {
        [Key]
        public int IlanId { get; set; }
        public string IlanAdi { get; set; } = string.Empty;
        public int ? Yil { get; set; }
        public string AracDurumu { get; set; } = string.Empty;
        public int ? Kilometre { get; set; }
        [ForeignKey("YakitId")]
        public int ? YakitId { get; set; }
        public Yakit? Yakit { get; set; }

        [ForeignKey("MarkaId")]
        public int ? MarkaId { get; set; }
        public Markalar? Markalar { get; set; }
        public ICollection<ArabaResim> ArabaResimler { get; set; } = new List<ArabaResim>();    
    }
}
