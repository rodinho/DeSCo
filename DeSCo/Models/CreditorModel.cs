using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DeSCo.Models
{
    public class Creditor
    {
        private static int nextID = 17;


        public Creditor()
        {
            ID = nextID++;
        }

        [Display(Name = "ID")]
        public int ID { get; set; }


        [Required]
        [Display(Name = "Batch No")]
        [StringLength(20,
            ErrorMessage = "The {0} must be at least {2} character long.", MinimumLength = 6)]
        public string BatchNumber { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Old NRIC")]
        public string OldNRIC { get; set; }

        [Required]
        [Display(Name = "New NRIC")]
        public string NewNRIC { get; set; }


        [Display(Name = "Card No")]
        public string CardNo { get; set; }


        [Display(Name = "Account No")]
        public string AcNo { get; set; }


        [Display(Name = "Address 1")]
        public string Address1 { get; set; }


        [Display(Name = "Address 2")]
        public string Address2 { get; set; }


        [Display(Name = "Off Tel")]
        public string OffTel { get; set; }


        [Display(Name = "Res Tel")]
        public string ResTel { get; set; }


        [Display(Name = "HP No")]
        public string HPNo { get; set; }


        [Display(Name = "AssignTo")]
        public string AssignTo { get; set; }


        [Display(Name = "Assign Date")]
        public string AssignDate { get; set; }


        [Display(Name = "Abort Date")]
        public string AbortDate { get; set; }


        [Display(Name = "OS Amount")]
        public string OSAmount { get; set; }


        [Display(Name = "Min Payment")]
        public string MinPymt { get; set; }


        [Display(Name = "Due Date")]
        public string DueDate { get; set; }


        [Display(Name = "Last Paid Amount")]
        public string LastPaidAmt { get; set; }


        [Display(Name = "Last Paid Date")]
        public string LastPaidDate { get; set; }


        [Display(Name = "HSLDOS Amount")]
        public string HSLDOSAmount { get; set; }


        [Display(Name = "TPS 1")]
        public string TPS1 { get; set; }


        [Display(Name = "TPS 2")]
        public string TPS2 { get; set; }


        [Display(Name = "TPS 3")]
        public string TPS3 { get; set; }


        [Display(Name = "Owe To")]
        public string OweTo { get; set; }


        [Display(Name = "Status")]
        public string Status { get; set; }


        [Display(Name = "TPS Status")]
        public string TPSStatus { get; set; }


        [Display(Name = "Region")]
        public string Region { get; set; }


        [Display(Name = "Product")]
        public string Product { get; set; }


        [Display(Name = "Total Amount Due")]
        public string TltAmtDue { get; set; }

        [Display(Name = "Min Payment 1")]
        public string MinPayment1 { get; set; }

        [Display(Name = "Min Payment 2")]
        public string MinPayment2 { get; set; }

        [Display(Name = "MIA")]
        public string MIA { get; set; }

        [Display(Name = "Guarantor 1")]
        public string Guarantor1 { get; set; }

        [Display(Name = "Guarantor Address 1")]
        public string GuAdd1 { get; set; }

        [Display(Name = "Guarantor Address 2")]
        public string GuAdd2 { get; set; }

        [Display(Name = "Guarantor Address 3")]
        public string GuAdd3 { get; set; }

        [Display(Name = "Guarantor Off Tell")]
        public string GuOffTel { get; set; }

        [Display(Name = "Guarantor Res Tell")]
        public string GuResTel { get; set; }

        [Display(Name = "Guarantor HP Tell")]
        public string GuHPTel { get; set; }

        [Display(Name = "Guarantor 2")]
        public string Guarantor2 { get; set; }

        [Display(Name = "Guarantor 2 Address 1")]
        public string Gu2Add1 { get; set; }

        [Display(Name = "Guarantor 2 Address 2")]
        public string Gu2Add2 { get; set; }

        [Display(Name = "Guarantor 2 Address 3")]
        public string Gu2Add3 { get; set; }

        [Display(Name = "Guarantor 2 Off Tell")]
        public string Gu2OffTel { get; set; }

        [Display(Name = "Guarantor 2 Res Tell")]
        public string Gu2ResTel { get; set; }

        [Display(Name = "Guarantor 2 HP Tell")]
        public string Gu2HPTel { get; set; }


        [Display(Name = "Others 1")]
        public string Others1 { get; set; }

        [Display(Name = "Others 2")]
        public string Others2 { get; set; }
    }


    public class CreditorDBContext : DbContext
    {
        public DbSet<Creditor> Creditors { get; set; }
    }
}