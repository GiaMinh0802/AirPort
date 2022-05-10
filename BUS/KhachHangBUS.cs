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
    public class KhachHangBUS
    {
        KhachHangDAL dal = new KhachHangDAL();
        public DataTable GetOfCMND(string maKhachHang)
        {
            return dal.GetOfCMND(maKhachHang);
        }

        public DataTable GetForDisplay()
        {
            return dal.GetForDisplay();
        }
        public bool Add(KhachHangDTO dto)
        {
            return dal.Add(dto);
        }
        public bool Update(KhachHangDTO dto)
        {
            return dal.Update(dto);
        }
        public bool Delete(string str)
        {
            return dal.Delete(str);
        }
        public DataTable SearchOfMaKhachHang(string str)
        {
            return dal.SearchOfMaKhachHang(str);
        }
    }
}
