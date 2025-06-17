using System.ComponentModel.DataAnnotations;

namespace ArabaSatis.Models
{
    public class ArabaResim
    {
        [Key]
        public int ArabaResimId { get; set; }
        public int ? ilanId { get; set; }
        public string ? Resim { get; set; }
    }
}
