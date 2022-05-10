using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThamSoDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();

        public DataTable Get()
        {
            var query = from i in db.THAMSOs
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool Update(ThamSoDTO dto)
        {
            try
            {
                THAMSO edit = db.THAMSOs.First();
                edit.THOIGIANBAYTOITHIEU = dto.ThoiGianBayToiThieu;
                edit.SOSANBAYTGTOIDA = dto.SoSanBayTGToiDa;
                edit.THOIGIANDUNGTOITHIEU = dto.ThoiGianDungToiThieu;
                edit.THOIGIANDUNGTOIDA = dto.ThoiGianDungToiDa;
                edit.TGCHAMNHATDATVE = Convert.ToInt32(dto.ThoiGianChamNhatDatVe);
                edit.TGCHAMNHATHUYDATVE = Convert.ToInt32(dto.ThoiGianChamNhatHuyVe);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
