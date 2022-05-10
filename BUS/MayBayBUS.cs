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
    public class MayBayBUS
    {
        MayBayDAL dal = new MayBayDAL();

        public DataTable Get()
        {
            return dal.Get();
        }

        public DataTable GetForDisplay()
        {
            return dal.GetForDisplay();
        }
        public bool Add(MayBayDTO dto)
        {
            return dal.Add(dto);
        }
        public bool Update(MayBayDTO dto)
        {
            return dal.Update(dto);
        }

        public bool Delete(string str)
        {
            return dal.Delete(str);
        }
        public DataTable SearchOfMaMayBay(string str)
        {
            return dal.SearchOfMaMayBay(str);
        }
    }
}
