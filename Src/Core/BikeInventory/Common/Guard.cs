using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory
{
    public static class Guard
    {
        public static void ThrowIfNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentException(argumentName);
            }
        }
    }
}
