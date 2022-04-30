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
                           MaVe = v.MAHANGVE,
                           TenKhachHang = k.TENKHACHHANG,
                           CMND = k.CMND,
                           MaChuyenBay = v.MACHUYENBAY,
                           TenHangVe = h.TENHANGVE,
                           GiaTien = v.GIATIEN,
                           NgayGioGD = v.NGAYGIOGD,
                           NgayHuy = v.NGAYHUY,
                           LoaiVe = v.LOAIVE
                       };
            DataTable dt = cv.LINQResultToDataTable(dtVe);
            return dt;
        }

        public bool Add(VeChuyenBayDTO dto)
        {

            //string sqlQuery = string.Format("INSERT INTO VECHUYENBAY(MAVE, MAKHACHHANG, " +
            //    "MACHUYENBAY, MAHANGVE, MANHANVIEN, GIATIEN, NGAYGIOGD, LOAIVE) " +
            //    "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')"
            //    , maVe, dto.MaKhachHang, dto.MaChuyenBay, dto.MaHangVe, dto.MaNhanVien,
            //    dto.GiaTien, dto.NgayGioGD, dto.LoaiVe);
            string maVe = TaoMaVe();
            dto.MaVe = maVe;
            VECHUYENBAY insert = db.VECHUYENBAYs.Where(p => p.MAVE.Equals(dto.MaVe)).SingleOrDefault();
            try
            {
                db.VECHUYENBAYs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;
            }
            catch
            {

            }
            return false;
        }

        public DataTable GetAndSortDesc()
        {
            //string query = "SELECT * FROM VECHUYENBAY ORDER BY MAVE DESC";
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
