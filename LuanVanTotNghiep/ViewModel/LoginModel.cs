using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.ViewModel
{
    public class LoginModel
    {
        [Key]
        public string UserName { set; get; }

        public string Password { set; get; }
    }
}