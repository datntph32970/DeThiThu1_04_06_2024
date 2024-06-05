using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class NhanVien
    {
        public Guid id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(30, ErrorMessage = "Độ dài tối đa 30 kí tự")]
        public string ten { get; set; }
        [Range(18, 50, ErrorMessage = "Độ tuổi phải từ 18 đến 50")]
        public int tuoi { get; set; }
        public int role { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Định dạng email không hợp lệ")]
        public string Email { get; set; }
        public int luong { get; set; }
        public bool trangThai { get; set; }
    }
}
