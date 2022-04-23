using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    interface IPaypalPayment
    {
        Token authToken();
        void payPalPayment();
        void payPalReceive();
    }
}
