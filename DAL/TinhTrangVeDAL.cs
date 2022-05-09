﻿using System;
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
    }
}