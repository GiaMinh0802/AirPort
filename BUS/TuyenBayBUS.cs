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
    public class TuyenBayBUS
    {
        TuyenBayDAL dal = new TuyenBayDAL();

        public DataTable Get()
        {
            return dal.Get();
        }

        public DataTable GetOfMaTuyenBay(string str)
        {
            return dal.GetOfMaTuyenBay(str);
        }

        public DataTable GetOfMaSanBay(string maSBDi, string maSBDen)
        {
            return dal.GetOfMaSanBay(maSBDi, maSBDen);
        }

        public DataTable GetForDSTuyenBay()
        {
            return dal.GetForDSTuyenBay();
        }
        public bool Add(TuyenBayDTO dto)
        {
            return dal.Add(dto);
        }
        public bool Update(TuyenBayDTO dto)
        {
            return dal.Update(dto);
        }

        public bool Delete(string str)
        {
            return dal.Delete(str);
        }
        public DataTable SearchOfMaTuyenBay(string maTuyenBay)
        {
            return dal.SearchOfMaTuyenBay(maTuyenBay);
        }
    }
}
