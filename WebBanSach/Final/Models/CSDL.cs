using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class CSDLContext : DbContext
    {
        public CSDLContext()
        {
            SqlConnectionStringBuilder sqlb = new SqlConnectionStringBuilder();
            sqlb.DataSource = "DESKTOP-8UETP3M\\BAONGOC";
            sqlb.InitialCatalog = "db1";
            sqlb.IntegratedSecurity = true;
            this.Database.Connection.ConnectionString = sqlb.ConnectionString;

        }
        public DbSet<Sach> Saches { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<LoginManage> LoginManages { get; set; }
    }
    public class Sach
    {
        [Key]
        public int MaSach { get; set; }
        [DisplayName("Tên Sách")]
        public string TenSach { get; set; }
        [DisplayName("Đơn Giá"), Range(100, int.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn 100"), Required(ErrorMessage = "Hãy nhập đơn giá")]
        public int GiaBan { get; set; }
        [DisplayName("Ngày Xuất Bản")]
        public string NgayXuatBan { get; set; }
        [DisplayName("Loại Bìa")]
        public string LoaiBia { get; set; }
        [DisplayName("Số Trang")]
        public int SoTrang { get; set; }
        [DisplayName("Hình Ảnh")]
        public string Hinh { get; set; }
        public Nullable<int> MaDanhMuc { get; set; }
        public virtual DanhMuc DanhMucs { get; set; }
        public virtual ICollection<GioHang> GioHang { get; set; }
    }
    public class DanhMuc
    {
        [Key]
        public int MaDanhMuc { get; set; }
        [DisplayName("Tên Danh Mục")]
        public string TenDanhMuc { get; set; }
        public virtual ICollection<Sach> Saches { get; set; }
    }

    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        [DisplayName("Tên Khách Hàng")]
        public string TenKH { get; set; }
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Số Điện Thoại")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Please input username"), StringLength(maximumLength: 25, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3 đến 25 kí tự")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please input password"), StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "Mật khẩu phải từ 3 đến 30 kí tự")]
        public string Password { get; set; }
        public virtual ICollection<GioHang> GioHang { get; set; }
        public Nullable<int> MaQuyen { get; set; }
        public virtual Quyen Quyen { get; set; }
    }
    public class Quyen
    {
        [Key,DisplayName("Quyền")]
        public int MaQuyen { get; set; }
        [DisplayName("Tên Quyền")]
        public string TenQuyen { get; set; }
        public virtual ICollection<KhachHang> KhachHang { get; set; }
    }
    public class GioHang
    {
        [Key]
        public int MaGioHang { get; set; }
        public Nullable<int> MaKH { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public Nullable<int> MaSach { get; set; }
        public virtual Sach Sach { get; set; }
        [DisplayName("Số Lượng"), Range(1, int.MaxValue, ErrorMessage = "Số lượng sản phẩm phải lớn hơn 1")]
        public int SoLuong { get; set; }
    }
    public class LoginManage
    {
        [Key]
        public int LoginManageKey { get; set; }
        [DisplayName("Tên Quyền")]
        public string UserName { get; set; }
        public string TimeLogin { get; set; }
        public string TimeLogout { get; set; }
    }
}