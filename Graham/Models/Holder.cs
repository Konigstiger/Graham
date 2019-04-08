using System;
using System.Collections.Generic;

namespace Graham.Models
{
    public partial class Holder
    {
        public Holder()
        {
            Portfolio = new HashSet<Portfolio>();
        }

        public int IdHolder { get; set; }
        public string Denomination { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public ICollection<Portfolio> Portfolio { get; set; }
    }
}
