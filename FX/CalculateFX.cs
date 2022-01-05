using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubcornTakip.Models;
namespace SubcornTakip.FX
{
    public class CalculateFX
    {
        SubcornTakipEntities db = new SubcornTakipEntities();
        public void CalculateFX_DB(Tbl_Kurlar kur)
        {
            
          
            var kurlist = db.Tbl_Kurlar.Where(p => p.KurTarih == kur.KurTarih && p.KurBanka == kur.KurBanka).SingleOrDefault();
                if(kurlist == null) { 
                    db.Tbl_Kurlar.Add(kur);
                    db.SaveChanges();
                
                    }
            
            
        }
    }
}