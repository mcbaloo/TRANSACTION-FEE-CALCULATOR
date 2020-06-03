using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace TRANSACTION_FEE_CALCULATOR
{
    class FeeHelper
    {
        //configure the path for the json file. 
        static string jsonPath = ConfigurationManager.AppSettings["JsonPath"];
        private static Fee getAppSettings()
        {
            try
            {
                using (StreamReader r = new StreamReader(jsonPath))
                {
                    string json = r.ReadToEnd();
                    var Items = JsonConvert.DeserializeObject<Fee>(json);
                    return Items;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public static decimal? computeServiceCharge(decimal amount)
        {
            Fee feeObj =  getAppSettings();
            var result = feeObj.fees.Where(m => m.minAmount <= amount && m.maxAmount >= amount).Select(m => m.feeAmount);
            if(result.Any())
            {
                return result.FirstOrDefault();
            }
            return null;
        }
    }
}
