    using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SubcornTakip.Models;

namespace SubcornTakip.Math
{
    public class Calculating
    {
        SubcornTakipEntities db = new SubcornTakipEntities();
        Formatting.Formatting fmt = new Formatting.Formatting();
        public double CalculateFXRateSelectedDay(DateTime selectday,string tofx,string companykur,string companykurbanka)
        {
            char decimalseperator = fmt.GetDecimalSeperator(System.Web.HttpContext.Current.Session["lang"].ToString());
            char groupseperator = fmt.GetGroupSeperator(System.Web.HttpContext.Current.Session["lang"].ToString());
            double belgefiyatı = 0;
            DateTime t = Convert.ToDateTime(selectday.Date);
            var kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == companykurbanka && pp.KurTarih == t).SingleOrDefault();
            if (kurlist == null)
            {
                //int k = -1;

                while (kurlist == null)
                {
                    t = t.AddDays(-1);
                    kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == companykurbanka && pp.KurTarih == t).SingleOrDefault();

                }
            }
            var coloumnnamequery = kurlist.GetType().GetProperties().Where(p => p.Name == companykur).Select(a => a.GetValue(kurlist, null)).FirstOrDefault();
            double coloumname = double.Parse(coloumnnamequery.ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
            coloumname = 1 / coloumname;

            if (companykur != tofx)
            {

                switch (tofx)
                {
                    case "EUR":
                        
                        belgefiyatı = double.Parse(((1 / kurlist.EUR) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "USD":
                        belgefiyatı = double.Parse(((1 / kurlist.USD) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "GPB":
                        belgefiyatı = double.Parse(((1 / kurlist.GPB) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "RUB":
                        belgefiyatı = double.Parse(((1 / kurlist.RUB) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "JPY":
                        belgefiyatı = double.Parse(((1 / kurlist.JPY) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "DKK":
                        belgefiyatı = double.Parse(((1 / kurlist.DKK) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "PLN":
                        belgefiyatı = double.Parse(((1 / kurlist.PLN) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "SEK":
                        belgefiyatı = double.Parse(((1 / kurlist.SEK) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "RON":
                        belgefiyatı = double.Parse(((1 / kurlist.RON) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "CHF":
                        belgefiyatı = double.Parse(((1 / kurlist.CHF) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "HRK":
                        belgefiyatı = double.Parse(((1 / kurlist.HRK) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "AUD":
                        belgefiyatı = double.Parse(((1 / kurlist.AUD) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "CAD":
                        belgefiyatı = double.Parse(((1 / kurlist.CAD) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "HKD":
                        belgefiyatı = double.Parse(((1 / kurlist.HKD) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "ILS":
                        belgefiyatı = double.Parse(((1 / kurlist.ILS) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "MXN":
                        belgefiyatı = double.Parse(((1 / kurlist.MXN) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "NZD":
                        belgefiyatı = double.Parse(((1 / kurlist.NZD) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "SGD":
                        belgefiyatı = double.Parse(((1 / kurlist.SGD) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    case "ZAR":
                        belgefiyatı = double.Parse(((1 / kurlist.ZAR) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                    default:
                        belgefiyatı = double.Parse(((1 / kurlist.TRY) / coloumname).ToString().Replace('.',decimalseperator), NumberStyles.Currency, new CultureInfo(System.Web.HttpContext.Current.Session["lang"].ToString()));
                        break;
                }
            }
            else
            {
                belgefiyatı = Convert.ToDouble(1);
            }
            return belgefiyatı;
        } //belirli bir gündeki kur oranı(TRY/USD=6,2)
        public double CalculateFXRateSelectedDayExchange(DateTime selectday, string tofx, string companykur, string companykurbanka)
        {
            double belgefiyatı = 0;
            DateTime t = Convert.ToDateTime(selectday.Date);
            var kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == companykurbanka && pp.KurTarih == t).SingleOrDefault();
            if (kurlist == null)
            {
                //int k = -1;

                while (kurlist == null)
                {
                    t = t.AddDays(-1);
                    kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == companykurbanka && pp.KurTarih == t).SingleOrDefault();

                }
            }
            var coloumnnamequery = kurlist.GetType().GetProperties().Where(p => p.Name == companykur).Select(a => a.GetValue(kurlist, null)).FirstOrDefault();
            double coloumname = Convert.ToDouble(coloumnnamequery.ToString());
            //coloumname = 1 / coloumname;

            if (companykur != tofx)
            {

                switch (tofx)
                {
                    case "EUR":
                        belgefiyatı = Convert.ToDouble(((kurlist.EUR) / coloumname));
                        break;
                    case "USD":
                        belgefiyatı = Convert.ToDouble(((kurlist.USD) / coloumname));
                        break;
                    case "GPB":
                        belgefiyatı = Convert.ToDouble(((kurlist.GPB) / coloumname));
                        break;
                    case "RUB":
                        belgefiyatı = Convert.ToDouble(((kurlist.RUB) / coloumname));
                        break;
                    case "JPY":
                        belgefiyatı = Convert.ToDouble(((kurlist.JPY) / coloumname));
                        break;
                    case "DKK":
                        belgefiyatı = Convert.ToDouble(((kurlist.DKK) / coloumname));
                        break;
                    case "PLN":
                        belgefiyatı = Convert.ToDouble(((kurlist.PLN) / coloumname));
                        break;
                    case "SEK":
                        belgefiyatı = Convert.ToDouble(((kurlist.SEK) / coloumname));
                        break;
                    case "RON":
                        belgefiyatı = Convert.ToDouble(((kurlist.RON) / coloumname));
                        break;
                    case "CHF":
                        belgefiyatı = Convert.ToDouble(((kurlist.CHF) / coloumname));
                        break;
                    case "HRK":
                        belgefiyatı = Convert.ToDouble(((kurlist.HRK) / coloumname));
                        break;
                    case "AUD":
                        belgefiyatı = Convert.ToDouble(((kurlist.AUD) / coloumname));
                        break;
                    case "CAD":
                        belgefiyatı = Convert.ToDouble(((kurlist.CAD) / coloumname));
                        break;
                    case "HKD":
                        belgefiyatı = Convert.ToDouble(((kurlist.HKD) / coloumname));
                        break;
                    case "ILS":
                        belgefiyatı = Convert.ToDouble(((kurlist.ILS) / coloumname));
                        break;
                    case "MXN":
                        belgefiyatı = Convert.ToDouble(((kurlist.MXN) / coloumname));
                        break;
                    case "NZD":
                        belgefiyatı = Convert.ToDouble(((kurlist.NZD) / coloumname));
                        break;
                    case "SGD":
                        belgefiyatı = Convert.ToDouble(((kurlist.SGD) / coloumname));
                        break;
                    case "ZAR":
                        belgefiyatı = Convert.ToDouble(((kurlist.ZAR) / coloumname));
                        break;
                    default:
                        belgefiyatı = Convert.ToDouble(((kurlist.TRY) / coloumname));
                        break;
                }
            }
            else
            {
                belgefiyatı = Convert.ToDouble(1);
            }
            return belgefiyatı;
        } //belirli bir gündeki kur oranı(TRY/USD=6,2)

        public double GetSelectedDayFXRate(DateTime selectday,string fx,string companykurbanka)
        {
            double belgefiyatı = 0;
            DateTime t = Convert.ToDateTime(selectday.Date);
            var kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == companykurbanka && pp.KurTarih == t).SingleOrDefault();
            if (kurlist == null)
            {
                //int k = -1;

                while (kurlist == null)
                {
                    t = t.AddDays(-1);
                    kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == companykurbanka && pp.KurTarih == t).SingleOrDefault();

                }
            }
            var coloumnnamequery = kurlist.GetType().GetProperties().Where(p => p.Name == fx).Select(a => a.GetValue(kurlist, null)).FirstOrDefault();
            belgefiyatı = Convert.ToDouble(coloumnnamequery);
            return belgefiyatı;
        }

        public TaskDetailsData CalculateTaskAnalytic(int TaskID,string compa,string companykur,string companykurbanka,bool isestimationortimetracking)
        {
            TaskDetailsData newdata = new TaskDetailsData();
            List<TaskDetailsDataItems> newdatalist = new List<TaskDetailsDataItems>();
            bool isallvalid = true;
            var task = db.Tbl_EventStore.Where(p => p.IsActive == true && p.id == TaskID && p.Company == compa).SingleOrDefault();
            if (task != null)
            {
                DateTime chechStart_date = Convert.ToDateTime(task.start_date.ToShortDateString());
                DateTime chechEnd_date = Convert.ToDateTime(task.end_date.AddDays(1).ToShortDateString());
                Guid projectguid = Guid.Parse(task.job_id);
                var project = db.Tbl_EventJob.Where(p => p.key == projectguid && p.IsActive == true && p.Company == compa).SingleOrDefault();
                if (project != null)
                {
                    if (project.EventJobZamantur == "PriceList")
                    {
                        var pricelist = db.Tbl_PriceList.Where(p => p.Company == compa  && p.ListID == project.PriceListID).SingleOrDefault();
                        if (pricelist != null)
                        {
                            newdata.Expenserecarcble = project.EventJobMasrafYansıtma;
                            newdata.Margin = Convert.ToDouble(project.EventJobFiyatGunluk);
                            newdata.PriceListID = pricelist.ListID;
                            newdata.PriceListName = pricelist.ListName;
                            newdata.ProjeGuid = project.key;
                            newdata.ProjeLabel = project.label;
                            newdata.ProjePricingType = project.EventJobZamantur;
                            newdata.RecharceRate = Convert.ToDouble(project.EventJobExpensePercent);
                            int kontrol = 0;
                            var userkeysplit = task.key.Split(',');
                            var serviceskeysplit = task.hizmet_id.Split(',');
                            foreach (var itemUser in userkeysplit)
                            {
                                var userid = Convert.ToInt32(itemUser);
                                var user = db.Tbl_SubconUsers.Where(p => p.Company == compa && p.IsActive == true && p.SubconUserDepartment == userid).SingleOrDefault();
                                if (user != null)
                                {
                                    var servicesdetailsid = Convert.ToInt32(serviceskeysplit[kontrol].ToString());
                                    var userpricing = db.Tbl_EventDenetciDetails.Where(p => p.Company == compa && p.IsActive == true && p.key == servicesdetailsid).SingleOrDefault();
                                    if (userpricing != null)
                                    {
                                        int servicesid = Convert.ToInt32(userpricing.EventDenetciDenetimBelgeturu);
                                        var services = db.Tbl_Hizmetler.Where(p => p.Company == compa && p.key == servicesid).SingleOrDefault();
                                        if (services != null)
                                        {
                                            var taskdetailslist = db.Tbl_TaskDetails.Where(p => p.Company == compa && p.IsActive == true && p.TaskID == TaskID && p.AuditorID == userid && p.IsTimeTracking == isestimationortimetracking && p.StartDate >= chechStart_date && p.EndDate <= chechEnd_date).ToList();
                                            var pricelisdetails = db.Tbl_PriceListDetails.Where(p => p.ListID == pricelist.ListID && p.ServicesID == servicesid).SingleOrDefault();
                                            foreach (var daily in taskdetailslist)
                                            {
                                                DateTime sdate = Convert.ToDateTime(daily.StartDate);
                                                DateTime edate = Convert.ToDateTime(daily.EndDate);
                                                TaskDetailsDataItems newitem = new TaskDetailsDataItems();
                                                newitem.Username = user.SubronUserName;
                                                newitem.ProfilPhoto = user.UpdatedProfilePhotoURL;
                                                newitem.UserGuid = user.SubconUsersGuid;
                                                newitem.UserDailyPlanId = userid;
                                                newitem.Startdate = Convert.ToDateTime(daily.StartDate).ToString();
                                                newitem.EndDate = Convert.ToDateTime(daily.EndDate).ToString();
                                                newitem.ServicesID = servicesid;
                                                newitem.ServicesName = services.label;
                                                if (project.EventJobZamantur == "PriceList")
                                                {
                                                    newitem.Total = Convert.ToDouble(daily.TaskDetailsGelir);
                                                }
                                                else
                                                {
                                                    newitem.Total = System.Math.Round(Convert.ToDouble(daily.TaskDetailsGelir + ((daily.TaskDetailsGelir/100)*project.EventJobFiyatGunluk)),2);
                                                }
                                                if (pricelisdetails.PriceType == "Hourly")
                                                {
                                                    newitem.PriceType = "Hour";
                                                    newitem.PriceDuration = System.Math.Abs((sdate - edate).Hours).ToString();
                                                }
                                                else if (pricelisdetails.PriceType == "Manday")
                                                {
                                                    newitem.PriceType = "Manday";
                                                    newitem.PriceDuration = "1";
                                                }
                                                else if (pricelisdetails.PriceType == "Daily")
                                                {
                                                    newitem.PriceType = "Day";
                                                    newitem.PriceDuration = "1";
                                                }
                                                else if(pricelisdetails.PriceType == "Fixed")
                                                {
                                                    newitem.PriceType = "Fixed";
                                                    newitem.PriceDuration = "";
                                                }
                                                else
                                                {
                                                    newitem.PriceType = "Free";
                                                    newitem.PriceDuration = "";
                                                }
                                                if (task.is_paid == "True" && task.EventFaturaGuid != null)
                                                {
                                                    newitem.InvoicedStatus = "Invoiced";
                                                    newitem.InvoiceGuid = task.EventFaturaGuid;

                                                }
                                                else
                                                {
                                                    newitem.InvoicedStatus = "Invoiced";
                                                    newitem.InvoiceGuid = null;
                                                }
                                                newitem.Type = "Revenue";
                                                newdatalist.Add(newitem);

                                                TaskDetailsDataItems newitemCost = new TaskDetailsDataItems();
                                                newitemCost.Username = user.SubronUserName;
                                                newitemCost.ProfilPhoto = user.UpdatedProfilePhotoURL;
                                                newitemCost.UserGuid = user.SubconUsersGuid;
                                                newitemCost.UserDailyPlanId = userid;
                                                newitemCost.Startdate = Convert.ToDateTime(daily.StartDate).ToString();
                                                newitemCost.EndDate = Convert.ToDateTime(daily.EndDate).ToString();
                                                newitemCost.ServicesID = servicesid;
                                                newitemCost.ServicesName = services.label;
                                                newitemCost.Total = Convert.ToDouble(daily.TaskDetailsGider);
                                                if (userpricing.EventDenetciDenetimZamanTuru == "Hourly")
                                                {
                                                    newitemCost.PriceType = "Hour";
                                                    newitemCost.PriceDuration = System.Math.Abs((sdate - edate).Hours).ToString();
                                                }
                                                else if (userpricing.EventDenetciDenetimZamanTuru == "Manday")
                                                {
                                                    newitemCost.PriceType = "Manday";
                                                    newitemCost.PriceDuration = "1";
                                                }
                                                else if(userpricing.EventDenetciDenetimZamanTuru == "Fixed")
                                                {
                                                    newitemCost.PriceType = "Fixed";
                                                    newitemCost.PriceDuration = "";
                                                }
                                                else
                                                {
                                                    newitemCost.PriceType = "Free";
                                                    newitemCost.PriceDuration = "";
                                                }
                                                if (task.is_paid == "True" && task.EventFaturaGuid != null)
                                                {
                                                    newitemCost.InvoicedStatus = "Invoiced";
                                                    newitemCost.InvoiceGuid = task.EventFaturaGuid;

                                                }
                                                else
                                                {
                                                    newitemCost.InvoicedStatus = "Not Invoiced";
                                                    newitemCost.InvoiceGuid = null;
                                                }
                                                newitemCost.Type = "Cost";
                                                newdatalist.Add(newitemCost);
                                                ///revenue için yaptık fatura varsa onların da tutarlarını buray çektiricez toplatıcaz aynısını cost için yapıacz
                                            }
                                            if (project.EventJobMasrafYansıtma == "Will be recharged")
                                            {
                                                var expense = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == task.id && p.EventDenetciMasrafDenetciID == userid).ToList();
                                                foreach (var expensedetails in expense)
                                                {
                                                    var expenses = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == expensedetails.EventDenetciMasrafGuid && p.EventDenetciYansitilacak == "Will be recharged").ToList();
                                                    foreach (var expenseData in expenses)
                                                    {
                                                        if (expenseData.EventDenetciYansitilacak == project.EventJobMasrafYansıtma)
                                                        {
                                                            TaskDetailsDataItems newitem = new TaskDetailsDataItems();
                                                            newitem.Username = user.SubronUserName;
                                                            newitem.ProfilPhoto = user.UpdatedProfilePhotoURL;
                                                            newitem.UserGuid = user.SubconUsersGuid;
                                                            newitem.UserDailyPlanId = userid;
                                                            newitem.Startdate = "-";
                                                            newitem.EndDate = "-";
                                                            newitem.ServicesID = 0;
                                                            newitem.ServicesName = expenseData.EventDenetciMasrafMasrafsMasrafTuru;
                                                            newitem.Total = System.Math.Round(expenseData.EventDenetciMasrafMasrafsTutar + ((expenseData.EventDenetciMasrafMasrafsTutar/100)*Convert.ToDouble(project.EventJobExpensePercent)),2);
                                                            newitem.PriceType = "PCS";
                                                            newitem.PriceDuration = "1";
                                                            newitem.Type = "Revenue";
                                                            newdatalist.Add(newitem);

                                                            TaskDetailsDataItems newitemCost = new TaskDetailsDataItems();
                                                            newitemCost.Username = user.SubronUserName;
                                                            newitemCost.ProfilPhoto = user.UpdatedProfilePhotoURL;
                                                            newitemCost.UserGuid = user.SubconUsersGuid;
                                                            newitemCost.UserDailyPlanId = userid;
                                                            newitemCost.Startdate = "-";
                                                            newitemCost.EndDate = "-";
                                                            newitemCost.ServicesID = 0;
                                                            newitemCost.ServicesName = expenseData.EventDenetciMasrafMasrafsMasrafTuru;
                                                            newitemCost.Total = expenseData.EventDenetciMasrafMasrafsTutar;
                                                            newitemCost.PriceType = "PCS";
                                                            newitemCost.PriceDuration = "1";
                                                            newitemCost.Type = "Cost";
                                                            newdatalist.Add(newitemCost);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            var invoices = db.Tbl_EventFaturaEvents.Where(p => p.IsActive == true && p.Company == compa && p.EventFaturaEventid == task.id).ToList();
                            foreach (var itemInvoices in invoices)
                            {
                                if (itemInvoices.EventFaturaDiscount != 0)
                                {
                                    var invUst = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == itemInvoices.EventFaturaGuid).SingleOrDefault();
                                    double gunlukisfiyati = FXCalculateSelectedRate(Convert.ToDouble(itemInvoices.EventFaturaDiscount), DateTime.Now.Date, invUst.EventFaturaKurRate, companykur, invUst.EventFaturaKur, companykurbanka);
                                    TaskDetailsDataItems newitem = new TaskDetailsDataItems();
                                    newitem.Username = "-";
                                    newitem.ProfilPhoto = "-";
                                    newitem.UserGuid = Guid.NewGuid();
                                    newitem.UserDailyPlanId = 0;
                                    newitem.Startdate = "-";
                                    newitem.EndDate = "-";
                                    newitem.ServicesID = 0;
                                    newitem.ServicesName = "Invoice";
                                    newitem.Total = itemInvoices.EventFaturaDiscount * -1;
                                    newitem.PriceType = "PCS";
                                    newitem.PriceDuration = "1";
                                    newitem.Type = "Invoice";
                                    newitem.InvoicedStatus = "-";
                                    newitem.InvoiceGuid = itemInvoices.EventFaturaGuid;
                                    newdatalist.Add(newitem);
                                }
                            }
                        }
                    }
                    else
                    {
                        int kontrol = 0;
                        var userkeysplit = task.key.Split(',');
                        var serviceskeysplit = task.hizmet_id.Split(',');
                        foreach (var itemUser in userkeysplit)
                        {
                            var userid = Convert.ToInt32(itemUser);
                            var user = db.Tbl_SubconUsers.Where(p => p.Company == compa && p.IsActive == true && p.SubconUserDepartment == userid).SingleOrDefault();
                            if (user != null)
                            {
                                var servicesdetailsid = Convert.ToInt32(serviceskeysplit[kontrol].ToString());
                                var userpricing = db.Tbl_EventDenetciDetails.Where(p => p.Company == compa && p.IsActive == true && p.key == servicesdetailsid).SingleOrDefault();
                                if (userpricing != null)
                                {
                                    int servicesid = Convert.ToInt32(userpricing.EventDenetciDenetimBelgeturu);
                                    var services = db.Tbl_Hizmetler.Where(p =>p.Company == compa && p.key == servicesid).SingleOrDefault();
                                    if (services != null)
                                    {
                                        var taskdetailslist = db.Tbl_TaskDetails.Where(p => p.Company == compa && p.IsActive == true && p.TaskID == TaskID && p.AuditorID == userid && p.IsTimeTracking == isestimationortimetracking && p.StartDate >= chechStart_date && p.EndDate <= chechEnd_date).ToList();
                                        foreach (var daily in taskdetailslist)
                                        {
                                            DateTime sdate = Convert.ToDateTime(daily.StartDate);
                                            DateTime edate = Convert.ToDateTime(daily.EndDate);
                                            TaskDetailsDataItems newitem = new TaskDetailsDataItems();
                                            newitem.Username = user.SubronUserName;
                                            newitem.ProfilPhoto = user.UpdatedProfilePhotoURL;
                                            newitem.UserGuid = user.SubconUsersGuid;
                                            newitem.UserDailyPlanId = userid;
                                            newitem.Startdate = Convert.ToDateTime(daily.StartDate).ToString();
                                            newitem.EndDate = Convert.ToDateTime(daily.EndDate).ToString();
                                            newitem.ServicesID = servicesid;
                                            newitem.ServicesName = services.label;
                                            if (project.EventJobZamantur == "PriceList")
                                            {
                                                newitem.Total = Convert.ToDouble(daily.TaskDetailsGelir);
                                            }
                                            else
                                            {
                                                newitem.Total = System.Math.Round(Convert.ToDouble(daily.TaskDetailsGelir + ((daily.TaskDetailsGelir / 100) * project.EventJobFiyatGunluk)), 2);
                                            }
                                            if (userpricing.EventDenetciDenetimZamanTuru == "Hourly")
                                            {
                                                newitem.PriceType = "Hour";
                                                newitem.PriceDuration = System.Math.Abs((sdate - edate).Hours).ToString();
                                            }
                                            else if (userpricing.EventDenetciDenetimZamanTuru == "Manday")
                                            {
                                                newitem.PriceType = "Manday";
                                                newitem.PriceDuration = "1";
                                            }
                                            else if (userpricing.EventDenetciDenetimZamanTuru == "Fixed")
                                            {
                                                newitem.PriceType = "Fixed";
                                                newitem.PriceDuration = "";
                                            }
                                            else
                                            {
                                                newitem.PriceType = "Free";
                                                newitem.PriceDuration = "";
                                            }
                                            if (task.is_paid == "True" && task.EventFaturaGuid != null)
                                            {
                                                newitem.InvoicedStatus = "Invoiced";
                                                newitem.InvoiceGuid = task.EventFaturaGuid;

                                            }
                                            else
                                            {
                                                newitem.InvoicedStatus = "Not Invoiced";
                                                newitem.InvoiceGuid = null;
                                            }
                                            newitem.Type = "Revenue";
                                            newdatalist.Add(newitem);

                                            TaskDetailsDataItems newitemCost = new TaskDetailsDataItems();
                                            newitemCost.Username = user.SubronUserName;
                                            newitemCost.ProfilPhoto = user.UpdatedProfilePhotoURL;
                                            newitemCost.UserGuid = user.SubconUsersGuid;
                                            newitemCost.UserDailyPlanId = userid;
                                            newitemCost.Startdate = Convert.ToDateTime(daily.StartDate).ToString();
                                            newitemCost.EndDate = Convert.ToDateTime(daily.EndDate).ToString();
                                            newitemCost.ServicesID = servicesid;
                                            newitemCost.ServicesName = services.label;
                                            newitemCost.Total = Convert.ToDouble(daily.TaskDetailsGider);
                                            if (userpricing.EventDenetciDenetimZamanTuru == "Hourly")
                                            {
                                                newitemCost.PriceType = "Hour";
                                                newitemCost.PriceDuration = System.Math.Abs((sdate - edate).Hours).ToString();
                                            }
                                            else if (userpricing.EventDenetciDenetimZamanTuru == "Manday")
                                            {
                                                newitemCost.PriceType = "Manday";
                                                newitemCost.PriceDuration = "1";
                                            }
                                            else if (userpricing.EventDenetciDenetimZamanTuru == "Fixed")
                                            {
                                                newitem.PriceType = "Fixed";
                                                newitem.PriceDuration = "";
                                            }
                                            else
                                            {
                                                newitem.PriceType = "Free";
                                                newitem.PriceDuration = "";
                                            }
                                            if (task.is_paid == "True" && task.EventFaturaGuid != null)
                                            {
                                                newitemCost.InvoicedStatus = "Invoiced";
                                                newitemCost.InvoiceGuid = task.EventFaturaGuid;

                                            }
                                            else
                                            {
                                                newitemCost.InvoicedStatus = "Invoiced";
                                                newitemCost.InvoiceGuid = null;
                                            }
                                            newitemCost.Type = "Cost";
                                            newdatalist.Add(newitemCost);
                                            ///revenue için yaptık fatura varsa onların da tutarlarını buray çektiricez toplatıcaz aynısını cost için yapıacz
                                        }
                                        if (project.EventJobMasrafYansıtma == "Will be recharged")
                                        {
                                            var expense = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == task.id && p.EventDenetciMasrafDenetciID == userid).ToList();
                                            foreach (var expensedetails in expense)
                                            {
                                                var expenses = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == expensedetails.EventDenetciMasrafGuid && p.EventDenetciYansitilacak == "Will be recharged").ToList();
                                                foreach (var expenseData in expenses)
                                                {
                                                    if (expenseData.EventDenetciYansitilacak == project.EventJobMasrafYansıtma)
                                                    {
                                                        TaskDetailsDataItems newitem = new TaskDetailsDataItems();
                                                        newitem.Username = user.SubronUserName;
                                                        newitem.ProfilPhoto = user.UpdatedProfilePhotoURL;
                                                        newitem.UserGuid = user.SubconUsersGuid;
                                                        newitem.UserDailyPlanId = userid;
                                                        newitem.Startdate = "-";
                                                        newitem.EndDate = "-";
                                                        newitem.ServicesID = 0;
                                                        newitem.ServicesName = expenseData.EventDenetciMasrafMasrafsMasrafTuru;
                                                        newitem.Total = System.Math.Round(expenseData.EventDenetciMasrafMasrafsTutar + ((expenseData.EventDenetciMasrafMasrafsTutar / 100) * Convert.ToDouble(project.EventJobExpensePercent)), 2);
                                                        newitem.PriceType = "PCS";
                                                        newitem.PriceDuration = "1";
                                                        newitem.Type = "Revenue";
                                                        newdatalist.Add(newitem);

                                                        TaskDetailsDataItems newitemCost = new TaskDetailsDataItems();
                                                        newitemCost.Username = user.SubronUserName;
                                                        newitemCost.ProfilPhoto = user.UpdatedProfilePhotoURL;
                                                        newitemCost.UserGuid = user.SubconUsersGuid;
                                                        newitemCost.UserDailyPlanId = userid;
                                                        newitemCost.Startdate = "-";
                                                        newitemCost.EndDate = "-";
                                                        newitemCost.ServicesID = 0;
                                                        newitemCost.ServicesName = expenseData.EventDenetciMasrafMasrafsMasrafTuru;
                                                        newitemCost.Total = expenseData.EventDenetciMasrafMasrafsTutar;
                                                        newitemCost.PriceType = "PCS";
                                                        newitemCost.PriceDuration = "1";
                                                        newitemCost.Type = "Cost";
                                                        newdatalist.Add(newitemCost);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        var invoices = db.Tbl_EventFaturaEvents.Where(p => p.IsActive == true && p.Company == compa && p.EventFaturaEventid == task.id).ToList();
                        foreach (var itemInvoices in invoices)
                        {
                            if (itemInvoices.EventFaturaDiscount != 0)
                            {
                                var invUst = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == itemInvoices.EventFaturaGuid).SingleOrDefault();
                                double gunlukisfiyati = FXCalculateSelectedRate(Convert.ToDouble(itemInvoices.EventFaturaDiscount), DateTime.Now.Date, invUst.EventFaturaKurRate, companykur, invUst.EventFaturaKur, companykurbanka);
                                TaskDetailsDataItems newitem = new TaskDetailsDataItems();
                                newitem.Username = "-";
                                newitem.ProfilPhoto = "-";
                                newitem.UserGuid = Guid.NewGuid();
                                newitem.UserDailyPlanId = 0;
                                newitem.Startdate = "-";
                                newitem.EndDate = "-";
                                newitem.ServicesID = 0;
                                newitem.ServicesName = "Invoice";
                                newitem.Total = gunlukisfiyati * -1;
                                newitem.PriceType = "PCS";
                                newitem.PriceDuration = "1";
                                newitem.Type = "Invoice";
                                newitem.InvoicedStatus = "-";
                                newitem.InvoiceGuid = itemInvoices.EventFaturaGuid;
                                newdatalist.Add(newitem);
                            }
                        }
                    }
                }
            }
            newdata.TaskDetailsDataItems = newdatalist;
            return newdata;
        }
    
        public Tbl_EventStore CalculateCost(int evid,string compa,bool isestimationortimetracking,bool isdb = true)
        {
            var Event = db.Tbl_EventStore.Where(p => p.id == evid && p.Company == compa && p.IsActive == true && p.Onbazaar == "false" && p.saveType == "normal").SingleOrDefault();
            Guid jobid = Guid.Parse(Event.job_id);
            var job = db.Tbl_EventJob.Where(p => p.key == jobid).SingleOrDefault();
            if (Event != null && job != null && Event.start_date != null && Event.start_date != new DateTime(1979, 07, 07) &&
                Event.end_date != null && Event.end_date != new DateTime(2579, 07, 07) && Event.saveType == "normal")
            {
                DateTime chechStart_date = Convert.ToDateTime(Event.start_date.ToShortDateString());
                DateTime chechEnd_date = Convert.ToDateTime(Event.end_date.AddDays(1).ToShortDateString());
                double WorkHourByTask = 0;
                int WorkMandayByTask = 0;
                double TotalRevenueByTask = 0;
                double TotalIsTutarı = 0;
                double totalMasrafTutarı = 0;
                int HizmetIndexKontrol = 0;
                var EventAuditorSplit = Event.key.Split(',');
                var EventHizmetSplit = Event.hizmet_id.Split(',');
                foreach (var EventİtemByAuditor in EventAuditorSplit)
                {
                    if(EventİtemByAuditor != "0")
                    {
                        double DenetciUnitPrice = 0;
                        double DenetciUnitMasrafPrice = 0;
                        int Auditorid = Convert.ToInt32(EventİtemByAuditor);
                        int belgetur = Convert.ToInt32(EventHizmetSplit[HizmetIndexKontrol]);

                        var denetci = db.Tbl_SubconUsers.Where(denn => denn.SubconUserDepartment == Auditorid).SingleOrDefault();
                        var denetcidetailss = db.Tbl_EventDenetciDetails.Where(i => i.key == belgetur).SingleOrDefault();
                        var denetcidetails = denetcidetailss;
                        string denetcikur = denetcidetails.EventDenetciDenetimKur;
                        string dtur = denetcidetails.EventDenetciDenetimZamanTuru;

                        var company = db.Tbl_Companies.Where(companys => companys.CompanyName == compa).SingleOrDefault();
                        string companykur = company.Kur;
                        string companykurbanka = company.KurBanka;

                        if (Event.id != null)
                        {
                            DenetciUnitPrice = FXCalculateSelectedDay(denetcidetails.EventDenetciDenetimFiyatı, DateTime.Now.Date,companykur,denetcikur,companykurbanka);
                            if (dtur == "Fixed")
                            {
                                var detailstaskdetails = db.Tbl_TaskDetails.Where(p => p.TaskID == Event.id && p.AuditorID == Auditorid && p.Company == compa && p.IsActive == true && p.IsTimeTracking == isestimationortimetracking && p.StartDate >= chechStart_date && p.EndDate <= chechEnd_date).ToList();
                                bool isdbvalid = false;
                                if (detailstaskdetails.Count() > 0)
                                {
                                    isdbvalid = true;
                                }
                                double toplamgundays = 0;
                                foreach (var tasklistitem in detailstaskdetails)
                                {
                                    DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
                                    DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

                                    TimeSpan totalgun2 = enddatedet - startdatedet;
                                    toplamgundays += totalgun2.Hours;
                                }
                                foreach (var itemdetailstaskdetails in detailstaskdetails)
                                {
                                    DateTime startdatedet = Convert.ToDateTime(itemdetailstaskdetails.StartDate.ToString());
                                    DateTime enddatedet = Convert.ToDateTime(itemdetailstaskdetails.EndDate.ToString());

                                    TimeSpan totalgun2 = enddatedet - startdatedet;
                                    itemdetailstaskdetails.TaskDetailsGider = ((DenetciUnitPrice) / toplamgundays) * totalgun2.Hours;
                                    //if (isdb)
                                    //{
                                    //}
                                    db.SaveChanges();
                                }
                                if (isdb && isdbvalid)
                                {
                                    Event.WorkHours = 1;
                                    Event.WorkManday = 1;
                                    TotalRevenueByTask += DenetciUnitPrice;
                                    TotalIsTutarı += DenetciUnitPrice;
                                    db.SaveChanges();
                                }
                            }
                            else if (dtur == "Hourly")
                            {
                                var taskdetails = db.Tbl_TaskDetails.Where(p => p.TaskID == Event.id && p.AuditorID == Auditorid && p.Company == compa && p.IsActive == true && p.IsTimeTracking == isestimationortimetracking && p.StartDate >= chechStart_date && p.EndDate <= chechEnd_date).ToList();
                                foreach (var detailsteasks in taskdetails)
                                {
                                    DateTime startdatedet = Convert.ToDateTime(detailsteasks.StartDate.ToString());
                                    DateTime enddatedet = Convert.ToDateTime(detailsteasks.EndDate.ToString());
                                    TimeSpan totalgun = enddatedet - startdatedet;
                                    double toplamgun = totalgun.Hours;
                                    double totalminutes = (totalgun.Minutes / Convert.ToDouble(60));
                                    if (isdb)
                                    {
                                        toplamgun = toplamgun + totalminutes;
                                        TotalRevenueByTask += Convert.ToDouble(toplamgun) * DenetciUnitPrice;
                                        TotalIsTutarı += Convert.ToDouble(toplamgun) * DenetciUnitPrice;
                                        WorkHourByTask += toplamgun;
                                        Event.WorkHours = WorkHourByTask;
                                    }
                                    detailsteasks.TaskDetailsGider = System.Math.Round(Convert.ToInt32(toplamgun) * DenetciUnitPrice,2);
                                    db.SaveChanges();
                                }
                            }
                            else if (dtur == "Manday")
                            {
                                DateTime isdate = Convert.ToDateTime(Convert.ToDateTime(Event.start_date).ToShortDateString());
                                DateTime isdateend = Convert.ToDateTime(Event.end_date);


                                for (int i = 1; isdate <= isdateend; i++)
                                {
                                    DateTime isdatemodif = isdate.AddHours(23).AddMinutes(59);
                                    var tasklist = db.Tbl_TaskDetails.Where(p => p.AuditorID == Auditorid && p.StartDate <= isdatemodif && p.EndDate >= isdate && p.TaskID == Event.id && p.IsTimeTracking == isestimationortimetracking && p.IsActive == true && p.Company == compa).ToList();
                                    if (tasklist.Count > 1)
                                    {
                                        double toplamgundays = 0;
                                        foreach (var tasklistitem in tasklist)
                                        {
                                            DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
                                            DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

                                            TimeSpan totalgun = enddatedet - startdatedet;
                                            toplamgundays += totalgun.Hours;
                                        }
                                        foreach (var tasklistitem in tasklist)
                                        {
                                            DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
                                            DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

                                            TimeSpan totalgun = enddatedet - startdatedet;
                                            double toplamgun = totalgun.Hours;
                                            tasklistitem.TaskDetailsGider = System.Math.Round((toplamgun / toplamgundays) * DenetciUnitPrice,2);
                                            db.SaveChanges();
                                            if (isdb)
                                            {
                                                WorkMandayByTask += Convert.ToInt32(totalgun.TotalDays);
                                                Event.WorkManday += WorkMandayByTask;
                                                TotalRevenueByTask += System.Math.Round((toplamgun / toplamgundays) * DenetciUnitPrice, 2);
                                                TotalIsTutarı += System.Math.Round((toplamgun / toplamgundays) * DenetciUnitPrice, 2);
                                            }
                     
                                        }
                                    }
                                    else if (tasklist.Count == 1)
                                    {
                                        foreach (var taskdetlist in tasklist)
                                        {

                                            taskdetlist.TaskDetailsGider = System.Math.Round(DenetciUnitPrice,2);
                                            db.SaveChanges();
                                            if (isdb)
                                            {
                                                WorkMandayByTask += 1;
                                                Event.WorkManday = WorkMandayByTask;
                                                TotalRevenueByTask += DenetciUnitPrice;
                                                TotalIsTutarı += DenetciUnitPrice;
                                            }
                                      

                                        }
                                    }
                                    else
                                    {

                                    }
                                    isdate = isdate.AddDays(1);
                                }

                            }

                                var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == Event.id && p.EventDenetciMasrafDenetciID == Auditorid).ToList();
                                foreach (var masraff in masraflist)
                                {
                                    var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == masraff.EventDenetciMasrafGuid && p.EventDenetciYansitilacak == "Will be recharged").ToList();
                                    foreach (var masraf in masrafss)
                                    {
                                        DenetciUnitMasrafPrice = FXCalculateSelectedDay(masraf.EventDenetciMasrafMasrafsTutar, DateTime.Now.Date, companykur, masraf.FaturaKurS, companykurbanka);
                                            if (masraf.EventFaturaDurum == "Completed")
                                            {
                                                //var invdet = db.Tbl_EventFaturaEvents.Where(p => p.EventFaturaDescription == "ExpenseInvoice" && p.EventFaturaServicesID == masraf.EventDenetciMasrafMasrafsGuid && p.EventFaturaType == "Expense Invioce" && p.Company == compa && p.IsActive == true).SingleOrDefault();
                                                //var inv2 = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == invdet.EventFaturaGuid).SingleOrDefault();
                                                //totalmasraf = inv2.EventFaturaToplamTutar;
                                                //totalmasraf += Convert.ToDouble(((1 / job.EventJobExpensePercent) * totalmasraf) + totalmasraf);
                                            }
                                            else
                                            {
                                            totalMasrafTutarı += DenetciUnitMasrafPrice;
                                        TotalRevenueByTask += DenetciUnitMasrafPrice;
                                            }
                                    }

                                }
                        }
                        else
                        {

                        }
                    }
                    HizmetIndexKontrol++;
                }
                if (isdb)
                {
                    Event.EventTotalCost = System.Math.Round(TotalRevenueByTask, 2);
                    Event.EventMasrafTutar = System.Math.Round(totalMasrafTutarı, 2);
                    Event.EventDenetciTutar = System.Math.Round(TotalIsTutarı, 2);
                    db.SaveChanges();
                }

                if (job.EventJobZamantur == "CostPlus" && Event.EventFaturaGuid == null && Event.is_paid == "false")
                {
                    List<Tbl_EventStore> masrafcalculatetasklist = new List<Tbl_EventStore>();
                    double gunlukisfiyati = 0;
                    double totalgelir = 0;
                    double jobmasraf = 0;
                    double totalmaff = 0;
                    double istutar = 0;
                    var company = db.Tbl_Companies.Where(companys => companys.CompanyName == compa).SingleOrDefault();
                    //belgefiyatı = 1;
                    string companykur = company.Kur;
                    string companykurbanka = company.KurBanka;
                    DateTime lastdatefx = Convert.ToDateTime(db.Tbl_Kurlar.OrderByDescending(p => p.KurTarih).Where(i => i.KurBanka == companykurbanka).Max(a => a.KurTarih).ToString());
                    DateTime t = Convert.ToDateTime(lastdatefx.ToShortDateString());
                    var kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == companykurbanka && pp.KurTarih == t).SingleOrDefault();
                    var coloumnnamequery = kurlist.GetType().GetProperties().Where(p => p.Name == companykur).Select(a => a.GetValue(kurlist, null)).FirstOrDefault();
                    double coloumname = Convert.ToDouble(coloumnnamequery.ToString());
                    coloumname = 1 / coloumname;
                    var tasklisthourly = db.Tbl_EventStore.Where(p => p.job_id == job.key.ToString() && p.EventFaturaGuid == null && p.is_paid == "false" && p.IsActive == true && p.saveType == "normal").ToList();
                    foreach (var itemtasklisthourly in tasklisthourly)
                    {
                        masrafcalculatetasklist.Add(itemtasklisthourly);
                        totalgelir += (job.EventJobFiyatGunluk / 100) * (itemtasklisthourly.EventDenetciTutar) + itemtasklisthourly.EventDenetciTutar;
                        itemtasklisthourly.EventTotalRevenue = System.Math.Round(Convert.ToDouble((job.EventJobFiyatGunluk / 100) * (itemtasklisthourly.EventDenetciTutar) + itemtasklisthourly.EventDenetciTutar), 2);
                        //if (itemtasklisthourly.durum_id == "3")
                        //{
                        //    TotalrevenueTamamlanan += System.Math.Round(Convert.ToDouble((1 / job.EventJobFiyatGunluk) * (itemtasklisthourly.EventDenetciTutar) + itemtasklisthourly.EventDenetciTutar), 2);
                        //    itemtasklisthourly.EventTotalTamamlananRevenue = System.Math.Round(Convert.ToDouble((1 / job.EventJobFiyatGunluk) * (itemtasklisthourly.EventDenetciTutar) + itemtasklisthourly.EventDenetciTutar), 2);
                        //}
                        if (isdb)
                        {
                            db.SaveChanges();
                        }
                    }

                    if (job.JobOrClass == "Class")
                    {
                        int mandayforclass = db.Tbl_ConfirmApprovalList.Where(p => p.ConfirmApprovalListGelenObjID == job.EventJobInvoiceTo.ToString() && p.ConfirmApprovalListStatus == "Confirmed").Count();
                        totalgelir = (mandayforclass + 1) * gunlukisfiyati;

                    }
                    else
                    {
                        if (job.EventJobMasrafYansıtma == "Will be recharged" && isdb)
                        {

                            var tasklist = masrafcalculatetasklist;
                            foreach (var item in tasklist)
                            {
                                var Auditoridsplit2 = item.key.Split(',');
                                foreach (var item22 in Auditoridsplit2)
                                {
                                    int Auditorid2 = Convert.ToInt32(item22);
                                    var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == item.id && p.EventDenetciMasrafDenetciID == Auditorid2).ToList();
                                    if (masraflist.Count() > 0)
                                    {

                                        foreach (var masrafs in masraflist)
                                        {
                                            var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == masrafs.EventDenetciMasrafGuid).ToList();
                                            foreach (var item2 in masrafss)
                                            {
                                                if (item2.EventDenetciYansitilacak == job.EventJobMasrafYansıtma)
                                                {
                                                    if (item2.EventDenetciYansitmaDurum == "Completed")
                                                    {
                                                        var invdet = db.Tbl_EventFaturaEvents.Where(p => p.EventFaturaDescription == "Fatura" && p.EventFaturaServicesID == item2.EventDenetciMasrafMasrafsGuid && p.EventFaturaType == "Standart" && p.Company == compa && p.IsActive == true && p.EventFaturaQuantityType == "PCS").SingleOrDefault();
                                                        if (invdet != null)
                                                        {
                                                            var inv2 = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == invdet.EventFaturaGuid).SingleOrDefault();
                                                            if (inv2 != null)
                                                            {
                                                                jobmasraf = FXCalculateSelectedRate(Convert.ToDouble(invdet.EventFaturaNetTotal), DateTime.Now.Date, inv2.EventFaturaKurRate, companykur, inv2.EventFaturaKur, companykurbanka);
                                                                //double jobmasraf = FXCalculateSelectedRate(invdet.EventFaturaNetTotal, inv2.EventFaturaTarihi, inv2.EventFaturaKurRate, companykur, inv2.EventFaturaKur, companykurbanka);
                                                                jobmasraf = System.Math.Round(jobmasraf, 2);
                                                                totalgelir += jobmasraf;
                                                                item.EventTotalRevenue += jobmasraf;
                                                                totalmaff += jobmasraf;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        double DenetciUnitMasrafPrice = FXCalculateSelectedDay(item2.EventDenetciMasrafMasrafsTutar, DateTime.Now.Date, companykur, item2.FaturaKurS, companykurbanka);
                                                        totalgelir += (DenetciUnitMasrafPrice + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (DenetciUnitMasrafPrice));
                                                        item.EventTotalRevenue += (DenetciUnitMasrafPrice + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (DenetciUnitMasrafPrice));
                                                        totalmaff += DenetciUnitMasrafPrice;
                                                    }
                                                }

                                            }
                                        }

                                    }
                                }
                            }
                        }
                        else if (isdb)
                        {
                            totalgelir += gunlukisfiyati;
                        }
                    }
                }
                else
                {
                    double completecost = 0;
                    completecost += Event.EventDenetciTutar;
                    var expenses = db.Tbl_EventDenetciMasraf.Where(p => p.Company == compa && p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventDenetciMasrafEventId == Event.id).ToList();
                    foreach (var item in expenses)
                    {
                        var expensealt = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.Company ==compa && p.IsActive == true && p.EventDenetciMasrafguid == item.EventDenetciMasrafGuid).ToList();
                        foreach (var item2 in expensealt)
                        {
                            var invoice = db.Tbl_EventFaturaEvents.Where(p => p.Company == compa && p.IsActive == true && p.EventFaturaType == "ExpenseInvoice" && p.EventFaturaServicesID == item2.EventDenetciMasrafMasrafsGuid).SingleOrDefault();
                            if(invoice != null)
                            {
                                var invoiceust = db.Tbl_EventFatura.Where(p => p.Company == compa == p.IsActive == true && p.EventFaturaGuid == invoice.EventFaturaGuid).SingleOrDefault();
                                if(invoiceust != null)
                                {
                                    completecost += invoice.EventFaturaSubTotal;
                                }
                            }
                        }
                    }
                    if (isdb)
                    {
                        Event.EventTotalTamamlananCost = System.Math.Round(completecost, 2);
                    }
                    CalculateRevenue(Event.id, compa, Guid.Parse(Event.job_id), isestimationortimetracking, isdb);
                }
                return Event;
            }
            else
            {
                if (Event.saveType == "normal" && Event.durum_id != "3" && Event.EventFaturaGuid == null)
                {
                    if (Event.start_date == null || Event.start_date == new DateTime(1979, 07, 07) || Event.end_date == null || Event.end_date == new DateTime(2579, 07, 07) || Event.key == null ||
                        Event.key == "0" || Event.hizmet_id == null || Event.hizmet_id == "0")
                    {
                        Event.saveType = "Basic Task";
                        db.SaveChanges();
                    }
                }
                Tbl_EventStore newevet = new Tbl_EventStore();
                return Event;
            }
        }

        public void CalculateRevenue(int evid,string compa,Guid projectguid,bool isestimationortimetracking, bool isdb=true)
        {
            var job = db.Tbl_EventJob.Where(p => p.key == projectguid && p.Company == compa && p.IsActive == true).SingleOrDefault();
            if (job.EventJobZamantur != null)
            {
                var Event = db.Tbl_EventStore.Where(p => p.id == evid && p.Company == compa && p.IsActive == true && p.Onbazaar == "false" && p.saveType == "normal").SingleOrDefault();
                if(Event != null)
                {
                    DateTime chechStart_date = Convert.ToDateTime(Event.start_date.ToShortDateString());
                    DateTime chechEnd_date = Convert.ToDateTime(Event.end_date.AddDays(1).ToShortDateString());
                    double TotalRevenueByTask = 0;
                    double TotalRevenueByTaskInvoiced = 0;
                    double TotalIsTutarı = 0;
                    double totalMasrafTutarı = 0;
                    double TotalMasrafeByTaskInvoiced = 0;
                    double WorkHourByTask = 0;
                    int WorkMandayByTask = 0;
                    if (Event.EventFaturaGuid == null && job.EventJobZamantur != "CostPlus" && Event.is_paid == "false")
                    {
                        var pricelist = db.Tbl_PriceList.Where(p => p.Company == compa && p.ListID == job.PriceListID).SingleOrDefault();
                        var belgesplits = Event.hizmet_id.ToString().Split(',');
                        //int HizmetIndexKontrol = 0;
                        foreach (var belgesplit in belgesplits)
                        {
                            double DenetciUnitPrice = 0;
                            double DenetciUnitMasrafPrice = 0;
                            int servicesid = Convert.ToInt32(belgesplit);
                            var dendet = db.Tbl_EventDenetciDetails.Where(p => p.key == servicesid).SingleOrDefault();
                            int servicess = Convert.ToInt32(dendet.EventDenetciDenetimBelgeturu);
                            var services = db.Tbl_Hizmetler.Where(p => p.key == servicess).SingleOrDefault();
                            servicesid = services.key;

                            var details = db.Tbl_PriceListDetails.Where(p => p.ListID == pricelist.ListID && p.ServicesID == servicesid).SingleOrDefault();
                            string Pricelistfx = details.PriceFX;
                            var company = db.Tbl_Companies.Where(companys => companys.CompanyName == compa).SingleOrDefault();
                            string companykur = company.Kur;
                            string companykurbanka = company.KurBanka;

                            DenetciUnitPrice = FXCalculateSelectedDay(Convert.ToDouble(details.Price), DateTime.Now.Date, companykur, Pricelistfx, companykurbanka);

                            if (details.PriceType == "Fixed") //sıkıntılı
                            {
                                var detailstaskdetails = db.Tbl_TaskDetails.Where(p => p.TaskID == Event.id && p.AuditorID == dendet.EventDenetnciID && p.Company == compa && p.IsActive == true && p.IsTimeTracking == isestimationortimetracking && p.StartDate >= chechStart_date && p.EndDate <= chechEnd_date).ToList();
                                int detailstaskdetailschecker = detailstaskdetails.Select(p => p.AuditorID).Distinct().Count();
                                bool isdbvalid = false;
                                if (detailstaskdetails.Count() > 0)
                                {
                                    isdbvalid = true;
                                }
                                double toplamgundays = 0;
                                foreach (var tasklistitem in detailstaskdetails)
                                {
                                    DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
                                    DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

                                    TimeSpan totalgun2 = enddatedet - startdatedet;
                                    toplamgundays += totalgun2.Hours;
                                }
                                foreach (var itemdetailstaskdetails in detailstaskdetails)
                                {
                                    DateTime startdatedet = Convert.ToDateTime(itemdetailstaskdetails.StartDate.ToString());
                                    DateTime enddatedet = Convert.ToDateTime(itemdetailstaskdetails.EndDate.ToString());

                                    TimeSpan totalgun2 = enddatedet - startdatedet;
                                    itemdetailstaskdetails.TaskDetailsGelir = ((DenetciUnitPrice / detailstaskdetailschecker) / toplamgundays) * totalgun2.Hours;
                                    //if (isdb)
                                    //{
                                    //}
                                    db.SaveChanges();

                                }
                                if (isdb && isdbvalid)
                                {
                                    Event.WorkHours = 1;
                                    Event.WorkManday = 1;
                                    TotalRevenueByTask += DenetciUnitPrice / detailstaskdetailschecker;
                                    TotalIsTutarı += DenetciUnitPrice / detailstaskdetailschecker;
                                }
                            }
                            if(details.PriceType == "Hourly")
                            {
                                var detailstaskdetails = db.Tbl_TaskDetails.Where(p => p.TaskID == Event.id && p.AuditorID == dendet.EventDenetnciID && p.Company == compa && p.IsActive == true && p.IsTimeTracking == isestimationortimetracking && p.StartDate >= chechStart_date && p.EndDate <= chechEnd_date).ToList();
                                foreach (var itemdetailstaskdetails in detailstaskdetails)
                                {
                                    DateTime startdatedet = Convert.ToDateTime(itemdetailstaskdetails.StartDate.ToString());
                                    DateTime enddatedet = Convert.ToDateTime(itemdetailstaskdetails.EndDate.ToString());
                                    TimeSpan totalgun = enddatedet - startdatedet;
                                    double toplamgun = totalgun.Hours;
                                    double totalminutes = totalgun.Minutes / Convert.ToDouble(60);
                                    itemdetailstaskdetails.TaskDetailsGelir = System.Math.Round(Convert.ToDouble(toplamgun) * DenetciUnitPrice, 2);
                                    itemdetailstaskdetails.TaskDetailsKar = System.Math.Round((Convert.ToDouble(toplamgun) * DenetciUnitPrice) - Convert.ToDouble(itemdetailstaskdetails.TaskDetailsGider), 2);
                                    //if (isdb)
                                    //{
                                    //}
                                    db.SaveChanges();
                                    if (isdb)
                                    {
                                        toplamgun = toplamgun + totalminutes;
                                        TotalRevenueByTask += Convert.ToInt32(toplamgun) * DenetciUnitPrice;
                                        WorkHourByTask += toplamgun;
                                        Event.PlanningHours = WorkHourByTask;
                                        Event.PlaningManday = 0;
                                    }
                                }
                            }
                            if(details.PriceType == "Manday")
                            {

                                int totalmanday = 0;
                                var jobevents = Event;
                                TimeSpan totalgun = Convert.ToDateTime(jobevents.end_date) - Convert.ToDateTime(jobevents.start_date);
                                double toplamgun = System.Math.Floor(totalgun.TotalDays);
                                var detailstaskdetails = db.Tbl_TaskDetails.Where(p => p.TaskID == Event.id && p.AuditorID == dendet.EventDenetnciID && p.Company == compa && p.IsActive == true && p.IsTimeTracking == isestimationortimetracking && p.StartDate >= chechStart_date && p.EndDate <= chechEnd_date).ToList();
                                int detailstaskdetailschecker = detailstaskdetails.Select(p => p.StartDate.Value.Date).Distinct().Count();
                                bool isdbvalid = false;
                                if (detailstaskdetails.Count() > 0)
                                {
                                    isdbvalid = true;
                                }
                                DateTime isdate = Convert.ToDateTime(Convert.ToDateTime(jobevents.start_date).ToShortDateString());
                                DateTime isdateend = Convert.ToDateTime(jobevents.end_date);

                                for (int i = 1; isdate <= isdateend; i++)
                                {
                                    DateTime isdatemodif = isdate.AddHours(23).AddMinutes(59);
                                    var item = dendet.EventDenetnciID;
                                    int Auditorid = Convert.ToInt32(item);
                                    var tasklist = db.Tbl_TaskDetails.Where(p => p.AuditorID == Auditorid && p.StartDate <= isdatemodif && p.EndDate >= isdate && p.TaskID == Event.id && p.IsTimeTracking == isestimationortimetracking && p.IsActive == true && p.Company == compa).ToList();
                                    if (tasklist.Count > 1)
                                    {
                                        double toplamgundays = 0;
                                        foreach (var tasklistitem in tasklist)
                                        {
                                            DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
                                            DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

                                            TimeSpan totalgun2 = enddatedet - startdatedet;
                                            toplamgundays += totalgun2.Hours;
                                        }
                                        foreach (var tasklistitem in tasklist)
                                        {
                                            DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
                                            DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

                                            TimeSpan totalgun2 = enddatedet - startdatedet;
                                            double toplamgun2 = totalgun2.Hours;
                                            tasklistitem.TaskDetailsGelir = System.Math.Round((toplamgun2 / toplamgundays) * DenetciUnitPrice,2);
                                            tasklistitem.TaskDetailsKar = System.Math.Round((Convert.ToDouble(toplamgun2 / toplamgundays) * DenetciUnitPrice) - Convert.ToDouble(tasklistitem.TaskDetailsGider), 2);
                                            //if (isdb)
                                            //{
                                            //}
                                            db.SaveChanges();
                                        }
                                    }
                                    else if (tasklist.Count == 1)
                                    {
                                        foreach (var taskdetlist in tasklist)
                                        {

                                            taskdetlist.TaskDetailsGelir = System.Math.Round(DenetciUnitPrice,2);
                                            taskdetlist.TaskDetailsKar = System.Math.Round(DenetciUnitPrice - Convert.ToDouble(taskdetlist.TaskDetailsGider), 2);
                                            //if (isdb)
                                            //{
                                            //}
                                            db.SaveChanges();
                                        }
                                    }
                                    else
                                    {

                                    }
                                    isdate = isdate.AddDays(1);
                                }
                                if (isdbvalid && isdb)
                                {
                                    totalmanday += Convert.ToInt32(detailstaskdetailschecker);
                                    WorkMandayByTask += totalmanday;
                                    Event.PlaningManday = WorkMandayByTask;
                                    Event.PlanningHours = 0;
                                    TotalRevenueByTask += totalmanday * DenetciUnitPrice;
                                }
                            }
                            if(details.PriceType == "Daily")
                            {
                                int totalmanday = 0;
                                var jobevents = Event;

                                TimeSpan totalgun = Convert.ToDateTime(jobevents.end_date) - Convert.ToDateTime(jobevents.start_date);
                                double toplamgun = System.Math.Floor(totalgun.TotalDays);
                                var detailstaskdetails = db.Tbl_TaskDetails.Where(p => p.TaskID == Event.id && p.AuditorID == dendet.EventDenetnciID && p.Company == compa && p.IsActive == true && p.IsTimeTracking == isestimationortimetracking && p.StartDate >= chechStart_date && p.EndDate <= chechEnd_date).ToList();
                                int detailstaskdetailschecker = detailstaskdetails.Select(p => p.StartDate.Value.Date).Distinct().Count();
                                bool isdbvalid = false;
                                if (detailstaskdetails.Count() > 0)
                                {
                                    isdbvalid = true;
                                }
                                DateTime isdate = Convert.ToDateTime(Convert.ToDateTime(jobevents.start_date).ToShortDateString());
                                DateTime isdateend = Convert.ToDateTime(jobevents.end_date);
                                for (int i = 1; isdate <= isdateend; i++)
                                {
                                    DateTime isdatemodif = isdate.AddHours(23).AddMinutes(59);
                                    var item = dendet.EventDenetnciID;


                                    int Auditorid = Convert.ToInt32(item);
                                    var tasklist = db.Tbl_TaskDetails.Where(p => p.TaskID == Event.id && p.AuditorID == Auditorid && p.StartDate <= isdatemodif && p.EndDate >= isdate && p.IsTimeTracking == isestimationortimetracking && p.Company == compa && p.IsActive == true).ToList();
                                    if (tasklist.Count > 1)
                                    {
                                        double toplamgundays = 0;
                                        foreach (var tasklistitem in tasklist)
                                        {
                                            DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
                                            DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

                                            TimeSpan totalgun2 = enddatedet - startdatedet;
                                            toplamgundays += totalgun2.Hours;
                                        }
                                        foreach (var tasklistitem in tasklist)
                                        {
                                            DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
                                            DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

                                            TimeSpan totalgun2 = enddatedet - startdatedet;
                                            double toplamgun2 = totalgun2.Hours;
                                            tasklistitem.TaskDetailsGelir = System.Math.Round(((toplamgun2 / toplamgundays) * DenetciUnitPrice));
                                            tasklistitem.TaskDetailsKar = System.Math.Round((((toplamgun2 / toplamgundays) * DenetciUnitPrice)) - Convert.ToDouble(tasklistitem.TaskDetailsGider),2);
                                            //if (isdb)
                                            //{
                                            //}
                                            db.SaveChanges();
                                        }
                                    }
                                    else if (tasklist.Count == 1)
                                    {
                                        foreach (var taskdetlist in tasklist)
                                        {

                                            taskdetlist.TaskDetailsGelir = System.Math.Round(DenetciUnitPrice);
                                            taskdetlist.TaskDetailsKar = System.Math.Round(((DenetciUnitPrice)) - Convert.ToDouble(taskdetlist.TaskDetailsGider), 2);
                                            //if (isdb)
                                            //{
                                            //}
                                            db.SaveChanges();
                                        }
                                    }
                                    else
                                    {

                                    }
                                    isdate = isdate.AddDays(1);

                                }
                                if (isdbvalid && isdb)
                                {
                                    totalmanday += Convert.ToInt32(detailstaskdetailschecker);
                                    WorkMandayByTask += totalmanday;
                                    Event.PlaningManday = WorkMandayByTask;
                                    Event.PlanningHours = 0;
                                    TotalRevenueByTask += (totalmanday * DenetciUnitPrice);
                                }
                            }

                            if (job.EventJobMasrafYansıtma == "Will be recharged" && isdb)
                            {
                                var item = Event;
                                var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == item.id && p.EventDenetciMasrafDenetciID == dendet.EventDenetnciID).ToList();
                                if (masraflist.Count() > 0)
                                    {

                                        foreach (var masrafs in masraflist)
                                        {
                                            var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == masrafs.EventDenetciMasrafGuid && p.EventDenetciYansitilacak == "Will be recharged").ToList();
                                            foreach (var item2 in masrafss)
                                            {
                                                if (item2.EventDenetciYansitilacak == job.EventJobMasrafYansıtma)
                                                {
                                                    if (item2.EventDenetciYansitmaDurum == "Completed")
                                                    {
                                                        var invdet = db.Tbl_EventFaturaEvents.Where(p => p.EventFaturaDescription == "Fatura" && p.EventFaturaServicesID == item2.EventDenetciMasrafMasrafsGuid && p.EventFaturaType == "Standart" && p.Company == compa && p.IsActive == true).SingleOrDefault();
                                                        if (invdet != null)
                                                        {
                                                            var inv2 = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == invdet.EventFaturaGuid).SingleOrDefault();
                                                            if (inv2 != null)
                                                            {
                                                                double jobmasraf = System.Math.Round(inv2.EventFaturaToplamTutar, 2);
                                                                totalMasrafTutarı += jobmasraf;
                                                                TotalRevenueByTaskInvoiced += jobmasraf;
                                                                TotalRevenueByTask += jobmasraf;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        DenetciUnitMasrafPrice = FXCalculateSelectedDay(item2.EventDenetciMasrafMasrafsTutar, DateTime.Now.Date, companykur, item2.FaturaKurS, companykurbanka);
                                                        TotalRevenueByTask += (DenetciUnitMasrafPrice + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (DenetciUnitMasrafPrice));
                                                        totalMasrafTutarı += (DenetciUnitMasrafPrice + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (DenetciUnitMasrafPrice));
                                                    }
                                                }

                                            }
                                        }

                                    }
                            }

                            if (isdb)
                            {
                                Event.EventTotalRevenue = System.Math.Round(TotalRevenueByTask, 2);
                                Event.EventTotalTamamlananRevenue = System.Math.Round(TotalRevenueByTaskInvoiced, 2);
                                db.SaveChanges();
                            }
                        }
                    }
                    else 
                    {
                        var company = db.Tbl_Companies.Where(companys => companys.CompanyName == compa).SingleOrDefault();
                        string companykur = company.Kur;
                        string companykurbanka = company.KurBanka;
                        bool ismasrafkontrol = false;
                        var inveach = db.Tbl_EventFaturaEvents.Where(p => p.EventFaturaEventid == Event.id && p.EventFaturaQuantityType != "PCS").ToList();
                        foreach (var inv in inveach)
                        {
                            var invUst = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == inv.EventFaturaGuid).SingleOrDefault();
                            double gunlukisfiyati = Convert.ToDouble(inv.EventFaturaNetTotal);
                            gunlukisfiyati = FXCalculateSelectedRate(Convert.ToDouble(gunlukisfiyati), DateTime.Now.Date, invUst.EventFaturaKurRate, companykur, invUst.EventFaturaKur, companykurbanka);
                            //gunlukisfiyati = FXCalculateSelectedRate(gunlukisfiyati, invUst.EventFaturaTarihi, invUst.EventFaturaKurRate, companykur, invUst.EventFaturaKur, companykurbanka);
                            TotalRevenueByTask += gunlukisfiyati;
                            TotalRevenueByTaskInvoiced += gunlukisfiyati;
                            if (ismasrafkontrol == false && isdb)
                            {
                                ismasrafkontrol = true;
                                if (job.EventJobMasrafYansıtma == "Will be recharged")
                                {

                                    var tasklist = db.Tbl_EventStore.Where(p => p.Company == compa && p.Onbazaar == "false" && p.IsActive == true && p.job_id == job.key.ToString() && p.id == Event.id).ToList();
                                    foreach (var item in tasklist)
                                    {
                                        var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == item.id).ToList();
                                        if (masraflist.Count() > 0)
                                        {

                                            foreach (var masrafs in masraflist)
                                            {
                                                var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == masrafs.EventDenetciMasrafGuid && p.EventDenetciYansitilacak == "Will be recharged").ToList();
                                                foreach (var item2 in masrafss)
                                                {
                                                    if (item2.EventDenetciYansitilacak == job.EventJobMasrafYansıtma)
                                                    {
                                                        if (item2.EventDenetciYansitmaDurum == "Completed")
                                                        {
                                                            var invdetEach = db.Tbl_EventFaturaEvents.Where(p =>  p.EventFaturaServicesID == item2.EventDenetciMasrafMasrafsGuid && p.Company == compa && p.IsActive == true && p.EventFaturaQuantityType == "PCS").ToList();
                                                            foreach (var invdet in invdetEach)
                                                            {
                                                                var inv2 = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == invdet.EventFaturaGuid).SingleOrDefault();
                                                                if (inv2 != null)
                                                                {
                                                                    double jobmasraf = FXCalculateSelectedRate(Convert.ToDouble(invdet.EventFaturaNetTotal), DateTime.Now.Date, inv2.EventFaturaKurRate, companykur, inv2.EventFaturaKur, companykurbanka);
                                                                    //double jobmasraf = FXCalculateSelectedRate(invdet.EventFaturaNetTotal, inv2.EventFaturaTarihi, inv2.EventFaturaKurRate, companykur, inv2.EventFaturaKur, companykurbanka);
                                                                    jobmasraf = System.Math.Round(jobmasraf, 2);
                                                                    totalMasrafTutarı += jobmasraf;
                                                                    TotalRevenueByTaskInvoiced += jobmasraf;
                                                                    TotalRevenueByTask += jobmasraf;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            double DenetciUnitMasrafPrice = FXCalculateSelectedDay(item2.EventDenetciMasrafMasrafsTutar, DateTime.Now.Date, companykur, item2.FaturaKurS, companykurbanka);
                                                            TotalRevenueByTask += (DenetciUnitMasrafPrice + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (DenetciUnitMasrafPrice));
                                                            totalMasrafTutarı += (DenetciUnitMasrafPrice + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (DenetciUnitMasrafPrice));
                                                        }
                                                    }

                                                }
                                            }

                                        }
                                    }
                                }
                            }
                            

                            Event.EventTotalRevenue = System.Math.Round(TotalRevenueByTask, 2);
                            Event.EventTotalTamamlananRevenue = System.Math.Round(TotalRevenueByTaskInvoiced, 2);
                            if (isdb)
                            {
                                db.SaveChanges();
                            }
                        }
        
                    }
                }
            }
        }

        public Tbl_EventJob CalculateJob(Guid jobg,string compa,bool isdb=true)
        {
            var job = db.Tbl_EventJob.Where(p => p.key == jobg && p.Company == compa && p.IsActive == true).SingleOrDefault();
            double jobRevenue = db.Tbl_EventStore.Where(p => p.IsActive == true && p.Company == compa &&  p.job_id == jobg.ToString()).Sum(p => p.EventTotalRevenue);
            double jobCost = db.Tbl_EventStore.Where(p => p.IsActive == true && p.Company == compa && p.job_id == jobg.ToString()).Sum(p => p.EventTotalCost);
            double jobProfit = jobRevenue - jobCost;

            double jobRevenueC = 0;
            double jobCostC = 0;
            var jobRevenueCc = db.Tbl_EventStore.Where(p => p.IsActive == true && p.Company == compa && p.job_id == jobg.ToString() && p.durum_id == "3" && p.EventFaturaGuid != null).ToList();
            if(jobRevenueCc.Count() > 0)
            {
                jobRevenueC = db.Tbl_EventStore.Where(p => p.IsActive == true && p.Company == compa && p.job_id == jobg.ToString() && p.durum_id == "3" && p.EventFaturaGuid != null).Sum(p => p.EventTotalRevenue);
            }
            var jobCostCc = db.Tbl_EventStore.Where(p => p.IsActive == true && p.Company == compa && p.job_id == jobg.ToString() && p.durum_id == "3" && p.EventFaturaGuid != null).ToList();
            if (jobCostCc.Count() > 0)
            {
                jobCostC = db.Tbl_EventStore.Where(p => p.IsActive == true && p.Company == compa && p.job_id == jobg.ToString() && p.durum_id == "3" && p.EventFaturaGuid != null).Sum(p => p.EventTotalCost);
            }
            double jobProfitC = jobRevenueC - jobCostC;
            job.EventJobTotalFiyat = System.Math.Round(jobRevenue,2);
            job.EventJobTotalGider = System.Math.Round(jobCost,2);
            job.EventJobKar = System.Math.Round(jobProfit, 2);

            job.EventJobTamamlananGelir = System.Math.Round(jobRevenueC, 2);
            job.EventJobTamamlananGider = System.Math.Round(jobCostC, 2);
            job.EventJobTamamlananKar= System.Math.Round(jobProfitC, 2);
            if (isdb)
            {
                db.SaveChanges();
            }
            return job;
        }

        public void CalculateEventMasrafTotalCost()
        {

        }
        public double FXCalculateSelectedDay(double belgefiyatı,DateTime date,string fromfx,string tofx,string compabank)
        {
            DateTime t = Convert.ToDateTime(date.Date);
            var kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == compabank && pp.KurTarih == t).SingleOrDefault();
            if(kurlist == null)
            {
                //int k = -1;

                while (kurlist == null)
                {
                   t = t.AddDays(-1);
                    kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == compabank && pp.KurTarih == t).SingleOrDefault();

                }
            }
            var coloumnnamequery = kurlist.GetType().GetProperties().Where(p => p.Name == fromfx).Select(a => a.GetValue(kurlist, null)).FirstOrDefault();
            double coloumname = Convert.ToDouble(coloumnnamequery.ToString());
            coloumname = 1 / coloumname;

          
                    if (tofx != fromfx)
                    {

                        switch (tofx)
                        {
                            case "EUR":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.EUR) / coloumname));
                                break;
                            case "USD":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.USD) / coloumname));
                                break;
                            case "GPB":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.GPB) / coloumname));
                                break;
                            case "RUB":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.RUB) / coloumname));
                                break;
                            case "JPY":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.JPY) / coloumname));
                                break;
                            case "DKK":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.DKK) / coloumname));
                                break;
                            case "PLN":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.PLN) / coloumname));
                                break;
                            case "SEK":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.SEK) / coloumname));
                                break;
                            case "RON":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.RON) / coloumname));
                                break;
                            case "CHF":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.CHF) / coloumname));
                                break;
                            case "HRK":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.HRK) / coloumname));
                                break;
                            case "AUD":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.AUD) / coloumname));
                                break;
                            case "CAD":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.CAD) / coloumname));
                                break;
                            case "HKD":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.HKD) / coloumname));
                                break;
                            case "ILS":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.ILS) / coloumname));
                                break;
                            case "MXN":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.MXN) / coloumname));
                                break;
                            case "NZD":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.NZD) / coloumname));
                                break;
                            case "SGD":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.SGD) / coloumname));
                                break;
                            case "ZAR":
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.ZAR) / coloumname));
                                break;
                            default:
                                belgefiyatı = Convert.ToDouble(belgefiyatı * ((1 / kurlist.TRY) / coloumname));
                                break;
                        }
                    }
                    else
                    {
                        belgefiyatı = Convert.ToDouble(belgefiyatı * 1);
                    }
         
            return System.Math.Round(belgefiyatı,2);
        } //belirli bir gündeki kur çevirilmesi (100 usd = 600 tl)

        public double FXCalculateSelectedRate(double belgefiyatı, DateTime date,double rate, string fromfx, string tofx, string compabank)
        {
            DateTime t = Convert.ToDateTime(date.Date);
            var kurlist2 = db.Tbl_Kurlar.Where(pp => pp.KurBanka == compabank && pp.KurTarih == t).SingleOrDefault();
            if (kurlist2 == null)
            {
                //int k = -1;

                while (kurlist2 == null)
                {
                    t = t.AddDays(-1);
                    kurlist2 = db.Tbl_Kurlar.Where(pp => pp.KurBanka == compabank && pp.KurTarih == t).SingleOrDefault();

                }
            }
            var coloumnnamequery = kurlist2.GetType().GetProperties().Where(p => p.Name == fromfx).Select(a => a.GetValue(kurlist2, null)).FirstOrDefault();
            double coloumname = Convert.ToDouble(coloumnnamequery.ToString());
            ////coloumname = 1 / coloumname;
            double fxrates = Convert.ToDouble(rate);
            Tbl_Kurlar kur = new Tbl_Kurlar();
            kur.AUD = fxrates;
            kur.CAD = fxrates;
            kur.CHF = fxrates;
            kur.DKK = fxrates;
            kur.EUR = fxrates;
            kur.GPB = fxrates;
            kur.HKD = fxrates;
            kur.HRK = fxrates;
            kur.ILS = fxrates;
            kur.JPY = fxrates;
            kur.MXN = fxrates;
            kur.NZD = fxrates;
            kur.PLN = fxrates;
            kur.RON = fxrates;
            kur.RUB = fxrates;
            kur.SEK = fxrates;
            kur.SGD = fxrates;
            kur.TRY = fxrates;
            kur.USD = fxrates;
            kur.ZAR = fxrates;
            kur.KurBanka = compabank;
            var kurlist = kur;
            //var coloumnnamequery = kurlist.GetType().GetProperties().Where(p => p.Name == fromfx).Select(a => a.GetValue(kurlist, null)).FirstOrDefault();
            //double coloumname = Convert.ToDouble(coloumnnamequery.ToString());

            if (tofx != fromfx)
            {

                switch (tofx)
                {
                    case "EUR":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.EUR) / coloumname));
                        break;
                    case "USD":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.USD) / coloumname));
                        break;
                    case "GPB":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.GPB) / coloumname));
                        break;
                    case "RUB":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.RUB) / coloumname));
                        break;
                    case "JPY":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.JPY) / coloumname));
                        break;
                    case "DKK":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.DKK) / coloumname));
                        break;
                    case "PLN":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.PLN) / coloumname));
                        break;
                    case "SEK":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.SEK) / coloumname));
                        break;
                    case "RON":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.RON) / coloumname));
                        break;
                    case "CHF":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.CHF) / coloumname));
                        break;
                    case "HRK":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.HRK) / coloumname));
                        break;
                    case "AUD":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.AUD) / coloumname));
                        break;
                    case "CAD":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.CAD) / coloumname));
                        break;
                    case "HKD":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.HKD) / coloumname));
                        break;
                    case "ILS":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.ILS) / coloumname));
                        break;
                    case "MXN":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.MXN) / coloumname));
                        break;
                    case "NZD":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.NZD) / coloumname));
                        break;
                    case "SGD":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.SGD) / coloumname));
                        break;
                    case "ZAR":
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.ZAR) / coloumname));
                        break;
                    default:
                        belgefiyatı = Convert.ToDouble(belgefiyatı * ((1/kurlist.TRY) / coloumname));
                        break;
                }
            }
            else
            {
                belgefiyatı = Convert.ToDouble(belgefiyatı * 1);
            }

            return System.Math.Round(belgefiyatı, 2);
        } //belirli bir gündeki kur oranıyla çevirme çevirilmesi (100 usd = 600 tl) (usd=tl(1-6))

        public double FXCalculateExchangeRate(double calculatevalue, string fromfx, string tofx, string tobank,Tbl_Kurlar kur)
        {
            var kurlist = kur;
            var coloumnnamequery = kurlist.GetType().GetProperties().Where(p => p.Name == tofx).Select(a => a.GetValue(kurlist, null)).FirstOrDefault();
            double coloumname = Convert.ToDouble(coloumnnamequery.ToString());
            coloumname = 1 / coloumname;
            
                if (fromfx != tofx)
                {
                    switch (fromfx)
                    {
                        case "EUR":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.EUR) / coloumname));
                            break;
                        case "USD":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.USD) / coloumname));

                        break;
                        case "GPB":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.GPB) / coloumname));

                        break;
                        case "RUB":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.RUB) / coloumname));

                        break;
                        case "JPY":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.JPY) / coloumname));

                        break;
                        case "DKK":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.DKK) / coloumname));

                        break;
                        case "PLN":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.PLN) / coloumname));

                        break;
                        case "SEK":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.SEK) / coloumname));

                        break;
                        case "RON":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.RON) / coloumname));

                        break;
                        case "CHF":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.CHF) / coloumname));

                        break;
                        case "HRK":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.HRK) / coloumname));

                        break;
                        case "AUD":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.AUD) / coloumname));

                        break;
                        case "CAD":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.CAD) / coloumname));

                        break;
                        case "HKD":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.HKD) / coloumname));

                        break;
                        case "ILS":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.ILS) / coloumname));

                        break;
                        case "MXN":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.MXN) / coloumname));

                        break;
                        case "NZD":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.NZD) / coloumname));

                        break;
                        case "SGD":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.SGD) / coloumname));

                        break;
                        case "ZAR":
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.ZAR) / coloumname));

                        break;
                        default:
                        calculatevalue = Convert.ToDouble(calculatevalue * ((1 / kurlist.TRY) / coloumname));

                        break;
                    }

                }
                else
                {
                calculatevalue = Convert.ToDouble(calculatevalue  * 1);
                }
                return System.Math.Round(calculatevalue,2);
            
        } //reliaze kur değerlemesi kur değişim fonksiyonu
        public bool CalculatExchangeRate(string compa,Tbl_Kurlar kurlist,string tofx,string tobank,Guid? usg)
        {
            bool status = false;
            string[] dizi = new string[5];
            dizi[0] = "Alacak";
            dizi[1] = "Borç";
            dizi[2] = "Kasa/Banka";
            dizi[3] = "Verilen Avans";
            dizi[4] = "Alınan Avans";
            var maxrowkry = db.Tbl_AccountingRow.Where(p => p.company == compa).Max(p => p.AccountRowKey);
            int maxrowkeyint = Convert.ToInt32(maxrowkry) + 1;
            int rowkery = maxrowkeyint;
            var accounting = db.Tbl_Accounting.Where(p => p.AccountingCompa == compa).ToList();
            if(accounting.Count > 0){
                //muhasebe start
                for (int i = 0; i < 5; i++)
                {
                    string type = dizi[i];
                    var muhasebe = db.Tbl_Accounting.Where(p => p.AccountingHesapTuru == type && p.AccountingCompa == compa).ToList();
                    foreach (var muhuasebeitem in muhasebe)
                    {
                        var muhlistfx = db.Tbl_AccountingRow.Where(p => p.AccountingRow == muhuasebeitem.AccountingHesapKodu && p.company == compa).Select(p => p.AccountingRowOrjKur).Distinct().ToList();
                        foreach (var muhlistfxitem in muhlistfx)
                        {
                            double borcorj = 0;
                            double borccomp = 0;
                            var borcorjT = db.Tbl_AccountingRow.Where(p => p.AccountingRow == muhuasebeitem.AccountingHesapKodu && p.company == compa && p.AccountingRowOrjKur == muhlistfxitem && p.AccountingRowType == "Borç").ToList();
                            var borccompT = db.Tbl_AccountingRow.Where(p => p.AccountingRow == muhuasebeitem.AccountingHesapKodu && p.company == compa && p.AccountingRowOrjKur == muhlistfxitem && p.AccountingRowType == "Borç").ToList();

                            if (borcorjT.Count() > 0)
                            {
                               borcorj = db.Tbl_AccountingRow.Where(p => p.AccountingRow == muhuasebeitem.AccountingHesapKodu && p.company == compa && p.AccountingRowOrjKur == muhlistfxitem && p.AccountingRowType == "Borç").Sum(p => p.AccountingRowOrjKurtutar);
                            }
                            if (borccompT.Count() > 0)
                            {
                                borccomp = db.Tbl_AccountingRow.Where(p => p.AccountingRow == muhuasebeitem.AccountingHesapKodu && p.company == compa && p.AccountingRowOrjKur == muhlistfxitem && p.AccountingRowType == "Borç").Sum(p => p.AccountingRowCompanyKurTutar);                                
                            }

                            double alacakorj = 0;
                            double alacakcomp = 0;
                            var alacakorjT = db.Tbl_AccountingRow.Where(p => p.AccountingRow == muhuasebeitem.AccountingHesapKodu && p.company == compa && p.AccountingRowOrjKur == muhlistfxitem && p.AccountingRowType == "Alacak").ToList();
                            var alacakcompT = db.Tbl_AccountingRow.Where(p => p.AccountingRow == muhuasebeitem.AccountingHesapKodu && p.company == compa && p.AccountingRowOrjKur == muhlistfxitem && p.AccountingRowType == "Alacak").ToList();

                            if (alacakorjT.Count() > 0)
                            {
                                alacakorj = db.Tbl_AccountingRow.Where(p => p.AccountingRow == muhuasebeitem.AccountingHesapKodu && p.company == compa && p.AccountingRowOrjKur == muhlistfxitem && p.AccountingRowType == "Alacak").Sum(p => p.AccountingRowOrjKurtutar);
                            }
                            if (alacakcompT.Count() > 0)
                            {
                                alacakcomp = db.Tbl_AccountingRow.Where(p => p.AccountingRow == muhuasebeitem.AccountingHesapKodu && p.company == compa && p.AccountingRowOrjKur == muhlistfxitem && p.AccountingRowType == "Alacak").Sum(p => p.AccountingRowCompanyKurTutar);
                            }
                            var farkorj = alacakorj - borcorj;
                            var farkcompa = alacakcomp - borccomp;
                            if (farkorj != 0) { 
                            double exchangerate = FXCalculateExchangeRate(Convert.ToDouble(farkorj),  muhlistfxitem, tofx, tobank, kurlist);
                            exchangerate = System.Math.Round(Convert.ToDouble(exchangerate - farkcompa),2);
                            if (exchangerate > 0)
                            {

                                    Tbl_AccountingRow act = new Tbl_AccountingRow();
                                    act.AccountRowKey = rowkery;
                                    act.AccountingRow = "646";
                                    act.AccountingRowDate = DateTime.Now;
                                    act.AccountingRowCreateDate = DateTime.Now;
                                    act.AccountingRowDescription = "Unrelaize FX Exchange Rate-654-" + type + "-FX:" + muhlistfxitem + "-Zarar";
                                    act.AccountingRowType = "Borç";
                                    act.AccountingRowOrjKurtutar = 0;
                                    act.AccountingRowOrjKur = muhlistfxitem;
                                    act.AccountingRowOrjKurRate = 5;
                                    act.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                                    act.AccountingRowCompanyKur = tofx;
                                    act.AccountingRowCompanyKurRate = 5;
                                    act.AccountingRowKayıtTuru = "Unrelaize FX Exchange Rate";
                                    act.company = compa;
                                    act.IsActive = true;
                                    act.Creater = usg;
                                    act.ConfirmUser = usg;
                                    act.ConfirmDate = DateTime.Now;
                                    act.AccountingRowOriginalCreateDate = DateTime.Now;
                                    db.Tbl_AccountingRow.Add(act);
                                    db.SaveChanges();

                                    Tbl_AccountingRow act2 = new Tbl_AccountingRow();
                                    act2.AccountRowKey = rowkery;
                                    act2.AccountingRow = muhuasebeitem.AccountingHesapKodu;
                                    act2.AccountingRowDate = DateTime.Now;
                                    act2.AccountingRowCreateDate = DateTime.Now;
                                    act2.AccountingRowDescription = "Unrelaize FX Exchange Rate-654-" + type + "-FX:" + muhlistfxitem + "-Zarar";
                                    act2.AccountingRowType = "Alacak";
                                    act2.AccountingRowOrjKurtutar = 0;
                                    act2.AccountingRowOrjKur = muhlistfxitem;
                                    act2.AccountingRowOrjKurRate = 5;
                                    act2.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                                    act2.AccountingRowCompanyKur = tofx;
                                    act2.AccountingRowCompanyKurRate = 5;
                                    act2.AccountingRowKayıtTuru = "Unrelaize FX Exchange Rate Gider";
                                    act2.company = compa;
                                    act2.IsActive = true;
                                    act2.Creater = usg;
                                    act2.ConfirmUser = usg;
                                    act2.ConfirmDate = DateTime.Now;
                                    act2.AccountingRowOriginalCreateDate = DateTime.Now;
                                    db.Tbl_AccountingRow.Add(act2);
                                    db.SaveChanges();

                                }
                            else
                            {
                                    Tbl_AccountingRow act = new Tbl_AccountingRow();
                                    act.AccountRowKey = rowkery;
                                    act.AccountingRow = "656";
                                    act.AccountingRowDate = DateTime.Now;
                                    act.AccountingRowCreateDate = DateTime.Now;
                                    act.AccountingRowDescription = "Unrelaize FX Exchange Rate-654-" + type + "-FX:" + muhlistfxitem + "-Kar";
                                    act.AccountingRowType = "Alacak";
                                    act.AccountingRowOrjKurtutar = 0;
                                    act.AccountingRowOrjKur = muhlistfxitem;
                                    act.AccountingRowOrjKurRate = 5;
                                    act.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                                    act.AccountingRowCompanyKur = tofx;
                                    act.AccountingRowCompanyKurRate = 5;
                                    act.AccountingRowKayıtTuru = "Unrelaize FX Exchange Rate";
                                    act.company = compa;
                                    act.IsActive = true;
                                    act.Creater = usg;
                                    act.ConfirmUser = usg;
                                    act.ConfirmDate = DateTime.Now;
                                    act.AccountingRowOriginalCreateDate = DateTime.Now;
                                    db.Tbl_AccountingRow.Add(act);
                                    db.SaveChanges();

                                    Tbl_AccountingRow act2 = new Tbl_AccountingRow();
                                    act2.AccountRowKey = rowkery;
                                    act2.AccountingRow = muhuasebeitem.AccountingHesapKodu;
                                    act2.AccountingRowDate = DateTime.Now;
                                    act2.AccountingRowCreateDate = DateTime.Now;
                                    act2.AccountingRowDescription = "Unrelaize FX Exchange Rate-654-" + type + "-FX:" + muhlistfxitem + "-Zarar";
                                    act2.AccountingRowType = "Borç";
                                    act2.AccountingRowOrjKurtutar = 0;
                                    act2.AccountingRowOrjKur = muhlistfxitem;
                                    act2.AccountingRowOrjKurRate = 5;
                                    act2.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                                    act2.AccountingRowCompanyKur = tofx;
                                    act2.AccountingRowCompanyKurRate = 5;
                                    act2.AccountingRowKayıtTuru = "Unrelaize FX Exchange Rate Gelir";
                                    act2.company = compa;
                                    act2.IsActive = true;
                                    act2.Creater = usg;
                                    act2.ConfirmUser = usg;
                                    act2.ConfirmDate = DateTime.Now;
                                    act2.AccountingRowOriginalCreateDate = DateTime.Now;
                                    db.Tbl_AccountingRow.Add(act2);
                                    db.SaveChanges();



                                   
                                }
                        }
                        }
                    }
                }
                //muhasebe end
                //cari start

                //cari end
            }


            //caristart


            var cari = db.Tbl_CariFish.Where(p => p.Company == compa).ToList();
            if (cari.Count()>0)
            {
                var clients = db.Tbl_CariFish.Where(p => p.Company == compa).Select(p =>p.CustomerID).Distinct().ToList();
                foreach (var clientsitem in clients)
                {
                    var seectedcari = db.Tbl_CariFish.Where(p => p.Company == compa && p.CustomerID == clientsitem).Take(1).SingleOrDefault();
                    var fxclients = db.Tbl_CariFish.Where(p => p.Company == compa && p.CustomerID == clientsitem).Select(p => p.OrjFX).Distinct().ToList();
                    foreach (var fxclientsitem in fxclients)
                    {
                        double cariborcorj = 0;
                        double carialacakorj = 0;
                        var cariborcorjT = db.Tbl_CariFish.Where(p => p.Company == compa && p.OrjFX == fxclientsitem && p.DebitCredit == "Borç" && p.CustomerID == clientsitem).ToList();
                        var carialacakorjT = db.Tbl_CariFish.Where(p => p.Company == compa && p.OrjFX == fxclientsitem && p.DebitCredit == "Alacak" && p.CustomerID == clientsitem).ToList();

                        if (cariborcorjT.Count() > 0)
                        {
                            cariborcorj = db.Tbl_CariFish.Where(p => p.Company == compa && p.OrjFX == fxclientsitem && p.DebitCredit == "Borç" && p.CustomerID == clientsitem).Sum(p => p.OrjFXPrice);
                        }
                        if (carialacakorjT.Count() > 0)
                        {
                            carialacakorj = db.Tbl_CariFish.Where(p => p.Company == compa && p.OrjFX == fxclientsitem && p.DebitCredit == "Alacak" && p.CustomerID == clientsitem).Sum(p => p.OrjFXPrice);
                        }

                        double cariborccompa = 0;
                        double carialacakcompa = 0;
                        var cariborccompaT = db.Tbl_CariFish.Where(p => p.Company == compa && p.OrjFX == fxclientsitem && p.DebitCredit == "Borç" && p.CustomerID == clientsitem).ToList();
                        var carialacakcompaT = db.Tbl_CariFish.Where(p => p.Company == compa && p.OrjFX == fxclientsitem && p.DebitCredit == "Alacak" && p.CustomerID == clientsitem).ToList();
                        if (cariborccompaT.Count() > 0)
                        {
                            cariborccompa = db.Tbl_CariFish.Where(p => p.Company == compa && p.OrjFX == fxclientsitem && p.DebitCredit == "Borç" && p.CustomerID == clientsitem).Sum(p => p.FXPrice);                            
                        }
                        if (carialacakcompaT.Count() > 0)
                        {
                            carialacakcompa = db.Tbl_CariFish.Where(p => p.Company == compa && p.OrjFX == fxclientsitem && p.DebitCredit == "Alacak" && p.CustomerID == clientsitem).Sum(p => p.FXPrice);
                        }
                        var fark = carialacakorj - cariborcorj;
                        var farkcompa = carialacakcompa - cariborccompa;
                        if (fark == 0 && farkcompa == 0)
                        {

                        }
                        else
                        {
                            double exchangerate = FXCalculateExchangeRate(Convert.ToDouble(fark), fxclientsitem, tofx, tobank, kurlist);
                            exchangerate = System.Math.Round(Convert.ToDouble(exchangerate - farkcompa), 2);

                            if (exchangerate > 0)
                            {
                                Tbl_CariFish newcari = new Tbl_CariFish();
                                newcari.CustomerID = clientsitem;
                                newcari.CariWhere = seectedcari.CariWhere;
                                newcari.ProccesType = "Exchange Rate Zarar";
                                newcari.BelgeRef = "EXCH";
                                newcari.BelgeRefWhere = "EXCH";
                                newcari.DebitCredit = "Alacak";
                                newcari.OrjFX = fxclientsitem;
                                newcari.OrjFXPrice = 0;
                                newcari.FX = tofx;
                                newcari.FXPrice = System.Math.Abs(exchangerate);
                                newcari.CumulativeBallance = 0;
                                newcari.AccountingCode = "646";
                                newcari.IsActive = true;
                                newcari.Company = compa;
                                newcari.CariDate = DateTime.Now;
                                newcari.CariOriginalDate = DateTime.Now;
                                db.Tbl_CariFish.Add(newcari);
                                db.SaveChanges();
                            }
                            else
                            {
                                Tbl_CariFish newcari = new Tbl_CariFish();
                                newcari.CustomerID = clientsitem;
                                newcari.CariWhere = seectedcari.CariWhere;
                                newcari.ProccesType = "Exchange Rate KAR";
                                newcari.BelgeRef = "EXCH";
                                newcari.BelgeRefWhere = "EXCH";
                                newcari.DebitCredit = "Borç";
                                newcari.OrjFX = fxclientsitem;
                                newcari.OrjFXPrice = 0;
                                newcari.FX = tofx;
                                newcari.FXPrice = System.Math.Abs(exchangerate);
                                newcari.CumulativeBallance = 0;
                                newcari.AccountingCode = "656";
                                newcari.IsActive = true;
                                newcari.Company = compa;
                                newcari.CariOriginalDate = DateTime.Now;
                                newcari.CariDate = DateTime.Now;
                                db.Tbl_CariFish.Add(newcari);
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
            return status;
        } //reliaze kur değerlemesi

        public bool CalculateExchangeReliazeRate(string compa)
        {
            bool a = false;
            return a;
        }

        public string CalculateGelirTahakkuku(DateTime? Startdate , DateTime? Enddate,string HesapKoduGelirTahakkuku,string HesapKoduErtelenmişGelir,string HwsapKoduSatislar,string compa,string compakur,Guid? usg)
        {
            double? tahakkukkodu = 0;
            var tahhakkuktutar = db.Tbl_Accounting.Where(p => p.AccountingHesapTuru == "Gelir Tahakkuku").ToList();
            foreach (var itemtahakkuk in tahhakkuktutar)
            {
                var tahakkukkoduT = db.Tbl_AccountingRow.Where(p => p.AccountingRow == itemtahakkuk.AccountingHesapKodu).ToList();
                if(tahakkukkoduT.Count() > 0)
                {
                    tahakkukkodu  = db.Tbl_AccountingRow.Where(p => p.AccountingRow == itemtahakkuk.AccountingHesapKodu).Sum(p => p.AccountingRowCompanyKurTutar);
                     
                }
            }
            var maxrowkry = db.Tbl_AccountingRow.Where(p => p.company == compa).Max(p => p.AccountRowKey);
            int maxrowkeyint = Convert.ToInt32(maxrowkry) + 1;
            int rowkery = maxrowkeyint;
            double completedtaskrevenue = 0;
            double sameseasonaccountingrevenue = 0;
            string status = "Hesaplama";
            double completedprojects = 0;
            var completedprojectsT = db.Tbl_EventStore.Where(p => p.Company == compa && p.IsActive == true && p.durum_id == "3").ToList();
            if (completedprojectsT.Count() > 0)
            {
                completedprojects = db.Tbl_EventStore.Where(p => p.Company == compa && p.IsActive == true && p.durum_id == "3").Sum(p => p.EventTotalRevenue);
            }
            completedtaskrevenue = Convert.ToDouble(completedprojects);
            double sameseasonaccountingrevenuelistCredit = 0; 
            double sameseasonaccountingrevenuelistDebit = 0;
            var satistürühesaplar = db.Tbl_Accounting.Where(p => p.AccountingCompa == compa && p.AccountingIsActive == true && p.AccountingHesapTuru == "Satış").ToList();
            foreach (var item in satistürühesaplar)
            {
                var sameseasonaccountingrevenuelistCreditT = db.Tbl_AccountingRow.Where(p => p.AccountingRow == item.AccountingHesapKodu && p.AccountingRowType == "Alacak").ToList();
                if (sameseasonaccountingrevenuelistCreditT.Count() > 0)
                {
                    sameseasonaccountingrevenuelistCredit += db.Tbl_AccountingRow.Where(p => p.AccountingRow == item.AccountingHesapKodu && p.AccountingRowType == "Alacak").Sum(p => p.AccountingRowCompanyKurTutar);
                }
                var sameseasonaccountingrevenuelistDebitT = db.Tbl_AccountingRow.Where(p => p.AccountingRow == item.AccountingHesapKodu && p.AccountingRowType == "Borç").ToList();
                if (sameseasonaccountingrevenuelistDebitT.Count() > 0)
                {
                    sameseasonaccountingrevenuelistDebit += db.Tbl_AccountingRow.Where(p => p.AccountingRow == item.AccountingHesapKodu && p.AccountingRowType == "Borç").Sum(p => p.AccountingRowCompanyKurTutar);
                }
            }
            sameseasonaccountingrevenue = Convert.ToDouble(sameseasonaccountingrevenuelistCredit) - Convert.ToDouble(sameseasonaccountingrevenuelistDebit);
            double A = System.Math.Round(completedtaskrevenue,2);
            double B = System.Math.Round(sameseasonaccountingrevenue,2);
            if ((tahakkukkodu - (A - B)) != 0)
            {
                if (A > B)
                {
                    Tbl_AccountingRow gelirrow = new Tbl_AccountingRow();
                    gelirrow.AccountRowKey = rowkery;
                    gelirrow.AccountingRow = HesapKoduGelirTahakkuku;
                    gelirrow.AccountingRowDate = DateTime.Now;
                    gelirrow.AccountingRowCreateDate = DateTime.Now;
                    gelirrow.AccountingRowDescription = "Gelir tahakkuku";
                    gelirrow.AccountingRowType = "Borç";
                    gelirrow.AccountingRowOrjKur = compakur;
                    gelirrow.AccountingRowOrjKurRate = 5;
                    gelirrow.AccountingRowOrjKurtutar = System.Math.Abs(A - B);
                    gelirrow.AccountingRowCompanyKur = compakur;
                    gelirrow.AccountingRowCompanyKurRate = 5;
                    gelirrow.AccountingRowCompanyKurTutar = System.Math.Abs(A - B);
                    gelirrow.AccountingRowKayıtTuru = "Borç - Gelir Tahakkuku";
                    gelirrow.AccountingBelgeRefNo = "Gelir tahakkuku - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                    gelirrow.AccountingBelgeWhere = "Gelir tahakkuku - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                    gelirrow.company = compa;
                    gelirrow.IsActive = true;
                    gelirrow.Creater = usg;
                    gelirrow.ConfirmDate = DateTime.Now;
                    gelirrow.ConfirmUser = usg;
                    gelirrow.AccountingRowOriginalCreateDate = DateTime.Now;
                    gelirrow.AccountingRowCreateDate = DateTime.Now;
                    gelirrow.AccountingRowDate = DateTime.Now;
                    gelirrow.AccountingRowOriginalCreateDate = DateTime.Now;
                    gelirrow.ConfirmDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(gelirrow);
                    db.SaveChanges();

                    Tbl_AccountingRow satislarrow = new Tbl_AccountingRow();
                    satislarrow.AccountRowKey = rowkery;
                    satislarrow.AccountingRow = HwsapKoduSatislar;
                    satislarrow.AccountingRowDate = DateTime.Now;
                    satislarrow.AccountingRowCreateDate = DateTime.Now;
                    satislarrow.AccountingRowDescription = "Gelir tahakkuku satışlar";
                    satislarrow.AccountingRowType = "Alacak";
                    satislarrow.AccountingRowOrjKur = compakur;
                    satislarrow.AccountingRowOrjKurRate = 5;
                    satislarrow.AccountingRowOrjKurtutar = System.Math.Abs(A - B);
                    satislarrow.AccountingRowCompanyKur = compakur;
                    satislarrow.AccountingRowCompanyKurRate = 5;
                    satislarrow.AccountingRowCompanyKurTutar = System.Math.Abs(A - B);
                    satislarrow.AccountingRowKayıtTuru = "Alacak - Gelir Tahakkuku satıişlar";
                    satislarrow.AccountingBelgeRefNo = "Gelir tahakkuku satışlar - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                    satislarrow.AccountingBelgeWhere = "Gelir tahakkuku satuşlar - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                    satislarrow.company = compa;
                    satislarrow.IsActive = true;
                    satislarrow.Creater = usg;
                    satislarrow.ConfirmUser = usg;
                    satislarrow.AccountingRowOriginalCreateDate = DateTime.Now;
                    satislarrow.AccountingRowCreateDate = DateTime.Now;
                    satislarrow.AccountingRowDate = DateTime.Now;
                    satislarrow.AccountingRowOriginalCreateDate = DateTime.Now;
                    satislarrow.ConfirmDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(satislarrow);
                    db.SaveChanges();
                    status = "Hesaplandı";
                }
                else if (B > A)
                {
                 
                    Tbl_AccountingRow gelirrow = new Tbl_AccountingRow();
                    gelirrow.AccountRowKey = rowkery;
                    gelirrow.AccountingRow = HesapKoduErtelenmişGelir;
                    gelirrow.AccountingRowCreateDate = DateTime.Now;
                    gelirrow.AccountingRowDate = DateTime.Now;
                    gelirrow.AccountingRowDescription = "Ertelenmiş Gelir";
                    gelirrow.AccountingRowOrjKur = compakur;
                    gelirrow.AccountingRowOrjKurRate = 5;
                    gelirrow.AccountingRowOrjKurtutar = System.Math.Abs(A - B);
                    gelirrow.AccountingRowCompanyKurTutar = System.Math.Abs(A - B);
                    gelirrow.AccountingRowCompanyKur = compakur;
                    gelirrow.AccountingRowCompanyKurRate = 5;
                    gelirrow.AccountingRowKayıtTuru = "Alacak - Ertelenmiş Gelir";
                    gelirrow.AccountingRowType = "Alacak";
                    gelirrow.company = compa;
                    gelirrow.Creater = usg;
                    gelirrow.ConfirmUser = usg;
                    gelirrow.IsActive = true;
                    gelirrow.AccountingBelgeRefNo = "Ertelenmiş Gelir - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                    gelirrow.AccountingBelgeWhere = "Ertelenmiş Gelir - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                    gelirrow.AccountingRowOriginalCreateDate = DateTime.Now;
                    gelirrow.ConfirmDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(gelirrow);
                    db.SaveChanges();

                    Tbl_AccountingRow satislarrow = new Tbl_AccountingRow();
                    satislarrow.AccountRowKey = rowkery;
                    satislarrow.AccountingRow = HwsapKoduSatislar;
                    satislarrow.AccountingRowDate = DateTime.Now;
                    satislarrow.AccountingRowCreateDate = DateTime.Now;
                    satislarrow.AccountingRowDescription = "Gelir tahakkuku satışlar";
                    satislarrow.AccountingRowType = "Borç";
                    satislarrow.AccountingRowOrjKur = compakur;
                    satislarrow.AccountingRowOrjKurRate = 5;
                    satislarrow.AccountingRowOrjKurtutar = System.Math.Abs(A - B);
                    satislarrow.AccountingRowCompanyKur = compakur;
                    satislarrow.AccountingRowCompanyKurRate = 5;
                    satislarrow.AccountingRowCompanyKurTutar = System.Math.Abs(A - B);
                    satislarrow.AccountingRowKayıtTuru = "Borç - Gelir Tahakkuku satıişlar";
                    satislarrow.AccountingBelgeRefNo = "Ertelenmiş Gelir - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                    satislarrow.AccountingBelgeWhere = "Ertelenmiş Gelir - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                    satislarrow.company = compa;
                    satislarrow.IsActive = true;
                    satislarrow.Creater = usg;
                    satislarrow.ConfirmDate = DateTime.Now;
                    satislarrow.ConfirmUser = usg;
                    satislarrow.AccountingRowOriginalCreateDate = DateTime.Now;
                    satislarrow.ConfirmDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(satislarrow);
                    db.SaveChanges();
                    status = "Hesaplandı";
                }
                status = "BoşGeçti";
            }
            return status;
        }

        public string CalculateGiderTahakkuku(DateTime? Startdate, DateTime? Enddate, string HesapKoduGiderTahakkuku, string HesapKoduGider, string HesapKoduMaliyet, string compa, string compakur, Guid? usg)
        {
            double? tahakkukkodu = 0;
            var tahhakkuktutar = db.Tbl_Accounting.Where(p => p.AccountingHesapTuru == "Gider Tahakkuku").ToList();
            foreach (var itemtahakkuk in tahhakkuktutar)
            {
                var tahakkukkoduT = db.Tbl_AccountingRow.Where(p => p.AccountingRow == itemtahakkuk.AccountingHesapKodu).ToList();
                if (tahakkukkoduT.Count() > 0)
                {
                    tahakkukkodu = db.Tbl_AccountingRow.Where(p => p.AccountingRow == itemtahakkuk.AccountingHesapKodu).Sum(p => p.AccountingRowCompanyKurTutar);
                }
            }
            var maxrowkry = db.Tbl_AccountingRow.Where(p => p.company == compa).Max(p => p.AccountRowKey);
            int maxrowkeyint = Convert.ToInt32(maxrowkry) + 1;
            int rowkery = maxrowkeyint;
            double completedtaskrevenue = 0;
            double sameseasonaccountingrevenue = 0;
            string status = "Hesaplama";
            double completedprojects = 0;
            var completedprojectsT = db.Tbl_EventStore.Where(p => p.Company == compa && p.IsActive == true && p.durum_id == "3").ToList();
            if (completedprojectsT.Count()>0)
            {
                completedprojects = db.Tbl_EventStore.Where(p => p.Company == compa && p.IsActive == true && p.durum_id == "3").Sum(p => p.EventTotalCost);
            }
            completedtaskrevenue = Convert.ToDouble(completedprojects);
            double sameseasonaccountingrevenuelistCredit = 0;
            double sameseasonaccountingrevenuelistDebit = 0;
            var expensetürühesaplar = db.Tbl_Accounting.Where(p => p.AccountingCompa == compa && p.AccountingIsActive == true && p.AccountingHesapTuru == "Gider").ToList();
            foreach (var item in expensetürühesaplar)
            {
                var sameseasonaccountingrevenuelistCreditT = db.Tbl_AccountingRow.Where(p => p.AccountingRow == item.AccountingHesapKodu && p.AccountingRowType == "Alacak").ToList();
                if (sameseasonaccountingrevenuelistCreditT.Count() > 0)
                {
                    sameseasonaccountingrevenuelistCredit += db.Tbl_AccountingRow.Where(p => p.AccountingRow == item.AccountingHesapKodu && p.AccountingRowType == "Alacak").Sum(p => p.AccountingRowCompanyKurTutar);
                }
                var sameseasonaccountingrevenuelistDebitT = db.Tbl_AccountingRow.Where(p => p.AccountingRow == item.AccountingHesapKodu && p.AccountingRowType == "Borç").ToList();
                if (sameseasonaccountingrevenuelistDebitT.Count() > 0)
                {
                    sameseasonaccountingrevenuelistDebit += db.Tbl_AccountingRow.Where(p => p.AccountingRow == item.AccountingHesapKodu && p.AccountingRowType == "Borç").Sum(p => p.AccountingRowCompanyKurTutar);
                }
            }
            sameseasonaccountingrevenue = Convert.ToDouble(sameseasonaccountingrevenuelistDebit) - Convert.ToDouble(sameseasonaccountingrevenuelistCredit);
            double A = System.Math.Round(completedtaskrevenue,2);
            double B = System.Math.Round(sameseasonaccountingrevenue,2);
            if((tahakkukkodu-(A-B)) != 0) { 
            if (A > B)
            {
                Tbl_AccountingRow gelirrow = new Tbl_AccountingRow();
                gelirrow.AccountRowKey = rowkery;
                gelirrow.AccountingRow = HesapKoduGiderTahakkuku;
                gelirrow.AccountingRowDate = DateTime.Now;
                gelirrow.AccountingRowCreateDate = DateTime.Now;
                gelirrow.AccountingRowDescription = "Gider tahakkuku";
                gelirrow.AccountingRowType = "Alacak";
                gelirrow.AccountingRowOrjKur = compakur;
                gelirrow.AccountingRowOrjKurRate = 5;
                gelirrow.AccountingRowOrjKurtutar = System.Math.Abs(A - B);
                gelirrow.AccountingRowCompanyKur = compakur;
                gelirrow.AccountingRowCompanyKurRate = 5;
                gelirrow.AccountingRowCompanyKurTutar = System.Math.Abs(A - B);
                gelirrow.AccountingRowKayıtTuru = "Alacak - Gider Tahakkuku";
                gelirrow.AccountingBelgeRefNo = "Gider tahakkuku - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                gelirrow.AccountingBelgeWhere = "Gider tahakkuku - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                gelirrow.company = compa;
                gelirrow.IsActive = true;
                gelirrow.Creater = usg;
                gelirrow.ConfirmUser = usg;
                gelirrow.AccountingRowOriginalCreateDate = DateTime.Now;
                gelirrow.AccountingRowCreateDate = DateTime.Now;
                gelirrow.AccountingRowDate = DateTime.Now;
                gelirrow.AccountingRowOriginalCreateDate = DateTime.Now;
                gelirrow.ConfirmDate = DateTime.Now;
                db.Tbl_AccountingRow.Add(gelirrow);
                db.SaveChanges();

                Tbl_AccountingRow satislarrow = new Tbl_AccountingRow();
                satislarrow.AccountRowKey = rowkery;
                satislarrow.AccountingRow = HesapKoduMaliyet;
                satislarrow.AccountingRowDate = DateTime.Now;
                satislarrow.AccountingRowCreateDate = DateTime.Now;
                satislarrow.AccountingRowDescription = "Gider tahakkuku satışlar";
                satislarrow.AccountingRowType = "Borç";
                satislarrow.AccountingRowOrjKur = compakur;
                satislarrow.AccountingRowOrjKurRate = 5;
                satislarrow.AccountingRowOrjKurtutar = System.Math.Abs(A - B);
                satislarrow.AccountingRowCompanyKur = compakur;
                satislarrow.AccountingRowCompanyKurRate = 5;
                satislarrow.AccountingRowCompanyKurTutar = System.Math.Abs(A - B);
                satislarrow.AccountingRowKayıtTuru = "Borç - Gider Tahakkuku satıişlar";
                satislarrow.AccountingBelgeRefNo = "Gider tahakkuku satışlar - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                satislarrow.AccountingBelgeWhere = "Gider tahakkuku satuşlar - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                satislarrow.company = compa;
                satislarrow.IsActive = true;
                satislarrow.Creater = usg;
                satislarrow.ConfirmUser = usg;
                satislarrow.AccountingRowOriginalCreateDate = DateTime.Now;
                satislarrow.AccountingRowCreateDate = DateTime.Now;
                satislarrow.AccountingRowDate = DateTime.Now;
                satislarrow.AccountingRowOriginalCreateDate = DateTime.Now;
                satislarrow.ConfirmDate = DateTime.Now;
                db.Tbl_AccountingRow.Add(satislarrow);
                db.SaveChanges();
                status = "Hesaplandı";
                }
            else if (B > A)
            {
                Tbl_AccountingRow gelirrow = new Tbl_AccountingRow();
                gelirrow.AccountRowKey = rowkery;
                gelirrow.AccountingRow = HesapKoduMaliyet;
                gelirrow.AccountingRowDate = DateTime.Now;
                gelirrow.AccountingRowCreateDate = DateTime.Now;
                gelirrow.AccountingRowDescription = "Gider Tahakkuku";
                gelirrow.AccountingRowType = "Alacak";
                gelirrow.AccountingRowOrjKur = compakur;
                gelirrow.AccountingRowOrjKurRate = 5;
                gelirrow.AccountingRowOrjKurtutar = System.Math.Abs(A - B);
                gelirrow.AccountingRowCompanyKur = compakur;
                gelirrow.AccountingRowCompanyKurRate = 5;
                gelirrow.AccountingRowCompanyKurTutar = System.Math.Abs(A - B);
                gelirrow.AccountingRowKayıtTuru = "Alacak - ErtelenmişGider Tahakkuku";
                gelirrow.AccountingBelgeRefNo = "Gider Tahakkuku - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                gelirrow.AccountingBelgeWhere = "Gider Tahakkuku - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                gelirrow.company = compa;
                gelirrow.IsActive = true;
                gelirrow.Creater = usg;
                gelirrow.ConfirmDate = DateTime.Now;
                gelirrow.ConfirmUser = usg;
                gelirrow.AccountingRowOriginalCreateDate = DateTime.Now;
                gelirrow.AccountingRowOriginalCreateDate = DateTime.Now;
                gelirrow.AccountingRowCreateDate = DateTime.Now;
                gelirrow.AccountingRowDate = DateTime.Now;
                gelirrow.AccountingRowOriginalCreateDate = DateTime.Now;
                gelirrow.ConfirmDate = DateTime.Now;
                db.Tbl_AccountingRow.Add(gelirrow);
                db.SaveChanges();

                Tbl_AccountingRow satislarrow = new Tbl_AccountingRow();
                satislarrow.AccountRowKey = rowkery;
                satislarrow.AccountingRow = HesapKoduGider;
                satislarrow.AccountingRowDate = DateTime.Now;
                satislarrow.AccountingRowCreateDate = DateTime.Now;
                satislarrow.AccountingRowDescription = "Peşin Ödenmiş Gider";
                satislarrow.AccountingRowType = "Borç";
                satislarrow.AccountingRowOrjKur = compakur;
                satislarrow.AccountingRowOrjKurRate = 5;
                satislarrow.AccountingRowOrjKurtutar = System.Math.Abs(A - B);
                satislarrow.AccountingRowCompanyKur = compakur;
                satislarrow.AccountingRowCompanyKurRate = 5;
                satislarrow.AccountingRowCompanyKurTutar = System.Math.Abs(A - B);
                satislarrow.AccountingRowKayıtTuru = "Borç - Peşin Ödenmiş Gider";
                satislarrow.AccountingBelgeRefNo = "Peşin Ödenmiş Gider - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                satislarrow.AccountingBelgeWhere = "Peşin Ödenmiş Gider - " + Startdate.Value.ToShortDateString() + " to " + Enddate.Value.ToShortDateString();
                satislarrow.company = compa;
                satislarrow.IsActive = true;
                satislarrow.Creater = usg;
                satislarrow.ConfirmDate = DateTime.Now;
                satislarrow.ConfirmUser = usg;
                satislarrow.AccountingRowOriginalCreateDate = DateTime.Now;
                satislarrow.AccountingRowCreateDate = DateTime.Now;
                satislarrow.AccountingRowDate = DateTime.Now;
                satislarrow.AccountingRowOriginalCreateDate = DateTime.Now;
                satislarrow.ConfirmDate = DateTime.Now;
                db.Tbl_AccountingRow.Add(satislarrow);
                db.SaveChanges();
                status = "Hesaplandı";
                }
                status = "BoşGeçti";
            }
            return status;
        }

        public bool CalculateReliazeFXChangeRate(string usgto,string where,string compabank,string compa,string compakur,string usg,int rowkery,int? colid, List<colinvoices> coinv, bool status = false, string typeForRow = "Null")
        {
            string ticarialacak = "";
            double exchangerate = 0;
            var tahsilat = db.Tbl_Collection.Where(p => p.Company == compa && p.CollectID == colid).SingleOrDefault();
            var maxrowkry = db.Tbl_AccountingRow.Where(p => p.company == compa).Max(p => p.AccountRowKey);
            int maxrowkeyint = Convert.ToInt32(maxrowkry) + 1;
            rowkery = maxrowkeyint;
            Tbl_Match newmatch = new Tbl_Match();
            newmatch.Company = compa;
            newmatch.IsActive = true;
            newmatch.MatchDate = DateTime.Now;
            newmatch.MatchFrom = "Collection";
            newmatch.MatchFromID = tahsilat.CollectID.ToString();
            newmatch.MatchGuid = Guid.NewGuid();
            newmatch.MatchTime = DateTime.Now.TimeOfDay;
            newmatch.MatchTo = "Invoice";
            newmatch.MatchUser = Guid.Parse(usg);
            newmatch.Dates = DateTime.Now;
            newmatch.OriginalDate = DateTime.Now;
            db.Tbl_Match.Add(newmatch);
            db.SaveChanges();
            List<Tbl_EventFatura> invlist = new List<Tbl_EventFatura>();
            foreach (var item in coinv)
            {
                var invoices = db.Tbl_EventFatura.Where(p => p.Company == compa && p.EventFaturaGuid == item.invoiceguid).SingleOrDefault();
                invlist.Add(invoices);
            }
            foreach (var inv in invlist)
            {
                if (typeForRow != "Null")
                {
                                ticarialacak = typeForRow;
                }
                else
                {
                    var invoicealt = db.Tbl_EventFaturaEvents.Where(p => p.Company == compa && p.IsActive == true && p.EventFaturaGuid == inv.EventFaturaGuid).Take(1).SingleOrDefault();
                    var invoiceacc = db.Tbl_AccountingRow.Where(p => p.AccountingBelgeWhere == "Invoice" && p.AccountingBelgeRefNo == invoicealt.EventFaturaFaturaJobsGuid.ToString()).ToList();
                    foreach (var item in invoiceacc)
                    {
                        var muhasebekod = db.Tbl_Accounting.Where(p => p.AccountingHesapKodu == item.AccountingRow && p.AccountingCompa == compa && p.AccountingIsActive == true).SingleOrDefault();
                        if (muhasebekod != null)
                        {

                            if (muhasebekod.AccountingHesapTuru == "Alacak")
                            {
                                ticarialacak = muhasebekod.AccountingHesapKodu;
                            }
                        }
                    }
                }
                
                if (inv.EventFaturaKur == tahsilat.CollectFX)
                {
                    var deger = System.Math.Round(Convert.ToDouble(inv.EventFaturaKalan - tahsilat.CollectKalan),2);
                    if (deger == 0 && tahsilat.CollectKalan > 0)
                    {
                        inv.EventFaturaTahsilEdilen = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)),2);
                        inv.EventFaturaKalan = 0;
                        tahsilat.CollectTahsilEdilen = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (tahsilat.CollectPrice - tahsilat.CollectKalan)),2);
                        tahsilat.CollectKalan = 0;
                        Tbl_MatchTo newmto = new Tbl_MatchTo();
                        newmto.Company = compa;
                        newmto.IsActive = true;
                        newmto.MatchDate = DateTime.Now;
                        newmto.MatchFromGuid = newmatch.MatchGuid;
                        newmto.MatchTime = DateTime.Now.TimeOfDay;
                        newmto.MatchTouniq = inv.EventFaturaGuid.ToString();
                        newmto.MatchToWhere = "Invoice";
                        newmto.MatchType = "Numerical";
                        newmto.MatchTypeKısmen = "All";
                        newmto.MatchTypeEslesenKısım = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2).ToString();
                        db.Tbl_MatchTo.Add(newmto);
                        db.SaveChanges();
                        if (compakur != inv.EventFaturaKur)
                        {
                            var fxchange = (CalculateFXRateSelectedDay(Convert.ToDateTime(tahsilat.CollectDateFX), inv.EventFaturaKur, compakur, compabank) -( 1 / inv.EventFaturaKurRate)) * tahsilat.CollectPrice;
                            exchangerate = System.Math.Abs(fxchange);
                            if (fxchange > 0)
                            {
                                //Muhaseleştirilmemiş olan satış fautraları eşleştirilememsi down payment kontrol
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate profit invoice #"+inv.EventFaturaNo;
                                newrow.AccountingRowType = "Borç";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Borç";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "646";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Alacak";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Alacak";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }
                            else
                            {
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate loss #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Alacak";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Alacak";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "656";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate loss #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Borç";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Borç";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }

                            if (where == "Clients")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                            else if (where == "User")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                        }

                    }
                    else if (deger > 0 && tahsilat.CollectKalan > 0)
                    {
                        inv.EventFaturaTahsilEdilen = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)),2);
                        inv.EventFaturaKalan = System.Math.Round(deger,2);
                        tahsilat.CollectTahsilEdilen = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (tahsilat.CollectPrice - tahsilat.CollectKalan)),2);
                        tahsilat.CollectKalan = 0;
                        Tbl_MatchTo newmto = new Tbl_MatchTo();
                        newmto.Company = compa;
                        newmto.IsActive = true;
                        newmto.MatchDate = DateTime.Now;
                        newmto.MatchFromGuid = newmatch.MatchGuid;
                        newmto.MatchTime = DateTime.Now.TimeOfDay;
                        newmto.MatchTouniq = inv.EventFaturaGuid.ToString();
                        newmto.MatchToWhere = "Invoice";
                        newmto.MatchType = "Numerical";
                        newmto.MatchTypeKısmen = "All";
                        newmto.MatchTypeEslesenKısım = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2).ToString();
                        db.Tbl_MatchTo.Add(newmto);
                        db.SaveChanges();
                        if (compakur != inv.EventFaturaKur)
                        {
                            var fxchange = System.Math.Round(Convert.ToDouble((CalculateFXRateSelectedDay(Convert.ToDateTime(tahsilat.CollectDateFX), inv.EventFaturaKur, compakur, compabank) - (1 / inv.EventFaturaKurRate)) * tahsilat.CollectPrice),2);
                            exchangerate = System.Math.Abs(fxchange);
                            if (fxchange > 0)
                            {
                                //Muhaseleştirilmemiş olan satış fautraları eşleştirilememsi down payment kontrol
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Borç";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Borç";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "646";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate invoice profit #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Alacak";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Alacak";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }
                            else
                            {
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Alacak";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Alacak";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "656";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Borç";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Borç";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }


                            if (where == "Clients")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                            else if (where == "User")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                        }

                    }
                    else if (deger < 0 && tahsilat.CollectKalan > 0)
                    {
                        inv.EventFaturaTahsilEdilen = System.Math.Round(Convert.ToDouble(inv.EventFaturaKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)),2);
                        inv.EventFaturaKalan = 0;
                        tahsilat.CollectTahsilEdilen = System.Math.Round(Convert.ToDouble(inv.EventFaturaTahsilEdilen + (tahsilat.CollectPrice - tahsilat.CollectKalan)),2);
                        tahsilat.CollectKalan = System.Math.Round(System.Math.Abs(deger),2);
                        Tbl_MatchTo newmto = new Tbl_MatchTo();
                        newmto.Company = compa;
                        newmto.IsActive = true;
                        newmto.MatchDate = DateTime.Now;
                        newmto.MatchFromGuid = newmatch.MatchGuid;
                        newmto.MatchTime = DateTime.Now.TimeOfDay;
                        newmto.MatchTouniq = inv.EventFaturaGuid.ToString();
                        newmto.MatchToWhere = "Invoice";
                        newmto.MatchType = "Numerical";
                        newmto.MatchTypeKısmen = "Partial";
                        newmto.MatchTypeEslesenKısım = System.Math.Round(Convert.ToDouble(inv.EventFaturaKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2).ToString();
                        db.Tbl_MatchTo.Add(newmto);
                        db.SaveChanges();
                        if (compakur != inv.EventFaturaKur)
                        {
                            var fxchange = System.Math.Round(Convert.ToDouble((CalculateFXRateSelectedDay(Convert.ToDateTime(tahsilat.CollectDateFX), inv.EventFaturaKur, compakur, compabank) -(1 / inv.EventFaturaKurRate)) * (tahsilat.CollectPrice-System.Math.Round(deger))),2);
                            exchangerate = System.Math.Abs(fxchange);
                            if (fxchange > 0)
                            {
                                //Muhaseleştirilmemiş olan satış fautraları eşleştirilememsi down payment kontrol
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Borç";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Borç";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "646";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate profit #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Alacak";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Alacak";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }
                            else
                            {
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Alacak";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Alacak";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "656";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Borç";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Borç";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }


                            if (where == "Clients")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                            else if (where == "User")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                        }

                    }
                    status = true;
                }
                else
                {
                    double vlue = System.Math.Round(Convert.ToDouble(FXCalculateSelectedDay(inv.EventFaturaToplamTutarKDVdahil, inv.EventFaturaTarihi, tahsilat.CollectFX, inv.EventFaturaKur, compabank)),2);
                    if (vlue > tahsilat.CollectPrice)
                    {
                        vlue = System.Math.Round(Convert.ToDouble(tahsilat.CollectPrice),2);
                    }
                    double tahsilatgunututar = System.Math.Round(Convert.ToDouble(FXCalculateSelectedDay(vlue, tahsilat.CollectDateFX.Date, inv.EventFaturaKur, tahsilat.CollectFX, compabank)),2);
                    if (vlue == tahsilat.CollectPrice)
                    {
                        inv.EventFaturaTahsilEdilen = System.Math.Round(Convert.ToDouble(tahsilatgunututar + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)),2);
                        inv.EventFaturaKalan = System.Math.Round(Convert.ToDouble(inv.EventFaturaToplamTutarKDVdahil - tahsilatgunututar),2);
                        tahsilat.CollectTahsilEdilen = System.Math.Round(Convert.ToDouble(vlue + (tahsilat.CollectPrice - tahsilat.CollectKalan)),2);
                        tahsilat.CollectKalan = 0;
                        Tbl_MatchTo newmto = new Tbl_MatchTo();
                        newmto.Company = compa;
                        newmto.IsActive = true;
                        newmto.MatchDate = DateTime.Now;
                        newmto.MatchFromGuid = newmatch.MatchGuid;
                        newmto.MatchTime = DateTime.Now.TimeOfDay;
                        newmto.MatchTouniq = inv.EventFaturaGuid.ToString();
                        newmto.MatchToWhere = "Invoice";
                        newmto.MatchType = "Numerical";
                        newmto.MatchTypeKısmen = "All";
                        newmto.MatchTypeEslesenKısım = System.Math.Round(Convert.ToDouble(tahsilatgunututar + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2).ToString();
                        db.Tbl_MatchTo.Add(newmto);
                        db.SaveChanges();
                    }
                    else
                    {
                        inv.EventFaturaTahsilEdilen = tahsilatgunututar + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan);
                        inv.EventFaturaKalan = 0;
                        tahsilat.CollectTahsilEdilen = vlue;
                        tahsilat.CollectKalan = tahsilat.CollectKalan - vlue + (tahsilat.CollectPrice - tahsilat.CollectKalan);
                        Tbl_MatchTo newmto = new Tbl_MatchTo();
                        newmto.Company = compa;
                        newmto.IsActive = true;
                        newmto.MatchDate = DateTime.Now;
                        newmto.MatchFromGuid = newmatch.MatchGuid;
                        newmto.MatchTime = DateTime.Now.TimeOfDay;
                        newmto.MatchTouniq = inv.EventFaturaGuid.ToString();
                        newmto.MatchToWhere = "Invoice";
                        newmto.MatchType = "Numerical";
                        newmto.MatchTypeKısmen = "Partial";
                        newmto.MatchTypeEslesenKısım = tahsilatgunututar + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan).ToString();
                        db.Tbl_MatchTo.Add(newmto);
                        db.SaveChanges();
                    }



                    Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                    newrow2.AccountRowKey = rowkery;
                    newrow2.AccountingRow = ticarialacak;
                    newrow2.AccountingRowDate = DateTime.Now;
                    newrow2.AccountingRowCreateDate = DateTime.Now;
                    newrow2.AccountingRowDescription = "Clear";
                    newrow2.AccountingRowType = "Borç";
                    newrow2.AccountingRowOrjKurtutar = vlue;
                    newrow2.AccountingRowOrjKur = tahsilat.CollectFX;
                    newrow2.AccountingRowOrjKurRate = 1;
                    newrow2.AccountingRowCompanyKurTutar = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate),2);
                    newrow2.AccountingRowCompanyKur = compakur;
                    newrow2.AccountingRowCompanyKurRate = 1;
                    newrow2.AccountingRowKayıtTuru = "Borç";
                    newrow2.company = compa;
                    newrow2.IsActive = true;
                    newrow2.Creater = Guid.Parse(usg);
                    newrow2.ConfirmUser = Guid.Parse(usg);
                    newrow2.ConfirmDate = DateTime.Now;
                    newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(newrow2);
                    db.SaveChanges();


                    Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                    newrow.AccountRowKey = rowkery;
                    newrow.AccountingRow = "61";
                    newrow.AccountingRowDate = DateTime.Now;
                    newrow.AccountingRowCreateDate = DateTime.Now;
                    newrow.AccountingRowDescription = "Clear";
                    newrow.AccountingRowType = "Alacak";
                    newrow.AccountingRowOrjKurtutar = vlue;
                    newrow.AccountingRowOrjKur = tahsilat.CollectFX;
                    newrow.AccountingRowOrjKurRate = 1;
                    newrow.AccountingRowCompanyKurTutar = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate),2);
                    newrow.AccountingRowCompanyKur = compakur;
                    newrow.AccountingRowCompanyKurRate = 1;
                    newrow.AccountingRowKayıtTuru = "Alacak";
                    newrow.company = compa;
                    newrow.IsActive = true;
                    newrow.Creater = Guid.Parse(usg);
                    newrow.ConfirmUser = Guid.Parse(usg);
                    newrow.ConfirmDate = DateTime.Now;
                    newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(newrow);
                    db.SaveChanges();



                    Tbl_AccountingRow newrow3 = new Tbl_AccountingRow();
                    newrow3.AccountRowKey = rowkery;
                    newrow3.AccountingRow = ticarialacak;
                    newrow3.AccountingRowDate = DateTime.Now;
                    newrow3.AccountingRowCreateDate = DateTime.Now;
                    newrow3.AccountingRowDescription = "Clear";
                    newrow3.AccountingRowType = "Alacak";
                    newrow3.AccountingRowOrjKurtutar = tahsilatgunututar;
                    newrow3.AccountingRowOrjKur = inv.EventFaturaKur;
                    newrow3.AccountingRowOrjKurRate = 1;
                    newrow3.AccountingRowCompanyKurTutar = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate),2);
                    newrow3.AccountingRowCompanyKur = compakur;
                    newrow3.AccountingRowCompanyKurRate = 1;
                    newrow3.AccountingRowKayıtTuru = "Alacak";
                    newrow3.company = compa;
                    newrow3.IsActive = true;
                    newrow3.Creater = Guid.Parse(usg);
                    newrow3.ConfirmUser = Guid.Parse(usg);
                    newrow3.ConfirmDate = DateTime.Now;
                    newrow3.AccountingRowOriginalCreateDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(newrow3);
                    db.SaveChanges();

                    Tbl_AccountingRow newrow4 = new Tbl_AccountingRow();
                    newrow4.AccountRowKey = rowkery;
                    newrow4.AccountingRow = "61";
                    newrow4.AccountingRowDate = DateTime.Now;
                    newrow4.AccountingRowCreateDate = DateTime.Now;
                    newrow4.AccountingRowDescription = "Clear";
                    newrow4.AccountingRowType = "Borç";
                    newrow4.AccountingRowOrjKurtutar = tahsilatgunututar;
                    newrow4.AccountingRowOrjKur = inv.EventFaturaKur;
                    newrow4.AccountingRowOrjKurRate = 1;
                    newrow4.AccountingRowCompanyKurTutar = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate),2);
                    newrow4.AccountingRowCompanyKur = compakur;
                    newrow4.AccountingRowCompanyKurRate = 1;
                    newrow4.AccountingRowKayıtTuru = "Borç";
                    newrow4.company = compa;
                    newrow4.IsActive = true;
                    newrow4.Creater = Guid.Parse(usg);
                    newrow4.ConfirmUser = Guid.Parse(usg);
                    newrow4.ConfirmDate = DateTime.Now;
                    newrow4.AccountingRowOriginalCreateDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(newrow4);
                    db.SaveChanges();

                    if (compakur != inv.EventFaturaKur)
                    {
                        exchangerate = System.Math.Round(Convert.ToDouble((CalculateFXRateSelectedDay(Convert.ToDateTime(tahsilat.CollectDateFX), inv.EventFaturaKur, compakur, compabank) - (1 / inv.EventFaturaKurRate)) * vlue / tahsilat.CollectFXRate),2);
                        exchangerate = exchangerate / CalculateFXRateSelectedDay(Convert.ToDateTime(tahsilat.CollectDateFX), inv.EventFaturaKur, compakur, compabank);
                        if (exchangerate > 0)
                        {
                            Tbl_AccountingRow newrow5 = new Tbl_AccountingRow();
                            newrow5.AccountRowKey = rowkery;
                            newrow5.AccountingRow = ticarialacak;
                            newrow5.AccountingRowDate = DateTime.Now;
                            newrow5.AccountingRowCreateDate = DateTime.Now;
                            newrow5.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                            newrow5.AccountingRowType = "Borç";
                            newrow5.AccountingRowOrjKurtutar = 0;
                            newrow5.AccountingRowOrjKur = inv.EventFaturaKur;
                            newrow5.AccountingRowOrjKurRate = 1;
                            newrow5.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                            newrow5.AccountingRowCompanyKur = compakur;
                            newrow5.AccountingRowCompanyKurRate = 1;
                            newrow5.AccountingRowKayıtTuru = "Borç";
                            newrow5.company = compa;
                            newrow5.IsActive = true;
                            newrow5.Creater = Guid.Parse(usg);
                            newrow5.ConfirmUser = Guid.Parse(usg);
                            newrow5.ConfirmDate = DateTime.Now;
                            newrow5.AccountingRowOriginalCreateDate = DateTime.Now;
                            db.Tbl_AccountingRow.Add(newrow5);
                            db.SaveChanges();

                            Tbl_AccountingRow newrow6 = new Tbl_AccountingRow();
                            newrow6.AccountRowKey = rowkery;
                            newrow6.AccountingRow = "646";
                            newrow6.AccountingRowDate = DateTime.Now;
                            newrow6.AccountingRowCreateDate = DateTime.Now;
                            newrow6.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                            newrow6.AccountingRowType = "Alacak";
                            newrow6.AccountingRowOrjKurtutar = 0;
                            newrow6.AccountingRowOrjKur = inv.EventFaturaKur;
                            newrow6.AccountingRowOrjKurRate = 1;
                            newrow6.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                            newrow6.AccountingRowCompanyKur = compakur;
                            newrow6.AccountingRowCompanyKurRate = 1;
                            newrow6.AccountingRowKayıtTuru = "Alacak";
                            newrow6.company = compa;
                            newrow6.IsActive = true;
                            newrow6.Creater = Guid.Parse(usg);
                            newrow6.ConfirmUser = Guid.Parse(usg);
                            newrow6.ConfirmDate = DateTime.Now;
                            newrow6.AccountingRowOriginalCreateDate = DateTime.Now;
                            db.Tbl_AccountingRow.Add(newrow6);
                            db.SaveChanges();
                        }
                        else
                        {
                            Tbl_AccountingRow newrow5 = new Tbl_AccountingRow();
                            newrow5.AccountRowKey = rowkery;
                            newrow5.AccountingRow = ticarialacak;
                            newrow5.AccountingRowDate = DateTime.Now;
                            newrow5.AccountingRowCreateDate = DateTime.Now;
                            newrow5.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                            newrow5.AccountingRowType = "Alacak";
                            newrow5.AccountingRowOrjKurtutar = 0;
                            newrow5.AccountingRowOrjKur = inv.EventFaturaKur;
                            newrow5.AccountingRowOrjKurRate = 1;
                            newrow5.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                            newrow5.AccountingRowCompanyKur = compakur;
                            newrow5.AccountingRowCompanyKurRate = 1;
                            newrow5.AccountingRowKayıtTuru = "Alacak";
                            newrow5.company = compa;
                            newrow5.IsActive = true;
                            newrow5.Creater = Guid.Parse(usg);
                            newrow5.ConfirmUser = Guid.Parse(usg);
                            newrow5.ConfirmDate = DateTime.Now;
                            newrow5.AccountingRowOriginalCreateDate = DateTime.Now;
                            db.Tbl_AccountingRow.Add(newrow5);
                            db.SaveChanges();

                            Tbl_AccountingRow newrow6 = new Tbl_AccountingRow();
                            newrow6.AccountRowKey = rowkery;
                            newrow6.AccountingRow = "656";
                            newrow6.AccountingRowDate = DateTime.Now;
                            newrow6.AccountingRowCreateDate = DateTime.Now;
                            newrow6.AccountingRowDescription = "Exchange rate loss invoice 3" + inv.EventFaturaNo;
                            newrow6.AccountingRowType = "Borç";
                            newrow6.AccountingRowOrjKurtutar = 0;
                            newrow6.AccountingRowOrjKur = inv.EventFaturaKur;
                            newrow6.AccountingRowOrjKurRate = 1;
                            newrow6.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                            newrow6.AccountingRowCompanyKur = compakur;
                            newrow6.AccountingRowCompanyKurRate = 1;
                            newrow6.AccountingRowKayıtTuru = "Borç";
                            newrow6.company = compa;
                            newrow6.IsActive = true;
                            newrow6.Creater = Guid.Parse(usg);
                            newrow6.ConfirmUser = Guid.Parse(usg);
                            newrow6.ConfirmDate = DateTime.Now;
                            newrow6.AccountingRowOriginalCreateDate = DateTime.Now;
                            db.Tbl_AccountingRow.Add(newrow6);
                            db.SaveChanges();


                        }

                    }
                    //120ye attığım toplam 4 satır cariyede at

                    if(where == "Clients")
                    {
                        Tbl_CariFish newcari = new Tbl_CariFish();
                        newcari.CustomerID = inv.EventFaturaMusteriId.ToString();
                        newcari.CariWhere = "Client";
                        newcari.ProccesType = "Pairing";
                        newcari.BelgeRef = "EXC";
                        newcari.BelgeRefWhere = "EXC";
                        newcari.DebitCredit = "Borç";
                        newcari.OrjFX = tahsilat.CollectFX;
                        newcari.OrjFXPrice = vlue;
                        newcari.FX = compakur;
                        newcari.FXPrice = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate),2);
                        newcari.CumulativeBallance = 0;
                        newcari.AccountingCode = ticarialacak;
                        newcari.Company = compa;
                        newcari.IsActive = true;
                        newcari.CariDate = DateTime.Now;
                        newcari.CariOriginalDate = DateTime.Now;
                        db.Tbl_CariFish.Add(newcari);
                        db.SaveChanges();


                        Tbl_CariFish newcari3 = new Tbl_CariFish();
                        newcari3.CustomerID = inv.EventFaturaMusteriId.ToString();
                        newcari3.CariWhere = "Client";
                        newcari3.ProccesType = "Pairing";
                        newcari3.BelgeRef = "EXC";
                        newcari3.BelgeRefWhere = "EXC";
                        newcari3.DebitCredit = "Alacak";
                        newcari3.OrjFX = inv.EventFaturaKur;
                        newcari3.OrjFXPrice = tahsilatgunututar;
                        newcari3.FX = compakur;
                        newcari3.FXPrice = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate),2);
                        newcari3.CumulativeBallance = 0;
                        newcari3.AccountingCode = ticarialacak;
                        newcari3.Company = compa;
                        newcari3.IsActive = true;
                        newcari3.CariOriginalDate = DateTime.Now;
                        newcari3.CariDate = DateTime.Now;
                        db.Tbl_CariFish.Add(newcari3);
                        db.SaveChanges();
                        if(exchangerate > 0)
                        {
                            Tbl_CariFish newcari4 = new Tbl_CariFish();
                            newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                            newcari4.CariWhere = "Client";
                            newcari4.ProccesType = "Pairing";
                            newcari4.BelgeRef = "EXC";
                            newcari4.BelgeRefWhere = "EXC";
                            newcari4.DebitCredit = "Borç";
                            newcari4.OrjFX = inv.EventFaturaKur;
                            newcari4.OrjFXPrice = 0;
                            newcari4.FX = compakur;
                            newcari4.FXPrice = System.Math.Abs(exchangerate);
                            newcari4.CumulativeBallance = 0;
                            newcari4.AccountingCode = ticarialacak;
                            newcari4.Company = compa;
                            newcari4.IsActive = true;
                            newcari4.CariDate = DateTime.Now;
                            newcari4.CariOriginalDate = DateTime.Now;
                            db.Tbl_CariFish.Add(newcari4);
                            db.SaveChanges();
                        }
                        else
                        {
                            Tbl_CariFish newcari4 = new Tbl_CariFish();
                            newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                            newcari4.CariWhere = "Client";
                            newcari4.ProccesType = "Pairing";
                            newcari4.BelgeRef = "EXC";
                            newcari4.BelgeRefWhere = "EXC";
                            newcari4.DebitCredit = "Alacak";
                            newcari4.OrjFX = inv.EventFaturaKur;
                            newcari4.OrjFXPrice = 0;
                            newcari4.FX = compakur;
                            newcari4.FXPrice = System.Math.Abs(exchangerate);
                            newcari4.CumulativeBallance = 0;
                            newcari4.AccountingCode = ticarialacak;
                            newcari4.Company = compa;
                            newcari4.IsActive = true;
                            newcari4.CariOriginalDate = DateTime.Now;
                            newcari4.CariDate = DateTime.Now;
                            db.Tbl_CariFish.Add(newcari4);
                            db.SaveChanges();
                        }
                        

                        //Tbl_CariFish newcari4 = new Tbl_CariFish();
                        //newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                        //newcari4.CariWhere = "Client";
                        //newcari4.ProccesType = "";
                        //newcari4.BelgeRef = "EXC";
                        //newcari4.BelgeRefWhere = "EXC";
                        //newcari4.DebitCredit = "Borç";
                        //newcari4.OrjFX = tahsilat.CollectFX;
                        //newcari4.OrjFXPrice = tahsilatgunututar;
                        //newcari4.FX = compakur;
                        //newcari4.FXPrice = vlue * tahsilat.CollectFXRate;
                        //newcari4.CumulativeBallance = 0;
                        //newcari4.AccountingCode = "61";
                        //newcari4.Company = compa;
                        //newcari4.IsActive = true;
                        //db.Tbl_CariFish.Add(newcari4);
                        //db.SaveChanges();
                    }
                   else if(where == "User")
                    {
                        Tbl_CariFish newcari = new Tbl_CariFish();
                        newcari.CustomerID = usgto;
                        newcari.CariWhere = "User";
                        newcari.ProccesType = "Pairing";
                        newcari.BelgeRef = "EXC";
                        newcari.BelgeRefWhere = "EXC";
                        newcari.DebitCredit = "Borç";
                        newcari.OrjFX = tahsilat.CollectFX;
                        newcari.OrjFXPrice = vlue;
                        newcari.FX = compakur;
                        newcari.FXPrice = System.Math.Round(Convert.ToDouble(vlue * tahsilat.CollectFXRate),2);
                        newcari.CumulativeBallance = 0;
                        newcari.AccountingCode = ticarialacak;
                        newcari.Company = compa;
                        newcari.IsActive = true;
                        newcari.CariDate = DateTime.Now;
                        newcari.CariOriginalDate = DateTime.Now;
                        db.Tbl_CariFish.Add(newcari);
                        db.SaveChanges();

                        //Tbl_CariFish newcari2 = new Tbl_CariFish();
                        //newcari2.CustomerID = usgto;
                        //newcari2.CariWhere = "User";
                        //newcari2.ProccesType = "";
                        //newcari2.BelgeRef = "EXC";
                        //newcari2.BelgeRefWhere = "EXC";
                        //newcari2.DebitCredit = "Alacak";
                        //newcari2.OrjFX = tahsilat.CollectFX;
                        //newcari2.OrjFXPrice = vlue;
                        //newcari2.FX = compakur;
                        //newcari2.FXPrice = vlue * tahsilat.CollectFXRate;
                        //newcari2.CumulativeBallance = 0;
                        //newcari2.AccountingCode = "61";
                        //newcari2.Company = compa;
                        //newcari2.IsActive = true;
                        //db.Tbl_CariFish.Add(newcari2);
                        //db.SaveChanges();

                        Tbl_CariFish newcari3 = new Tbl_CariFish();
                        newcari3.CustomerID = usgto;
                        newcari3.CariWhere = "User";
                        newcari3.ProccesType = "Pairing";
                        newcari3.BelgeRef = "EXC";
                        newcari3.BelgeRefWhere = "EXC";
                        newcari3.DebitCredit = "Alacak";
                        newcari3.OrjFX = inv.EventFaturaKur;
                        newcari3.OrjFXPrice = tahsilatgunututar;
                        newcari3.FX = compakur;
                        newcari3.FXPrice = System.Math.Round(Convert.ToDouble(vlue * tahsilat.CollectFXRate),2);
                        newcari3.CumulativeBallance = 0;
                        newcari3.AccountingCode = ticarialacak;
                        newcari3.Company = compa;
                        newcari3.IsActive = true;
                        newcari3.CariOriginalDate = DateTime.Now;
                        newcari3.CariDate = DateTime.Now;
                        db.Tbl_CariFish.Add(newcari3);
                        db.SaveChanges();


                        if (exchangerate > 0)
                        {
                            Tbl_CariFish newcari4 = new Tbl_CariFish();
                            newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                            newcari4.CariWhere = "Client";
                            newcari4.ProccesType = "Pairing";
                            newcari4.BelgeRef = "EXC";
                            newcari4.BelgeRefWhere = "EXC";
                            newcari4.DebitCredit = "Borç";
                            newcari4.OrjFX = inv.EventFaturaKur;
                            newcari4.OrjFXPrice = 0;
                            newcari4.FX = compakur;
                            newcari4.FXPrice = System.Math.Abs(exchangerate);
                            newcari4.CumulativeBallance = 0;
                            newcari4.AccountingCode = ticarialacak;
                            newcari4.Company = compa;
                            newcari4.IsActive = true;
                            newcari4.CariDate = DateTime.Now;
                            newcari4.CariOriginalDate = DateTime.Now;
                            db.Tbl_CariFish.Add(newcari4);
                            db.SaveChanges();
                        }
                        else
                        {
                            Tbl_CariFish newcari4 = new Tbl_CariFish();
                            newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                            newcari4.CariWhere = "Client";
                            newcari4.ProccesType = "Pairing";
                            newcari4.BelgeRef = "EXC";
                            newcari4.BelgeRefWhere = "EXC";
                            newcari4.DebitCredit = "Alacak";
                            newcari4.OrjFX = inv.EventFaturaKur;
                            newcari4.OrjFXPrice = 0;
                            newcari4.FX = compakur;
                            newcari4.FXPrice = System.Math.Abs(exchangerate);
                            newcari4.CumulativeBallance = 0;
                            newcari4.AccountingCode = ticarialacak;
                            newcari4.Company = compa;
                            newcari4.IsActive = true;
                            newcari4.CariOriginalDate = DateTime.Now;
                            newcari4.CariDate = DateTime.Now;
                            db.Tbl_CariFish.Add(newcari4);
                            db.SaveChanges();
                        }
                        //Tbl_CariFish newcari4 = new Tbl_CariFish();
                        //newcari4.CustomerID = usgto;
                        //newcari4.CariWhere = "User";
                        //newcari4.ProccesType = "";
                        //newcari4.BelgeRef = "EXC";
                        //newcari4.BelgeRefWhere = "EXC";
                        //newcari4.DebitCredit = "Borç";
                        //newcari4.OrjFX = tahsilat.CollectFX;
                        //newcari4.OrjFXPrice = tahsilatgunututar;
                        //newcari4.FX = compakur;
                        //newcari4.FXPrice = vlue * tahsilat.CollectFXRate;
                        //newcari4.CumulativeBallance = 0;
                        //newcari4.AccountingCode = "61";
                        //newcari4.Company = compa;
                        //newcari4.IsActive = true;
                        //db.Tbl_CariFish.Add(newcari4);
                        //db.SaveChanges();
                    }
                    status = true;
                }
            }
            return status;
        }

        public bool CalculateReliazeFXChangeRatePayment(string usgto, string where, string compabank, string compa, string compakur, string usg, int rowkery, int? colid, List<colinvoices> coinv, bool status = false, string typeForRow = "Null")
        {
            string ticarialacak = "";
            double exchangerate = 0;
            var tahsilat = db.Tbl_Collection.Where(p => p.Company == compa && p.CollectID == colid).SingleOrDefault();
            var maxrowkry = db.Tbl_AccountingRow.Where(p => p.company == compa).Max(p => p.AccountRowKey);
            int maxrowkeyint = Convert.ToInt32(maxrowkry) + 1;
            rowkery = maxrowkeyint;
            Tbl_Match newmatch = new Tbl_Match();
            newmatch.Company = compa;
            newmatch.IsActive = true;
            newmatch.MatchDate = DateTime.Now;
            newmatch.MatchFrom = "Collection";
            newmatch.MatchFromID = tahsilat.CollectID.ToString();
            newmatch.MatchGuid = Guid.NewGuid();
            newmatch.MatchTime = DateTime.Now.TimeOfDay;
            newmatch.MatchTo = "Invoice";
            newmatch.MatchUser = Guid.Parse(usg);
            newmatch.Dates = DateTime.Now;
            newmatch.OriginalDate = DateTime.Now;
            db.Tbl_Match.Add(newmatch);
            db.SaveChanges();
            List<Tbl_EventFatura> invlist = new List<Tbl_EventFatura>();
            foreach (var item in coinv)
            {
                var invoices = db.Tbl_EventFatura.Where(p => p.Company == compa && p.EventFaturaGuid == item.invoiceguid).SingleOrDefault();
                invlist.Add(invoices);
            }
            foreach (var inv in invlist)
            {
                if (typeForRow != "Null")
                {
                    ticarialacak = typeForRow;
                }
                else
                {
                    var invoicealt = db.Tbl_EventFaturaEvents.Where(p => p.Company == compa && p.IsActive == true && p.EventFaturaGuid == inv.EventFaturaGuid).Take(1).SingleOrDefault();
                    var invoiceacc = db.Tbl_AccountingRow.Where(p => p.AccountingBelgeWhere == "Invoice" && p.AccountingBelgeRefNo == invoicealt.EventFaturaFaturaJobsGuid.ToString()).ToList();
                    foreach (var item in invoiceacc)
                    {
                        var muhasebekod = db.Tbl_Accounting.Where(p => p.AccountingHesapKodu == item.AccountingRow && p.AccountingCompa == compa && p.AccountingIsActive == true).SingleOrDefault();
                        if (muhasebekod != null)
                        {

                            if (muhasebekod.AccountingHesapTuru == "Borç")
                            {
                                ticarialacak = muhasebekod.AccountingHesapKodu;
                            }
                        }
                    }
                }

                if (inv.EventFaturaKur == tahsilat.CollectFX)
                {
                    var deger = System.Math.Round(Convert.ToDouble(inv.EventFaturaKalan - tahsilat.CollectKalan), 2);
                    if (deger == 0 && tahsilat.CollectKalan > 0)
                    {
                        inv.EventFaturaTahsilEdilen = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2);
                        inv.EventFaturaKalan = 0;
                        tahsilat.CollectTahsilEdilen = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (tahsilat.CollectPrice - tahsilat.CollectKalan)), 2);
                        tahsilat.CollectKalan = 0;
                        Tbl_MatchTo newmto = new Tbl_MatchTo();
                        newmto.Company = compa;
                        newmto.IsActive = true;
                        newmto.MatchDate = DateTime.Now;
                        newmto.MatchFromGuid = newmatch.MatchGuid;
                        newmto.MatchTime = DateTime.Now.TimeOfDay;
                        newmto.MatchTouniq = inv.EventFaturaGuid.ToString();
                        newmto.MatchToWhere = "Invoice";
                        newmto.MatchType = "Numerical";
                        newmto.MatchTypeKısmen = "All";
                        newmto.MatchTypeEslesenKısım = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2).ToString();
                        db.Tbl_MatchTo.Add(newmto);
                        db.SaveChanges();
                        if (compakur != inv.EventFaturaKur)
                        {
                            var fxchange = (CalculateFXRateSelectedDay(Convert.ToDateTime(tahsilat.CollectDateFX), inv.EventFaturaKur, compakur, compabank) - (1 / inv.EventFaturaKurRate)) * tahsilat.CollectPrice;
                            exchangerate = System.Math.Abs(fxchange);
                            if (fxchange > 0)
                            {
                                //Muhaseleştirilmemiş olan satış fautraları eşleştirilememsi down payment kontrol
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Alacak";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Alacak";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "656";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Borç";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Borç";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }
                            else
                            {
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Borç";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Alacak";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "646";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate profit #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Alacak";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Alacak";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }

                            if (where == "Clients")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                            else if (where == "User")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                        }

                    }
                    else if (deger > 0 && tahsilat.CollectKalan > 0)
                    {
                        inv.EventFaturaTahsilEdilen = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2);
                        inv.EventFaturaKalan = System.Math.Round(deger, 2);
                        tahsilat.CollectTahsilEdilen = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (tahsilat.CollectPrice - tahsilat.CollectKalan)), 2);
                        tahsilat.CollectKalan = 0;
                        Tbl_MatchTo newmto = new Tbl_MatchTo();
                        newmto.Company = compa;
                        newmto.IsActive = true;
                        newmto.MatchDate = DateTime.Now;
                        newmto.MatchFromGuid = newmatch.MatchGuid;
                        newmto.MatchTime = DateTime.Now.TimeOfDay;
                        newmto.MatchTouniq = inv.EventFaturaGuid.ToString();
                        newmto.MatchToWhere = "Invoice";
                        newmto.MatchType = "Numerical";
                        newmto.MatchTypeKısmen = "All";
                        newmto.MatchTypeEslesenKısım = System.Math.Round(Convert.ToDouble(tahsilat.CollectKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2).ToString();
                        db.Tbl_MatchTo.Add(newmto);
                        db.SaveChanges();
                        if (compakur != inv.EventFaturaKur)
                        {
                            var fxchange = System.Math.Round(Convert.ToDouble((CalculateFXRateSelectedDay(Convert.ToDateTime(tahsilat.CollectDateFX), inv.EventFaturaKur, compakur, compabank) - (1 / inv.EventFaturaKurRate)) * tahsilat.CollectPrice), 2);
                            exchangerate = System.Math.Abs(fxchange);
                            if (fxchange > 0)
                            {
                                //Muhaseleştirilmemiş olan satış fautraları eşleştirilememsi down payment kontrol
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Alacak";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Alacak";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "656";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate invoice loss #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Borç";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Borç";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }
                            else
                            {
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Borç";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Borç";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "646";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Alacak";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Alacak";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }


                            if (where == "Clients")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                            else if (where == "User")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                        }

                    }
                    else if (deger < 0 && tahsilat.CollectKalan > 0)
                    {
                        inv.EventFaturaTahsilEdilen = System.Math.Round(Convert.ToDouble(inv.EventFaturaKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2);
                        inv.EventFaturaKalan = 0;
                        tahsilat.CollectTahsilEdilen = System.Math.Round(Convert.ToDouble(inv.EventFaturaTahsilEdilen + (tahsilat.CollectPrice - tahsilat.CollectKalan)), 2);
                        tahsilat.CollectKalan = System.Math.Round(System.Math.Abs(deger), 2);
                        Tbl_MatchTo newmto = new Tbl_MatchTo();
                        newmto.Company = compa;
                        newmto.IsActive = true;
                        newmto.MatchDate = DateTime.Now;
                        newmto.MatchFromGuid = newmatch.MatchGuid;
                        newmto.MatchTime = DateTime.Now.TimeOfDay;
                        newmto.MatchTouniq = inv.EventFaturaGuid.ToString();
                        newmto.MatchToWhere = "Invoice";
                        newmto.MatchType = "Numerical";
                        newmto.MatchTypeKısmen = "Partial";
                        newmto.MatchTypeEslesenKısım = System.Math.Round(Convert.ToDouble(inv.EventFaturaKalan + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2).ToString();
                        db.Tbl_MatchTo.Add(newmto);
                        db.SaveChanges();
                        if (compakur != inv.EventFaturaKur)
                        {
                            var fxchange = System.Math.Round(Convert.ToDouble((CalculateFXRateSelectedDay(Convert.ToDateTime(tahsilat.CollectDateFX), inv.EventFaturaKur, compakur, compabank) - (1 / inv.EventFaturaKurRate)) * (tahsilat.CollectPrice - System.Math.Round(deger))), 2);
                            exchangerate = System.Math.Abs(fxchange);
                            if (fxchange > 0)
                            {
                                //Muhaseleştirilmemiş olan satış fautraları eşleştirilememsi down payment kontrol
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Alacak";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Alacak";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "656";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate loss #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Borç";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Borç";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }
                            else
                            {
                                Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                                newrow.AccountRowKey = rowkery;
                                newrow.AccountingRow = ticarialacak;
                                newrow.AccountingRowDate = DateTime.Now;
                                newrow.AccountingRowCreateDate = DateTime.Now;
                                newrow.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                                newrow.AccountingRowType = "Borç";
                                newrow.AccountingRowOrjKurtutar = 0;
                                newrow.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow.AccountingRowOrjKurRate = 1;
                                newrow.AccountingRowCompanyKurTutar = exchangerate;
                                newrow.AccountingRowCompanyKur = compakur;
                                newrow.AccountingRowCompanyKurRate = 1;
                                newrow.AccountingRowKayıtTuru = "Borç";
                                newrow.company = compa;
                                newrow.IsActive = true;
                                newrow.Creater = Guid.Parse(usg);
                                newrow.ConfirmUser = Guid.Parse(usg);
                                newrow.ConfirmDate = DateTime.Now;
                                newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow);
                                db.SaveChanges();

                                Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                                newrow2.AccountRowKey = rowkery;
                                newrow2.AccountingRow = "646";
                                newrow2.AccountingRowDate = DateTime.Now;
                                newrow2.AccountingRowCreateDate = DateTime.Now;
                                newrow2.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                                newrow2.AccountingRowType = "Alacak";
                                newrow2.AccountingRowOrjKurtutar = 0;
                                newrow2.AccountingRowOrjKur = inv.EventFaturaKur;
                                newrow2.AccountingRowOrjKurRate = 1;
                                newrow2.AccountingRowCompanyKurTutar = exchangerate;
                                newrow2.AccountingRowCompanyKur = compakur;
                                newrow2.AccountingRowCompanyKurRate = 1;
                                newrow2.AccountingRowKayıtTuru = "Alacak";
                                newrow2.company = compa;
                                newrow2.IsActive = true;
                                newrow2.Creater = Guid.Parse(usg);
                                newrow2.ConfirmUser = Guid.Parse(usg);
                                newrow2.ConfirmDate = DateTime.Now;
                                newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                                db.Tbl_AccountingRow.Add(newrow2);
                                db.SaveChanges();
                            }


                            if (where == "Clients")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                            else if (where == "User")
                            {
                                if (fxchange > 0)
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Alacak";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariDate = DateTime.Now;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Tbl_CariFish newcari4 = new Tbl_CariFish();
                                    newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                                    newcari4.CariWhere = "Client";
                                    newcari4.ProccesType = "Pairing";
                                    newcari4.BelgeRef = "EXC";
                                    newcari4.BelgeRefWhere = "EXC";
                                    newcari4.DebitCredit = "Borç";
                                    newcari4.OrjFX = inv.EventFaturaKur;
                                    newcari4.OrjFXPrice = 0;
                                    newcari4.FX = compakur;
                                    newcari4.FXPrice = exchangerate;
                                    newcari4.CumulativeBallance = 0;
                                    newcari4.AccountingCode = ticarialacak;
                                    newcari4.Company = compa;
                                    newcari4.IsActive = true;
                                    newcari4.CariOriginalDate = DateTime.Now;
                                    newcari4.CariDate = DateTime.Now;
                                    db.Tbl_CariFish.Add(newcari4);
                                    db.SaveChanges();
                                }
                            }
                        }

                    }
                    status = true;
                }
                else
                {
                    double vlue = System.Math.Round(Convert.ToDouble(FXCalculateSelectedDay(inv.EventFaturaToplamTutarKDVdahil, inv.EventFaturaTarihi, tahsilat.CollectFX, inv.EventFaturaKur, compabank)), 2);
                    if (vlue > tahsilat.CollectPrice)
                    {
                        vlue = System.Math.Round(Convert.ToDouble(tahsilat.CollectPrice), 2);
                    }
                    double tahsilatgunututar = System.Math.Round(Convert.ToDouble(FXCalculateSelectedDay(vlue, tahsilat.CollectDateFX.Date, inv.EventFaturaKur, tahsilat.CollectFX, compabank)), 2);
                    if (vlue == tahsilat.CollectPrice)
                    {
                        inv.EventFaturaTahsilEdilen = System.Math.Round(Convert.ToDouble(tahsilatgunututar + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2);
                        inv.EventFaturaKalan = System.Math.Round(Convert.ToDouble(inv.EventFaturaToplamTutarKDVdahil - tahsilatgunututar), 2);
                        tahsilat.CollectTahsilEdilen = System.Math.Round(Convert.ToDouble(vlue + (tahsilat.CollectPrice - tahsilat.CollectKalan)), 2);
                        tahsilat.CollectKalan = 0;
                        Tbl_MatchTo newmto = new Tbl_MatchTo();
                        newmto.Company = compa;
                        newmto.IsActive = true;
                        newmto.MatchDate = DateTime.Now;
                        newmto.MatchFromGuid = newmatch.MatchGuid;
                        newmto.MatchTime = DateTime.Now.TimeOfDay;
                        newmto.MatchTouniq = inv.EventFaturaGuid.ToString();
                        newmto.MatchToWhere = "Invoice";
                        newmto.MatchType = "Numerical";
                        newmto.MatchTypeKısmen = "All";
                        newmto.MatchTypeEslesenKısım = System.Math.Round(Convert.ToDouble(tahsilatgunututar + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan)), 2).ToString();
                        db.Tbl_MatchTo.Add(newmto);
                        db.SaveChanges();
                    }
                    else
                    {
                        inv.EventFaturaTahsilEdilen = tahsilatgunututar + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan);
                        inv.EventFaturaKalan = 0;
                        tahsilat.CollectTahsilEdilen = vlue;
                        tahsilat.CollectKalan = tahsilat.CollectKalan - vlue + (tahsilat.CollectPrice - tahsilat.CollectKalan);
                        Tbl_MatchTo newmto = new Tbl_MatchTo();
                        newmto.Company = compa;
                        newmto.IsActive = true;
                        newmto.MatchDate = DateTime.Now;
                        newmto.MatchFromGuid = newmatch.MatchGuid;
                        newmto.MatchTime = DateTime.Now.TimeOfDay;
                        newmto.MatchTouniq = inv.EventFaturaGuid.ToString();
                        newmto.MatchToWhere = "Invoice";
                        newmto.MatchType = "Numerical";
                        newmto.MatchTypeKısmen = "Partial";
                        newmto.MatchTypeEslesenKısım = tahsilatgunututar + (inv.EventFaturaToplamTutarKDVdahil - inv.EventFaturaKalan).ToString();
                        db.Tbl_MatchTo.Add(newmto);
                        db.SaveChanges();
                    }



                    Tbl_AccountingRow newrow2 = new Tbl_AccountingRow();
                    newrow2.AccountRowKey = rowkery;
                    newrow2.AccountingRow = ticarialacak;
                    newrow2.AccountingRowDate = DateTime.Now;
                    newrow2.AccountingRowCreateDate = DateTime.Now;
                    newrow2.AccountingRowDescription = "Clear";
                    newrow2.AccountingRowType = "Alacak";
                    newrow2.AccountingRowOrjKurtutar = vlue;
                    newrow2.AccountingRowOrjKur = tahsilat.CollectFX;
                    newrow2.AccountingRowOrjKurRate = 1;
                    newrow2.AccountingRowCompanyKurTutar = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate), 2);
                    newrow2.AccountingRowCompanyKur = compakur;
                    newrow2.AccountingRowCompanyKurRate = 1;
                    newrow2.AccountingRowKayıtTuru = "Alacak";
                    newrow2.company = compa;
                    newrow2.IsActive = true;
                    newrow2.Creater = Guid.Parse(usg);
                    newrow2.ConfirmUser = Guid.Parse(usg);
                    newrow2.ConfirmDate = DateTime.Now;
                    newrow2.AccountingRowOriginalCreateDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(newrow2);
                    db.SaveChanges();


                    Tbl_AccountingRow newrow = new Tbl_AccountingRow();
                    newrow.AccountRowKey = rowkery;
                    newrow.AccountingRow = "61";
                    newrow.AccountingRowDate = DateTime.Now;
                    newrow.AccountingRowCreateDate = DateTime.Now;
                    newrow.AccountingRowDescription = "Clear";
                    newrow.AccountingRowType = "Borç";
                    newrow.AccountingRowOrjKurtutar = vlue;
                    newrow.AccountingRowOrjKur = tahsilat.CollectFX;
                    newrow.AccountingRowOrjKurRate = 1;
                    newrow.AccountingRowCompanyKurTutar = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate), 2);
                    newrow.AccountingRowCompanyKur = compakur;
                    newrow.AccountingRowCompanyKurRate = 1;
                    newrow.AccountingRowKayıtTuru = "Borç";
                    newrow.company = compa;
                    newrow.IsActive = true;
                    newrow.Creater = Guid.Parse(usg);
                    newrow.ConfirmUser = Guid.Parse(usg);
                    newrow.ConfirmDate = DateTime.Now;
                    newrow.AccountingRowOriginalCreateDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(newrow);
                    db.SaveChanges();



                    Tbl_AccountingRow newrow3 = new Tbl_AccountingRow();
                    newrow3.AccountRowKey = rowkery;
                    newrow3.AccountingRow = ticarialacak;
                    newrow3.AccountingRowDate = DateTime.Now;
                    newrow3.AccountingRowCreateDate = DateTime.Now;
                    newrow3.AccountingRowDescription = "Clear";
                    newrow3.AccountingRowType = "Borç";
                    newrow3.AccountingRowOrjKurtutar = tahsilatgunututar;
                    newrow3.AccountingRowOrjKur = inv.EventFaturaKur;
                    newrow3.AccountingRowOrjKurRate = 1;
                    newrow3.AccountingRowCompanyKurTutar = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate), 2);
                    newrow3.AccountingRowCompanyKur = compakur;
                    newrow3.AccountingRowCompanyKurRate = 1;
                    newrow3.AccountingRowKayıtTuru = "Borç";
                    newrow3.company = compa;
                    newrow3.IsActive = true;
                    newrow3.Creater = Guid.Parse(usg);
                    newrow3.ConfirmUser = Guid.Parse(usg);
                    newrow3.ConfirmDate = DateTime.Now;
                    newrow3.AccountingRowOriginalCreateDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(newrow3);
                    db.SaveChanges();

                    Tbl_AccountingRow newrow4 = new Tbl_AccountingRow();
                    newrow4.AccountRowKey = rowkery;
                    newrow4.AccountingRow = "61";
                    newrow4.AccountingRowDate = DateTime.Now;
                    newrow4.AccountingRowCreateDate = DateTime.Now;
                    newrow4.AccountingRowDescription = "Clear";
                    newrow4.AccountingRowType = "Alacak";
                    newrow4.AccountingRowOrjKurtutar = tahsilatgunututar;
                    newrow4.AccountingRowOrjKur = inv.EventFaturaKur;
                    newrow4.AccountingRowOrjKurRate = 1;
                    newrow4.AccountingRowCompanyKurTutar = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate), 2);
                    newrow4.AccountingRowCompanyKur = compakur;
                    newrow4.AccountingRowCompanyKurRate = 1;
                    newrow4.AccountingRowKayıtTuru = "Alacak";
                    newrow4.company = compa;
                    newrow4.IsActive = true;
                    newrow4.Creater = Guid.Parse(usg);
                    newrow4.ConfirmUser = Guid.Parse(usg);
                    newrow4.ConfirmDate = DateTime.Now;
                    newrow4.AccountingRowOriginalCreateDate = DateTime.Now;
                    db.Tbl_AccountingRow.Add(newrow4);
                    db.SaveChanges();

                    if (compakur != inv.EventFaturaKur)
                    {
                        exchangerate = System.Math.Round(Convert.ToDouble((CalculateFXRateSelectedDay(Convert.ToDateTime(tahsilat.CollectDateFX), inv.EventFaturaKur, compakur, compabank) - (1 / inv.EventFaturaKurRate)) * vlue / tahsilat.CollectFXRate), 2);
                        exchangerate = exchangerate / CalculateFXRateSelectedDay(Convert.ToDateTime(tahsilat.CollectDateFX), inv.EventFaturaKur, compakur, compabank);
                        if (exchangerate > 0)
                        {
                            Tbl_AccountingRow newrow5 = new Tbl_AccountingRow();
                            newrow5.AccountRowKey = rowkery;
                            newrow5.AccountingRow = ticarialacak;
                            newrow5.AccountingRowDate = DateTime.Now;
                            newrow5.AccountingRowCreateDate = DateTime.Now;
                            newrow5.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                            newrow5.AccountingRowType = "Alacak";
                            newrow5.AccountingRowOrjKurtutar = 0;
                            newrow5.AccountingRowOrjKur = inv.EventFaturaKur;
                            newrow5.AccountingRowOrjKurRate = 1;
                            newrow5.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                            newrow5.AccountingRowCompanyKur = compakur;
                            newrow5.AccountingRowCompanyKurRate = 1;
                            newrow5.AccountingRowKayıtTuru = "Alacak";
                            newrow5.company = compa;
                            newrow5.IsActive = true;
                            newrow5.Creater = Guid.Parse(usg);
                            newrow5.ConfirmUser = Guid.Parse(usg);
                            newrow5.ConfirmDate = DateTime.Now;
                            newrow5.AccountingRowOriginalCreateDate = DateTime.Now;
                            db.Tbl_AccountingRow.Add(newrow5);
                            db.SaveChanges();

                            Tbl_AccountingRow newrow6 = new Tbl_AccountingRow();
                            newrow6.AccountRowKey = rowkery;
                            newrow6.AccountingRow = "656";
                            newrow6.AccountingRowDate = DateTime.Now;
                            newrow6.AccountingRowCreateDate = DateTime.Now;
                            newrow6.AccountingRowDescription = "Exchange rate loss invoice #" + inv.EventFaturaNo;
                            newrow6.AccountingRowType = "Borç";
                            newrow6.AccountingRowOrjKurtutar = 0;
                            newrow6.AccountingRowOrjKur = inv.EventFaturaKur;
                            newrow6.AccountingRowOrjKurRate = 1;
                            newrow6.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                            newrow6.AccountingRowCompanyKur = compakur;
                            newrow6.AccountingRowCompanyKurRate = 1;
                            newrow6.AccountingRowKayıtTuru = "Borç";
                            newrow6.company = compa;
                            newrow6.IsActive = true;
                            newrow6.Creater = Guid.Parse(usg);
                            newrow6.ConfirmUser = Guid.Parse(usg);
                            newrow6.ConfirmDate = DateTime.Now;
                            newrow6.AccountingRowOriginalCreateDate = DateTime.Now;
                            db.Tbl_AccountingRow.Add(newrow6);
                            db.SaveChanges();
                        }
                        else
                        {
                            Tbl_AccountingRow newrow5 = new Tbl_AccountingRow();
                            newrow5.AccountRowKey = rowkery;
                            newrow5.AccountingRow = ticarialacak;
                            newrow5.AccountingRowDate = DateTime.Now;
                            newrow5.AccountingRowCreateDate = DateTime.Now;
                            newrow5.AccountingRowDescription = "Exchange rate profit invoice #" + inv.EventFaturaNo;
                            newrow5.AccountingRowType = "Borç";
                            newrow5.AccountingRowOrjKurtutar = 0;
                            newrow5.AccountingRowOrjKur = inv.EventFaturaKur;
                            newrow5.AccountingRowOrjKurRate = 1;
                            newrow5.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                            newrow5.AccountingRowCompanyKur = compakur;
                            newrow5.AccountingRowCompanyKurRate = 1;
                            newrow5.AccountingRowKayıtTuru = "Borç";
                            newrow5.company = compa;
                            newrow5.IsActive = true;
                            newrow5.Creater = Guid.Parse(usg);
                            newrow5.ConfirmUser = Guid.Parse(usg);
                            newrow5.ConfirmDate = DateTime.Now;
                            newrow5.AccountingRowOriginalCreateDate = DateTime.Now;
                            db.Tbl_AccountingRow.Add(newrow5);
                            db.SaveChanges();

                            Tbl_AccountingRow newrow6 = new Tbl_AccountingRow();
                            newrow6.AccountRowKey = rowkery;
                            newrow6.AccountingRow = "646";
                            newrow6.AccountingRowDate = DateTime.Now;
                            newrow6.AccountingRowCreateDate = DateTime.Now;
                            newrow6.AccountingRowDescription = "Exchange rate profit invoice 3" + inv.EventFaturaNo;
                            newrow6.AccountingRowType = "Alacak";
                            newrow6.AccountingRowOrjKurtutar = 0;
                            newrow6.AccountingRowOrjKur = inv.EventFaturaKur;
                            newrow6.AccountingRowOrjKurRate = 1;
                            newrow6.AccountingRowCompanyKurTutar = System.Math.Abs(exchangerate);
                            newrow6.AccountingRowCompanyKur = compakur;
                            newrow6.AccountingRowCompanyKurRate = 1;
                            newrow6.AccountingRowKayıtTuru = "Alacak";
                            newrow6.company = compa;
                            newrow6.IsActive = true;
                            newrow6.Creater = Guid.Parse(usg);
                            newrow6.ConfirmUser = Guid.Parse(usg);
                            newrow6.ConfirmDate = DateTime.Now;
                            newrow6.AccountingRowOriginalCreateDate = DateTime.Now;
                            db.Tbl_AccountingRow.Add(newrow6);
                            db.SaveChanges();


                        }

                    }
                    //120ye attığım toplam 4 satır cariyede at

                    if (where == "Clients")
                    {
                        Tbl_CariFish newcari = new Tbl_CariFish();
                        newcari.CustomerID = inv.EventFaturaMusteriId.ToString();
                        newcari.CariWhere = "Client";
                        newcari.ProccesType = "Pairing";
                        newcari.BelgeRef = "EXC";
                        newcari.BelgeRefWhere = "EXC";
                        newcari.DebitCredit = "Alacak";
                        newcari.OrjFX = tahsilat.CollectFX;
                        newcari.OrjFXPrice = vlue;
                        newcari.FX = compakur;
                        newcari.FXPrice = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate), 2);
                        newcari.CumulativeBallance = 0;
                        newcari.AccountingCode = ticarialacak;
                        newcari.Company = compa;
                        newcari.IsActive = true;
                        newcari.CariDate = DateTime.Now;
                        newcari.CariOriginalDate = DateTime.Now;
                        db.Tbl_CariFish.Add(newcari);
                        db.SaveChanges();


                        Tbl_CariFish newcari3 = new Tbl_CariFish();
                        newcari3.CustomerID = inv.EventFaturaMusteriId.ToString();
                        newcari3.CariWhere = "Client";
                        newcari3.ProccesType = "Pairing";
                        newcari3.BelgeRef = "EXC";
                        newcari3.BelgeRefWhere = "EXC";
                        newcari3.DebitCredit = "Borç";
                        newcari3.OrjFX = inv.EventFaturaKur;
                        newcari3.OrjFXPrice = tahsilatgunututar;
                        newcari3.FX = compakur;
                        newcari3.FXPrice = System.Math.Round(Convert.ToDouble(vlue / tahsilat.CollectFXRate), 2);
                        newcari3.CumulativeBallance = 0;
                        newcari3.AccountingCode = ticarialacak;
                        newcari3.Company = compa;
                        newcari3.IsActive = true;
                        newcari3.CariOriginalDate = DateTime.Now;
                        newcari3.CariDate = DateTime.Now;
                        db.Tbl_CariFish.Add(newcari3);
                        db.SaveChanges();
                        if (exchangerate > 0)
                        {
                            Tbl_CariFish newcari4 = new Tbl_CariFish();
                            newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                            newcari4.CariWhere = "Client";
                            newcari4.ProccesType = "Pairing";
                            newcari4.BelgeRef = "EXC";
                            newcari4.BelgeRefWhere = "EXC";
                            newcari4.DebitCredit = "Alacak";
                            newcari4.OrjFX = inv.EventFaturaKur;
                            newcari4.OrjFXPrice = 0;
                            newcari4.FX = compakur;
                            newcari4.FXPrice = System.Math.Abs(exchangerate);
                            newcari4.CumulativeBallance = 0;
                            newcari4.AccountingCode = ticarialacak;
                            newcari4.Company = compa;
                            newcari4.IsActive = true;
                            newcari4.CariDate = DateTime.Now;
                            newcari4.CariOriginalDate = DateTime.Now;
                            db.Tbl_CariFish.Add(newcari4);
                            db.SaveChanges();
                        }
                        else
                        {
                            Tbl_CariFish newcari4 = new Tbl_CariFish();
                            newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                            newcari4.CariWhere = "Client";
                            newcari4.ProccesType = "Pairing";
                            newcari4.BelgeRef = "EXC";
                            newcari4.BelgeRefWhere = "EXC";
                            newcari4.DebitCredit = "Borç";
                            newcari4.OrjFX = inv.EventFaturaKur;
                            newcari4.OrjFXPrice = 0;
                            newcari4.FX = compakur;
                            newcari4.FXPrice = System.Math.Abs(exchangerate);
                            newcari4.CumulativeBallance = 0;
                            newcari4.AccountingCode = ticarialacak;
                            newcari4.Company = compa;
                            newcari4.IsActive = true;
                            newcari4.CariOriginalDate = DateTime.Now;
                            newcari4.CariDate = DateTime.Now;
                            db.Tbl_CariFish.Add(newcari4);
                            db.SaveChanges();
                        }


                        //Tbl_CariFish newcari4 = new Tbl_CariFish();
                        //newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                        //newcari4.CariWhere = "Client";
                        //newcari4.ProccesType = "";
                        //newcari4.BelgeRef = "EXC";
                        //newcari4.BelgeRefWhere = "EXC";
                        //newcari4.DebitCredit = "Borç";
                        //newcari4.OrjFX = tahsilat.CollectFX;
                        //newcari4.OrjFXPrice = tahsilatgunututar;
                        //newcari4.FX = compakur;
                        //newcari4.FXPrice = vlue * tahsilat.CollectFXRate;
                        //newcari4.CumulativeBallance = 0;
                        //newcari4.AccountingCode = "61";
                        //newcari4.Company = compa;
                        //newcari4.IsActive = true;
                        //db.Tbl_CariFish.Add(newcari4);
                        //db.SaveChanges();
                    }
                    else if (where == "User")
                    {
                        Tbl_CariFish newcari = new Tbl_CariFish();
                        newcari.CustomerID = usgto;
                        newcari.CariWhere = "User";
                        newcari.ProccesType = "Pairing";
                        newcari.BelgeRef = "EXC";
                        newcari.BelgeRefWhere = "EXC";
                        newcari.DebitCredit = "Alacak";
                        newcari.OrjFX = tahsilat.CollectFX;
                        newcari.OrjFXPrice = vlue;
                        newcari.FX = compakur;
                        newcari.FXPrice = System.Math.Round(Convert.ToDouble(vlue * tahsilat.CollectFXRate), 2);
                        newcari.CumulativeBallance = 0;
                        newcari.AccountingCode = ticarialacak;
                        newcari.Company = compa;
                        newcari.IsActive = true;
                        newcari.CariDate = DateTime.Now;
                        newcari.CariOriginalDate = DateTime.Now;
                        db.Tbl_CariFish.Add(newcari);
                        db.SaveChanges();

                        //Tbl_CariFish newcari2 = new Tbl_CariFish();
                        //newcari2.CustomerID = usgto;
                        //newcari2.CariWhere = "User";
                        //newcari2.ProccesType = "";
                        //newcari2.BelgeRef = "EXC";
                        //newcari2.BelgeRefWhere = "EXC";
                        //newcari2.DebitCredit = "Alacak";
                        //newcari2.OrjFX = tahsilat.CollectFX;
                        //newcari2.OrjFXPrice = vlue;
                        //newcari2.FX = compakur;
                        //newcari2.FXPrice = vlue * tahsilat.CollectFXRate;
                        //newcari2.CumulativeBallance = 0;
                        //newcari2.AccountingCode = "61";
                        //newcari2.Company = compa;
                        //newcari2.IsActive = true;
                        //db.Tbl_CariFish.Add(newcari2);
                        //db.SaveChanges();

                        Tbl_CariFish newcari3 = new Tbl_CariFish();
                        newcari3.CustomerID = usgto;
                        newcari3.CariWhere = "User";
                        newcari3.ProccesType = "Pairing";
                        newcari3.BelgeRef = "EXC";
                        newcari3.BelgeRefWhere = "EXC";
                        newcari3.DebitCredit = "Borç";
                        newcari3.OrjFX = inv.EventFaturaKur;
                        newcari3.OrjFXPrice = tahsilatgunututar;
                        newcari3.FX = compakur;
                        newcari3.FXPrice = System.Math.Round(Convert.ToDouble(vlue * tahsilat.CollectFXRate), 2);
                        newcari3.CumulativeBallance = 0;
                        newcari3.AccountingCode = ticarialacak;
                        newcari3.Company = compa;
                        newcari3.IsActive = true;
                        newcari3.CariOriginalDate = DateTime.Now;
                        newcari3.CariDate = DateTime.Now;
                        db.Tbl_CariFish.Add(newcari3);
                        db.SaveChanges();


                        if (exchangerate > 0)
                        {
                            Tbl_CariFish newcari4 = new Tbl_CariFish();
                            newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                            newcari4.CariWhere = "Client";
                            newcari4.ProccesType = "Pairing";
                            newcari4.BelgeRef = "EXC";
                            newcari4.BelgeRefWhere = "EXC";
                            newcari4.DebitCredit = "Alacak";
                            newcari4.OrjFX = inv.EventFaturaKur;
                            newcari4.OrjFXPrice = 0;
                            newcari4.FX = compakur;
                            newcari4.FXPrice = System.Math.Abs(exchangerate);
                            newcari4.CumulativeBallance = 0;
                            newcari4.AccountingCode = ticarialacak;
                            newcari4.Company = compa;
                            newcari4.IsActive = true;
                            newcari4.CariDate = DateTime.Now;
                            newcari4.CariOriginalDate = DateTime.Now;
                            db.Tbl_CariFish.Add(newcari4);
                            db.SaveChanges();
                        }
                        else
                        {
                            Tbl_CariFish newcari4 = new Tbl_CariFish();
                            newcari4.CustomerID = inv.EventFaturaMusteriId.ToString();
                            newcari4.CariWhere = "Client";
                            newcari4.ProccesType = "Pairing";
                            newcari4.BelgeRef = "EXC";
                            newcari4.BelgeRefWhere = "EXC";
                            newcari4.DebitCredit = "Borç";
                            newcari4.OrjFX = inv.EventFaturaKur;
                            newcari4.OrjFXPrice = 0;
                            newcari4.FX = compakur;
                            newcari4.FXPrice = System.Math.Abs(exchangerate);
                            newcari4.CumulativeBallance = 0;
                            newcari4.AccountingCode = ticarialacak;
                            newcari4.Company = compa;
                            newcari4.IsActive = true;
                            newcari4.CariOriginalDate = DateTime.Now;
                            newcari4.CariDate = DateTime.Now;
                            db.Tbl_CariFish.Add(newcari4);
                            db.SaveChanges();
                        }
                        //Tbl_CariFish newcari4 = new Tbl_CariFish();
                        //newcari4.CustomerID = usgto;
                        //newcari4.CariWhere = "User";
                        //newcari4.ProccesType = "";
                        //newcari4.BelgeRef = "EXC";
                        //newcari4.BelgeRefWhere = "EXC";
                        //newcari4.DebitCredit = "Borç";
                        //newcari4.OrjFX = tahsilat.CollectFX;
                        //newcari4.OrjFXPrice = tahsilatgunututar;
                        //newcari4.FX = compakur;
                        //newcari4.FXPrice = vlue * tahsilat.CollectFXRate;
                        //newcari4.CumulativeBallance = 0;
                        //newcari4.AccountingCode = "61";
                        //newcari4.Company = compa;
                        //newcari4.IsActive = true;
                        //db.Tbl_CariFish.Add(newcari4);
                        //db.SaveChanges();
                    }
                    status = true;
                }
            }
            return status;
        }


        //public Tbl_EventStore CalculateEventTotalCost(int Eventid, string Auditoridnosplit, string belgeturss, DateTime startdate, DateTime endtdate, bool status, string compa, string fxrate, bool insertcontrol, bool audexpcontrol)
        //{
        //    var Event = db.Tbl_EventStore.Where(ev => ev.id == Eventid).SingleOrDefault();
        //    Guid jobid = Guid.Parse(Event.job_id);
        //    var job = db.Tbl_EventJob.Where(p => p.key == jobid).SingleOrDefault();
        //    var Auditoridsplit = Auditoridnosplit.Split(',');
        //    var belgesplit = belgeturss.Split(',');
        //    if (Auditoridsplit.Count() > 0)
        //    {
        //        if (Event.saveType == "normal" && Event.key != null && Event.Customer_id != null && Event.IsActive == true)
        //        {
        //            int belgekontrol = 0;
        //            double Totalcost = 0;
        //            double TotalcostTamamlanan = 0;
        //            double TotalrevenueTamamlanan = 0;
        //            double TotalprofitTamamlanan = 0;
        //            double Totalcostifbelgenon = 0;
        //            double totalmasraf = 0;
        //            double workhours = 0;
        //            int workmanday = 0;

        //            foreach (var items in Auditoridsplit)
        //            {
        //                if (items != "0")
        //                {
        //                    int Auditorid = Convert.ToInt32(items);
        //                    string belgeturs = belgesplit[belgekontrol];
        //                    belgekontrol++;
        //                    bool auditorisexpensecontrol = audexpcontrol;
        //                    double fxratedouble = 0;
        //                    if (fxrate != null)
        //                    {
        //                        fxratedouble = double.Parse(fxrate, NumberStyles.Any, new CultureInfo("en-Us"));

        //                    }
        //                    int belgetur = Convert.ToInt32(belgeturs);
        //                    double belgefiyatı = 0;
        //                    var company = db.Tbl_Companies.Where(companys => companys.CompanyName == compa).SingleOrDefault();
        //                    //belgefiyatı = 1;
        //                    string companykur = company.Kur;
        //                    string companykurbanka = company.KurBanka;
        //                    DateTime lastdatefx = Convert.ToDateTime(db.Tbl_Kurlar.OrderByDescending(p => p.KurTarih).Where(i => i.KurBanka == companykurbanka).Max(a => a.KurTarih).ToString());
        //                    DateTime t = Convert.ToDateTime(lastdatefx.ToShortDateString());
        //                    var kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == companykurbanka && pp.KurTarih == t).SingleOrDefault();
        //                    var coloumnnamequery = kurlist.GetType().GetProperties().Where(p => p.Name == companykur).Select(a => a.GetValue(kurlist, null)).FirstOrDefault();
        //                    double coloumname = Convert.ToDouble(coloumnnamequery.ToString());
        //                    coloumname = 1 / coloumname;

        //                    if (status == false)
        //                    {

        //                        var denetci = db.Tbl_SubconUsers.Where(denn => denn.SubconUserDepartment == Auditorid).SingleOrDefault();
        //                        var denetcidetailss = db.Tbl_EventDenetciDetails.Where(i => i.key == belgetur).SingleOrDefault();
        //                        var denetcidetails = denetcidetailss;//denetçi detayındaki id yolladığımızda bunlar kalkacak
        //                        string denetcikur = denetcidetails.EventDenetciDenetimKur;
        //                        string dtur = denetcidetails.EventDenetciDenetimZamanTuru;

        //                        if (Event.EventFaturaGuid == null)
        //                        {
        //                            if (companykur != denetcikur)
        //                            {

        //                                switch (denetcikur)
        //                                {
        //                                    case "EUR":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.EUR) / coloumname));
        //                                        break;
        //                                    case "USD":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.USD) / coloumname));
        //                                        break;
        //                                    case "GPB":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.GPB) / coloumname));
        //                                        break;
        //                                    case "RUB":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.RUB) / coloumname));
        //                                        break;
        //                                    case "JPY":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.JPY) / coloumname));
        //                                        break;
        //                                    case "DKK":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.DKK) / coloumname));
        //                                        break;
        //                                    case "PLN":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.PLN) / coloumname));
        //                                        break;
        //                                    case "SEK":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.SEK) / coloumname));
        //                                        break;
        //                                    case "RON":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.RON) / coloumname));
        //                                        break;
        //                                    case "CHF":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.CHF) / coloumname));
        //                                        break;
        //                                    case "HRK":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.HRK) / coloumname));
        //                                        break;
        //                                    case "AUD":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.AUD) / coloumname));
        //                                        break;
        //                                    case "CAD":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.CAD) / coloumname));
        //                                        break;
        //                                    case "HKD":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.HKD) / coloumname));
        //                                        break;
        //                                    case "ILS":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.ILS) / coloumname));
        //                                        break;
        //                                    case "MXN":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.MXN) / coloumname));
        //                                        break;
        //                                    case "NZD":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.NZD) / coloumname));
        //                                        break;
        //                                    case "SGD":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.SGD) / coloumname));
        //                                        break;
        //                                    case "ZAR":
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.ZAR) / coloumname));
        //                                        break;
        //                                    default:
        //                                        belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * ((1 / kurlist.TRY) / coloumname));
        //                                        break;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                belgefiyatı = Convert.ToDouble(denetcidetails.EventDenetciDenetimFiyatı * 1);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Totalcostifbelgenon = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == Event.EventFaturaGuid).SingleOrDefault().EventFaturaToplamTutar;
        //                        }

        //                        if (dtur == "Fixed" && Event.EventFaturaGuid == null)
        //                        {
        //                            Event.WorkHours = 1;
        //                            Event.WorkManday = 1;
        //                            Totalcost += belgefiyatı;
        //                            if (Event.durum_id == "3")
        //                            {
        //                                TotalcostTamamlanan += Convert.ToDouble(Totalcost);
        //                                Event.EventTotalTamamlananCost = Convert.ToDouble(Totalcost);
        //                                db.SaveChanges();

        //                            }

        //                        }
        //                        else if (dtur == "Hourly" && Event.EventFaturaGuid == null)
        //                        {
        //                            var taskdetails = db.Tbl_TaskDetails.Where(p => p.TaskID == Eventid && p.AuditorID == Auditorid).ToList();
        //                            foreach (var detailsteasks in taskdetails)
        //                            {
        //                                DateTime startdatedet = Convert.ToDateTime(detailsteasks.StartDate.ToString());
        //                                DateTime enddatedet = Convert.ToDateTime(detailsteasks.EndDate.ToString());
        //                                TimeSpan totalgun = enddatedet - startdatedet;
        //                                double toplamgun = totalgun.TotalHours;
        //                                double totalminutes = (totalgun.Minutes / Convert.ToDouble(60));
        //                                toplamgun = toplamgun + totalminutes;
        //                                Totalcost += Convert.ToDouble(toplamgun) * belgefiyatı;
        //                                workhours += toplamgun;
        //                                Event.WorkHours = workhours;
        //                                detailsteasks.TaskDetailsGider = System.Math.Round(Convert.ToInt32(toplamgun) * belgefiyatı);
        //                                db.SaveChanges();
        //                            }
        //                            if (Event.durum_id == "3")
        //                            {
        //                                TotalcostTamamlanan += Convert.ToDouble(Totalcost);
        //                                Event.EventTotalTamamlananCost = Convert.ToDouble(Totalcost);
        //                                db.SaveChanges();
        //                            }
        //                        }
        //                        else if (dtur == "Manday" && Event.EventFaturaGuid == null)
        //                        {
        //                            DateTime isdate = Convert.ToDateTime(Convert.ToDateTime(Event.start_date).ToShortDateString());
        //                            DateTime isdateend = Convert.ToDateTime(Event.end_date);


        //                            for (int i = 1; isdate <= isdateend; i++)
        //                            {
        //                                DateTime isdatemodif = isdate.AddHours(23).AddMinutes(59);
        //                                var tasklist = db.Tbl_TaskDetails.Where(p => p.AuditorID == Auditorid && p.StartDate <= isdatemodif && p.EndDate >= isdate && p.TaskID == Event.id).ToList();
        //                                if (tasklist.Count > 1)
        //                                {
        //                                    double toplamgundays = 0;
        //                                    foreach (var tasklistitem in tasklist)
        //                                    {
        //                                        DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
        //                                        DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

        //                                        TimeSpan totalgun = enddatedet - startdatedet;
        //                                        toplamgundays += totalgun.Hours;
        //                                    }
        //                                    foreach (var tasklistitem in tasklist)
        //                                    {
        //                                        DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
        //                                        DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

        //                                        TimeSpan totalgun = enddatedet - startdatedet;
        //                                        double toplamgun = totalgun.Hours;
        //                                        tasklistitem.TaskDetailsGider = System.Math.Round((toplamgun / toplamgundays) * belgefiyatı);
        //                                        workmanday += Convert.ToInt32(totalgun.TotalDays);
        //                                        Event.WorkManday += workmanday;
        //                                        db.SaveChanges();
        //                                        Totalcost += System.Math.Round((toplamgun / toplamgundays) * belgefiyatı);
        //                                        if (Event.durum_id == "3")
        //                                        {
        //                                            TotalcostTamamlanan += Convert.ToDouble(Totalcost);
        //                                            Event.EventTotalTamamlananCost = Convert.ToDouble(Totalcost);
        //                                            db.SaveChanges();

        //                                        }
        //                                    }
        //                                }
        //                                else if (tasklist.Count == 1)
        //                                {
        //                                    foreach (var taskdetlist in tasklist)
        //                                    {

        //                                        taskdetlist.TaskDetailsGider = System.Math.Round(belgefiyatı);
        //                                        workhours += 8;
        //                                        workmanday += 1;
        //                                        Event.WorkHours = workhours;
        //                                        Event.WorkManday = workmanday;
        //                                        db.SaveChanges();
        //                                        Totalcost += belgefiyatı;
        //                                        if (Event.durum_id == "3")
        //                                        {
        //                                            TotalcostTamamlanan += Convert.ToDouble(Totalcost);
        //                                            Event.EventTotalTamamlananCost = Convert.ToDouble(Totalcost);
        //                                            db.SaveChanges();

        //                                        }
        //                                    }
        //                                }
        //                                else
        //                                {

        //                                }
        //                                isdate = isdate.AddDays(1);
        //                            }

        //                        }



        //                        if (db.Tbl_EventDenetciMasraf.Where(masraf => masraf.EventDenetciMasrafEventId == Eventid).ToList().Count > 0)
        //                        {
        //                            var eventmasraflistt = db.Tbl_EventDenetciMasraf.Where(masraf => masraf.EventDenetciMasrafEventId == Eventid && !masraf.EventMasrafNeden.Contains("Advance Payment") && masraf.EventDenetciMasrafDenetciID == Auditorid).ToList();
        //                            foreach (var masraff in eventmasraflistt)
        //                            {
        //                                var eventmasraflist = db.Tbl_EventDenetciMasrafMasrafs.Where(ms => ms.EventDenetciMasrafDurum == "Confirmed" && !ms.Tbl_EventDenetciMasraf.EventMasrafNeden.Contains("Advance Payment") && ms.EventDenetciMasrafguid == masraff.EventDenetciMasrafGuid).ToList();
        //                                foreach (var masraf in eventmasraflist)
        //                                {

        //                                    #region masraf kur hesaplatması
        //                                    string masrafkur = masraf.FaturaKurS;



        //                                    if (companykur != masrafkur)
        //                                    {
        //                                        if (masraf.EventFaturaDurum == "Completed")
        //                                        {
        //                                            var invdet = db.Tbl_EventFaturaEvents.Where(p => p.EventFaturaDescription == "ExpenseInvoice" && p.EventFaturaServicesID == masraf.EventDenetciMasrafMasrafsGuid && p.EventFaturaType == "Expense Invioce" && p.Company == compa && p.IsActive == true).SingleOrDefault();
        //                                            var inv2 = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == invdet.EventFaturaGuid).SingleOrDefault();
        //                                            totalmasraf = inv2.EventFaturaToplamTutar;
        //                                            totalmasraf += Convert.ToDouble(((1 / job.EventJobExpensePercent) * totalmasraf) + totalmasraf);
        //                                        }
        //                                        else
        //                                        {
        //                                            switch (masrafkur)
        //                                            {
        //                                                case "EUR":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.EUR) / coloumname));
        //                                                    break;
        //                                                case "USD":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.USD) / coloumname));
        //                                                    break;
        //                                                case "GPB":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.GPB) / coloumname));
        //                                                    break;
        //                                                case "RUB":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RUB) / coloumname));
        //                                                    break;
        //                                                case "JPY":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.JPY) / coloumname));
        //                                                    break;
        //                                                case "DKK":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.DKK) / coloumname));
        //                                                    break;
        //                                                case "PLN":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.PLN) / coloumname));
        //                                                    break;
        //                                                case "SEK":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SEK) / coloumname));
        //                                                    break;
        //                                                case "RON":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RON) / coloumname));
        //                                                    break;
        //                                                case "CHF":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CHF) / coloumname));
        //                                                    break;
        //                                                case "HRK":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HRK) / coloumname));
        //                                                    break;
        //                                                case "AUD":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.AUD) / coloumname));
        //                                                    break;
        //                                                case "CAD":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CAD) / coloumname));
        //                                                    break;
        //                                                case "HKD":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HKD) / coloumname));
        //                                                    break;
        //                                                case "ILS":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ILS) / coloumname));
        //                                                    break;
        //                                                case "MXN":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.MXN) / coloumname));
        //                                                    break;
        //                                                case "NZD":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.NZD) / coloumname));
        //                                                    break;
        //                                                case "SGD":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SGD) / coloumname));
        //                                                    break;
        //                                                case "ZAR":
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ZAR) / coloumname));
        //                                                    break;
        //                                                default:
        //                                                    totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.TRY) / coloumname));
        //                                                    break;
        //                                            }

        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        totalmasraf += Convert.ToDouble(masraf.EventDenetciMasrafMasrafsTutar * 1);
        //                                    }


        //                                    #endregion


        //                                }

        //                            }
        //                        }
        //                        Event.EventMasrafTutar = System.Math.Round(totalmasraf, 2);
        //                        if (Totalcostifbelgenon == 0)
        //                        {
        //                            Event.EventDenetciTutar = System.Math.Round(Totalcost, 2);
        //                            Event.EventTotalCost = System.Math.Round(Totalcost + totalmasraf, 2);
        //                            if (Event.durum_id == "3")
        //                            {
        //                                TotalcostTamamlanan += System.Math.Round(Convert.ToDouble(Totalcost), 2);
        //                                Event.EventTotalTamamlananCost = System.Math.Round(Convert.ToDouble(Totalcost), 2);
        //                                db.SaveChanges();

        //                            }
        //                        }
        //                        else
        //                        {
        //                            //Event.EventDenetciTutar = System.Math.Round(Totalcostifbelgenon, 2);
        //                            //Event.EventTotalCost = System.Math.Round(Totalcostifbelgenon + totalmasraf, 2);
        //                            if (Event.durum_id == "3")
        //                            {
        //                                TotalcostTamamlanan += System.Math.Round(Convert.ToDouble(Event.EventTotalTamamlananCost), 2);
        //                                //Event.EventTotalTamamlananCost = Convert.ToDouble(Totalcostifbelgenon);
        //                                db.SaveChanges();

        //                            }

        //                        }
        //                        db.SaveChanges();
        //                        //costplus




        //                    }
        //                    else
        //                    {
        //                        return Event;
        //                    }

        //                }
        //            }

        //            if (job.EventJobZamantur == "CostPlus")
        //            {
        //                double gunlukisfiyati = 0;
        //                double totalgelir = 0;
        //                double jobmasraf = 0;
        //                double totalmaff = 0;
        //                double istutar = 0;
        //                var company = db.Tbl_Companies.Where(companys => companys.CompanyName == compa).SingleOrDefault();
        //                //belgefiyatı = 1;
        //                string companykur = company.Kur;
        //                string companykurbanka = company.KurBanka;
        //                DateTime lastdatefx = Convert.ToDateTime(db.Tbl_Kurlar.OrderByDescending(p => p.KurTarih).Where(i => i.KurBanka == companykurbanka).Max(a => a.KurTarih).ToString());
        //                DateTime t = Convert.ToDateTime(lastdatefx.ToShortDateString());
        //                var kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == companykurbanka && pp.KurTarih == t).SingleOrDefault();
        //                var coloumnnamequery = kurlist.GetType().GetProperties().Where(p => p.Name == companykur).Select(a => a.GetValue(kurlist, null)).FirstOrDefault();
        //                double coloumname = Convert.ToDouble(coloumnnamequery.ToString());
        //                coloumname = 1 / coloumname;
        //                var tasklisthourly = db.Tbl_EventStore.Where(p => p.job_id == job.key.ToString()).ToList();
        //                foreach (var itemtasklisthourly in tasklisthourly)
        //                {
        //                    totalgelir += (job.EventJobFiyatGunluk / 100) * (itemtasklisthourly.EventDenetciTutar) + itemtasklisthourly.EventDenetciTutar;
        //                    itemtasklisthourly.EventTotalRevenue = System.Math.Round(Convert.ToDouble((job.EventJobFiyatGunluk / 100) * (itemtasklisthourly.EventDenetciTutar) + itemtasklisthourly.EventDenetciTutar), 2);
        //                    if (itemtasklisthourly.durum_id == "3")
        //                    {
        //                        TotalrevenueTamamlanan += System.Math.Round(Convert.ToDouble((1 / job.EventJobFiyatGunluk) * (itemtasklisthourly.EventDenetciTutar) + itemtasklisthourly.EventDenetciTutar), 2);
        //                        itemtasklisthourly.EventTotalTamamlananRevenue = System.Math.Round(Convert.ToDouble((1 / job.EventJobFiyatGunluk) * (itemtasklisthourly.EventDenetciTutar) + itemtasklisthourly.EventDenetciTutar), 2);
        //                    }
        //                    db.SaveChanges();
        //                }

        //                if (job.JobOrClass == "Class")
        //                {
        //                    int mandayforclass = db.Tbl_ConfirmApprovalList.Where(p => p.ConfirmApprovalListGelenObjID == job.EventJobInvoiceTo.ToString() && p.ConfirmApprovalListStatus == "Confirmed").Count();
        //                    totalgelir = (mandayforclass + 1) * gunlukisfiyati;

        //                }
        //                else
        //                {
        //                    if (job.EventJobMasrafYansıtma == "Will be recharged")
        //                    {

        //                        var tasklist = db.Tbl_EventStore.Where(p => p.Company == compa && p.Onbazaar == "false" && p.IsActive == true && p.is_paid == "false" && p.durum_id != "3" && p.job_id == job.key.ToString()).ToList();
        //                        foreach (var item in tasklist)
        //                        {
        //                            var Auditoridsplit2 = item.key.Split(',');
        //                            foreach (var item22 in Auditoridsplit2)
        //                            {
        //                                int Auditorid2 = Convert.ToInt32(item22);
        //                                var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == item.id && p.EventDenetciMasrafDenetciID == Auditorid2).ToList();
        //                                if (masraflist.Count() > 0)
        //                                {

        //                                    foreach (var masrafs in masraflist)
        //                                    {
        //                                        var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == masrafs.EventDenetciMasrafGuid).ToList();
        //                                        foreach (var item2 in masrafss)
        //                                        {
        //                                            if (item2.EventDenetciYansitilacak == job.EventJobMasrafYansıtma)
        //                                            {
        //                                                switch (item2.FaturaKurS)
        //                                                {
        //                                                    case "EUR":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.EUR) / coloumname));
        //                                                        break;
        //                                                    case "USD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.USD) / coloumname));
        //                                                        break;
        //                                                    case "GPB":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.GPB) / coloumname));
        //                                                        break;
        //                                                    case "RUB":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RUB) / coloumname));
        //                                                        break;
        //                                                    case "JPY":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.JPY) / coloumname));
        //                                                        break;
        //                                                    case "DKK":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.DKK) / coloumname));
        //                                                        break;
        //                                                    case "PLN":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.PLN) / coloumname));
        //                                                        break;
        //                                                    case "SEK":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SEK) / coloumname));
        //                                                        break;
        //                                                    case "RON":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RON) / coloumname));
        //                                                        break;
        //                                                    case "CHF":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CHF) / coloumname));
        //                                                        break;
        //                                                    case "HRK":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HRK) / coloumname));
        //                                                        break;
        //                                                    case "AUD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.AUD) / coloumname));
        //                                                        break;
        //                                                    case "CAD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CAD) / coloumname));
        //                                                        break;
        //                                                    case "HKD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HKD) / coloumname));
        //                                                        break;
        //                                                    case "ILS":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ILS) / coloumname));
        //                                                        break;
        //                                                    case "MXN":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.MXN) / coloumname));
        //                                                        break;
        //                                                    case "NZD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.NZD) / coloumname));
        //                                                        break;
        //                                                    case "SGD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SGD) / coloumname));
        //                                                        break;
        //                                                    case "ZAR":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ZAR) / coloumname));
        //                                                        break;
        //                                                    default:
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.TRY) / coloumname));
        //                                                        break;
        //                                                }
        //                                                totalgelir += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                item.EventTotalRevenue += jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf);
        //                                                totalmaff += jobmasraf;

        //                                            }

        //                                        }
        //                                    }

        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        totalgelir += gunlukisfiyati;
        //                    }
        //                }
        //                istutar = System.Math.Round(Convert.ToDouble(db.Tbl_EventStore.Where(i => i.job_id == job.key.ToString()).Sum(masf => masf.EventDenetciTutar)), 2);
        //                job.EventJobTotalFiyat = System.Math.Round(totalgelir, 2);
        //                job.EventJobMasrafTutar = System.Math.Round(jobmasraf, 2);
        //                job.EventJobJobtutar = System.Math.Round(istutar, 2);
        //                job.EventJobTotalGider = System.Math.Round(istutar + totalmaff, 2);
        //                job.EventJobTamamlananGelir = System.Math.Round(TotalrevenueTamamlanan, 2);
        //                job.EventJobTamamlananGider = System.Math.Round(TotalcostTamamlanan, 2);
        //                job.EventJobTamamlananKar = System.Math.Round(TotalprofitTamamlanan, 2);
        //                db.SaveChanges();
        //            }

        //            if (job.EventJobZamantur != "CostPlus")
        //            {
        //                CalculateJobTotalCost(Event.job_id, 1, compa, null);

        //            }
        //            else
        //            {
        //                CalculateJobKar(job.key.ToString());
        //            }
        //            //CalculateManday(Event.job_id, compa, fxrate);
        //            return Event;
        //        }
        //        else
        //        {
        //            Tbl_EventStore newevent2 = new Tbl_EventStore();
        //            return newevent2;
        //        }
        //    }
        //    else
        //    {

        //        Tbl_EventStore newevent = new Tbl_EventStore();
        //        return newevent;
        //    }




        //}
        //public void CalculateManday(string jobid, string compa, string fxrate)
        //{
        //    string fxxrate = fxrate;
        //    int totalmanday = 0;
        //    Guid key = Guid.Parse(jobid);
        //    var job = db.Tbl_EventJob.Where(p => p.key == key).SingleOrDefault();
        //    var jobeventslist = db.Tbl_EventStore.Where(jid => jid.job_id == jobid).ToList();
        //    foreach (var jobevents in jobeventslist)
        //    {
        //        TimeSpan totalgun = Convert.ToDateTime(jobevents.end_date) - Convert.ToDateTime(jobevents.start_date);
        //        double toplamgun = System.Math.Floor(totalgun.TotalDays);
        //        totalmanday += Convert.ToInt32(toplamgun);
        //    }
        //    job.EventJobManday = totalmanday;
        //    db.SaveChanges();
        //    CalculateJobTotalCost(jobid, totalmanday, compa, fxxrate);
        //}
        //public void CalculateJobTotalCost(string jobid, int manday, string compa, string xfxrate = "0")
        //{
        //    int planingmanday = 0;
        //    double planinghours = 0;
        //    double jobmasraf = 0;
        //    double fxratedouble = 0;
        //    double TotalcostTamamlanan = 0;
        //    double TotalrevenueTamamlanan = 0;
        //    //double TotalprofitTamamlanan = 0;
        //    if (xfxrate != null)
        //    {
        //        fxratedouble = double.Parse(xfxrate, NumberStyles.Any, new CultureInfo("en-Us"));

        //    }
        //    double masraftutar = 0;
        //    double istutar = 0;
        //    double totalrevenue = 0;
        //    double totalgelir = 0;

        //    Guid key = Guid.Parse(jobid);
        //    var job = db.Tbl_EventJob.Where(p => p.key == key && p.Company == compa).SingleOrDefault();
        //    job.EventJobMasrafTutar = 0;
        //    job.EventJobMasrafTutar = 0;
        //    job.EventJobTamamlananGider = 0;
        //    job.EventJobTamamlananGelir = 0;
        //    job.EventJobTamamlananKar = 0;
        //    job.EventJobTotalFiyat = 0;
        //    job.EventJobKar = 0;
        //    if (job.EventJobZamantur != "CostPlus")
        //    {
        //        if (db.Tbl_EventStore.Where(i => i.job_id == jobid).ToList().Count > 0)
        //        {
        //            if (db.Tbl_EventStore.Where(i => i.job_id == jobid && i.Company == compa && i.IsActive == true && i.Onbazaar == "false").ToList().Count > 0 && job.EventJobMasrafYansıtma != "Will be recharged")
        //            {
        //                masraftutar = db.Tbl_EventStore.Where(i => i.job_id == jobid && i.Company == compa && i.IsActive == true && i.Onbazaar == "false").Sum(masf => masf.EventMasrafTutar);

        //            }
        //            if (db.Tbl_EventStore.Where(i => i.job_id == jobid).ToList().Count() > 0)
        //            {
        //                istutar = db.Tbl_EventStore.Where(i => i.job_id == jobid).Sum(masf => masf.EventDenetciTutar);
        //            }
        //            if (db.Tbl_EventStore.Where(i => i.job_id == jobid && i.durum_id == "3").ToList().Count > 0)
        //            {
        //                TotalcostTamamlanan = Convert.ToDouble(db.Tbl_EventStore.Where(i => i.job_id == jobid && i.durum_id == "3").Sum(masf => masf.EventTotalTamamlananCost));
        //            }
        //        }
        //        int k = 0;
        //        var tasklists = db.Tbl_EventStore.Where(i => i.job_id == jobid).ToList();
        //        foreach (var itemtasklists in tasklists)
        //        {
        //            double revenuebytaskforhourly = 0;
        //            double revenuebytaskforhourlyforcomp = 0;
        //            double itemtasklistmandayrevenue = 0;
        //            bool fixedkontrol = false;
        //            k = 0;
        //            var pricelist = db.Tbl_PriceList.Where(p => p.Company == compa && p.ListID == job.PriceListID).SingleOrDefault();
        //            var belgesplits = itemtasklists.hizmet_id.ToString().Split(',');
        //            if (belgesplits.Count() > 0)
        //            {

        //                foreach (var belgesplit in belgesplits)
        //                {


        //                    int servicesid = Convert.ToInt32(belgesplits[k].ToString());
        //                    var dendet = db.Tbl_EventDenetciDetails.Where(p => p.key == servicesid).SingleOrDefault();
        //                    int servicess = Convert.ToInt32(dendet.EventDenetciDenetimBelgeturu);
        //                    var services = db.Tbl_Hizmetler.Where(p => p.key == servicess).SingleOrDefault();
        //                    servicesid = services.key;
        //                    k++;
        //                    var details = db.Tbl_PriceListDetails.Where(p => p.ListID == pricelist.ListID && p.ServicesID == servicesid).SingleOrDefault();
        //                    string jobkur = details.PriceFX;
        //                    double gunlukisfiyati = 0;
        //                    var company = db.Tbl_Companies.Where(companys => companys.CompanyName == compa).SingleOrDefault();
        //                    string companykur = company.Kur;
        //                    string companykurbanka = company.KurBanka;
        //                    DateTime lastdatefx = Convert.ToDateTime(db.Tbl_Kurlar.OrderByDescending(p => p.KurTarih).Where(i => i.KurBanka == companykurbanka).Max(a => a.KurTarih).ToString());
        //                    DateTime t = Convert.ToDateTime(lastdatefx.ToShortDateString());
        //                    var kurlist = db.Tbl_Kurlar.Where(pp => pp.KurBanka == companykurbanka && pp.KurTarih == t).SingleOrDefault();
        //                    var coloumnnamequery = kurlist.GetType().GetProperties().Where(p => p.Name == companykur).Select(a => a.GetValue(kurlist, null)).FirstOrDefault();
        //                    double coloumname = Convert.ToDouble(coloumnnamequery.ToString());
        //                    coloumname = 1 / coloumname;
        //                    if (itemtasklists.EventFaturaGuid == null)
        //                    {
        //                        if (companykur != jobkur)
        //                        {
        //                            switch (jobkur)
        //                            {
        //                                case "EUR":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.EUR) / coloumname));
        //                                    break;
        //                                case "USD":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.USD) / coloumname));
        //                                    break;
        //                                case "GPB":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.GPB) / coloumname));
        //                                    break;
        //                                case "RUB":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.RUB) / coloumname));
        //                                    break;
        //                                case "JPY":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.JPY) / coloumname));
        //                                    break;
        //                                case "DKK":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.DKK) / coloumname));
        //                                    break;
        //                                case "PLN":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.PLN) / coloumname));
        //                                    break;
        //                                case "SEK":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.SEK) / coloumname));
        //                                    break;
        //                                case "RON":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.RON) / coloumname));
        //                                    break;
        //                                case "CHF":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.CHF) / coloumname));
        //                                    break;
        //                                case "HRK":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.HRK) / coloumname));
        //                                    break;
        //                                case "AUD":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.AUD) / coloumname));
        //                                    break;
        //                                case "CAD":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.CAD) / coloumname));
        //                                    break;
        //                                case "HKD":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.HKD) / coloumname));
        //                                    break;
        //                                case "ILS":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.ILS) / coloumname));
        //                                    break;
        //                                case "MXN":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.MXN) / coloumname));
        //                                    break;
        //                                case "NZD":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.NZD) / coloumname));
        //                                    break;
        //                                case "SGD":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.SGD) / coloumname));
        //                                    break;
        //                                case "ZAR":
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.ZAR) / coloumname));
        //                                    break;
        //                                default:
        //                                    gunlukisfiyati = Convert.ToDouble(details.Price * ((1 / kurlist.TRY) / coloumname));
        //                                    break;
        //                            }

        //                        }
        //                        else
        //                        {
        //                            gunlukisfiyati = Convert.ToDouble(details.Price * 1);
        //                        }

        //                        string jtur = details.PriceType;
        //                        if (details.PriceType == "Fixed") //sıkıntılı
        //                        {

        //                            if (manday == 0)
        //                            {
        //                                if (job.EventJobMasrafYansıtma == "Will be recharged")
        //                                {
        //                                    var tasklist = db.Tbl_EventStore.Where(p => p.Company == compa && p.Onbazaar == "false" && p.IsActive == true && p.is_paid == "false" && p.durum_id != "3" && p.job_id == job.key.ToString()).ToList();
        //                                    foreach (var item in tasklist)
        //                                    {
        //                                        var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventMasrafDurum2 == "Confirmed" && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == item.id).ToList();
        //                                        if (masraflist.Count() > 0)
        //                                        {
        //                                            foreach (var masrafs in masraflist)
        //                                            {
        //                                                var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafDurum2 == "Confirmed" && p.EventDenetciMasrafguid == masrafs.EventDenetciMasrafGuid).ToList();
        //                                                foreach (var item2 in masrafss)
        //                                                {
        //                                                    if (item2.EventDenetciYansitilacak == job.EventJobMasrafYansıtma)
        //                                                    {
        //                                                        switch (item2.FaturaKurS)
        //                                                        {
        //                                                            case "EUR":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.EUR) / coloumname));
        //                                                                break;
        //                                                            case "USD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.USD) / coloumname));
        //                                                                break;
        //                                                            case "GPB":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.GPB) / coloumname));
        //                                                                break;
        //                                                            case "RUB":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.RUB) / coloumname));
        //                                                                break;
        //                                                            case "JPY":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.JPY) / coloumname));
        //                                                                break;
        //                                                            case "DKK":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.DKK) / coloumname));
        //                                                                break;
        //                                                            case "PLN":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.PLN) / coloumname));
        //                                                                break;
        //                                                            case "SEK":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.SEK) / coloumname));
        //                                                                break;
        //                                                            case "RON":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.RON) / coloumname));
        //                                                                break;
        //                                                            case "CHF":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.CHF) / coloumname));
        //                                                                break;
        //                                                            case "HRK":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.HRK) / coloumname));
        //                                                                break;
        //                                                            case "AUD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.AUD) / coloumname));
        //                                                                break;
        //                                                            case "CAD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.CAD) / coloumname));
        //                                                                break;
        //                                                            case "HKD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.HKD) / coloumname));
        //                                                                break;
        //                                                            case "ILS":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.ILS) / coloumname));
        //                                                                break;
        //                                                            case "MXN":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.MXN) / coloumname));
        //                                                                break;
        //                                                            case "NZD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.NZD) / coloumname));
        //                                                                break;
        //                                                            case "SGD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.SGD) / coloumname));
        //                                                                break;
        //                                                            case "ZAR":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.ZAR) / coloumname));
        //                                                                break;
        //                                                            default:
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsKDVDahilTutar * ((1 / kurlist.TRY) / coloumname));
        //                                                                break;
        //                                                        }
        //                                                        totalrevenue += gunlukisfiyati + item2.EventDenetciMasrafMasrafsKDVDahilTutar;
        //                                                    }

        //                                                }
        //                                            }

        //                                        }
        //                                        else
        //                                        {
        //                                            totalrevenue += gunlukisfiyati;

        //                                        }

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    totalrevenue += gunlukisfiyati;
        //                                    itemtasklists.PlaningManday = 1;
        //                                    itemtasklists.PlanningHours = 1;
        //                                    DateTime isdate = Convert.ToDateTime(Convert.ToDateTime(itemtasklists.start_date).ToShortDateString());
        //                                    DateTime isdateend = Convert.ToDateTime(itemtasklists.end_date);


        //                                    for (int i = 0; isdate <= isdateend; i++)
        //                                    {
        //                                        DateTime isdatemodif = isdate.AddHours(23).AddMinutes(59);
        //                                        int Auditorid = Convert.ToInt32(itemtasklists.key);
        //                                        var tasklist = db.Tbl_TaskDetails.Where(p => p.AuditorID == Auditorid && p.StartDate <= isdatemodif && p.EndDate >= isdate).ToList();
        //                                        if (tasklist.Count > 1)
        //                                        {
        //                                            double toplamgundays = 0;
        //                                            foreach (var tasklistitem in tasklist)
        //                                            {
        //                                                DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
        //                                                DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

        //                                                TimeSpan totalgun = enddatedet - startdatedet;
        //                                                toplamgundays += totalgun.Hours;
        //                                            }
        //                                            foreach (var tasklistitem in tasklist)
        //                                            {
        //                                                DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
        //                                                DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

        //                                                TimeSpan totalgun = enddatedet - startdatedet;
        //                                                double toplamgun = totalgun.Hours;
        //                                                tasklistitem.TaskDetailsGelir = System.Math.Round(((toplamgun / toplamgundays) * gunlukisfiyati), 2);
        //                                                db.SaveChanges();
        //                                            }
        //                                        }
        //                                        else if (tasklist.Count == 1)
        //                                        {
        //                                            foreach (var taskdetlist in tasklist)
        //                                            {

        //                                                taskdetlist.TaskDetailsGelir = System.Math.Round(gunlukisfiyati, 2);
        //                                                db.SaveChanges();
        //                                            }
        //                                        }
        //                                        else
        //                                        {

        //                                        }
        //                                        isdate = isdate.AddDays(i + 1);
        //                                    }
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (job.EventJobMasrafYansıtma == "Will be recharged")
        //                                {
        //                                    var item = itemtasklists;
        //                                    var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == item.id && p.EventMasrafDurum == "Confirmed" && p.EventDenetciMasrafDenetciID == dendet.EventDenetnciID).ToList();
        //                                    if (masraflist.Count() > 0)
        //                                    {
        //                                        foreach (var masrafs in masraflist)
        //                                        {
        //                                            var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == masrafs.EventDenetciMasrafGuid && p.EventDenetciYansitilacak == "Will be recharged").ToList();
        //                                            foreach (var item2 in masrafss)
        //                                            {
        //                                                if (item2.EventDenetciYansitilacak == job.EventJobMasrafYansıtma)
        //                                                {
        //                                                    if (item2.EventDenetciYansitmaDurum == "Completed")
        //                                                    {
        //                                                        var invdet = db.Tbl_EventFaturaEvents.Where(p => p.EventFaturaDescription == "Fatura" && p.EventFaturaServicesID == item2.EventDenetciMasrafMasrafsGuid && p.EventFaturaType == "Standart" && p.Company == compa && p.IsActive == true).SingleOrDefault();
        //                                                        if (invdet != null)
        //                                                        {
        //                                                            var inv2 = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == invdet.EventFaturaGuid).SingleOrDefault();
        //                                                            if (inv2 != null)
        //                                                            {
        //                                                                jobmasraf = System.Math.Round(inv2.EventFaturaToplamTutar, 2);
        //                                                                TotalrevenueTamamlanan += jobmasraf;
        //                                                                itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(totalgelir, 2);
        //                                                                totalrevenue += ((gunlukisfiyati / belgesplit.Count()) + (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf)));
        //                                                                revenuebytaskforhourly += System.Math.Round(((gunlukisfiyati / belgesplit.Count()) + (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf))), 2);
        //                                                                masraftutar += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                                itemtasklists.EventTotalRevenue = revenuebytaskforhourly;

        //                                                            }
        //                                                        }
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        switch (item2.FaturaKurS)
        //                                                        {
        //                                                            case "EUR":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.EUR) / coloumname));
        //                                                                break;
        //                                                            case "USD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.USD) / coloumname));
        //                                                                break;
        //                                                            case "GPB":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.GPB) / coloumname));
        //                                                                break;
        //                                                            case "RUB":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RUB) / coloumname));
        //                                                                break;
        //                                                            case "JPY":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.JPY) / coloumname));
        //                                                                break;
        //                                                            case "DKK":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.DKK) / coloumname));
        //                                                                break;
        //                                                            case "PLN":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.PLN) / coloumname));
        //                                                                break;
        //                                                            case "SEK":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SEK) / coloumname));
        //                                                                break;
        //                                                            case "RON":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RON) / coloumname));
        //                                                                break;
        //                                                            case "CHF":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CHF) / coloumname));
        //                                                                break;
        //                                                            case "HRK":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HRK) / coloumname));
        //                                                                break;
        //                                                            case "AUD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.AUD) / coloumname));
        //                                                                break;
        //                                                            case "CAD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CAD) / coloumname));
        //                                                                break;
        //                                                            case "HKD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HKD) / coloumname));
        //                                                                break;
        //                                                            case "ILS":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ILS) / coloumname));
        //                                                                break;
        //                                                            case "MXN":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.MXN) / coloumname));
        //                                                                break;
        //                                                            case "NZD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.NZD) / coloumname));
        //                                                                break;
        //                                                            case "SGD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SGD) / coloumname));
        //                                                                break;
        //                                                            case "ZAR":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ZAR) / coloumname));
        //                                                                break;
        //                                                            default:
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.TRY) / coloumname));
        //                                                                break;
        //                                                        }
        //                                                        totalrevenue += ((gunlukisfiyati + (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf)))) / belgesplit.Count();
        //                                                        revenuebytaskforhourly += System.Math.Round(((gunlukisfiyati + (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf))) / belgesplit.Count()), 2);
        //                                                        masraftutar += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                        itemtasklists.EventTotalRevenue = revenuebytaskforhourly;
        //                                                    }
        //                                                    itemtasklists.PlaningManday = 1;
        //                                                    itemtasklists.PlanningHours = 1;
        //                                                    var detlist = db.Tbl_TaskDetails.Where(p => p.TaskID == itemtasklists.id).ToList();
        //                                                    foreach (var itemtaskdetailsre in detlist)
        //                                                    {
        //                                                        itemtaskdetailsre.TaskDetailsGelir = System.Math.Round(gunlukisfiyati / detlist.Count(), 2);
        //                                                    }
        //                                                }

        //                                            }
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        totalrevenue += ((gunlukisfiyati + (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf)))) / belgesplit.Count();
        //                                        revenuebytaskforhourly += System.Math.Round(((gunlukisfiyati + (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf))) / belgesplit.Count()), 2);
        //                                        itemtasklists.EventTotalRevenue = revenuebytaskforhourly;
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    jobmasraf = 0;
        //                                    totalrevenue += ((gunlukisfiyati + (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf)))) / belgesplit.Count();
        //                                    revenuebytaskforhourly += System.Math.Round(((gunlukisfiyati + (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf))) / belgesplit.Count()), 2);
        //                                    itemtasklists.EventTotalRevenue = revenuebytaskforhourly;
        //                                    //if (itemtasklists.durum_id == "3")
        //                                    //{
        //                                    //   TotalrevenueTamamlanan += System.Math.Round(Convert.ToDouble(revenuebytaskforhourly), 2);
        //                                    //   itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(Convert.ToDouble(revenuebytaskforhourly), 2);
        //                                    //}
        //                                    itemtasklists.PlaningManday = 1;
        //                                    itemtasklists.PlanningHours = 1;
        //                                    var detlist = db.Tbl_TaskDetails.Where(p => p.TaskID == itemtasklists.id).ToList();
        //                                    foreach (var itemtaskdetailsre in detlist)
        //                                    {
        //                                        itemtaskdetailsre.TaskDetailsGelir = System.Math.Round(gunlukisfiyati / detlist.Count(), 2);
        //                                    }
        //                                }
        //                            }

        //                        }
        //                        else if (details.PriceType == "Hourly")
        //                        {
        //                            var itemtasklisthourly = itemtasklists;
        //                            var detailstaskdetails = db.Tbl_TaskDetails.Where(p => p.TaskID == itemtasklisthourly.id && p.AuditorID == dendet.EventDenetnciID).ToList();
        //                            foreach (var itemdetailstaskdetails in detailstaskdetails)
        //                            {
        //                                DateTime startdatedet = Convert.ToDateTime(itemdetailstaskdetails.StartDate.ToString());
        //                                DateTime enddatedet = Convert.ToDateTime(itemdetailstaskdetails.EndDate.ToString());
        //                                TimeSpan totalgun = enddatedet - startdatedet;
        //                                double toplamgun = totalgun.Hours;
        //                                double totalminutes = totalgun.Minutes / Convert.ToDouble(60);
        //                                toplamgun = toplamgun + totalminutes;
        //                                totalrevenue += Convert.ToInt32(toplamgun) * gunlukisfiyati;
        //                                planinghours += toplamgun;
        //                                itemtasklists.PlanningHours = planinghours;
        //                                itemtasklists.PlaningManday = 0;
        //                                revenuebytaskforhourly += Convert.ToInt32(toplamgun) * gunlukisfiyati;
        //                                itemtasklists.EventTotalRevenue = System.Math.Round(revenuebytaskforhourly, 2);
        //                                itemdetailstaskdetails.TaskDetailsGelir = System.Math.Round(Convert.ToDouble(toplamgun) * gunlukisfiyati, 2);
        //                                itemdetailstaskdetails.TaskDetailsKar = System.Math.Round((Convert.ToDouble(toplamgun) * gunlukisfiyati) - Convert.ToDouble(itemdetailstaskdetails.TaskDetailsGider), 2);

        //                                //totalgelir += Convert.ToInt32(toplamgun) * gunlukisfiyati;



        //                            }

        //                            if (job.JobOrClass == "Class")
        //                            {
        //                                int mandayforclass = db.Tbl_ConfirmApprovalList.Where(p => p.ConfirmApprovalListGelenObjID == job.EventJobInvoiceTo.ToString() && p.ConfirmApprovalListStatus == "Confirmed").Count();
        //                                totalrevenue = (mandayforclass + 1) * gunlukisfiyati;

        //                            }
        //                            else
        //                            {
        //                                if (job.EventJobMasrafYansıtma == "Will be recharged")
        //                                {

        //                                    var item = itemtasklists;

        //                                    double itemtaskcomprevenueexp = 0;


        //                                    var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafNeden != "Advance Payment" && p.EventMasrafDurum == "Confirmed" && p.EventDenetciMasrafEventId == item.id && p.EventDenetciMasrafDenetciID == dendet.EventDenetnciID).ToList();
        //                                    if (masraflist.Count() > 0)
        //                                    {

        //                                        foreach (var masrafs in masraflist)
        //                                        {
        //                                            var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == masrafs.EventDenetciMasrafGuid && p.EventDenetciYansitilacak == "Will be recharged").ToList();
        //                                            foreach (var item2 in masrafss)
        //                                            {
        //                                                if (item2.EventDenetciYansitilacak == job.EventJobMasrafYansıtma)
        //                                                {
        //                                                    if (item2.EventDenetciYansitmaDurum == "Completed")
        //                                                    {
        //                                                        var invdet = db.Tbl_EventFaturaEvents.Where(p => p.EventFaturaDescription == "Fatura" && p.EventFaturaServicesID == item2.EventDenetciMasrafMasrafsGuid && p.EventFaturaType == "Standart" && p.Company == compa && p.IsActive == true).SingleOrDefault();
        //                                                        if (invdet != null)
        //                                                        {
        //                                                            var inv2 = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == invdet.EventFaturaGuid).SingleOrDefault();
        //                                                            if (inv2 != null)
        //                                                            {
        //                                                                jobmasraf = System.Math.Round(inv2.EventFaturaToplamTutar, 2);
        //                                                                masraftutar += jobmasraf;
        //                                                                TotalrevenueTamamlanan += jobmasraf;
        //                                                                totalrevenue += jobmasraf;
        //                                                                itemtaskcomprevenueexp += jobmasraf;
        //                                                                itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(itemtaskcomprevenueexp, 2);
        //                                                                itemtasklists.EventTotalRevenue += System.Math.Round(jobmasraf, 2);
        //                                                            }
        //                                                        }
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        switch (item2.FaturaKurS)
        //                                                        {
        //                                                            case "EUR":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.EUR) / coloumname));
        //                                                                break;
        //                                                            case "USD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.USD) / coloumname));
        //                                                                break;
        //                                                            case "GPB":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.GPB) / coloumname));
        //                                                                break;
        //                                                            case "RUB":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RUB) / coloumname));
        //                                                                break;
        //                                                            case "JPY":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.JPY) / coloumname));
        //                                                                break;
        //                                                            case "DKK":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.DKK) / coloumname));
        //                                                                break;
        //                                                            case "PLN":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.PLN) / coloumname));
        //                                                                break;
        //                                                            case "SEK":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SEK) / coloumname));
        //                                                                break;
        //                                                            case "RON":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RON) / coloumname));
        //                                                                break;
        //                                                            case "CHF":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CHF) / coloumname));
        //                                                                break;
        //                                                            case "HRK":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HRK) / coloumname));
        //                                                                break;
        //                                                            case "AUD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.AUD) / coloumname));
        //                                                                break;
        //                                                            case "CAD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CAD) / coloumname));
        //                                                                break;
        //                                                            case "HKD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HKD) / coloumname));
        //                                                                break;
        //                                                            case "ILS":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ILS) / coloumname));
        //                                                                break;
        //                                                            case "MXN":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.MXN) / coloumname));
        //                                                                break;
        //                                                            case "NZD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.NZD) / coloumname));
        //                                                                break;
        //                                                            case "SGD":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SGD) / coloumname));
        //                                                                break;
        //                                                            case "ZAR":
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ZAR) / coloumname));
        //                                                                break;
        //                                                            default:
        //                                                                jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.TRY) / coloumname));
        //                                                                break;
        //                                                        }
        //                                                        totalrevenue += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                        itemtasklists.EventTotalRevenue += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                        masraftutar += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                    }
        //                                                }

        //                                            }
        //                                        }

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    //if (itemtasklists.durum_id == "3")
        //                                    //{
        //                                    //    TotalrevenueTamamlanan += System.Math.Round(Convert.ToDouble(revenuebytaskforhourly), 2);
        //                                    //    itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(Convert.ToDouble(revenuebytaskforhourly), 2);
        //                                    //}

        //                                }
        //                            }
        //                        }
        //                        else if (details.PriceType == "Manday")
        //                        {

        //                            int totalmanday = 0;
        //                            var jobevents = itemtasklists;
        //                            TimeSpan totalgun = Convert.ToDateTime(jobevents.end_date) - Convert.ToDateTime(jobevents.start_date);
        //                            double toplamgun = System.Math.Floor(totalgun.TotalDays);
        //                            totalmanday += Convert.ToInt32(toplamgun);
        //                            planingmanday += totalmanday;
        //                            itemtasklists.PlaningManday = planingmanday;
        //                            itemtasklists.PlanningHours = 0;
        //                            totalrevenue += totalmanday * gunlukisfiyati;
        //                            itemtasklistmandayrevenue += totalmanday * gunlukisfiyati;
        //                            itemtasklists.EventTotalRevenue = itemtasklistmandayrevenue;
        //                            DateTime isdate = Convert.ToDateTime(Convert.ToDateTime(jobevents.start_date).ToShortDateString());
        //                            DateTime isdateend = Convert.ToDateTime(jobevents.end_date);


        //                            for (int i = 1; isdate <= isdateend; i++)
        //                            {
        //                                DateTime isdatemodif = isdate.AddHours(23).AddMinutes(59);
        //                                var item = dendet.EventDenetnciID;
        //                                int Auditorid = Convert.ToInt32(item);
        //                                var tasklist = db.Tbl_TaskDetails.Where(p => p.AuditorID == Auditorid && p.StartDate <= isdatemodif && p.EndDate >= isdate).ToList();
        //                                if (tasklist.Count > 1)
        //                                {
        //                                    double toplamgundays = 0;
        //                                    foreach (var tasklistitem in tasklist)
        //                                    {
        //                                        DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
        //                                        DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

        //                                        TimeSpan totalgun2 = enddatedet - startdatedet;
        //                                        toplamgundays += totalgun2.Hours;
        //                                    }
        //                                    foreach (var tasklistitem in tasklist)
        //                                    {
        //                                        DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
        //                                        DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

        //                                        TimeSpan totalgun2 = enddatedet - startdatedet;
        //                                        double toplamgun2 = totalgun2.Hours;
        //                                        tasklistitem.TaskDetailsGelir = System.Math.Round((toplamgun2 / toplamgundays) * gunlukisfiyati);
        //                                        db.SaveChanges();
        //                                    }
        //                                }
        //                                else if (tasklist.Count == 1)
        //                                {
        //                                    foreach (var taskdetlist in tasklist)
        //                                    {

        //                                        taskdetlist.TaskDetailsGelir = System.Math.Round(gunlukisfiyati);
        //                                        db.SaveChanges();
        //                                    }
        //                                }
        //                                else
        //                                {

        //                                }
        //                                isdate = isdate.AddDays(1);


        //                            }





        //                            if (job.JobOrClass == "Class")
        //                            {
        //                                int mandayforclass = db.Tbl_ConfirmApprovalList.Where(p => p.ConfirmApprovalListGelenObjID == job.EventJobInvoiceTo.ToString() && p.ConfirmApprovalListStatus == "Confirmed").Count();
        //                                totalrevenue = (mandayforclass + 1) * gunlukisfiyati;

        //                            }
        //                            else
        //                            {
        //                                if (job.EventJobMasrafYansıtma == "Will be recharged")
        //                                {

        //                                    var tasklist = db.Tbl_EventStore.Where(p => p.Company == compa && p.Onbazaar == "false" && p.IsActive == true && p.is_paid == "false" && p.durum_id != "3" && p.job_id == job.key.ToString() && p.id == itemtasklists.id).ToList();
        //                                    foreach (var item in tasklist)
        //                                    {

        //                                        double itemtaskcomprevenueexp = 0;
        //                                        var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == item.id && p.EventDenetciMasrafDenetciID == dendet.EventDenetnciID).ToList();
        //                                        if (masraflist.Count() > 0)
        //                                        {

        //                                            foreach (var masrafs in masraflist)
        //                                            {
        //                                                var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == masrafs.EventDenetciMasrafGuid && p.EventDenetciYansitilacak == "Will be recharged").ToList();
        //                                                foreach (var item2 in masrafss)
        //                                                {
        //                                                    if (item2.EventDenetciYansitilacak == job.EventJobMasrafYansıtma)
        //                                                    {
        //                                                        if (item2.EventDenetciYansitmaDurum == "Completed")
        //                                                        {
        //                                                            var invdet = db.Tbl_EventFaturaEvents.Where(p => p.EventFaturaDescription == "Fatura" && p.EventFaturaServicesID == item2.EventDenetciMasrafMasrafsGuid && p.EventFaturaType == "Standart" && p.Company == compa && p.IsActive == true).SingleOrDefault();
        //                                                            if (invdet != null)
        //                                                            {
        //                                                                var inv2 = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == invdet.EventFaturaGuid).SingleOrDefault();
        //                                                                if (inv2 != null)
        //                                                                {
        //                                                                    jobmasraf = System.Math.Round(inv2.EventFaturaToplamTutar, 2);
        //                                                                    masraftutar += jobmasraf;
        //                                                                    TotalrevenueTamamlanan += jobmasraf;
        //                                                                    itemtaskcomprevenueexp += jobmasraf;
        //                                                                    totalrevenue += jobmasraf;
        //                                                                    itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(itemtaskcomprevenueexp, 2);
        //                                                                    itemtasklists.EventTotalRevenue += System.Math.Round(jobmasraf, 2);
        //                                                                }
        //                                                            }
        //                                                        }
        //                                                        else
        //                                                        {
        //                                                            switch (item2.FaturaKurS)
        //                                                            {
        //                                                                case "EUR":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.EUR) / coloumname));
        //                                                                    break;
        //                                                                case "USD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.USD) / coloumname));
        //                                                                    break;
        //                                                                case "GPB":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.GPB) / coloumname));
        //                                                                    break;
        //                                                                case "RUB":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RUB) / coloumname));
        //                                                                    break;
        //                                                                case "JPY":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.JPY) / coloumname));
        //                                                                    break;
        //                                                                case "DKK":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.DKK) / coloumname));
        //                                                                    break;
        //                                                                case "PLN":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.PLN) / coloumname));
        //                                                                    break;
        //                                                                case "SEK":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SEK) / coloumname));
        //                                                                    break;
        //                                                                case "RON":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RON) / coloumname));
        //                                                                    break;
        //                                                                case "CHF":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CHF) / coloumname));
        //                                                                    break;
        //                                                                case "HRK":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HRK) / coloumname));
        //                                                                    break;
        //                                                                case "AUD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.AUD) / coloumname));
        //                                                                    break;
        //                                                                case "CAD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CAD) / coloumname));
        //                                                                    break;
        //                                                                case "HKD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HKD) / coloumname));
        //                                                                    break;
        //                                                                case "ILS":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ILS) / coloumname));
        //                                                                    break;
        //                                                                case "MXN":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.MXN) / coloumname));
        //                                                                    break;
        //                                                                case "NZD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.NZD) / coloumname));
        //                                                                    break;
        //                                                                case "SGD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SGD) / coloumname));
        //                                                                    break;
        //                                                                case "ZAR":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ZAR) / coloumname));
        //                                                                    break;
        //                                                                default:
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.TRY) / coloumname));
        //                                                                    break;
        //                                                            }
        //                                                            totalrevenue += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                            itemtasklists.EventTotalRevenue += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                            masraftutar += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                        }
        //                                                    }

        //                                                }
        //                                            }

        //                                        }
        //                                        else
        //                                        {
        //                                            //totalrevenue += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                            //itemtasklists.EventTotalRevenue += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));

        //                                        }
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    //if (itemtasklists.durum_id == "3")
        //                                    //{
        //                                    //    TotalrevenueTamamlanan += System.Math.Round(Convert.ToDouble(revenuebytaskforhourly), 2);
        //                                    //    itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(Convert.ToDouble(revenuebytaskforhourly), 2);
        //                                    //}

        //                                }
        //                            }
        //                        }
        //                        else if (details.PriceType == "Daily")
        //                        {

        //                            int totalmanday = 0;
        //                            var jobevents = itemtasklists;

        //                            TimeSpan totalgun = Convert.ToDateTime(jobevents.end_date) - Convert.ToDateTime(jobevents.start_date);
        //                            double toplamgun = System.Math.Floor(totalgun.TotalDays);
        //                            totalmanday += Convert.ToInt32(toplamgun);
        //                            planingmanday += totalmanday;
        //                            itemtasklists.PlaningManday = planingmanday;
        //                            itemtasklists.PlanningHours = 0;
        //                            totalrevenue += (totalmanday * gunlukisfiyati) / belgesplits.Count();
        //                            revenuebytaskforhourly += (totalmanday * gunlukisfiyati) / belgesplits.Count();
        //                            itemtasklists.EventTotalRevenue = revenuebytaskforhourly;
        //                            DateTime isdate = Convert.ToDateTime(Convert.ToDateTime(jobevents.start_date).ToShortDateString());
        //                            DateTime isdateend = Convert.ToDateTime(jobevents.end_date);


        //                            for (int i = 1; isdate <= isdateend; i++)
        //                            {
        //                                DateTime isdatemodif = isdate.AddHours(23).AddMinutes(59);
        //                                var item = dendet.EventDenetnciID;


        //                                int Auditorid = Convert.ToInt32(item);
        //                                var tasklist = db.Tbl_TaskDetails.Where(p => p.AuditorID == Auditorid && p.StartDate <= isdatemodif && p.EndDate >= isdate).ToList();
        //                                if (tasklist.Count > 1)
        //                                {
        //                                    double toplamgundays = 0;
        //                                    foreach (var tasklistitem in tasklist)
        //                                    {
        //                                        DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
        //                                        DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

        //                                        TimeSpan totalgun2 = enddatedet - startdatedet;
        //                                        toplamgundays += totalgun2.Hours;
        //                                    }
        //                                    foreach (var tasklistitem in tasklist)
        //                                    {
        //                                        DateTime startdatedet = Convert.ToDateTime(tasklistitem.StartDate.ToString());
        //                                        DateTime enddatedet = Convert.ToDateTime(tasklistitem.EndDate.ToString());

        //                                        TimeSpan totalgun2 = enddatedet - startdatedet;
        //                                        double toplamgun2 = totalgun2.Hours;
        //                                        tasklistitem.TaskDetailsGelir = System.Math.Round(((toplamgun2 / toplamgundays) * gunlukisfiyati) / belgesplits.Length);

        //                                        db.SaveChanges();
        //                                    }
        //                                }
        //                                else if (tasklist.Count == 1)
        //                                {
        //                                    foreach (var taskdetlist in tasklist)
        //                                    {

        //                                        taskdetlist.TaskDetailsGelir = System.Math.Round(gunlukisfiyati) / belgesplits.Length;
        //                                        db.SaveChanges();
        //                                    }
        //                                }
        //                                else
        //                                {

        //                                }
        //                                isdate = isdate.AddDays(1);

        //                            }





        //                            if (job.JobOrClass == "Class")
        //                            {
        //                                int mandayforclass = db.Tbl_ConfirmApprovalList.Where(p => p.ConfirmApprovalListGelenObjID == job.EventJobInvoiceTo.ToString() && p.ConfirmApprovalListStatus == "Confirmed").Count();
        //                                totalrevenue = (mandayforclass + 1) * gunlukisfiyati;

        //                            }
        //                            else
        //                            {
        //                                if (job.EventJobMasrafYansıtma == "Will be recharged")
        //                                {

        //                                    var tasklist = db.Tbl_EventStore.Where(p => p.Company == compa && p.Onbazaar == "false" && p.IsActive == true && p.is_paid == "false" && p.durum_id != "3" && p.job_id == job.key.ToString() && p.id == itemtasklists.id).ToList();
        //                                    foreach (var item in tasklist)
        //                                    {

        //                                        double itemtaskcomprevenueexp = 0;
        //                                        var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafDurum == "Confirmed" && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == item.id && p.EventDenetciMasrafDenetciID == dendet.EventDenetnciID).ToList();
        //                                        if (masraflist.Count() > 0)
        //                                        {

        //                                            foreach (var masrafs in masraflist)
        //                                            {
        //                                                var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == masrafs.EventDenetciMasrafGuid && p.EventDenetciYansitilacak == "Will be recharged").ToList();
        //                                                foreach (var item2 in masrafss)
        //                                                {
        //                                                    if (item2.EventDenetciYansitilacak == job.EventJobMasrafYansıtma)
        //                                                    {
        //                                                        if (item2.EventDenetciYansitmaDurum == "Completed")
        //                                                        {
        //                                                            var invdet = db.Tbl_EventFaturaEvents.Where(p => p.EventFaturaDescription == "Fatura" && p.EventFaturaServicesID == item2.EventDenetciMasrafMasrafsGuid && p.EventFaturaType == "Standart" && p.Company == compa && p.IsActive == true).SingleOrDefault();
        //                                                            if (invdet != null)
        //                                                            {
        //                                                                var inv2 = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == invdet.EventFaturaGuid).SingleOrDefault();
        //                                                                if (inv2 != null)
        //                                                                {
        //                                                                    jobmasraf = System.Math.Round(inv2.EventFaturaToplamTutar, 2);
        //                                                                    masraftutar += jobmasraf;
        //                                                                    TotalrevenueTamamlanan += jobmasraf;
        //                                                                    totalrevenue += jobmasraf;
        //                                                                    itemtaskcomprevenueexp += jobmasraf;
        //                                                                    itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(itemtaskcomprevenueexp, 2);
        //                                                                    itemtasklists.EventTotalRevenue += System.Math.Round(jobmasraf, 2);
        //                                                                }
        //                                                            }
        //                                                        }
        //                                                        else
        //                                                        {
        //                                                            switch (item2.FaturaKurS)
        //                                                            {
        //                                                                case "EUR":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.EUR) / coloumname));
        //                                                                    break;
        //                                                                case "USD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.USD) / coloumname));
        //                                                                    break;
        //                                                                case "GPB":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.GPB) / coloumname));
        //                                                                    break;
        //                                                                case "RUB":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RUB) / coloumname));
        //                                                                    break;
        //                                                                case "JPY":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.JPY) / coloumname));
        //                                                                    break;
        //                                                                case "DKK":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.DKK) / coloumname));
        //                                                                    break;
        //                                                                case "PLN":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.PLN) / coloumname));
        //                                                                    break;
        //                                                                case "SEK":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SEK) / coloumname));
        //                                                                    break;
        //                                                                case "RON":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RON) / coloumname));
        //                                                                    break;
        //                                                                case "CHF":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CHF) / coloumname));
        //                                                                    break;
        //                                                                case "HRK":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HRK) / coloumname));
        //                                                                    break;
        //                                                                case "AUD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.AUD) / coloumname));
        //                                                                    break;
        //                                                                case "CAD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CAD) / coloumname));
        //                                                                    break;
        //                                                                case "HKD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HKD) / coloumname));
        //                                                                    break;
        //                                                                case "ILS":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ILS) / coloumname));
        //                                                                    break;
        //                                                                case "MXN":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.MXN) / coloumname));
        //                                                                    break;
        //                                                                case "NZD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.NZD) / coloumname));
        //                                                                    break;
        //                                                                case "SGD":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SGD) / coloumname));
        //                                                                    break;
        //                                                                case "ZAR":
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ZAR) / coloumname));
        //                                                                    break;
        //                                                                default:
        //                                                                    jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.TRY) / coloumname));
        //                                                                    break;
        //                                                            }
        //                                                            totalrevenue += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                            itemtasklists.EventTotalRevenue += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                            masraftutar += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                                        }
        //                                                    }

        //                                                }
        //                                            }

        //                                        }
        //                                        else
        //                                        {
        //                                            //totalrevenue += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));
        //                                            //itemtasklists.EventTotalRevenue += (jobmasraf + (Convert.ToDouble(job.EventJobExpensePercent) / 100) * (jobmasraf));

        //                                        }
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    //totalrevenue += gunlukisfiyati;

        //                                }
        //                            }

        //                        }



        //                        job.EventJobTotalFiyat = System.Math.Round(totalrevenue, 2);
        //                        job.EventJobMasrafTutar = System.Math.Round(masraftutar, 2);
        //                        job.EventJobJobtutar = System.Math.Round(istutar, 2);
        //                        job.EventJobTamamlananGelir = System.Math.Round(TotalrevenueTamamlanan, 2);
        //                        job.EventJobTamamlananGider = System.Math.Round(TotalcostTamamlanan, 2);
        //                        job.EventJobTamamlananKar = TotalrevenueTamamlanan - System.Math.Round(TotalcostTamamlanan, 2);
        //                        if (job.IsIFRIC == true)
        //                        {

        //                        }
        //                        db.SaveChanges();
        //                        //job = db.Tbl_EventJob.Where(p => p.key == key && p.Company == compa).SingleOrDefault();
        //                    }

        //                    else
        //                    {
        //                        double totalrevbyelse = 0;
        //                        double totalrevbyelsetask = 0;
        //                        var inv = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == itemtasklists.EventFaturaGuid).SingleOrDefault();
        //                        gunlukisfiyati = Convert.ToDouble(System.Math.Round(inv.EventFaturaToplamTutarKDVdahil / belgesplits.Count()));
        //                        gunlukisfiyati = FXCalculateSelectedRate(gunlukisfiyati, inv.EventFaturaTarihi, inv.EventFaturaKurRate, companykur, inv.EventFaturaKur, companykurbanka);
        //                        totalrevenue += gunlukisfiyati;

        //                        TotalrevenueTamamlanan = totalrevenue;
        //                        itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(totalrevenue, 2);
        //                        db.SaveChanges();

        //                        //job.EventJobTotalFiyat = Convert.ToDouble(db.Tbl_EventStore.Where(p => p.job_id == job.key.ToString()).Sum(p => p.EventTotalRevenue));
        //                        //job.EventJobMasrafTutar = System.Math.Round(masraftutar, 2);
        //                        //job.EventJobJobtutar = System.Math.Round(istutar, 2);
        //                        job.EventJobTamamlananGelir = System.Math.Round(TotalrevenueTamamlanan, 2);
        //                        job.EventJobTamamlananGider = System.Math.Round(TotalcostTamamlanan, 2);
        //                        job.EventJobTamamlananKar = TotalrevenueTamamlanan - System.Math.Round(TotalcostTamamlanan, 2);
        //                        db.SaveChanges();
        //                        //job = db.Tbl_EventJob.Where(p => p.key == key && p.Company == compa).SingleOrDefault();
        //                        if (job.IsIFRIC == true)
        //                        {

        //                        }
        //                        db.SaveChanges();
        //                        //masrafların faturalaşan tasklar için hesaplatılması ve masrafın faturası geldiyse onu farklı hesaplatma vs.vs.
        //                        if (job.EventJobMasrafYansıtma == "Will be recharged")
        //                        {

        //                            var item = itemtasklists;




        //                            var masraflist = db.Tbl_EventDenetciMasraf.Where(p => p.IsActive == true && p.EventMasrafNeden != "Advance Payment" && p.EventDenetciMasrafEventId == item.id && p.EventDenetciMasrafDenetciID == dendet.EventDenetnciID).ToList();
        //                            if (masraflist.Count() > 0)
        //                            {

        //                                foreach (var masrafs in masraflist)
        //                                {
        //                                    var masrafss = db.Tbl_EventDenetciMasrafMasrafs.Where(p => p.IsActive == true && p.EventDenetciMasrafDurum == "Confirmed" && p.EventDenetciMasrafguid == masrafs.EventDenetciMasrafGuid && p.EventDenetciYansitilacak == "Will be recharged").ToList();
        //                                    foreach (var item2 in masrafss)
        //                                    {
        //                                        if (item2.EventDenetciYansitilacak == job.EventJobMasrafYansıtma)
        //                                        {

        //                                            if (item2.EventDenetciYansitmaDurum == "Completed")
        //                                            {
        //                                                var invdet = db.Tbl_EventFaturaEvents.Where(p => p.EventFaturaDescription == "Fatura" && p.EventFaturaServicesID == item2.EventDenetciMasrafMasrafsGuid && p.EventFaturaType == "Standart" && p.Company == compa && p.IsActive == true).SingleOrDefault();
        //                                                if (invdet != null)
        //                                                {
        //                                                    var inv2 = db.Tbl_EventFatura.Where(p => p.EventFaturaGuid == invdet.EventFaturaGuid).SingleOrDefault();
        //                                                    if (inv2 != null)
        //                                                    {
        //                                                        jobmasraf = System.Math.Round(inv2.EventFaturaToplamTutar, 2);
        //                                                        totalrevenue += jobmasraf;
        //                                                        masraftutar += jobmasraf;
        //                                                        itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(totalrevenue, 2);
        //                                                        itemtasklists.EventTotalRevenue = totalrevenue;
        //                                                        //totalrevenue += totalgelir;
        //                                                        job.EventJobTotalFiyat = System.Math.Round(totalrevenue, 2);
        //                                                        job.EventJobMasrafTutar = System.Math.Round(masraftutar, 2);
        //                                                        db.SaveChanges();
        //                                                    }
        //                                                }

        //                                            }
        //                                            else
        //                                            {
        //                                                switch (item2.FaturaKurS)
        //                                                {
        //                                                    case "EUR":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.EUR) / coloumname));
        //                                                        break;
        //                                                    case "USD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.USD) / coloumname));
        //                                                        break;
        //                                                    case "GPB":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.GPB) / coloumname));
        //                                                        break;
        //                                                    case "RUB":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RUB) / coloumname));
        //                                                        break;
        //                                                    case "JPY":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.JPY) / coloumname));
        //                                                        break;
        //                                                    case "DKK":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.DKK) / coloumname));
        //                                                        break;
        //                                                    case "PLN":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.PLN) / coloumname));
        //                                                        break;
        //                                                    case "SEK":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SEK) / coloumname));
        //                                                        break;
        //                                                    case "RON":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.RON) / coloumname));
        //                                                        break;
        //                                                    case "CHF":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CHF) / coloumname));
        //                                                        break;
        //                                                    case "HRK":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HRK) / coloumname));
        //                                                        break;
        //                                                    case "AUD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.AUD) / coloumname));
        //                                                        break;
        //                                                    case "CAD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.CAD) / coloumname));
        //                                                        break;
        //                                                    case "HKD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.HKD) / coloumname));
        //                                                        break;
        //                                                    case "ILS":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ILS) / coloumname));
        //                                                        break;
        //                                                    case "MXN":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.MXN) / coloumname));
        //                                                        break;
        //                                                    case "NZD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.NZD) / coloumname));
        //                                                        break;
        //                                                    case "SGD":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.SGD) / coloumname));
        //                                                        break;
        //                                                    case "ZAR":
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.ZAR) / coloumname));
        //                                                        break;
        //                                                    default:
        //                                                        jobmasraf = Convert.ToDouble(item2.EventDenetciMasrafMasrafsTutar * ((1 / kurlist.TRY) / coloumname));
        //                                                        break;
        //                                                }
        //                                                totalrevenue += jobmasraf;
        //                                                masraftutar += jobmasraf;
        //                                                itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(totalrevenue, 2);
        //                                                itemtasklists.EventTotalRevenue = totalrevenue;
        //                                                //totalrevenue += totalgelir;
        //                                                job.EventJobTotalFiyat = System.Math.Round(totalrevenue, 2);
        //                                                job.EventJobMasrafTutar = System.Math.Round(masraftutar, 2);
        //                                                db.SaveChanges();
        //                                            }
        //                                        }

        //                                    }
        //                                }

        //                            }
        //                            else
        //                            {
        //                                //totalrevenue += jobmasraf;
        //                                //masraftutar += jobmasraf;
        //                                itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(totalrevenue, 2);
        //                                itemtasklists.EventTotalRevenue = totalrevenue;
        //                                //totalrevenue += totalgelir;
        //                                job.EventJobTotalFiyat = System.Math.Round(totalrevenue, 2);
        //                                job.EventJobMasrafTutar = System.Math.Round(masraftutar, 2);
        //                                db.SaveChanges();
        //                            }
        //                        }
        //                        else
        //                        {
        //                            //totalrevenue += jobmasraf;
        //                            //masraftutar += jobmasraf;
        //                            itemtasklists.EventTotalTamamlananRevenue = System.Math.Round(totalrevenue, 2);
        //                            itemtasklists.EventTotalRevenue = totalrevenue;
        //                            //totalrevenue += totalgelir;
        //                            job.EventJobTotalFiyat = System.Math.Round(totalrevenue, 2);
        //                            job.EventJobMasrafTutar = System.Math.Round(masraftutar, 2);
        //                            db.SaveChanges();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        CalculateJobTotalGider(jobid);
        //    }
        //    else
        //    {
        //        CalculateJobKar(jobid);
        //    }

        //}
        //public void CalculateJobTotalGider(string jobid)
        //{
        //    double totalgider = 0;
        //    double eventcost = 0;
        //    Guid key = Guid.Parse(jobid);
        //    var job = db.Tbl_EventJob.Where(p => p.key == key).SingleOrDefault();
        //    var jobeventslist = db.Tbl_EventStore.Where(jid => jid.job_id == jobid).ToList();
        //    if (jobeventslist.Count > 0)
        //    {
        //        foreach (var jobevents in jobeventslist)
        //        {
        //            eventcost = Convert.ToDouble(jobevents.EventTotalCost);
        //            totalgider += eventcost;
        //        }
        //    }
        //    else
        //    {
        //        totalgider = 0;
        //    }
        //    job.EventJobTotalGider = System.Math.Round(totalgider, 2);
        //    db.SaveChanges();
        //    CalculateJobKar(jobid);
        //}
        //public void CalculateJobKar(string jobid)
        //{
        //    Guid key = Guid.Parse(jobid);
        //    var job = db.Tbl_EventJob.Where(p => p.key == key).SingleOrDefault();
        //    double kar = Convert.ToDouble(job.EventJobTotalFiyat) - Convert.ToDouble(job.EventJobTotalGider);
        //    job.EventJobKar = System.Math.Round(Convert.ToDouble(kar), 2);
        //    db.SaveChanges();
        //}
    }
}