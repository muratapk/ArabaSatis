using ArabaSatis.Dto;
using ArabaSatis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

namespace ArabaSatis.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: Register
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        // POST: Register
        [HttpPost]
        public async Task<IActionResult> Index(AppUserDtoRegister appUserDto)
        {
            // Burada kullanıcı kaydı işlemleri yapılabilir.
            // Örneğin, veritabanına kaydetme işlemi.

            // Başarılı bir kayıt sonrası yönlendirme
            Random random = new Random();
            int confirmCode = random.Next(100000, 999999); // 6 haneli rastgele bir kod oluşturma
            // Kullanıcı bilgilerini ve onay kodunu veritabanına kaydetme işlemi burada yapılabilir.
            AppUser newUser = new AppUser
            {
                FirstName = appUserDto.FirstName,
                LastName = appUserDto.LastName,
                Email = appUserDto.Email,
                UserName = appUserDto.UserName,
                City = appUserDto.City,
                ConfirmCode = confirmCode // Onay kodunu atama
            };

            var result=await _userManager.CreateAsync(newUser, appUserDto.Password);
            if (result.Succeeded)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailBoxAdressFrom=new MailboxAddress("Araba Kiralama","kurs.aribilgi@gmail.com");
                MailboxAddress mailBoxAdressTo = new MailboxAddress(appUserDto.FirstName + " " + appUserDto.LastName, appUserDto.Email);
                mimeMessage.From.Add(mailBoxAdressFrom);
                mimeMessage.To.Add(mailBoxAdressTo);
                mimeMessage.Subject = "Araba Kiralama Onay Kodu"+confirmCode;
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = $"Merhaba {appUserDto.FirstName} {appUserDto.LastName},\n\n" +
                                       $"Araba kiralama işleminiz için onay kodunuz: {confirmCode}\n\n" +
                                       "Lütfen bu kodu kullanarak işleminizi tamamlayın.\n\n" +
                                       "Teşekkürler,\nAraba Kiralama Ekibi";
                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("kurs.aribilgi@gmail.com", "uyqj aysq cs2z kv25 2jjk kjsj laqb ynm4");
                client.Send(mimeMessage);
                client.Disconnect(true);
                TempData["Mail"] = appUserDto.Email;
                return RedirectToAction("Index", "ConfirmMail");
              
            }
            else
            {
                return View("Index");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
