using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DonGiaBUS
    {
        DonGiaDAL dal = new DonGiaDAL();
        public DataTable SearchOfMaTuyenBayAndMaHangVe(string maTuyenBay, string maHangVe)
        {
            return dal.SearchOfMaTuyenBayAndMaHangVe(maTuyenBay, maHangVe);
        }

        public DataTable GetForDisplay()
        {
            return dal.GetForDisplay();
        }
    }
}
