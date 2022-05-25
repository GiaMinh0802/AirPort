using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoanhThuDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable GetOfThangNam(string strThang, string strNam)
        {
            var query = from i in db.CTDOANHTHUTHANGs
                        where i.THANG == strThang && i.NAM == strNam
                        select new
                        {
                            i.THANG,
                            i.NAM,
                            i.MACHUYENBAY,
                            i.SOVEBANDUOC,
                            i.DOANHTHU
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public DataTable GetOfNam(string strNam)
        {
            var query = from i in db.DOANHTHUTHANGs
                        where i.NAM == strNam
                        select new
                        {
                            i.THANG,
                            i.NAM,
                            i.SOCHUYENBAY,
                            i.DOANHTHU
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public DataTable GetOfNamDoanhThu()
        {
            var query = from i in db.DOANHTHUNAMs
                        select new
                        {
                            i.NAM,
                            i.DOANHTHU
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
    }
}
