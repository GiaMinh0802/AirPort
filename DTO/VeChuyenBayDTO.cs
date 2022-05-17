using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VeChuyenBayDTO
    {
        private string maVe;
        private string maKhachHang;
        private string maChuyenBay;
        private string maHangVe;
        private string maNhanVien;
        private decimal giaTien;
        private DateTime ngayGioGD;
        private DateTime ngayHuy;
        private string loaiVe;
        private string veghe;
        private int kygui;

        public VeChuyenBayDTO(string maVe, string maKhachHang, string maChuyenBay, string maHangVe, string maNhanVien, decimal giaTien, DateTime ngayGioGD, DateTime ngayHuy, string loaiVe, string veghe, int kygui)
        {
            this.maVe = maVe;
            this.maKhachHang = maKhachHang;
            this.maChuyenBay = maChuyenBay;
            this.maHangVe = maHangVe;
            this.maNhanVien = maNhanVien;
            this.giaTien = giaTien;
            this.ngayGioGD = ngayGioGD;
            this.ngayHuy = ngayHuy;
            this.loaiVe = loaiVe;
            this.veghe = veghe;
            this.kygui = kygui;
        }

        public string MaVe { get => maVe; set => maVe = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string MaHangVe { get => maHangVe; set => maHangVe = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public decimal GiaTien { get => giaTien; set => giaTien = value; }
        public DateTime NgayGioGD { get => ngayGioGD; set => ngayGioGD = value; }
        public DateTime NgayHuy { get => ngayHuy; set => ngayHuy = value; }
        public string LoaiVe { get => loaiVe; set => loaiVe = value; }
        public string VeGhe { get => veghe; set => veghe = value; }
        public int Kygui { get => kygui; set => kygui = value; }
    }
}
