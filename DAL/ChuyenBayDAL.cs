using DTO;
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

        public bool Add(ChuyenBayDTO dto)
        {
            try
            {
                string maChuyenBay = TaoMaChuyenBay();
                CHUYENBAY insert = new CHUYENBAY();
                insert.MACHUYENBAY = maChuyenBay;
                insert.MATUYENBAY = dto.MaTuyenBay;
                insert.MAMAYBAY = dto.MaMayBay;
                insert.THOIGIANKHOIHANH = dto.ThoiGianKhoiHanh;
                insert.THOIGIANBAY = dto.ThoiGianBay;
                db.CHUYENBAYs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(ChuyenBayDTO dto)
        {
            try
            {
                CHUYENBAY edit = db.CHUYENBAYs.Where(p => p.MACHUYENBAY.Equals(dto.MaChuyenBay)).SingleOrDefault();
                edit.MATUYENBAY = dto.MaTuyenBay;
                edit.MAMAYBAY = dto.MaMayBay;
                edit.THOIGIANKHOIHANH = dto.ThoiGianKhoiHanh;
                edit.THOIGIANBAY = dto.ThoiGianBay;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string str)
        {
            try
            {
                CHUYENBAY delete = db.CHUYENBAYs.Where(p => p.MACHUYENBAY.Equals(str)).SingleOrDefault();
                db.CHUYENBAYs.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
        public DataTable SearchOfMaChuyenBay(string str)
        {
            var query = from i in db.CHUYENBAYs
                        where System.Data.Linq.SqlClient.SqlMethods.Like(i.MACHUYENBAY, "%" + str + "%")
                        select new
                        {
                            i.MACHUYENBAY,
                            i.MATUYENBAY,
                            i.MAMAYBAY,
                            i.THOIGIANKHOIHANH,
                            i.THOIGIANBAY
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public DataTable GetAndSortDesc()
        {
            var query = from i in db.CHUYENBAYs
                        orderby i.MACHUYENBAY descending
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        private string TaoMaChuyenBay()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "CB000" + dt.Rows.Count;
            DataRow row = dt.Rows[0];
            string maChuyenBay = row[0].ToString().Substring(2);
            int count = int.Parse(maChuyenBay) + 1;
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
            return "CB" + strSoKhong + count;
        }
    }
}
