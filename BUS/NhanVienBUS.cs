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
    public class NhanVienBUS
    {
        NhanVienDAL dal = new NhanVienDAL();
        public DataTable GetOfUsernameAndPassword(string username, string password)
        {
            return dal.GetOfUsernameAndPassword(username, password);
        }

        public DataTable GetForDisplay()
        {
            return dal.GetForDisplay();
        }
        public bool Add(NhanVienDTO dto)
        {
            return dal.Add(dto);
        }
        public bool Update(NhanVienDTO dto)
        {
            return dal.Update(dto);
        }

        public bool Delete(string str)
        {
            return dal.Delete(str);
        }
        public DataTable SearchOfMaNhanVien(string str)
        {
            return dal.SearchOfMaNhanVien(str);
        }
    }
}
