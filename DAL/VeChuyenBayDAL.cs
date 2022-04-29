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
    }
}
