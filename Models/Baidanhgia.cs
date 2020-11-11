using System;
using System.Collections.Generic;

namespace DL.Models
{
    public partial class Baidanhgia
    {
        public Baidanhgia()
        {
            Baivietdulich = new HashSet<Baivietdulich>();
        }

        public string BdgMa { get; set; }
        public string BdgNoidung { get; set; }
        public string TkBdg { get; set; }

        public virtual Taikhoan TkBdgNavigation { get; set; }
        public virtual ICollection<Baivietdulich> Baivietdulich { get; set; }
    }
}
