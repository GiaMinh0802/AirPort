using DAL;
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
    }
}
