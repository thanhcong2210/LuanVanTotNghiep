using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.Areas.Admin.Models
{
    public class PagedCollection<T>
    {
        public int Page { get; set; }

        public int Count
        {
            get
            {
                return (null != this.Items) ? this.Items.Count() : 0;
            }
        }

        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int MaxPage { set; get; }

        public IEnumerable<T> Items { get; set; }
    }
}