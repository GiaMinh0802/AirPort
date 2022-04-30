using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChuyenBayDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable Get()
        {
            var query = from i in db.CHUYENBAYs
                           select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetToDisplay()
        {
            var query = from i in db.CHUYENBAYs
                        select new
                        {
                            MaChuyenBay = i.MACHUYENBAY,
                            MaTuyenBay = i.MATUYENBAY,
                            MaMayBay = i.MAMAYBAY,
                            ThoiGianKhoiHanh = i.THOIGIANKHOIHANH,
                            ThoiGianBay = i.THOIGIANBAY
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetOfMaChuyenBay(string maChuyenBay)
        {
            var query = from c in db.CHUYENBAYs
                        join t in db.TUYENBAYs
                        on c.MATUYENBAY equals t.MATUYENBAY
                        join s1 in db.SANBAYs
                        on t.MASANBAYDI equals s1.MASANBAY
                        join s2 in db.SANBAYs
                        on t.MASANBAYDEN equals s2.MASANBAY
                        where c.MACHUYENBAY == maChuyenBay
                        select new
                        {
                            MaChuyenBay = c.MACHUYENBAY,
                            MaTuyenBay = t.MATUYENBAY,
                            MaMayBay = c.MAMAYBAY,
                            ThoiGianKhoiHanh = c.THOIGIANKHOIHANH,
                            ThoiGianBay = c.THOIGIANBAY,
                            TenSanBayDi = s1.TENSANBAY,
                            TenSanBayDen = s2.TENSANBAY
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable Search(string maSanBayDi, string maSanBayDen, DateTime thoiGianKHTu, DateTime thoiGianKHDen)
        {
            var query = from c in db.CHUYENBAYs
                        join t in db.TUYENBAYs
                        on c.MATUYENBAY equals t.MATUYENBAY
                        where t.MASANBAYDI == maSanBayDi && t.MASANBAYDEN == maSanBayDen &&
                            (c.THOIGIANKHOIHANH.Date >= thoiGianKHTu && c.THOIGIANKHOIHANH.Date <= thoiGianKHDen)
                        select new
                        {
                            c.MACHUYENBAY,
                            c.THOIGIANKHOIHANH,
                            c.THOIGIANBAY
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
    }
}
