using System;
using System.Collections.Generic;

namespace DL.Models
{
    public partial class Hinhanh
    {
        public Hinhanh()
        {
            Baivietdulich = new HashSet<Baivietdulich>();
        }

        public string HaMa { get; set; }
        public string HaUrl { get; set; }

        public virtual ICollection<Baivietdulich> Baivietdulich { get; set; }
    }
}
