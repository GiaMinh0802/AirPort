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
    public class CTChuyenBayBUS
    {
        CTChuyenBayDAL dal = new CTChuyenBayDAL();
        public DataTable GetForDisplayOfMaChuyenBay(string str)
        {
            return dal.GetForDisplayOfMaChuyenBay(str);
        }
        public bool Add(CTChuyenBayDTO dto)
        {
            return dal.Add(dto);
        }
        public bool Update(CTChuyenBayDTO dto)
        {
            return dal.Update(dto);
        }

        public bool Delete(CTChuyenBayDTO dto)
        {
            return dal.Delete(dto);
        }
    }
}
