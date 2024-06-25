using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.DTOs
{

    public class Rootobject
    {
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public Rate[] rates { get; set; }
    }

    public class Rate
    {
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public float mid { get; set; }
    }

}
