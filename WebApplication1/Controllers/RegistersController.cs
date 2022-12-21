using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.Repository;
using WebApplication1.Models.Services;

namespace WebApplication1.Controllers
{
    public class RegistersController : Controller
    {
        private IRegisterRepository repository;
        public RegistersController()
        {
            repository = new RegisterRepository();
        }
        //private AppDbContext db = new AppDbContext();

        // GET: Registers
        public ActionResult Index()
        {
            var data = repository.GetAll();
            return View(data);
        }

        // GET: Registers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                Register register = new RegisterService(repository).Find(id.Value);
                return View(register);
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }
            //Register register = db.Registers.Find(id);
            //if (register == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(register);
        }

        // GET: Registers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,")] Register register)
        {

            try
            {
                new RegisterService(repository).Create(register);
                //驗證Eail是否已經存在
                //var dataInDb = db.Registers.FirstOrDefault(x => x.Email == register.Email); //LINQ找符合的第一筆，如果沒找到就是null
                //if (dataInDb != null)//表示這筆資料有紀錄
                //{
                //    throw new Exception("這個Email已經報名過了，無法再度報名");

                //}
                ////用程式指定建檔時間，而不是由使用者輸入
                //register.CreatedTime = DateTime.Now;

                //db.Registers.Add(register);
                //db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }

            return View(register);
        }


        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
