using System;
using System.Collections.Generic;

namespace Graham.Models
{
    public partial class Market
    {
        public Market()
        {
            Security = new HashSet<Security>();
        }

        public int IdMarket { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }

        public ICollection<Security> Security { get; set; }
    }
}
