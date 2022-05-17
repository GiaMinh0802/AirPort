using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TinhTrangVeDTO
    {
        private string maChuyenBay;
        private string maHangVe;
        private int tongSoGhe;
        private int soGheTrong;
        private string soDoGhe;

        public TinhTrangVeDTO(string maChuyenBay, string maHangVe, int tongSoGhe, int soGheTrong, string soDoGhe)
        {
            this.maChuyenBay = maChuyenBay;
            this.maHangVe = maHangVe;
            this.tongSoGhe = tongSoGhe;
            this.soGheTrong = soGheTrong;
            this.soDoGhe = soDoGhe;
        }

        public string MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string MaHangVe { get => maHangVe; set => maHangVe = value; }
        public int TongSoGhe { get => tongSoGhe; set => tongSoGhe = value; }
        public int SoGheTrong { get => soGheTrong; set => soGheTrong = value; }
        public string SoDoGhe { get => soDoGhe; set => soDoGhe = value; }
    }
}
