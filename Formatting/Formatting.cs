using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubcornTakip.App_Start;
using SubcornTakip.Models;

namespace SubcornTakip.Formatting
{
    [MyCustomFilter]
    public class Formatting : Controller
    {
        SubcornTakipEntities db = new SubcornTakipEntities();

        public DateTime ConvertDateTimeFromUTC(DateTime convertedDateTime, string fromtimezone, string totimezone) //iki zone arasındaki saat farkını buulup yeni tarih çıkarmak
        {
            //totimezone = sunucu
            //fromtimezone = kullanıcı
            //totimezone = TimeZoneInfo.Local.Id;
            ReadOnlyCollection<TimeZoneInfo> tzi;
            //DateTimeOffset fromdatetime;
            tzi = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo timeZone in tzi)
            {
                if (timeZone.Id == fromtimezone && fromtimezone != totimezone)
                {
                    convertedDateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(convertedDateTime, totimezone, fromtimezone);

                }


            }
            return convertedDateTime;
        }
        public List<timezone> GetTimeZones()
        {
            ReadOnlyCollection<TimeZoneInfo> tzi;
            List<timezone> tzz = new List<timezone>();
            tzi = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo timeZone in tzi)
            {
                timezone ntzzz = new timezone();
                ntzzz.timezoneid = timeZone.Id;
                ntzzz.timezonename = timeZone.DisplayName;
                tzz.Add(ntzzz);
            }
            return tzz;
        } //zone listesi

        public List<countries> GetCountries()
        {
            List<string> cultureList = new List<string>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);

            foreach (CultureInfo culture in cultures)
            {
                if (culture.LCID != 127)
                {
                    try
                    {
                        RegionInfo region = new RegionInfo(culture.LCID);
                        //RegionInfo region = new RegionInfo(culture.LCID);

                        if (!(cultureList.Contains(region.EnglishName)))
                        {
                            cultureList.Add(region.EnglishName);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    
                }
            }

            cultureList.Sort(); //put the country list in alphabetic order.

            List<countries> clist = new List<countries>();
            foreach (var item in cultureList)
            {
                countries newc = new countries();
                newc.Name = item;
                clist.Add(newc);
            }
            return clist;
        }

        public string GetNumberFormat(string culture)
        {
            string format = "";
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo(culture, false).NumberFormat;
            string decimalsepperator = nfi.NumberDecimalSeparator.ToString();
            string groupsepperator = nfi.CurrencyGroupSeparator.ToString();
            int decimaldigitcount = nfi.NumberDecimalDigits;
            string decimaldigits = "";
            for (int i = 1; i <= decimaldigitcount; i++)
            {
                decimaldigits += "0";
            }
            format = "#" + groupsepperator + "##0" + decimalsepperator + decimaldigits;
            return format;
        }
        public char GetDecimalSeperator(string culture)
        {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo(culture, false).NumberFormat;
            char decimalsepperator = Convert.ToChar(nfi.NumberDecimalSeparator);
            return decimalsepperator;
        }
        public char GetGroupSeperator(string culture)
        {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo(culture, false).NumberFormat;
            char groupsepperator = Convert.ToChar(nfi.CurrencyGroupSeparator);
            return groupsepperator;
        }
        public string GetPercentageFormat(string culture)
        {
            string format = "";
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo(culture, false).NumberFormat;
            string decimalsepperator = nfi.NumberDecimalSeparator.ToString();
            string groupsepperator = nfi.CurrencyGroupSeparator.ToString();
            int decimaldigitcount = nfi.NumberDecimalDigits;
            string decimaldigits = "";
            for (int i = 1; i <= decimaldigitcount; i++)
            {
                decimaldigits += "0";
            }
            format = "###" + decimalsepperator + "##";
            return format;
        }
        public bool CheckUniqueConditionInvoiceSettings(string company)
        {
            bool status = true;
            var compa = db.Tbl_Companies.Where(p => p.IsActive == true && p.CompanyName == company).SingleOrDefault();
            if (compa.CompaniyMailVerify == false)
            {
                status = false;
            }
            if (compa.LastUpdateLogo50XUrl == null && compa.LastUpdateLogo50XUrl == "https://saas.wremia.com/assets/img/avatar/briefcase.png")
            {
                status = false;
            }
            if (compa.CompanyAdress == null && compa.CompanyAdress == "No Adress")
            {
                status = false;
            }
            if (compa.CompanyTel == null && compa.CompanyTel == "No Phone")
            {
                status = false;
            }
            return status;
        }
        public string GetCurrencyFormat(string culture)
        {
            string format = "";
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo(culture, false).NumberFormat;
            string decimalsepperator = nfi.CurrencyDecimalSeparator.ToString();
            string groupsepperator = nfi.CurrencyGroupSeparator.ToString();
            int decimaldigitcount = nfi.CurrencyDecimalDigits;
            string decimaldigits = "";
            for (int i = 1; i < decimaldigitcount; i++)
            {
                decimaldigits += "0";
            }
            format = "#" + groupsepperator + "##0" + decimalsepperator + decimaldigits;
            return format;
        }

        public string GetDateFormat(string culture)
        {
            string format = "";
            System.Globalization.DateTimeFormatInfo dfi = new System.Globalization.CultureInfo(culture, false).DateTimeFormat;
            format = dfi.ShortDatePattern;
            return format;
        }
        public string GetTimeFormat(string culture)
        {
            string format = "";
            System.Globalization.DateTimeFormatInfo dfi = new System.Globalization.CultureInfo(culture, false).DateTimeFormat;
            format = dfi.ShortTimePattern;
            return format;
        }

        public string GetCurrencySymbol(string culture)
        {
            string symbol = "";
            System.Globalization.RegionInfo rfi = new System.Globalization.RegionInfo(culture);
            symbol = rfi.CurrencySymbol;
            return symbol;
        }
        public string GetCurrencySymbolISO(string culture)
        {
            string symbol = "";
            System.Globalization.RegionInfo rfi = new System.Globalization.RegionInfo(culture);
            symbol = rfi.ISOCurrencySymbol;
            return symbol;
        }
        public List<Tbl_Taxs> GetTaxs(string compa)
        {
            var taxs = db.Tbl_Taxs.Where(p => p.IsActive == true && p.Company == compa).ToList();
            return taxs;
        }

        public List<fxs> GetFXs(string CentralBank)
        {
            List<fxs> lfxs = new List<fxs>();
            switch (CentralBank)
            {
                case "Europan Central Bank":
                    string[] fx = {"EUR","TRY", "USD", "GPB", "RUB", "JPY", "DKK", "PLN", "SEK", "RON", "CHK", "HRK", "AUD", "CAD", "HKD", "ILS", "MXN", "NZD", "SGD", "ZAR" };
                    for (int i = 0; i < fx.Length; i++)
                    {
                        fxs newfx = new fxs();
                        newfx.Name = fx[i];
                        lfxs.Add(newfx);
                    }
                    break;
                case "American-LiveRates":
                    string[] fxusa = { "EUR", "TRY", "USD", "GPB", "RUB", "JPY", "DKK", "PLN", "SEK", "RON", "CHK", "HRK", "AUD", "CAD", "HKD", "ILS", "MXN", "NZD", "SGD", "ZAR" };
                    for (int i = 0; i < fxusa.Length; i++)
                    {
                        fxs newfx = new fxs();
                        newfx.Name = fxusa[i];
                        lfxs.Add(newfx);
                    }
                    break;
                case "Turkish Central Bank":
                    string[] fxtr = { "EUR", "TRY", "USD", "GPB", "RUB", "JPY", "DKK", "SEK", "CHK", "AUD", "CAD"};
                    for (int i = 0; i < fxtr.Length; i++)
                    {
                        fxs newfx = new fxs();
                        newfx.Name = fxtr[i];
                        lfxs.Add(newfx);
                    }
                    break;
                default:
                    break;
            }

            return lfxs;
        }

        public bool CheckUnique(string unique,string value,string company)
        {
            bool status = true;
            switch (unique)
            {
                case "mail":
                    var mailisvalid = db.Tbl_SubconUsers.Where(p => p.SubconUserMail == value).SingleOrDefault();
                    if (mailisvalid != null)
                    {
                        status = false;
                    }
                    break;
                case "username":
                    var usernameisvalid = db.Tbl_SubconUsers.Where(p => p.SubronUserName == value).SingleOrDefault();
                    if (usernameisvalid != null)
                    {
                        status = false;
                    }
                    break;
                case "account":
                    if (value == "61" || value == "656" || value == "646")
                    {
                        status = false;
                    }
                    else
                    {
                        var accountisvalid = db.Tbl_Accounting.Where(p => p.AccountingHesapKodu == value && p.AccountingIsActive == true && p.AccountingCompa == company).SingleOrDefault();
                        if (accountisvalid != null)
                        {
                            status = false;
                        }
                    }
                    break;
                default:
                    break;
            }
            return status;
        }
        public bool CheckDateTimeFormat(string convertDatetime, string format, string cultur)
        {
            bool status = false;
            bool gecerlilik = false;
            try
            {
                System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo(cultur);
                format = cultureinfo.DateTimeFormat.ShortDatePattern.ToString() + " " + cultureinfo.DateTimeFormat.LongTimePattern.ToString();
                if (convertDatetime.ToString().Substring(0,9).IndexOf("-") != -1)
                {
                    convertDatetime = ReplaceXforDatetime(convertDatetime, '-');
                    gecerlilik=true;
                }
                if (convertDatetime.ToString().Substring(0,9).IndexOf(".") != -1)
                {
                    convertDatetime = ReplaceXforDatetime(convertDatetime, '.');
                    gecerlilik = true;

                }
                if (convertDatetime.ToString().Substring(0, 9).IndexOf("/") != -1)
                {
                    gecerlilik = true;
                }
                if (gecerlilik == true)
                {
                    try
                    {
                       DateTime convertDatetimee = DateTime.ParseExact(convertDatetime.ToString(), format, cultureinfo);
                        status = true;
                        return status;

                    }
                    catch (Exception)
                    {

                        status = false;
                        return status;
                    }
     
                }
            }
            catch (Exception)
            {
                status = false;
                return status;
                //throw;
            }
            return status;

        } //formatın doğruluğınu kontrol etme
        public DateTime ConvertDateTimeFormatValid(DateTime convertDatetime,string format,string cultur) //herhangi bir formatı sistem formatına çevirme
        {
            //HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["Language"];
            //string returndatetime;
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo(cultur);
            //cookie.Value = cultur;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            format = cultureinfo.DateTimeFormat.ShortDatePattern.ToString() + " "+ cultureinfo.DateTimeFormat.LongTimePattern.ToString();
            //if (convertDatetime.ToString().Substring(0, 12).IndexOf("-") != -1)
            //{
            //    returndatetime = ReplaceXforDatetime(convertDatetime.ToString(), '-');

            //}
            //if (convertDatetime.ToString().Substring(0, 12).IndexOf(".") != -1)
            //{
            //    returndatetime = ReplaceXforDatetime(convertDatetime.ToString(), '.');

            //}
            string todate = convertDatetime.Date.ToString(format);
            convertDatetime = DateTime.ParseExact(todate, format, cultureinfo);
            return convertDatetime;
        }
        public string ConvertDateTimeForScheduler(DateTime convertDatetime, string format, string cultur, string fromcultur)
        {
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo(cultur);
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["Language"];
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
            System.Globalization.CultureInfo cultureinfo2 = new System.Globalization.CultureInfo("tr-TR");
            format = cultureinfo2.DateTimeFormat.ShortDatePattern.ToString() + " " + cultureinfo2.DateTimeFormat.LongTimePattern.ToString();

            //if (convertDatetime.ToString().Substring(0, 12).IndexOf("-") != -1)
            //{
            //    convertDatetime = ReplaceXforDatetime(convertDatetime, '-');

            //}
            //if (convertDatetime.ToString().Substring(0, 12).IndexOf(".") != -1)
            //{
            //    convertDatetime = ReplaceXforDatetime(convertDatetime, '.');

            //}
            string todate = convertDatetime.ToString(format);
            todate = DateTime.ParseExact(todate, format, cultureinfo).ToString();
            cookie.Value = fromcultur;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            return todate;
        }
        public DateTime ConvertDateTimeFormatValidFromSunucu(DateTime convertDatetime, string format, string cultur, string fromcultur) //herhangi bir formatı sistem formatına çevirme
        {
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo(cultur);
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["Language"];
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
            System.Globalization.CultureInfo cultureinfo2 = new System.Globalization.CultureInfo("tr-TR");
            format = cultureinfo2.DateTimeFormat.ShortDatePattern.ToString() + " " + cultureinfo2.DateTimeFormat.LongTimePattern.ToString();

            //if (convertDatetime.ToString().Substring(0, 12).IndexOf("-") != -1)
            //{
            //    convertDatetime = ReplaceXforDatetime(convertDatetime, '-');

            //}
            //if (convertDatetime.ToString().Substring(0, 12).IndexOf(".") != -1)
            //{
            //    convertDatetime = ReplaceXforDatetime(convertDatetime, '.');

            //}
            string todate = convertDatetime.Date.ToString(format);
            convertDatetime = DateTime.ParseExact(todate, format, cultureinfo);
            cookie.Value = fromcultur;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            return convertDatetime;
        }
        public DateTime ConvertDateTimeFormat(DateTime convertDatetime, string format) // işaretleme kontrolü
        {
            convertDatetime = DateTime.ParseExact(convertDatetime.Date.ToString(), format, CultureInfo.InvariantCulture);
            return convertDatetime;
        }
        public string ReplaceXforDatetime(string time,char split)
        {
            //DateTime returnedtime;
            char to = '/';
            time = time.ToString().Replace('.',to);
            return time;
        }

        public double ConvertNumberFormat(string value)
        {
            double val = -1;
            try
            {
                val = double.Parse(value, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {

                return val;
            }
            return val;
        }

        public bool CheckNumberFormat(double value)
        {
            char[] kontroldizi = GetNumericDataControl();
            char[] specialchars = GetSpecialCharDataControl();
            bool status = false;
            bool stringkontrol = false;
            try
            {
                string valcheckstring = value.ToString();
                for (int i = 0; i < valcheckstring.Length; i++)
                {
                    for (int i2 = 0; i2 < kontroldizi.Length; i2++)
                    {
                        if (valcheckstring[i] == kontroldizi[i2])
                        {
                            stringkontrol = true;
                        }
                    }
                   
                }
                if (stringkontrol == false)
                {
                    for (int i = 0; i < valcheckstring.Length; i++)
                    {
                        for (int i2 = 0; i2 < specialchars.Length; i2++)
                        {
                            if (valcheckstring[i] == specialchars[i2])
                            {
                                stringkontrol = true;
                            }
                        }

                    }
                    if(stringkontrol == false)
                    {
                        string val = value.ToString();
                        value = double.Parse(val, CultureInfo.InvariantCulture);
                        status = true;
                        return status;
                    }
              
                }
            }
            catch (Exception)
            {

                return status;
            }
            return status;

        }
        public char[] GetNumericDataControl()
        {
            char[] kontroldizi = {'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'H', 'Ğ', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z', 'X'};
            return kontroldizi;
        }
        public char[] GetSpecialCharDataControl()
        {
            char[] kontroldizi = {'*', '/', '!', '"', '#', '$', '&', '%', ')', '(', '[', ']', '}', '{', '?', '+', '-', '_', ';', '`', '<', '>', '=', '@', '^', '~', '!', '|', '€'};
            return kontroldizi;
        }
        public char[] GetAlphaDataControl()
        {
            char[] kontroldizi = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return kontroldizi;
        }
    }
}