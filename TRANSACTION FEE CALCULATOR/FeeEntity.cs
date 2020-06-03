using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRANSACTION_FEE_CALCULATOR
{
    class FeeEntity
    {
        public decimal minAmount { get; set; }
        public decimal maxAmount { get; set; }
        public decimal feeAmount { get; set; }
    }
}
