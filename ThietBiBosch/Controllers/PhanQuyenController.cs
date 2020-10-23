using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ThietBiBosch.Database;

namespace ThietBiBosch.Controllers
{
    public class PhanQuyenController : BaseController
    {
        // GET: PhanQuyen
        public ActionResult PhanQuyenNguoiDung()
        {
            var nv = db.NhanViens.ToDictionary(x => x.MaNhanVien, y => y.TenNhanVien);

            var tk = db.TaiKhoans.ToList();
            List<TaiKhoan> lstTaiKhoan = new List<TaiKhoan>();
            string tenNhanVien = string.Empty;
            foreach (var item in tk)
            {
                foreach (var acc in nv)
                {
                    if (item.MaNhanVien == acc.Key)
                    {
                        tenNhanVien = acc.Value;
                    }
                }
                item.MaNhanVien = tenNhanVien;
                lstTaiKhoan.Add(item);
            }
            List<Models.TaiKhoanModel> map = new List<Models.TaiKhoanModel>();
            if (lstTaiKhoan.Count > 0)
            {
                Models.TaiKhoanModel tkm;

                foreach (var lst in lstTaiKhoan)
                {
                    tkm = new Models.TaiKhoanModel();
                    tkm.MaNhanVien = lst.MaNhanVien;
                    tkm.MaTaiKhoan = lst.MaTaiKhoan;
                    tkm.MatKhau = lst.MatKhau;
                    tkm.TenDangNhap = lst.TenDangNhap;
                    var id_quyen = db.ChiTietQuyens.FirstOrDefault(x => x.MaTaiKhoan == lst.MaTaiKhoan)?.id_quyen;
                    tkm.Rule = db.PhanQuyens.Find(id_quyen)?.TenQuyen;
                    map.Add(tkm);
                }
            }

            ViewBag.Account = map;

            var quyen = db.PhanQuyens.ToList();
            return View(quyen);
        }
    }
}