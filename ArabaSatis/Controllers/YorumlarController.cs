using ArabaSatis.Data;
using ArabaSatis.Models;
using Microsoft.AspNetCore.Mvc;


namespace ArabaSatis.Controllers
{
    public class YorumlarController : Controller
    {
        private readonly ArabamDbContext _context;

        public YorumlarController(ArabamDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var veri = _context.Yorumlars.ToList();
            return View(veri);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Yorumlar gelen)
        {
            if(ModelState.IsValid)
            {
                _context.Yorumlars.Add(gelen);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //var veri = _context.Yorumlars.Find(id);
            var veri = _context.Yorumlars.Where(x => x.YorumId == id).FirstOrDefault();
            return View(veri);
        }
        [HttpPost]
        public IActionResult Edit(Yorumlar gelen)
        {
            if(ModelState.IsValid)
            {
                _context.Yorumlars.Update(gelen);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
         
        }
        [HttpPost]
        public IActionResult Delete(Yorumlar gelen)
        {
            _context.Yorumlars.Remove(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //var veri = _context.Yorumlars.Find(id);
            var veri = _context.Yorumlars.Where(x => x.YorumId == id).FirstOrDefault();
            return View(veri);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            //var veri= _context.Yorumlars.Find(id);
            var veri = _context.Yorumlars.Where(x => x.YorumId == id).FirstOrDefault();
            return View();
        }
    }
}
