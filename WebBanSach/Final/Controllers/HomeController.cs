using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private CSDLContext db = new CSDLContext();
        public ActionResult Index()
        {
            if(Session["lang"] == null)
            {
                Session["lang"] = "0".ToString();
            }
            return View();
        }
        [OutputCache(Duration =15*60)]
        public ActionResult Shop(int? page,int? quantityBook)
        {
            if (Session["lang"] == null)
            {
                Session["lang"] = "0".ToString();
            }
            int number = 0;
            if (page != null && quantityBook ==null)
            {
                number = page.GetValueOrDefault() * 6;
            }
            else if(page!= null && quantityBook != null)
            {
                int a = (int)quantityBook;
                number = page.GetValueOrDefault() * a;
            }
            if(quantityBook != null)
            {
                ViewBag.count = db.Saches.Count() / quantityBook;
            }
            else
            {
                ViewBag.count = db.Saches.Count() / 6;
            }
            if(quantityBook != null)
            {
                int a = (int)quantityBook;
                var saches = db.Saches.OrderBy(s => s.MaSach).Skip(number).Take(a).ToList();
                ViewBag.ds = saches;
            }
            else
            {
                var saches = db.Saches.OrderBy(s => s.MaSach).Skip(number).Take(6).ToList();
                ViewBag.ds = saches;
            }
            
            if(page == null)
            {
                page = 0;
            }
            ViewBag.quantityBook = quantityBook;
            if(ViewBag.quantityBook == null)
            {
                ViewBag.quantityBook = 6;
            }
            ViewBag.page = page;
            var danhmuc2 = from s in db.Saches
                         where s.MaDanhMuc==1
                         orderby s.GiaBan ascending
                         select s;      
            var danhmuc1 = from s in db.Saches
                           orderby s.GiaBan descending
                           select s;
            ViewBag.danhmuc2 = danhmuc2;
            ViewBag.danhmuc1 = danhmuc1;
            return View();
        }
        public ActionResult ExceptionShop()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchByPrice(int price)
        {
            var result = from s in db.Saches
                         where price >= s.GiaBan
                         orderby s.GiaBan ascending
                         select s;
            ViewBag.ds = result;
            return View();
        }
        [HttpGet]
        public ActionResult AddIntoCart(int maSach)
        {

            if (Session["kh"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                KhachHang khachHang = Session["kh"] as KhachHang;
                if (Session["cart"] == null)
                {
                    Session["cart"] = new List<GioHang>();
                }
                List<GioHang> gioHangs = Session["cart"] as List<GioHang>;
                if (gioHangs.FirstOrDefault(m => m.MaSach == maSach) == null)
                {
                    Sach sach = db.Saches.Find(maSach);
                    GioHang gioHang = new GioHang()
                    {
                        MaSach = maSach,
                        SoLuong = 1,
                        MaKH = khachHang.MaKH
                    };
                    gioHangs.Add(gioHang);
                }
                else
                {
                    GioHang gioHang = gioHangs.FirstOrDefault(m => m.MaSach == maSach);
                    gioHang.SoLuong++;
                }
                return RedirectToAction("Cart", "Home");
            }
        }
        public ActionResult Vietnamese()
        {
            Session["lang"] = "1".ToString();
            return View();
        }
        public ActionResult English()
        {
            Session["lang"] = "0".ToString();
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Cart()
        {
            if (Session["kh"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            List<GioHang> giohang = Session["cart"] as List<GioHang>;
            if (giohang == null)
            {
                return View("ExceptionCartView");
            }
            else
            {
                var result = from g in giohang
                             join k in db.KhachHangs on g.MaKH equals k.MaKH
                             join s in db.Saches on g.MaSach equals s.MaSach
                             select new Tmp
                             {
                                 TenKH = k.TenKH,
                                 Hinh = s.Hinh,
                                 TenSach = s.TenSach,
                                 SoLuong = g.SoLuong,
                                 DonGia = s.GiaBan,
                                 ThanhTien = s.GiaBan * g.SoLuong,
                                 MaSach = s.MaSach,
                                 MaKH = k.MaKH
                             };
                int total = 0;
                foreach (var money in result)
                {
                    total = total + money.ThanhTien;
                }
                ViewBag.totalMoney = total;
                ViewData["data"] = result;
                return View(result);
            }
        }

        public class Tmp
        {
            public int DonGia { get; set; }
            public int SoLuong { get; set; }
            public string TenKH { get; set; }
            public string TenSach { get; set; }
            public string Hinh { get; set; }
            public int ThanhTien { get; set; }
            public int MaSach { get; set; }
            public int MaKH { get; set; }
        }
        public ActionResult ExceptionCartView()
        {
            return View();
        }
        public ActionResult UpdateQuantity(int maSach, int newQuantity)
        {
            List<GioHang> giohang = Session["cart"] as List<GioHang>;
            GioHang gioHangSua = giohang.FirstOrDefault(m => m.MaSach == maSach);
            if (gioHangSua != null)
            {
                gioHangSua.SoLuong = newQuantity;
            }
            return RedirectToAction("Cart", "Home");
        }
        public RedirectToRouteResult DeleteItemFromCart(int maSach)
        {
            List<GioHang> giohang = Session["cart"] as List<GioHang>;
            GioHang gioHangXoa = giohang.FirstOrDefault(m => m.MaSach == maSach);
            if (gioHangXoa != null)
            {
                giohang.Remove(gioHangXoa);
            }
            return RedirectToAction("Cart", "Home");
        }
        public RedirectToRouteResult DeleteCart()
        {
            List<GioHang> giohang = Session["cart"] as List<GioHang>;
            giohang.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AddIntoDatabase()
        {
            Session["OrderTime"] = DateTime.Now;
            List<GioHang> gioHangs = Session["cart"] as List<GioHang>;
            foreach(var item in gioHangs)
            {
                GioHang giohang = new GioHang { MaKH = item.MaKH, MaSach = item.MaSach, SoLuong = item.SoLuong };
                db.GioHangs.Add(giohang);
                db.SaveChanges();
            }
            var result = from g in gioHangs
                         join k in db.KhachHangs on g.MaKH equals k.MaKH
                         join s in db.Saches on g.MaSach equals s.MaSach
                         select new Tmp1
                         {
                             Ngay = Session["OrderTime"].ToString(),
                             TenKH = k.TenKH,
                             TenSach = s.TenSach,
                             SoLuong = g.SoLuong,
                             DonGia = s.GiaBan,
                             ThanhTien = s.GiaBan * g.SoLuong,
                             MaSach = s.MaSach,
                             MaKH = k.MaKH
                         };
            ViewData["data"] = result;
            int total = 0;
            foreach(var money in result)
            {
                total = total + money.ThanhTien;
            }
            ViewBag.totalMoney = total;
            Session.Remove("cart");
            
            return View(result);

        }
        public class Tmp1
        {
            public string Ngay { get; set; }
            public int DonGia { get; set; }
            public int SoLuong { get; set; }
            public string TenKH { get; set; }
            public string TenSach { get; set; }
            public int ThanhTien { get; set; }
            public int MaSach { get; set; }
            public int MaKH { get; set; }
        }
        public JsonResult GetSearchingData(string SearchValue)
        {
            List<Sach> BookList = new List<Sach>();
            BookList = db.Saches.Where(x => x.TenSach.StartsWith(SearchValue) || SearchValue == null).ToList();
            return Json(BookList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PersonalCart()
        {
            if (Session["kh"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            int a = Convert.ToInt32(Session["UserID"].ToString());
            var result = from g in db.GioHangs
                         join k in db.KhachHangs on g.MaKH equals k.MaKH
                         join s in db.Saches on g.MaSach equals s.MaSach
                         where k.MaKH == a
                         select new Tmp2
                         {
                             TenKH = k.TenKH,
                             TenSach = s.TenSach,
                             SoLuong = g.SoLuong,
                             DonGia = s.GiaBan,
                             ThanhTien = s.GiaBan * g.SoLuong,
                             MaSach = s.MaSach,
                             MaKH = k.MaKH,
                             Hinh = s.Hinh
                         };
            if (result == null)
            {
                ViewBag.message = "Không có sản phẩm nào trong đơn hàng của bạn";
            }
            ViewBag.ds = result;
            return View();
        }

        public class Tmp2
        {
            public int DonGia { get; set; }
            public int SoLuong { get; set; }
            public string TenKH { get; set; }
            public string TenSach { get; set; }
            public string Hinh { get; set; }
            public int ThanhTien { get; set; }
            public int MaSach { get; set; }
            public int MaKH { get; set; }
        }

    }

}