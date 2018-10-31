using LuanVanTotNghiep.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuanVanTotNghiep.Models.DAO
{
    public class ProductDAO
    {
        QLNhaHangEntities db = new QLNhaHangEntities();

        public List<MonAnViewModel> ListByCategoryId(int id, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.MONANs.Where(x => x.MALOAI == id).Count();
            var model = (from m in db.MONANs
                         join l in db.LOAIMONANs
                         on m.MALOAI equals l.MALOAI
                         join h in db.HINHANHs
                         on m.MAHINHANH equals h.MAHINHANH
                         join dv in db.DONVITINHs
                         on m.MADVTINH equals dv.MADVTINH
                         where m.MALOAI == id
                         select new
                         {
                             MAMON = m.MAMON,
                             DUONGDAN = h.DUONGDAN1,
                             TENGOI = m.TENGOI,
                             DONGIA = m.DONGIA,
                             TENDVTINH = dv.TENDVTINH
                         }).AsEnumerable().Select(x => new MonAnViewModel()
                         {
                             MAMON = x.MAMON,
                             DUONGDAN = x.DUONGDAN,
                             TENGOI = x.TENGOI,
                             DONGIA = x.DONGIA,
                             DVTINH = x.TENDVTINH
                         });

            model.OrderByDescending(x => x.MAMON).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        public List<MonAnViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.MONANs.Where(x => x.TENGOI == keyword).Count();
            var model = (from m in db.MONANs
                         join l in db.LOAIMONANs
                         on m.MALOAI equals l.MALOAI
                         join h in db.HINHANHs
                         on m.MAHINHANH equals h.MAHINHANH
                         join dv in db.DONVITINHs
                         on m.MADVTINH equals dv.MADVTINH
                         where m.TENGOI.Contains(keyword)
                         select new
                         {
                             MAMON = m.MAMON,
                             DUONGDAN = h.DUONGDAN1,
                             TENGOI = m.TENGOI,
                             DONGIA = m.DONGIA,
                             TENDVTINH = dv.TENDVTINH
                         }).AsEnumerable().Select(x => new MonAnViewModel()
                         {
                             MAMON = x.MAMON,
                             DUONGDAN = x.DUONGDAN,
                             TENGOI = x.TENGOI,
                             DONGIA = x.DONGIA,
                             DVTINH = x.TENDVTINH
                         });

            model.OrderByDescending(x => x.MAMON).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        public MONAN ViewDetail(int id)
        {
            return db.MONANs.Find(id);
        }
    }
}