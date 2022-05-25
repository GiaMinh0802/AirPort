using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DoanhThuBUS
    {
        DoanhThuDAL dal = new DoanhThuDAL();
        public DataTable GetOfNam(string strNam)
        {
            return dal.GetOfNam(strNam);
        }
        public DataTable GetOfThangNam(string strThang, string strNam)
        {
            return dal.GetOfThangNam(strThang, strNam);
        }
        public DataTable GetOfNamDoanhThu()
        {
            return dal.GetOfNamDoanhThu();
        }
    }
}
