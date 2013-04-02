using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeSCo.Models
{
    public class SiteVisit
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public string AccNo { get; set; }
        public string CollectorName { get; set; }
        public string Remarks { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RemarksDate { get; set; }


         [DataType(DataType.Date)]
        public DateTime? VisitDate { get; set; }
        public string Location { get; set; }

        public byte Siteimage { get; set; }
       

    }
}