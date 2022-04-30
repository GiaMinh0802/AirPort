using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CTChuyenBayDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable GetForDisplayOfMaChuyenBay(string str)
        {
            string sqlQuery = string.Format("SELECT S.TENSANBAY[Tên sân bay], " +
                "C.THOIGIANDUNG[Thời gian dừng],C.GHICHU[Ghi chú] FROM CTCHUYENBAY C " +
                "INNER JOIN SANBAY S ON C.MASANBAYTG=S.MASANBAY WHERE C.MACHUYENBAY='{0}'", str);
            var query = from c in db.CTCHUYENBAYs
                        join s in db.SANBAYs
                        on c.MASANBAYTG equals s.MASANBAY
                        where c.MACHUYENBAY == str
                        select new
                        {
                            s.TENSANBAY, 
                            c.THOIGIANDUNG,
                            c.GHICHU
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

    }
}
