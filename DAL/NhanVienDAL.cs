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
            var dtAcc = from acc in db.ACCOUNTs
                        where acc.USERNAME == username && acc.PASSWORD == password
                        select acc;
            DataTable dt = cv.LINQResultToDataTable(dtAcc);
            return dt;
        }
    }
}
