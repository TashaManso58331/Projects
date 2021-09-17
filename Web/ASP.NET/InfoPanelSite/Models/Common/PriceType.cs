using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPanelModels.Common
{
    public enum PriceType
    {
        NotSet = 0,
        GasStationPrice = 1,
        IssuerPublicPrice = 2,
        IssuerSpecialPrice = 3,
        SellerDirectPrice = 4,
        SellerSpecialPrice = 5
    }
}
