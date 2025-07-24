using System.ComponentModel.DataAnnotations;

namespace Arabaapi.Models
{
    public class LoginModel
    {
        [Key]
        public int LoginModelId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;
    }
}
