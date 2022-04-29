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
            var dtHangVe = from i in db.HANGVEs 
                           select i;
            DataTable dt = cv.LINQResultToDataTable(dtHangVe);
            return dt;
        }
    }
}
