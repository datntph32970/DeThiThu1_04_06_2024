using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext()
        {
            
        }
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
            
        }
        public DbSet<NhanVien> NhanViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ACER\\SQLEXPRESS;Database=DeThiThu_04_06_2024;Trusted_Connection=True;TrustServerCertificate=true;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
