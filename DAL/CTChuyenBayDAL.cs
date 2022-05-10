using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CTChuyenBayDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable GetForDisplayOfMaChuyenBay(string str)
        {
            string sqlQuery = string.Format("SELECT S.TENSANBAY[Tên sân bay], " +
                "C.THOIGIANDUNG[Thời gian dừng],C.GHICHU[Ghi chú] FROM CTCHUYENBAY C " +
                "INNER JOIN SANBAY S ON C.MASANBAYTG=S.MASANBAY WHERE C.MACHUYENBAY='{0}'", str);
            var query = from c in db.CTCHUYENBAYs
                        join s in db.SANBAYs
                        on c.MASANBAYTG equals s.MASANBAY
                        where c.MACHUYENBAY == str
                        select new
                        {
                            s.TENSANBAY, 
                            c.THOIGIANDUNG,
                            c.GHICHU
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool Add(CTChuyenBayDTO dto)
        {
            try
            {
                CTCHUYENBAY insert = new CTCHUYENBAY();
                insert.MACHUYENBAY = dto.MaChuyenBay;
                insert.MASANBAYTG = dto.MaSanBayTG;
                insert.THOIGIANDUNG = dto.ThoiGianDung;
                insert.GHICHU = dto.GhiChu;
                db.CTCHUYENBAYs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(CTChuyenBayDTO dto)
        {
            try
            {
                CTCHUYENBAY edit = db.CTCHUYENBAYs.Where(p => p.MACHUYENBAY.Equals(dto.MaChuyenBay) && p.MASANBAYTG.Equals(dto.MaSanBayTG)).SingleOrDefault();
                edit.THOIGIANDUNG = dto.ThoiGianDung;
                edit.GHICHU = dto.GhiChu;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(CTChuyenBayDTO dto)
        {
            try
            {
                CTCHUYENBAY delete = db.CTCHUYENBAYs.Where(p => p.MACHUYENBAY.Equals(dto.MaChuyenBay) && p.MASANBAYTG.Equals(dto.MaSanBayTG)).SingleOrDefault();
                db.CTCHUYENBAYs.DeleteOnSubmit(delete);
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
