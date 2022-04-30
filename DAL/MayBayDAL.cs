using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MayBayDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable Get()
        {
            var query = from i in db.MAYBAYs
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
    }
}
