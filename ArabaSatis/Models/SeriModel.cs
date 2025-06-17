using System.ComponentModel.DataAnnotations;

namespace ArabaSatis.Models
{
    public class SeriModel
    {
        [Key]
        public int SeriId { get; set; }
        public string SeriAdi { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int? MarkaId { get; set; }
        public Markalar ? Markalars { get; set; }
    }
}
