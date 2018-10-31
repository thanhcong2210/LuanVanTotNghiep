using LuanVanTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.ViewModel
{
    [Serializable]
    public class CartItem
    {
        public MONAN product { set; get; }
        public int Quantity { get; set; }
        public double? Total
        {
            get
            {
                return product.DONGIA * Quantity;
            }
        }
    }
}