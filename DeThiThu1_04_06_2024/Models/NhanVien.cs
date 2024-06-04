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
        [MaxLength(30,ErrorMessage ="do dai toi da 30")]
        public string ten { get; set; }
        public int tuoi { get; set; }
        public int role { get; set; }
        public string Email { get; set; }
        public int luong { get; set; }
        public bool trangThai { get; set; }
    }
}
