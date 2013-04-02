using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeSCo.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string HpNo { get; set; }
        public string OffAddress { get; set; }
        public string OffTelNo{ get; set; }
        public string ResAddress { get; set; }
        public string ResTelNo { get; set; }


    }
}