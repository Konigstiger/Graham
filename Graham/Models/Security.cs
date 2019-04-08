using System;
using System.Collections.Generic;

namespace Graham.Models
{
    public partial class Security
    {
        public Security()
        {
            PortfolioSecurity = new HashSet<PortfolioSecurity>();
        }

        public int IdSecurity { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }
        public int IdMarket { get; set; }
        public string Notes { get; set; }
        public decimal? CurrentPrice { get; set; }

        public Market IdMarketNavigation { get; set; }
        public ICollection<PortfolioSecurity> PortfolioSecurity { get; set; }
    }
}
