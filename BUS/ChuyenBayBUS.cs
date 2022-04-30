using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChuyenBayBUS
    {
        ChuyenBayDAL dal = new ChuyenBayDAL();
        public DataTable Get()
        {
            return dal.Get();
        }

        public DataTable GetToDisplay()
        {
            return dal.GetToDisplay();
        }

        public DataTable GetOfMaChuyenBay(string maChuyenBay)
        {
            return dal.GetOfMaChuyenBay(maChuyenBay);
        }

        public DataTable Search(string maSanBayDi, string maSanBayDen, DateTime ngayKHTu, DateTime ngayKHDen)
        {
            return dal.Search(maSanBayDi, maSanBayDen, ngayKHTu, ngayKHDen);
        }
    }
}
