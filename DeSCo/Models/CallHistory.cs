using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DeSCo.Models
{
    public class CallHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public string AccNo { get; set; }
        public string Collector { get; set; }
        public string Remarks { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RmksDate { get; set; }

        public string LastStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FollowUpDate { get; set; }

        public double? PtpAmount { get; set; }
    }
}