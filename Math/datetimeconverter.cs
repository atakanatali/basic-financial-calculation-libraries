using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubcornTakip.Math
{
    public class datetimeconverter
    {
        public DateTime ConvertToDateTime(string date)




        {
            DateTime isdate = DateTime.Now.Date;
            string dates = date;
            string[] a = date.Split('.');
            dates = a[2].Substring(0,4) + "-" + a[0] + "-" + a[1];
            isdate = DateTime.Parse(dates);
            return isdate;
        }
    }
}