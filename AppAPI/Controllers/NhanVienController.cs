using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NhanVienController: ControllerBase
    {
        AppDBContext _db;

        public NhanVienController()
        {
            _db = new AppDBContext();
        }
        [HttpGet("BMI-NhanVien")]
        public double GetBMI(double chieuCao, double canNang)
        {
            double bmi = canNang / (chieuCao * chieuCao);
            return bmi;
        }
        [HttpGet("GetAll")]
        public List<NhanVien> GetAll()
        {
            return _db.NhanViens.ToList();
        }
        [HttpGet("GetById")]
        public NhanVien GetById(Guid id)
        {
            return _db.NhanViens.Find(id);
        }
        [HttpPost("Create")]
        public NhanVien Create(NhanVien nhanVien)
        {
            _db.NhanViens.Add(nhanVien);
            _db.SaveChanges();
            return nhanVien;
        }
        [HttpPut("Update")]
        public NhanVien Update(NhanVien nhanVien)
        {
            _db.NhanViens.Update(nhanVien);
            _db.SaveChanges();
            return nhanVien;
        }
        [HttpDelete("Delete")]
        public NhanVien Delete(Guid id)
        {
            NhanVien nhanVien = _db.NhanViens.Find(id);
            _db.NhanViens.Remove(nhanVien);
            _db.SaveChanges();
            return nhanVien;
        }

    }
}
