using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonGiaDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();

        public DataTable GetForDisplay()
        {
            var query = from i in db.DONGIAs
                        orderby i.MATUYENBAY ascending
                        select new
                        {
                            i.MATUYENBAY,
                            i.MAHANGVE,
                            i.DONGIA1
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public bool Add(DonGiaDTO dto)
        {
            try
            {
                DONGIA insert = new DONGIA();
                insert.MATUYENBAY = dto.MaTuyenBay;
                insert.MAHANGVE = dto.MaHangVe;
                insert.DONGIA1 = dto.DonGia;
                db.DONGIAs.InsertOnSubmit(insert);
                db.SubmitChanges();
                return true;    
            }
            catch
            {
                return false;
            }   
        }
        public bool Update(DonGiaDTO dto)
        {
            try
            {
                DONGIA edit = db.DONGIAs.Where(p => p.MATUYENBAY.Equals(dto.MaTuyenBay) && p.MAHANGVE.Equals(dto.MaHangVe)).SingleOrDefault();
                edit.DONGIA1 = dto.DonGia;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(DonGiaDTO dto)
        {
            try
            {
                DONGIA delete = db.DONGIAs.Where(p => p.MATUYENBAY.Equals(dto.MaTuyenBay) && p.MAHANGVE.Equals(dto.MaHangVe)).SingleOrDefault();
                db.DONGIAs.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable SearchOfMaTuyenBayAndMaHangVe(string maTuyenBay, string maHangVe)
        {
            var query = from g in db.DONGIAs
                        where g.MATUYENBAY == maTuyenBay && g.MAHANGVE == maHangVe
                        select g;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
        public DataTable SearchOfMaTuyenBay(string maTuyenBay)
        {
            var query = from g in db.DONGIAs
                        where System.Data.Linq.SqlClient.SqlMethods.Like(g.MATUYENBAY, "%" + maTuyenBay + "%")
                        select new
                        {
                            g.MATUYENBAY,
                            g.MAHANGVE,
                            g.DONGIA1
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
    }
}
