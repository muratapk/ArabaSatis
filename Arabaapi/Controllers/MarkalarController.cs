using Arabaapi.Data;
using Arabaapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arabaapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkalarController : ControllerBase
    {
        private readonly AppDataDbContext _context;

        public MarkalarController(AppDataDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var markalar = _context.Markalars.ToList();
            if (markalar == null || !markalar.Any())
            {
                return NotFound("Marka bulunamadı.");
            }
            return Ok(markalar);
        }
        [HttpPost]
        public IActionResult Post(Markalar gelen)
        {
            if (gelen == null)
            {
                return BadRequest("Geçersiz marka verisi.");
            }
            _context.Markalars.Add(gelen);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = gelen.MarkaId }, gelen);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var marka = _context.Markalars.Find(id);
            if (marka == null)
            {
                return NotFound("Silinecek marka bulunamadı.");
            }
            _context.Markalars.Remove(marka);
            _context.SaveChanges();
            return Ok("Marka başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult Update(Markalar gelen)
        {
            var result = _context.Markalars.Find(gelen.MarkaId);
            if (result == null)
            {
                return NotFound("Güncellenecek marka bulunamadı.");
            }
            result.MarkaAd = gelen.MarkaAd;
            _context.Update(result);
            _context.SaveChanges();
            return Ok("Marka başarıyla güncellendi.");
        }
    }  
}
