using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private string maNhanVien;
        private string tenNhanVien;
        private string username;
        private string password;
        private int type;
        public NhanVienDTO()
        {
        }

        public NhanVienDTO(string maNhanVien, string tenNhanVien, string username, string password, int type)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            Username = username;
            Password = password;
            Type = type;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Type { get => type; set => type = value; }
    }
}
