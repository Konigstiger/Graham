using System;
using System.Collections.Generic;

namespace Graham.Models
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            PortfolioSecurity = new HashSet<PortfolioSecurity>();
        }

        public int IdPortfolio { get; set; }
        public int IdHolder { get; set; }
        public int IdCurrency { get; set; }

        public Holder IdHolderNavigation { get; set; }
        public ICollection<PortfolioSecurity> PortfolioSecurity { get; set; }
    }
}
