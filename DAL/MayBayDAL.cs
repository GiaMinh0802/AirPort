using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MayBayDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable Get()
        {
            var query = from i in db.MAYBAYs
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetForDisplay()
        {
            var query = from i in db.MAYBAYs
                        select new
                        {
                            i.MAMAYBAY,
                            i.TENMAYBAY,
                            i.SOLUONGGHE
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool Add(MayBayDTO dto)
        {
            try
            {
                string maMayBay = TaoMaMayBay();
                MAYBAY insert = new MAYBAY();
                insert.MAMAYBAY = maMayBay;
                insert.TENMAYBAY = dto.TenMayBay;
                insert.SOLUONGGHE = dto.SoLuongGhe;
                db.MAYBAYs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(MayBayDTO dto)
        {
            try
            {
                MAYBAY edit = db.MAYBAYs.Where(p => p.MAMAYBAY.Equals(dto.MaMayBay)).SingleOrDefault();
                edit.TENMAYBAY = dto.TenMayBay;
                edit.SOLUONGGHE = dto.SoLuongGhe;
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
                MAYBAY delete = db.MAYBAYs.Where(p => p.MAMAYBAY.Equals(str)).SingleOrDefault();
                db.MAYBAYs.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetAndSortDesc()
        {
            var query = from i in db.MAYBAYs
                        orderby i.MAMAYBAY descending
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        private string TaoMaMayBay()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "MB000" + dt.Rows.Count;
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
            return "MB" + strSoKhong + count;
        }
        public DataTable SearchOfMaMayBay(string str)
        {
            string sqlQuery = string.Format("SELECT MAMAYBAY[Mã máy bay], TENMAYBAY[Tên máy bay], " +
                "SOLUONGGHE[Số lượng ghế] FROM MAYBAY WHERE MAMAYBAY LIKE('%{0}%')", str);
            var query = from i in db.MAYBAYs
                        where System.Data.Linq.SqlClient.SqlMethods.Like(i.MAMAYBAY, "%" + str + "%")
                        select new
                        {
                            i.MAMAYBAY,
                            i.TENMAYBAY,
                            i.SOLUONGGHE
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
    }
}
