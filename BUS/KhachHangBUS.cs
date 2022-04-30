using DAL;
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
    }
}
