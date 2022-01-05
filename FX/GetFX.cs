using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SubcornTakip.Models;

namespace SubcornTakip.FX
{
    public class GetFX
    {
        SubcornTakipEntities db = new SubcornTakipEntities();
        private getFxfromLiverares Deserialise<getFxfromLiverares>(string json)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serialiser = new DataContractJsonSerializer(typeof(getFxfromLiverares));
                return (getFxfromLiverares)serialiser.ReadObject(ms);
            }
        }

        public Tbl_Kurlar EuropanCentralBank()
        {
            DateTime time = DateTime.Now;
            Tbl_Kurlar rate = new Tbl_Kurlar();
            var doc = new XmlDocument();
            try
            {
                doc.Load(@"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

                XmlNodeList nodes = doc.SelectNodes("//*[@currency]");
                XmlNodeList nodes2 = doc.SelectNodes("//*[@time]");
                if (nodes2 != null)
                {
                    foreach (XmlNode node2 in nodes2)
                    {
                        time = Convert.ToDateTime(node2.Attributes["time"].Value);
                    }
                }
                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {


                        switch (node.Attributes["currency"].Value)
                        {
                            case "TRY":
                                rate.TRY = double.Parse(node.Attributes["rate"].Value, NumberStyles.Currency, new CultureInfo("en-GB"));
                                break;
                            case "USD":
                                rate.USD = double.Parse(node.Attributes["rate"].Value, NumberStyles.Currency, new CultureInfo("en-GB"));
                                break;
                            case "GBP":
                                rate.GPB = double.Parse(node.Attributes["rate"].Value, NumberStyles.Currency, new CultureInfo("en-GB"));
                                break;
                            case "RUB":
                                rate.RUB = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "JPY":
                                rate.JPY = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "DKK":
                                rate.DKK = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "PLN":
                                rate.PLN = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "SEK":
                                rate.SEK = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "CHF":
                                rate.CHF = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "HRK":
                                rate.HRK = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "AUD":
                                rate.AUD = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "CAD":
                                rate.CAD = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "HKD":
                                rate.HKD = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "ILS":
                                rate.ILS = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "MXN":
                                rate.MXN = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "NZD":
                                rate.NZD = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "SGD":
                                rate.SGD = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "RON":
                                rate.RON = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            case "ZAR":
                                rate.ZAR = double.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-GB"));
                                break;
                            default:
                                break;
                        }
                        rate.EUR = 1;
                        rate.KurTarih = time;
                        rate.KurBanka = "Europan Central Bank";

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
 

            return rate;
        }
        public Tbl_Kurlar TurkishCentralBank()
        {

            DateTime time = DateTime.Now;
            Tbl_Kurlar rate = new Tbl_Kurlar();
            var doc = new XmlDocument();
            try
            {
                System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("tr-TR");
                doc.Load(@"http://www.tcmb.gov.tr/kurlar/today.xml");
                string s = doc.InnerXml;
                XmlNodeList nodes = doc.SelectNodes("//*[@CurrencyCode]");
                XmlNodeList nodes2 = doc.SelectNodes("//*[@Tarih]");
                XmlNodeList nodes3 = doc.SelectNodes("/Tarih_Date/Currency/ForexBuying");
                int k = -1;
                if (nodes2 != null)
                {
                    foreach (XmlNode node22 in nodes2)
                    {
                        time = DateTime.Parse(node22.Attributes["Tarih"].Value, cultureinfo);
                    }
                }
                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {
                        k++;


                        switch (node.Attributes["CurrencyCode"].Value)
                        {
                            case "EUR":
                                rate.EUR = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "USD":
                                rate.USD = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "GBP":
                                rate.GPB = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "RUB":
                                rate.RUB = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "JPY":
                                rate.JPY = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "DKK":
                                rate.DKK = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "PLN":
                                rate.PLN = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "SEK":
                                rate.SEK = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "CHF":
                                rate.CHF = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "HRK":
                                rate.HRK = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "AUD":
                                rate.AUD = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "CAD":
                                rate.CAD = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "HKD":
                                rate.HKD = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "ILS":
                                rate.ILS = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "MXN":
                                rate.MXN = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "NZD":
                                rate.NZD = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "SGD":
                                rate.SGD = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            case "ZAR":
                                rate.ZAR = double.Parse(nodes3[k].InnerXml, NumberStyles.Any, new CultureInfo("en-US"));
                                break;
                            default:
                                break;
                        }
                        rate.TRY = 1;
                        rate.KurTarih = time;
                        rate.KurBanka = "Turkish Central Bank";
                    }


                }
            }
            catch (Exception)
            {

                
            }
 

            return rate;
        }

        public async Task<Tbl_Kurlar> AmericanBankFromLiveRate()
        {
            DateTime time = DateTime.Now.Date;
            Tbl_Kurlar rate = new Tbl_Kurlar();
            var lastfx = db.Tbl_Kurlar.Where(p => p.KurBanka == "American-LiveRates" && p.KurTarih == time).SingleOrDefault();
            if(lastfx == null) {
            List<getFxfromLiverares> LiveRates = new List<getFxfromLiverares>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://live-rates.com/rates");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContent content = response.Content;

                    string data = await content.ReadAsStringAsync();

                    IEnumerable<getFxfromLiverares> d = Deserialise<IEnumerable<getFxfromLiverares>>(data);
                    foreach (var item in d)
                    {
                        var currency = item.currency.ToString();
                        double rates = Convert.ToDouble(item.rate);
                        getFxfromLiverares newrate = new getFxfromLiverares();
                        newrate.currency = currency;
                        newrate.rate = rates;
                        LiveRates.Add(newrate);

                    }




                    foreach (var item in LiveRates)
                    {
                        if (item.currency.Contains("USD/"))
                        {
                            switch (item.currency.Substring(4))
                            {
                                case "EUR":
                                    rate.EUR = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "TRY":
                                    rate.TRY = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "GBP":
                                    rate.GPB = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "RUB":
                                    rate.RUB = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "JPY":
                                    rate.JPY = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "DKK":
                                    rate.DKK = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "PLN":
                                    rate.PLN = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "SEK":
                                    rate.SEK = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "CHF":
                                    rate.CHF = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "HRK":
                                    rate.HRK = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "AUD":
                                    rate.AUD = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "CAD":
                                    rate.CAD = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "HKD":
                                    rate.HKD = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "ILS":
                                    rate.ILS = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "MXN":
                                    rate.MXN = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "NZD":
                                    rate.NZD = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "SGD":
                                    rate.SGD = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                case "ZAR":
                                    rate.ZAR = double.Parse(item.rate.ToString(), NumberStyles.Any, new CultureInfo("en-US"));
                                    break;
                                default:
                                    break;
                            }
                        }
                        rate.USD = 1;
                        rate.KurTarih = time;
                        rate.KurBanka = "American-LiveRates";

                    }
                }
            
            }
            return rate;
        }
    }
}