using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanBayDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable Get()
        {
            var query = from i in db.SANBAYs
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetForDisplay()
        {
            var query = from i in db.SANBAYs
                        orderby i.MASANBAY ascending
                        select new
                        {
                            i.MASANBAY,
                            i.TENSANBAY,
                            i.TENTHANHPHO
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool Add(SanBayDTO dto)
        {
            try
            {
                string maSanBay = TaoMaSanBay();
                SANBAY insert = new SANBAY();
                insert.MASANBAY = maSanBay;
                insert.TENSANBAY = dto.TenSanBay;
                insert.TENTHANHPHO = dto.TenThanhPho;
                db.SANBAYs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(SanBayDTO dto)
        {
            try
            {
                SANBAY edit = db.SANBAYs.Where(p => p.MASANBAY.Equals(dto.MaSanBay)).SingleOrDefault();
                edit.TENSANBAY = dto.TenSanBay;
                edit.TENTHANHPHO = dto.TenThanhPho;
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
                SANBAY delete = db.SANBAYs.Where(p => p.MASANBAY.Equals(str)).SingleOrDefault();
                db.SANBAYs.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable SearchOfMaSanBay(string maSanBay)
        {
            var query = from i in db.SANBAYs
                        where System.Data.Linq.SqlClient.SqlMethods.Like(i.MASANBAY, "%" + maSanBay + "%")
                        select new
                        {
                            i.MASANBAY,
                            i.TENSANBAY,
                            i.TENTHANHPHO
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool CheckSanBay(string tenSanBay, string tenThanhPho)
        {
            var query = from i in db.SANBAYs
                        where i.TENSANBAY == tenSanBay && i.TENTHANHPHO == tenThanhPho
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        public DataTable GetAndSortDesc()
        {
            var query = from i in db.SANBAYs
                        orderby i.MASANBAY descending
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        private string TaoMaSanBay()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "SB000" + dt.Rows.Count;
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
            return "SB" + strSoKhong + count;
        }
    }
}
