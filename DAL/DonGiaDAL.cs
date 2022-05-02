using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonGiaDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable SearchOfMaTuyenBayAndMaHangVe(string maTuyenBay, string maHangVe)
        {
            var query = from g in db.DONGIAs
                        where g.MATUYENBAY == maTuyenBay && g.MAHANGVE == maHangVe
                        select g;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetForDisplay()
        {
            var query = from i in db.DONGIAs
                        select new
                        {
                            i.MATUYENBAY,
                            i.MAHANGVE,
                            i.DONGIA1
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
    }
}
