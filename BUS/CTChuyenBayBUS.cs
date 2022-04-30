using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CTChuyenBayBUS
    {
        CTChuyenBayDAL dal = new CTChuyenBayDAL();
        public DataTable GetForDisplayOfMaChuyenBay(string str)
        {
            return dal.GetForDisplayOfMaChuyenBay(str);
        }
    }
}
