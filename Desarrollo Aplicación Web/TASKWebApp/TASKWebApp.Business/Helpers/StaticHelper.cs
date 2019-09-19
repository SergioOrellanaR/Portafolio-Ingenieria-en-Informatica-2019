using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWebApp.Business.Helpers
{
    public class StaticHelper
    {
        public static short? BoolToShort(bool? value)
        {
            short? returnValue = null;
            switch(value)
            {
                case false:
                    returnValue = 0;
                    break;
                case true:
                    returnValue = 1;
                    break;
            }
            return returnValue;
        }

        public static short BoolToShort(bool value)
        {
            return (short)(value ? 1 : 0);
        }

        public static bool? ShortToBool(short? value)
        {
            bool? returnValue = null;

            switch (value)
            {
                case 0:
                    returnValue = false;
                    break;
                case 1:
                    returnValue = true;
                    break;
            }
            return returnValue;

        }

        public static bool ShortToBool(short value)
        {
            return (value == 1 ? true : false);
        }
    }
}
