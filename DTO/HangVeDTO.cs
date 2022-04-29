using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HangVeDTO
    {
        private string maHangVe;
        private string tenHangVe;
        public HangVeDTO()
        {
        }
        public HangVeDTO(string maHangVe, string tenHangVe)
        {
            this.maHangVe = maHangVe;
            this.tenHangVe = tenHangVe;
        }

        public string MaHangVe { get => maHangVe; set => maHangVe = value; }
        public string TenHangVe { get => tenHangVe; set => tenHangVe = value; }
    }
}
