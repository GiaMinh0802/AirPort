using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TuyenBayDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable Get()
        {
            var query = from i in db.TUYENBAYs
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetOfMaTuyenBay(string str)
        {
            var query = from t in db.TUYENBAYs
                        join s1 in db.SANBAYs
                        on t.MASANBAYDI equals s1.MASANBAY
                        join s2 in db.SANBAYs
                        on t.MASANBAYDEN equals s2.MASANBAY
                        where t.MATUYENBAY == str
                        select new
                        {
                            t.MATUYENBAY,
                            MaSanBayDi = s1.MASANBAY,
                            TenSanBayDi = s1.TENSANBAY,
                            MaSanBayDen = s2.MASANBAY,
                            TenSanBayDen = s2.TENSANBAY,
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetOfMaSanBay(string maSBDi, string maSBDen)
        {
            var query = from i in db.TUYENBAYs
                        where i.MASANBAYDI == maSBDi && i.MASANBAYDEN == maSBDen
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetForDSTuyenBay()
        {
            var query = from t in db.TUYENBAYs
                        join s1 in db.SANBAYs
                        on t.MASANBAYDI equals s1.MASANBAY
                        join s2 in db.SANBAYs
                        on t.MASANBAYDEN equals s2.MASANBAY
                        select new
                        {
                            t.MATUYENBAY,
                            TenSanBayDi = s1.TENSANBAY,
                            TenSanBayDen = s2.TENSANBAY,
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool Add(TuyenBayDTO dto)
        {
            try
            {
                string maTuyenBay = TaoMaTuyenBay();
                TUYENBAY insert = new TUYENBAY();
                insert.MATUYENBAY = maTuyenBay;
                insert.MASANBAYDI = dto.MaSanBayDi;
                insert.MASANBAYDEN = dto.MaSanBayDen;
                db.TUYENBAYs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(TuyenBayDTO dto)
        {
            try
            {
                TUYENBAY edit = db.TUYENBAYs.Where(p => p.MATUYENBAY.Equals(dto.MaTuyenBay)).SingleOrDefault();
                edit.MASANBAYDI = dto.MaSanBayDi;
                edit.MASANBAYDEN = dto.MaSanBayDen;
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
                TUYENBAY delete = db.TUYENBAYs.Where(p => p.MATUYENBAY.Equals(str)).SingleOrDefault();
                db.TUYENBAYs.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable SearchOfMaTuyenBay(string str)
        {
            string sqlQuery = string.Format("SELECT T.MATUYENBAY[Mã tuyến bay], S1.TENSANBAY[Tên sân bay đi], " +
                "S2.TENSANBAY[Tên sân bay đến] FROM TUYENBAY T " +
                "INNER JOIN SANBAY S1 ON T.MASANBAYDI=S1.MASANBAY " +
                "INNER JOIN SANBAY S2 ON T.MASANBAYDEN = S2.MASANBAY WHERE MATUYENBAY LIKE('%{0}%')", str);
            var query = from t in db.TUYENBAYs
                        join s1 in db.SANBAYs
                        on t.MASANBAYDI equals s1.MASANBAY
                        join s2 in db.SANBAYs
                        on t.MASANBAYDEN equals s2.MASANBAY
                        where System.Data.Linq.SqlClient.SqlMethods.Like(t.MATUYENBAY, "%" + str + "%")
                        select new
                        {
                            t.MATUYENBAY,
                            TenSanBayDi = s1.TENSANBAY,
                            TenSanBayDen = s2.TENSANBAY
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public DataTable GetAndSortDesc()
        {
            var query = from i in db.TUYENBAYs
                        orderby i.MATUYENBAY descending
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        private string TaoMaTuyenBay()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "TB000" + dt.Rows.Count;
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
            return "TB" + strSoKhong + count;
        }
    }
}
