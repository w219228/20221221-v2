using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models.EFModels;

namespace WebApplication1.Models.DTOs
{
    public class RegisterDTO
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreatedTime { get; set; }
    }
    public static class RegisterExtensions
    { 
        public static RegisterDTO EntityToDTO(this Register source)
        {
            return new RegisterDTO
            {
                id = source.id,
                Name = source.Name,
                Email = source.Email,
                CreatedTime = source.CreatedTime,
            };
        }
    }

}