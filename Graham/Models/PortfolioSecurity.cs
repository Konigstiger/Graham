using System;
using System.Collections.Generic;

namespace Graham.Models
{
    public partial class PortfolioSecurity
    {
        public long IdPortfolioSecurity { get; set; }
        public int IdPortfolio { get; set; }
        public int IdSecurity { get; set; }
        public int Quantity { get; set; }

        public Portfolio IdPortfolioNavigation { get; set; }
        public Security IdSecurityNavigation { get; set; }
    }
}
