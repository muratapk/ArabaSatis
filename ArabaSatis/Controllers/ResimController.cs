using ArabaSatis.Data;
using ArabaSatis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace ArabaSatis.Controllers
{
    public class ResimController : Controller
    {
        private readonly ArabamDbContext _context;

        public ResimController(ArabamDbContext context)
        {
            _context = context;
        }

        // GET: ResimController
        public async Task<ActionResult> Index()
        {
            //var veri = _context.ArabaResim.ToList();
            //select * from ArabaResim
            var veri = await _context.ArabaResim.ToListAsync();

            return View(veri);
        }

        // GET: ResimController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResimController/Create
        public ActionResult Create()
        {
            ViewBag.ilanListe = new SelectList(_context.Ilanlars, "IlanId", "IlanAdi");
            return View();
        }

        // POST: ResimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArabaResim gelen,IFormFile Picture)
        {
            long resimboyut = 5 * 1024 * 1024;
            if(Picture!=null || Picture.Length>0)
            {
                var allowType = new[] { "image/jpeg", "image/png", "image/jpg", "image/gif" };
                if (!allowType.Contains(Picture.ContentType))
                {
                    return BadRequest("Hatalı Dosya Tipi jpg,gif,png,jpeg olacak");
                }
                if (Picture.Length > resimboyut)
                {
                    return BadRequest("5MB Büyük Olamaz");
                }


                var uzanti = Path.GetExtension(Picture.FileName).ToLower();
                string isim = Guid.NewGuid().ToString()+uzanti;
                string yol=Path.Combine(Directory.GetCurrentDirectory()+"/wwwroot/ArabaResim/"+isim);
                using(var stream=new FileStream(yol,FileMode.Create))
                {
                    Picture.CopyTo(stream);
                }
                gelen.Resim = isim;
            }




            try
            {
                
                _context.ArabaResim.Add(gelen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ilanListe = new SelectList(_context.Ilanlars, "IlanId", "IlanAdi");
                return View();
            }
        }

        // GET: ResimController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ilanListe = new SelectList(_context.Ilanlars, "IlanId", "IlanAdi");
            var bul = _context.ArabaResim.Find(id);
            return View(bul);
        }

        // POST: ResimController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArabaResim gelen,IFormFile Picture)
        {
            long resimboyut = 5 * 1024 * 1024;
            if (Picture != null || Picture.Length>0)
            {
                var allowType = new[] { "image/jpeg", "image/png", "image/jpg", "image/gif" };
                if(!allowType.Contains(Picture.ContentType))
                {
                    return BadRequest("Hatalı Dosya Tipi jpg,gif,png,jpeg olacak");
                }
                if(Picture.Length>resimboyut)
                {
                   return BadRequest("5MB Büyük Olamaz");
                }


                var uzanti = Path.GetExtension(Picture.FileName).ToLower();
                string isim = Guid.NewGuid().ToString() + uzanti;
                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/ArabaResim/" + isim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    Picture.CopyTo(stream);

                }
                gelen.Resim = isim;
            }



            try
            {
                _context.ArabaResim.Update(gelen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ilanListe = new SelectList(_context.Ilanlars, "IlanId", "IlanAdi");
                return View();
            }
        }

        // GET: ResimController/Delete/5
        public ActionResult Delete(int id)
        {
            var bul=_context.ArabaResim.Where(x=>x.ArabaResimId== id).FirstOrDefault();
            return View(bul);
        }

        // POST: ResimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ArabaResim gelen)
        {
            try
            {
                _context.ArabaResim.Remove(gelen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
