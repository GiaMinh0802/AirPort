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
    public class ThamSoBUS
    {
        ThamSoDAL dal = new ThamSoDAL();
        public DataTable Get()
        {
            return dal.Get();
        }
        public bool Update(ThamSoDTO dto)
        {
            return dal.Update(dto);
        }
    }
}
