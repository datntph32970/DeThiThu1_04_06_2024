using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class NhanVIenController : Controller
    {
        HttpClient client;
        public NhanVIenController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7168/");
        }
        public IActionResult GetBMI(double chieuCao, double canNang)
        {
            var response = client.GetAsync($"/NhanVien/BMI-NhanVien?chieuCao={chieuCao}&canNang={canNang}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return Ok(result);
            }
            return BadRequest();
        }
        public IActionResult Index()
        {
            var response = client.GetAsync("/NhanVien/GetAll").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var nhanViens = JsonConvert.DeserializeObject<IEnumerable<NhanVien>>(result);
                return View(nhanViens);
            }
            return BadRequest();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NhanVien nhanVien)
        {
            var json = JsonConvert.SerializeObject(nhanVien);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("/NhanVien/Create", data).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return Ok(result);
            }
            return BadRequest();
        }
        public IActionResult Edit(Guid id)
        {
            var response = client.GetAsync($"/NhanVien/GetById?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var nhanVien = JsonConvert.DeserializeObject<NhanVien>(result);
                return View(nhanVien);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Edit(NhanVien nhanVien)
        {
            var json = JsonConvert.SerializeObject(nhanVien);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync("/NhanVien/Update", data).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            var response = client.DeleteAsync($"/NhanVien/Delete?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        public IActionResult Details (Guid id)
        {
            var response = client.GetAsync($"/NhanVien/GetById?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var nhanVien = JsonConvert.DeserializeObject<NhanVien>(result);
                return View(nhanVien);
            }
            return BadRequest();
        }

    }
}
