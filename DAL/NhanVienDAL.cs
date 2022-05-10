using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable GetOfUsernameAndPassword(string username, string password)
        {
            var query = from acc in db.ACCOUNTs
                        where acc.USERNAME == username && acc.PASSWORD == password
                        select acc;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetForDisplay()
        {
            var query = from acc in db.ACCOUNTs
                       join nv in db.NHANVIENs
                       on acc.MANHANVIEN equals nv.MANHANVIEN
                       orderby nv.MANHANVIEN ascending
                       select new
                       {
                           nv.MANHANVIEN,
                           nv.TENNHANVIEN,
                           acc.USERNAME,
                           acc.PASSWORD,
                           acc.TYPE
                       };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool Add(NhanVienDTO dto)
        {
            try
            {
                string maNhanVien = TaoMaNhanVien();
                NHANVIEN insertNV = new NHANVIEN();
                insertNV.MANHANVIEN = maNhanVien;
                insertNV.TENNHANVIEN = dto.TenNhanVien;
                db.NHANVIENs.InsertOnSubmit(insertNV);
                
                ACCOUNT insertACC = new ACCOUNT();
                insertACC.USERNAME = dto.Username;
                insertACC.PASSWORD = dto.Password;
                insertACC.MANHANVIEN = maNhanVien;
                insertACC.TYPE = dto.Type;
                db.ACCOUNTs.InsertOnSubmit(insertACC);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(NhanVienDTO dto)
        {
            try
            {
                NHANVIEN editNV = db.NHANVIENs.Where(p => p.MANHANVIEN.Equals(dto.MaNhanVien)).SingleOrDefault();
                editNV.TENNHANVIEN = dto.TenNhanVien;
                ACCOUNT editACC = db.ACCOUNTs.Where(p => p.MANHANVIEN.Equals(dto.MaNhanVien)).SingleOrDefault();
                editACC.USERNAME = dto.Username;
                editACC.PASSWORD = dto.Password;
                editACC.TYPE = dto.Type;
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
                NHANVIEN deleteNV = db.NHANVIENs.Where(p => p.MANHANVIEN.Equals(str)).SingleOrDefault();
                ACCOUNT deleteACC = db.ACCOUNTs.Where(p => p.MANHANVIEN.Equals(str)).SingleOrDefault();
                db.NHANVIENs.DeleteOnSubmit(deleteNV);
                db.ACCOUNTs.DeleteOnSubmit(deleteACC);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable SearchOfMaNhanVien(string str)
        {
            string sqlQuery = string.Format("SELECT N.MANHANVIEN[Mã nhân viên], N.TENNHANVIEN[Tên nhân viên], " +
                "A.USERNAME[Username], A.PASSWORD[Password], A.TYPE[Loại nhân viên] " +
                "FROM NHANVIEN N INNER JOIN ACCOUNT A ON N.MANHANVIEN=A.MANHANVIEN " +
                "WHERE MANHANVIEN LIKE('%{0}%')", str);
            var query = from acc in db.ACCOUNTs
                        join nv in db.NHANVIENs
                        on acc.MANHANVIEN equals nv.MANHANVIEN
                        where System.Data.Linq.SqlClient.SqlMethods.Like(acc.MANHANVIEN, "%" + str + "%")
                        select new
                        {
                            nv.MANHANVIEN,
                            nv.TENNHANVIEN,
                            acc.USERNAME,
                            acc.PASSWORD,
                            acc.TYPE
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public DataTable GetAndSortDesc()
        {
            var query = from i in db.NHANVIENs
                        orderby i.MANHANVIEN descending
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        private string TaoMaNhanVien()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "NV000" + dt.Rows.Count;
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
            return "NV" + strSoKhong + count;
        }
    }
}
