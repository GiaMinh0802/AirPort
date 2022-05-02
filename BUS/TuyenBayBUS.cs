using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TuyenBayBUS
    {
        TuyenBayDAL dal = new TuyenBayDAL();

        public DataTable Get()
        {
            return dal.Get();
        }

        public DataTable GetOfMaTuyenBay(string str)
        {
            return dal.GetOfMaTuyenBay(str);
        }

        public DataTable GetOfMaSanBay(string maSBDi, string maSBDen)
        {
            return dal.GetOfMaSanBay(maSBDi, maSBDen);
        }

        public DataTable GetForDSTuyenBay()
        {
            return dal.GetForDSTuyenBay();
        }
    }
}
