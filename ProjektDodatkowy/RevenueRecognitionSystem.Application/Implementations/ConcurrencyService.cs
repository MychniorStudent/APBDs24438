using Newtonsoft.Json;
using RevenueRecognitionSystem.Application.Interfaces;
using RevenueRecognitionSystem.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Application.Implementations
{
    public class ConcurrencyService : IConcurrencyService
    {
        public decimal GetExchangedCurrenty(decimal amount, string currency)
        {
            string content = null;
            string URI = "http://api.nbp.pl/api/exchangerates/rates/a/"+currency;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            request.Headers.Add("Accept", "application/json");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(stream))
            {
                content = sr.ReadToEnd();
            }
            Rootobject rootobject = JsonConvert.DeserializeObject<Rootobject>(content);
              
            return amount / (decimal)rootobject.rates.FirstOrDefault().mid;
        }
    }
}
