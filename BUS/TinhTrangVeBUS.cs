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
    public class TinhTrangVeBUS
    {
        TinhTrangVeDAL dal = new TinhTrangVeDAL();
        public string GetSoGheTrongOfMaChuyenBayAndMaHangVe(string maChuyenBay, string maHangVe)
        {
            return dal.GetSoGheTrongOfMaChuyenBayAndMaHangVe(maChuyenBay, maHangVe);
        }

        public DataTable GetForDisplayOfMaChuyenBay(string maChuyenBay)
        {
            return dal.GetForDisplayOfMaChuyenBay(maChuyenBay);
        }
        public bool Add(TinhTrangVeDTO dto)
        {
            return dal.Add(dto);
        }
        public bool Update(TinhTrangVeDTO dto)
        {
            return dal.Update(dto);
        }

        public bool Delete(TinhTrangVeDTO dto)
        {
            return dal.Delete(dto);
        }
        public bool UpdateBanVe(TinhTrangVeDTO dto)
        {
            return dal.UpdateBanVe(dto);
        }

    }
}
