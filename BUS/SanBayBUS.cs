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
    public class SanBayBUS
    {
        SanBayDAL dal = new SanBayDAL();

        public DataTable Get()
        {
            return dal.Get();
        }

        public DataTable GetForDisplay()
        {
            return dal.GetForDisplay();
        }
        public bool Add(SanBayDTO dto)
        {
            return dal.Add(dto);
        }
        public bool Update(SanBayDTO dto)
        {
            return dal.Update(dto);
        }
        public bool Delete(string str)
        {
            return dal.Delete(str);
        }
        public DataTable SearchOfMaSanBay(string maSanBay)
        {
            return dal.SearchOfMaSanBay(maSanBay);
        }
        public bool CheckSanBay(string tenSanBay, string tenThanhPho)
        {
            return dal.CheckSanBay(tenSanBay, tenThanhPho);
        }
    }
}
