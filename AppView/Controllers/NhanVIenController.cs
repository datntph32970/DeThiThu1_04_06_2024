using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
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
                return RedirectToAction("Index");
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
    public class NhanVien
    {
        public Guid id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(30, ErrorMessage = "Độ dài tối đa 30 kí tự")]
        public string ten { get; set; }
        [Range(18, 50, ErrorMessage = "Độ tuổi phải từ 18 đến 50")]
        public int tuoi { get; set; }
        public int role { get; set; }
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Định dạng email không hợp lệ")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Range(5000000, 30000000, ErrorMessage = "Lương phải từ 5.000.000 đến 30.000.000")]
        public int luong { get; set; }
        public bool trangThai { get; set; }
    }
}
