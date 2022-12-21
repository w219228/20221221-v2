using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models.Services
{
    //這層做邏輯判斷
    public class RegisterService
    {

        //private RegisterRepository repository = new RegisterRepository();
        private IRegisterRepository repository;
        public RegisterService(IRegisterRepository repo)
        {
            repository = repo;
        }
        public void Create(RegisterDTO registerDto)
        {
            //var dataInDb = db.Registers.FirstOrDefault(x => x.Email == register.Email); //LINQ找符合的第一筆，如果沒找到就是null

            var dataInDb = repository.FindByEmail(registerDto.Email);
            if (dataInDb != null)//表示這筆資料有紀錄
            {
                throw new Exception("這個Email已經報名過了，無法再度報名");

            }
            //用程式指定建檔時間，而不是由使用者輸入
            registerDto.CreatedTime = DateTime.Now;

            repository.Create(registerDto);
            //db.Registers.Add(register);
            //db.SaveChanges();
        }

        public Register Find(int id)
        {
            //Register register = db.Registers.Find(id);
            Register register = repository.FindById(id);
            if (register == null)
            {
                throw new Exception("找不到指定的紀錄");
            }
            return register;
        }
    }
}