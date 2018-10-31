using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.ViewModel
{
    public class RegisterModel
    {
        [Key]
        public int ID { set; get; }

        public int CateID { set; get; }

        public string UserName { set; get; }

        
        public string Password { set; get; }

        
        public string ConfirmPassword { set; get; }

        

        public string Name { set; get; }

 
        public string Address { set; get; }

        public bool Sex { set; get; }

        public string Email { set; get; }

        public string Phone { set; get; }
    }
}