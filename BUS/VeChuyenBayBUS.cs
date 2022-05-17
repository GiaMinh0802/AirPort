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
    public class VeChuyenBayBUS
    {
        VeChuyenBayDAL dal = new VeChuyenBayDAL();

        public DataTable Get()
        {
            return dal.Get();
        }

        public DataTable GetForDisplay()
        {
            return dal.GetForDisplay();
        }

        public DataTable SearchOfSDT(string SDT)
        {
            return dal.SearchOfSDT(SDT);
        }

        public bool Add(VeChuyenBayDTO dto)
        {
            return dal.Add(dto);
        }
        public bool Delete(string maVe)
        {
            return dal.Delete(maVe);
        }
        public bool Update(string maVe, string txtvitri)
        {
            return dal.Update(maVe, txtvitri);
        }
    }
}
