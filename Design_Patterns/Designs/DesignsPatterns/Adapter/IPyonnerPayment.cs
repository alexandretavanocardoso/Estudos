using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    interface IPyonnerPayment
    {
        Token AuthToken();
        void SendPayment();
        void ReceivePayment();
    }
}
