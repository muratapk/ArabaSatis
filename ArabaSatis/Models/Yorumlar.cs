namespace ArabaSatis.Models
{
    public class Yorumlar
    {
        [Key]
        public int YorumId { get; set; }
        public int? ilanId { get; set; }
        public string? AdSoyad {  get; set; }  
        public string Yorum { get; set; }

    }
}
