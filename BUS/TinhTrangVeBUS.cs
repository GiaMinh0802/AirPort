using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TinhTrangVeBUS
    {
        TinhTrangVeDAL dal = new TinhTrangVeDAL();
        public string GetSoGheTrongOfMaChuyenBayAndMaHangVe(string maChuyenBay, string maHangVe)
        {
            return dal.GetSoGheTrongOfMaChuyenBayAndMaHangVe(maChuyenBay, maHangVe);
        }
    }
}
