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
        [HttpPost("TimSoLonThuHai")]
        public int TimSoLonThuHai(int[] arr)
        {
            int max1 = int.MinValue;
            int max2 = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max1)
                {
                    max2 = max1;
                    max1 = arr[i];
                }
                else if (arr[i] > max2 && arr[i] < max1)
                {
                    max2 = arr[i];
                }
            }
            return max2;
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
