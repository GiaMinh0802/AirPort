using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TuyenBayDAL
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        public DataTable Get()
        {
            var query = from i in db.TUYENBAYs
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetOfMaTuyenBay(string str)
        {
            var query = from t in db.TUYENBAYs
                        join s1 in db.SANBAYs
                        on t.MASANBAYDI equals s1.MASANBAY
                        join s2 in db.SANBAYs
                        on t.MASANBAYDEN equals s2.MASANBAY
                        where t.MATUYENBAY == str
                        select new
                        {
                            t.MATUYENBAY,
                            MaSanBayDi = s1.MASANBAY,
                            TenSanBayDi = s1.TENSANBAY,
                            MaSanBayDen = s2.MASANBAY,
                            TenSanBayDen = s2.TENSANBAY,
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetOfMaSanBay(string maSBDi, string maSBDen)
        {
            var query = from i in db.TUYENBAYs
                        where i.MASANBAYDI == maSBDi && i.MASANBAYDEN == maSBDen
                        select i;
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }

        public DataTable GetForDSTuyenBay()
        {
            var query = from t in db.TUYENBAYs
                        join s1 in db.SANBAYs
                        on t.MASANBAYDI equals s1.MASANBAY
                        join s2 in db.SANBAYs
                        on t.MASANBAYDEN equals s2.MASANBAY
                        select new
                        {
                            t.MATUYENBAY,
                            TenSanBayDi = s1.TENSANBAY,
                            TenSanBayDen = s2.TENSANBAY,
                        };
            DataTable dt = cv.LINQResultToDataTable(query);
            return dt;
        }
    }
}
