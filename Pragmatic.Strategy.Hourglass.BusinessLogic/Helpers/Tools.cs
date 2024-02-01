using Pragmatic.Common.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pragmatic.Strategy.Hourglass.BusinessLogic.Helpers
{
    public static class Tools
    {
        private static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);

        public static int ConvertDateTimeToEpochInt(DateTime inDate)
        {
            if (inDate == DateTime.MinValue)
            {
                return -1;
            }

            TimeSpan span = (inDate - UnixEpoch);
            return (int)Math.Floor(span.TotalSeconds);
        }

        public static DateTime ConvertEpochIntDateTime(int unixTime)
        {

            if (unixTime < 0)
            {
                return DateTime.MinValue;
            }
            return UnixEpoch.AddSeconds(unixTime);
        }
    }

   
}
