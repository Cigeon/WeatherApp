using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class WeatherRequest
    {
        public string City { get; set; }
        public string CustomCity { get; set; }
        public string Period { get; set; }
    }
}