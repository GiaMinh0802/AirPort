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
        public DataTable GetOfCMND(string CMND)
        {
            var query = from i in db.KHACHHANGs
                        where i.CMND == CMND
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

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
    }
}
