using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabaSatis.Models
{
    public class ArabaResim
    {
        [Key]
        public int ArabaResimId { get; set; }
        public int ? ilanId { get; set; }
        public string ? Resim { get; set; }
        [NotMapped]
        public IFormFile Picture { get; set; }
    }
}
