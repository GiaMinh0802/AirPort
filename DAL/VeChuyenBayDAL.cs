using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VeChuyenBayDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable Get()
        {
            var dtVe = from v in db.VECHUYENBAYs
                       select v;
            DataTable dt = cv.LINQResultToDataTable(dtVe);
            return dt;
        }

        public DataTable GetForDisplay()
        {
            var dtVe = from v in db.VECHUYENBAYs
                       join k in db.KHACHHANGs
                       on v.MAKHACHHANG equals k.MAKHACHHANG
                       join h in db.HANGVEs
                       on v.MAHANGVE equals h.MAHANGVE
                       select new
                       {
                           MaVe = v.MAVE,
                           TenKhachHang = k.TENKHACHHANG,
                           CMND = k.CMND,
                           MaChuyenBay = v.MACHUYENBAY,
                           TenHangVe = h.TENHANGVE,
                           GiaTien = v.GIATIEN,
                           NgayGioGD = v.NGAYGIOGD,
                           VeGhe = v.VEGHE,
                           KyGui = v.KYGUI,
                           LoaiVe = v.LOAIVE
                       };
            DataTable dt = cv.LINQResultToDataTable(dtVe);
            return dt;
        }

        public bool Add(VeChuyenBayDTO dto)
        {
            try
            {
                string maVe = TaoMaVe();
                VECHUYENBAY insert = new VECHUYENBAY();
                insert.MAVE = maVe;
                insert.MAKHACHHANG = dto.MaKhachHang;
                insert.MACHUYENBAY = dto.MaChuyenBay;
                insert.MAHANGVE = dto.MaHangVe;
                insert.MANHANVIEN = dto.MaNhanVien;
                insert.GIATIEN = dto.GiaTien;
                insert.NGAYGIOGD = dto.NgayGioGD;
                insert.LOAIVE = dto.LoaiVe;
                insert.KYGUI = dto.Kygui;
                insert.VEGHE = dto.VeGhe;
                db.VECHUYENBAYs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string maVe)
        {
            try
            {
                VECHUYENBAY delete = db.VECHUYENBAYs.Where(p => p.MAVE.Equals(maVe)).SingleOrDefault();
                db.VECHUYENBAYs.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(string maVe, string txtvitri)
        {
            try
            {
                VECHUYENBAY edit = db.VECHUYENBAYs.Where(p => p.MAVE.Equals(maVe)).SingleOrDefault();
                edit.VEGHE = txtvitri;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable SearchOfSDT(string SDT)
        {
            var dtVe = from v in db.VECHUYENBAYs
                       join k in db.KHACHHANGs
                       on v.MAKHACHHANG equals k.MAKHACHHANG
                       join h in db.HANGVEs
                       on v.MAHANGVE equals h.MAHANGVE
                       where System.Data.Linq.SqlClient.SqlMethods.Like(k.SDT, "%" + SDT + "%")
                       select new
                       {
                           MaVe = v.MAVE,
                           TenKhachHang = k.TENKHACHHANG,
                           CMND = k.CMND,
                           MaChuyenBay = v.MACHUYENBAY,
                           TenHangVe = h.TENHANGVE,
                           GiaTien = v.GIATIEN,
                           NgayGioGD = v.NGAYGIOGD,
                           VeGhe = v.VEGHE,
                           KyGui = v.KYGUI,
                           LoaiVe = v.LOAIVE
                       };
            DataTable dt = cv.LINQResultToDataTable(dtVe);
            return dt;
        }

        public DataTable GetAndSortDesc()
        {
            var query = from i in db.VECHUYENBAYs
                        orderby i.MAVE descending
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        private string TaoMaVe()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "VE000" + dt.Rows.Count;
            DataRow row = dt.Rows[0];
            string maTuyenBay = row[0].ToString().Substring(2);
            int count = int.Parse(maTuyenBay) + 1;
            int temp = count;
            string strSoKhong = "";
            int dem = 0;
            while (temp > 0)
            {
                temp /= 10;
                dem++;
            }
            for (int i = 0; i < 4 - dem; i++)
            {
                strSoKhong += "0";
            }
            return "VE" + strSoKhong + count;
        }
    }
}
