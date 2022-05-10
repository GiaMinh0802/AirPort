using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        

        public DataTable GetForDisplay()
        {
            var query = from i in db.KHACHHANGs
                        select new
                        {
                            i.MAKHACHHANG,
                            i.TENKHACHHANG,
                            i.CMND,
                            i.SDT
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool Add(KhachHangDTO dto)
        {
            try
            {
                string maKhachHang = TaoMaKhachHang();
                KHACHHANG insert = new KHACHHANG();
                insert.MAKHACHHANG = maKhachHang;
                insert.TENKHACHHANG = dto.TenKhachHang;
                insert.CMND = dto.CMND1;
                insert.SDT = dto.SDT1;
                db.KHACHHANGs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(KhachHangDTO dto)
        {
            try
            {
                KHACHHANG edit = db.KHACHHANGs.Where(p => p.MAKHACHHANG.Equals(dto.MaKhachHang)).SingleOrDefault();
                edit.TENKHACHHANG = dto.TenKhachHang;
                edit.CMND = dto.CMND1;
                edit.SDT = dto.SDT1;
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
                KHACHHANG delete = db.KHACHHANGs.Where(p => p.MAKHACHHANG.Equals(str)).SingleOrDefault();
                db.KHACHHANGs.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetOfCMND(string CMND)
        {
            var query = from i in db.KHACHHANGs
                        where i.CMND == CMND
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public DataTable GetAndSortDesc()
        {
            var query = from i in db.KHACHHANGs
                        orderby i.MAKHACHHANG descending
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        private string TaoMaKhachHang()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "KH000" + dt.Rows.Count;
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
            return "KH" + strSoKhong + count;
        }
        public DataTable SearchOfMaKhachHang(string str)
        {
            string sqlQuery = string.Format("SELECT MAKHACHHANG[Mã khách hàng], TENKHACHHANG[Tên khách hàng], " +
                "CMND[CMND], SDT[Số điện thoại] FROM KHACHHANG " +
                "WHERE MAKHACHHANG LIKE('%{0}%')", str);
            var query = from i in db.KHACHHANGs
                        where System.Data.Linq.SqlClient.SqlMethods.Like(i.MAKHACHHANG, "%" + str + "%")
                        select new
                        {
                            i.MAKHACHHANG,
                            i.TENKHACHHANG,
                            i.CMND,
                            i.SDT
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
    }
}
