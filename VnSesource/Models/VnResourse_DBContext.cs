using Microsoft.EntityFrameworkCore;

namespace VnSesource.Models
{
    public class VnResourse_DBContext : DbContext
    {
        public VnResourse_DBContext(DbContextOptions<VnResourse_DBContext> options) : base(options) { }
        public DbSet<KhoaHoc> KhoaHoc { get; set; } = null!;
        public DbSet<MonHoc> MonHoc { get; set; } = null!;
    }
}
