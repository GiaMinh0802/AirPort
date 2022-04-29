using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HangVeBUS
    {
        HangVeDAL dal = new HangVeDAL();
        public DataTable Get()
        {
            return dal.Get();
        }
    }
}
