using Final.Models;
using log4net;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Final.Controllers
{
    public class AuthenticationController : Controller
    {
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(AuthenticationController));
        private CSDLContext db = new CSDLContext();
        // GET: Authentication
        public ActionResult Login()
        {
            if (Session["lang"] == null)
            {
                Session["lang"] = "0".ToString();
            }
            return View();
        }
        [HttpPost, OutputCache(Duration = 60 * 15)]
        public ActionResult DoLogin(string userName, string password)
        {
            KhachHang k = db.KhachHangs.Where(kh => kh.UserName == userName && kh.Password == password).FirstOrDefault();
            if (k != null)
            {
                string role;
                if(k.MaQuyen == 1)
                {
                    role = "Admin";
                }
                else
                {
                    role = "User";
                }
                log.Info("Login :"+k.UserName.ToString()+" || Role : "+role);
                System.Web.HttpContext.Current.Cache.Insert("KH", k, null, DateTime.MaxValue, TimeSpan.FromMinutes(15));
                Session["kh"] = k;
                if (Session["lang"] == null)
                {
                    Session["lang"] = "0".ToString();
                }
                Session["UserName"] = k.TenKH.ToString();
                Session["UserID"] = k.MaKH.ToString();
                Session["UserRole"] = k.MaQuyen.ToString();
                Session["UserAddress"] = k.DiaChi.ToString();
                Session["TimeLogin"] = DateTime.Now.ToString();
                Session["user"] = k.UserName.ToString();
                FormsAuthentication.SetAuthCookie(k.UserName, false);
                if (Session["UserRole"].ToString() == "1")
                {
                    return View("Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.message = "Invalid Username or Password";
                return View("Login");
            }


        }
        public ActionResult LogOut()
        {
            string role="";
            if(Session["UserRole"].ToString() == "1")
            {
                role = "Admin";
            }
            else
            {
                role = "User";
            }
            log.Info("Logout :" + Session["user"].ToString() + " || Role : " + role);
            Session.Remove("kh");
            Session.Remove("UserName");
            FormsAuthentication.SignOut();
            Session["TimeLogout"] = DateTime.Now.ToString();
            LoginManage loginManage = new LoginManage();
            loginManage.UserName = Session["user"].ToString();
            loginManage.TimeLogin = Session["TimeLogin"].ToString();
            loginManage.TimeLogout = Session["TimeLogout"].ToString();
            db.LoginManages.Add(loginManage);
            db.SaveChanges();
            return RedirectToAction("Login", "Authentication");
        }
        public ActionResult Register()
        {
            if (Session["lang"] == null)
            {
                Session["lang"] = "0".ToString();
            }

            return View();
        }
        [HttpPost]
        public ActionResult AddIntoDatabase(string name, string address, string phoneNumber, string userName, string password)
        {
            KhachHang k = db.KhachHangs.Where(kh => kh.UserName == userName).FirstOrDefault();
            if(k != null)
            {
                ViewBag.message = "Trùng tên đăng nhập";
                return View("Register");
            }

            KhachHang khachHang = new KhachHang { TenKH = name, DiaChi = address, SDT = phoneNumber, UserName = userName, Password = password, MaQuyen = 2 };
            db.KhachHangs.Add(khachHang);
            db.SaveChanges();
            return DoLogin(userName, password);

        }


        public ActionResult Admin()
        {


            if (Session["UserRole"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            else if (Session["UserRole"].ToString() == "1")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
            
        }
        public ActionResult LineChart()
        {
            return View();

        }
        public ActionResult BarChart()
        {
            var query = db.GioHangs.Include("KhachHang").Include("Sach")
                   .GroupBy(p => p.Sach.TenSach)
                   .Select(g => new { name = g.Key, count = g.Sum(w => w.SoLuong) }).ToList();

            var result = from s in query
                         select new Tmp
                         {
                             TenSach = s.name,
                             SoLuong = s.count
                         };
            ViewBag.ds = result;
            return View(result);

        }

        public JsonResult GetSearchingData(string SearchValue)
        {
            List<Sach> BookList = new List<Sach>();
            BookList = db.Saches.Where(x => x.TenSach.StartsWith(SearchValue) || SearchValue == null).ToList();
            return Json(BookList, JsonRequestBehavior.AllowGet);
        }

        public class Tmp
        {
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
        }
        public ActionResult AreaChart()
        {
            return View();

        }
        public ActionResult Chart()
        {
            return View();

        }
        public ActionResult GetData()
        {
            var query = db.GioHangs.Include("KhachHang").Include("Sach")
                   .GroupBy(p => p.Sach.TenSach)
                   .Select(g => new { name = g.Key, count = g.Sum(w => w.SoLuong) }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
}