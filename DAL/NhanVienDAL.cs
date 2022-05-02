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
    }
}
