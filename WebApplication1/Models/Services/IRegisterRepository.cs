using System.Collections.Generic;
using WebApplication1.Models.EFModels;

namespace WebApplication1.Models.Services
{
    public interface IRegisterRepository
    {
        void Create(Register register);
        Register FindByEmail(string email);
        Register FindById(int id);
        List<Register> GetAll();
    }
}