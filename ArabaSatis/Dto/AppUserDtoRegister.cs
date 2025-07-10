namespace ArabaSatis.Dto
{
    public class AppUserDtoRegister
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
        public string  UserName { get; set; }
        public int? ConfirmCode { get; set; } // Nullable int for confirm code
    }
}
