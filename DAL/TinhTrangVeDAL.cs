using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TinhTrangVeDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public string GetSoGheTrongOfMaChuyenBayAndMaHangVe(string maChuyenBay, string maHangVe)
        {
            var query = from i in db.TINHTRANGVEs
                        where i.MACHUYENBAY == maChuyenBay && i.MAHANGVE == maHangVe
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            if (dt.Rows.Count != 0)
            {
                DataRow row = dt.Rows[0];
                return row["SOGHETRONG"].ToString();
            }
            else
            {
                return "0";
            }

        }
        public string GetSoDoGheByMaChuyenBayAndMaHangVe(string maChuyenBay, string maHangVe)
        {
            var query = from i in db.TINHTRANGVEs
                        where i.MACHUYENBAY == maChuyenBay && i.MAHANGVE == maHangVe
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            DataRow row = dt.Rows[0];
            return row["SODOGHE"].ToString();
        }
        public DataTable GetForDisplayOfMaChuyenBay(string maChuyenBay)
        {
            var query = from t in db.TINHTRANGVEs
                        join h in db.HANGVEs
                        on t.MAHANGVE equals h.MAHANGVE
                        where t.MACHUYENBAY == maChuyenBay
                        select new
                        {
                            TenHangVe = h.TENHANGVE,
                            TongSoGhe = t.TONGSOGHE,
                            SoGheTrong = t.SOGHETRONG
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool Add(TinhTrangVeDTO dto)
        {
            try
            {
                TINHTRANGVE insert = new TINHTRANGVE();
                insert.MACHUYENBAY = dto.MaChuyenBay;
                insert.MAHANGVE = dto.MaHangVe;
                insert.TONGSOGHE = dto.TongSoGhe;
                insert.SOGHETRONG = dto.SoGheTrong;
                db.TINHTRANGVEs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(TinhTrangVeDTO dto)
        {
            try
            {
                TINHTRANGVE edit = db.TINHTRANGVEs.Where(p => p.MACHUYENBAY.Equals(dto.MaChuyenBay) && p.MAHANGVE.Equals(dto.MaHangVe)).SingleOrDefault();
                edit.TONGSOGHE = dto.TongSoGhe;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(TinhTrangVeDTO dto)
        {
            try
            {
                TINHTRANGVE delete = db.TINHTRANGVEs.Where(p => p.MACHUYENBAY.Equals(dto.MaChuyenBay) && p.MAHANGVE.Equals(dto.MaHangVe)).SingleOrDefault();
                db.TINHTRANGVEs.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateBanVe(TinhTrangVeDTO dto)
        {
            try
            {
                TINHTRANGVE edit = db.TINHTRANGVEs.Where(p => p.MACHUYENBAY.Equals(dto.MaChuyenBay) && p.MAHANGVE.Equals(dto.MaHangVe)).SingleOrDefault();
                edit.SOGHETRONG = dto.SoGheTrong;
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
