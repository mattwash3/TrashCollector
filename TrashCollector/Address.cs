using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector
{
    public class Address
    {
        [Key]

        [Display(Name = "Address")]
        public string MyAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }

    }
}