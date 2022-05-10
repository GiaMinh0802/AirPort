using DAL;
using DTO;
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

        public DataTable GetForDisplay()
        {
            return dal.GetForDisplay();
        }
        public bool Add(DonGiaDTO dto)
        {
            return dal.Add(dto);
        }
        public bool Update(DonGiaDTO dto)
        {
            return dal.Update(dto);
        }
        public bool Delete(DonGiaDTO dto)
        {
            return dal.Delete(dto);
        }
        public DataTable SearchOfMaTuyenBayAndMaHangVe(string maTuyenBay, string maHangVe)
        {
            return dal.SearchOfMaTuyenBayAndMaHangVe(maTuyenBay, maHangVe);
        }
        public DataTable SearchOfMaTuyenBay(string maTuyenBay)
        {
            return dal.SearchOfMaTuyenBay(maTuyenBay);
        }
    }
}
