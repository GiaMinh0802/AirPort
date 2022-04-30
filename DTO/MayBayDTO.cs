using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MayBayDTO
    {
        private string maMayBay;
        private string tenMayBay;
        private int soLuongGhe;
        public MayBayDTO()
        {
        }
        public MayBayDTO(string maMayBay, string tenMayBay, int soLuongGhe)
        {
            this.maMayBay = maMayBay;
            this.TenMayBay = tenMayBay;
            this.SoLuongGhe = soLuongGhe;
        }


        public string MaMayBay { get => maMayBay; set => maMayBay = value; }
        public string TenMayBay { get => tenMayBay; set => tenMayBay = value; }
        public int SoLuongGhe { get => soLuongGhe; set => soLuongGhe = value; }
    }
}
