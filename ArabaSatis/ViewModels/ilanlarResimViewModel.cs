using ArabaSatis.Models;

namespace ArabaSatis.ViewModels
{
    public class ilanlarResimViewModel
    {
        public int IlanId { get; set; }
        public string IlanAdi { get; set; } = string.Empty;
        public int? Yil { get; set; }
        public string AracDurumu { get; set; } = string.Empty;
        public int? Kilometre { get; set; }
        public int? YakitId { get; set; }
        public int? MarkaId { get; set; }
        public List<ArabaResim> Resimler { get; set; } = new List<ArabaResim>();
    }
}
