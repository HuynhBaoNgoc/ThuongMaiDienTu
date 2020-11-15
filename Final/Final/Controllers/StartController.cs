using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class StartController : Controller
    {
        private CSDLContext db = new CSDLContext();
        // GET: Start
        public ActionResult Index()
        {
            Quyen quyen1 = new Quyen();
            quyen1.TenQuyen = "Admin";
            Quyen quyen2 = new Quyen();
            quyen2.TenQuyen = "User";
            db.Quyens.Add(quyen1);
            db.SaveChanges();
            db.Quyens.Add(quyen2);
            db.SaveChanges();
            KhachHang khachHang1 = new KhachHang();
            khachHang1.TenKH = "Trần Anh Đức";
            khachHang1.SDT = "0933131760";
            khachHang1.MaQuyen = 1;
            khachHang1.DiaChi = "36 Tôn Đản Q4 SaiGon";
            khachHang1.UserName = "admin";
            khachHang1.Password = "admin";
            db.KhachHangs.Add(khachHang1);
            DanhMuc danhMuc1 = new DanhMuc();
            danhMuc1.TenDanhMuc = "Kinh Doanh";
            DanhMuc danhMuc2 = new DanhMuc();
            danhMuc2.TenDanhMuc = "Văn Học";
            DanhMuc danhMuc3 = new DanhMuc(); 
            danhMuc3.TenDanhMuc = "Tiểu Thuyết";
            db.DanhMucs.Add(danhMuc1);
            db.SaveChanges();
            db.DanhMucs.Add(danhMuc2);
            db.SaveChanges();
            db.DanhMucs.Add(danhMuc3);
            db.SaveChanges();
            for (int i = 1; i <= 10; i++)
            {
                Sach sach = new Sach();
                sach.MaDanhMuc = 1;
                sach.TenSach = "Book" + i;
                sach.GiaBan = 1500 + i * 100;
                sach.NgayXuatBan = "28/07/2019";
                sach.LoaiBia = "Bìa Cứng";
                sach.SoTrang = 300;
                sach.Hinh = "http://bizweb.dktcdn.net/100/197/269/products/sach-du-an-phuong-hoang-alphabooks.jpg?v=1590647754677";
                db.Saches.Add(sach);
                db.SaveChanges();
            }
            for (int i = 11; i <= 20; i++)
            {
                Sach sach = new Sach();
                sach.MaDanhMuc = 2;
                sach.TenSach = "Book" + i;
                sach.GiaBan = 2500 + i * 100;
                sach.NgayXuatBan = "28/07/2019";
                sach.LoaiBia = "Bìa Cứng";
                sach.SoTrang = 300;
                sach.Hinh = "http://bizweb.dktcdn.net/100/197/269/products/thiet-ke-khong-ten-3.png?v=1592618552383";
                db.Saches.Add(sach);
                db.SaveChanges();
            }
            for (int i = 21; i <= 30; i++)
            {
                Sach sach = new Sach();
                sach.MaDanhMuc = 3;
                sach.TenSach = "Book" + i;
                sach.GiaBan = 3500 + i * 100;
                sach.NgayXuatBan = "28/07/2019";
                sach.LoaiBia = "Bìa Cứng";
                sach.SoTrang = 300;
                sach.Hinh = "http://bizweb.dktcdn.net/100/197/269/products/thiet-ke-khong-ten-3.png?v=1592618552383";
                db.Saches.Add(sach);
                db.SaveChanges();
            }










            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}