using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleBreakdownRecor.Business.Exceptions
{
    public class ClientSideException:Exception
    {
        public ClientSideException(string message):base(message)
        {

        }
    }
}
