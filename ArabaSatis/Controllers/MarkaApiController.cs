using ArabaSatis.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ArabaSatis.Controllers
{
    public class MarkaApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7221/api/Markalar");
        private readonly HttpClient _httpClient;
        public MarkaApiController()
        {
            _httpClient = new HttpClient { BaseAddress = baseAddress };
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Markalar> markalars = new List<Markalar>();
            HttpResponseMessage response = _httpClient.GetAsync("Markalar").Result;
            if (response.IsSuccessStatusCode)
            {
               string jsonData = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(jsonData))
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    markalars = System.Text.Json.JsonSerializer.Deserialize<List<Markalar>>(jsonData, options);



                    return View(markalars);

                }
                else
                {
                    ViewBag.ErrorMessage = "Marka verisi boş.";
                }

            }
            else
            {
                ViewBag.ErrorMessage = "Markalar alınırken bir hata oluştu.";
            }


            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Markalar marka)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = _httpClient.PostAsJsonAsync("Markalar", marka).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Marka eklenirken bir hata oluştu.";
                }
            }
            return View(marka);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync($"Markalar/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Marka silinirken bir hata oluştu.";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Markalar markalar = new Markalar();
                HttpResponseMessage response = _httpClient.GetAsync($"Markalar/{id}").Result;
                if(response.IsSuccessStatusCode)
                {
                    string jsonData = response.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        markalar = System.Text.Json.JsonSerializer.Deserialize<Markalar>(jsonData);
                        return View(markalar);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Marka verisi boş.";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Marka bulunamadı.";
                }

            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "Marka bulunamadı: " + ex.Message;
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Markalar marka)
        {
            return View();
        }
    }
}
