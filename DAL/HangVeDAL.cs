using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HangVeDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();

        public DataTable Get()
        {
            var query = from i in db.HANGVEs 
                           select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetForDisplay()
        {
            var query = from i in db.HANGVEs
                        orderby i.MAHANGVE ascending
                        select new
                        {
                            i.MAHANGVE,
                            i.TENHANGVE
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool Add(HangVeDTO dto)
        {
            try
            {
                string maHangVe = TaoMaHangVe();
                HANGVE insert = new HANGVE();
                insert.MAHANGVE = maHangVe;
                insert.TENHANGVE = dto.TenHangVe;
                db.HANGVEs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            } 
        }
        public bool Update(HangVeDTO dto)
        {
            try
            {
                HANGVE edit = db.HANGVEs.Where(p => p.MAHANGVE.Equals(dto.MaHangVe)).SingleOrDefault();
                edit.TENHANGVE = dto.TenHangVe;
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
                HANGVE delete = db.HANGVEs.Where(p => p.MAHANGVE.Equals(str)).SingleOrDefault();
                db.HANGVEs.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public DataTable SearchOfMaHangVe(string str)
        {
            var query = from i in db.HANGVEs
                           where System.Data.Linq.SqlClient.SqlMethods.Like(i.MAHANGVE, "%"+str+"%")
                           select new
                           {
                               i.MAHANGVE,
                               i.TENHANGVE
                           };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public DataTable GetAndSortDesc()
        {
            var query = from i in db.HANGVEs
                           orderby i.MAHANGVE descending
                           select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        private string TaoMaHangVe()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "HV000" + dt.Rows.Count;
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
            return "HV" + strSoKhong + count;
        }
    }
}
