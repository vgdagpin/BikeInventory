using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory
{
    public static class GuidExtensions
    {
        private static readonly int[] guidByteOrder = new[] { 15, 14, 13, 12, 11, 10, 9, 8, 6, 7, 4, 5, 0, 1, 2, 3 };
        public static Guid Increment(this Guid guid)
        {
            var bytes = guid.ToByteArray();
            bool carry = true;
            for (int i = 0; i < guidByteOrder.Length && carry; i++)
            {
                int index = guidByteOrder[i];
                byte oldValue = bytes[index]++;
                carry = oldValue > bytes[index];
            }
            return new Guid(bytes);
        }

        public static Guid Increment(this Guid guid, int by)
        {
            var g = guid;

            for (int i = 0; i < by; i++)
            {
                g = g.Increment();
            }

            return g;
        }

        public static string ToBase64(this Guid guid) => Convert.ToBase64String(Encoding.ASCII.GetBytes(guid.ToString()));
    }
}
