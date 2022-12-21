using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.Services;

namespace WebApplication1.Models.Repository
{
    //這層做存取資料庫
    public class RegisterRepository : IRegisterRepository
    {
        private AppDbContext db = new AppDbContext();

        public void Create(Register register)
        {
            db.Registers.Add(register);
            db.SaveChanges();
        }
        public List<Register> GetAll()
        {
            return db.Registers.ToList();
        }

        public Register FindByEmail(string email)
        {
            return db.Registers.FirstOrDefault(x => x.Email == email); //LINQ找符合的第一筆，如果沒找到就是null
        }
        public Register FindById(int id)
        {
            return db.Registers.Find(id);
        }
    }
}