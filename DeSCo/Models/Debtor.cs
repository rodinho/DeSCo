using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Web.Mvc;

namespace DeSCo.Models
{
    public class Debtor
    {
        public SelectList CodeItemList { get; set; }

        // public List<CallHistory> CallCollection { get; set; }
        //public List<SiteVisit> VisitCollection { get; set; }

        public virtual ICollection<CallHistory> CallCollection { get; set; }
        public virtual ICollection<SiteVisit> VisitCollection { get; set; }
        public virtual ICollection<PaymentMaster> PaymentCollection { get; set; }


        //List<CallHistory> _mList = new List<CallHistory>();
        //public List<CallHistory> CallCollection
        //{
        //    get { return _mList; }
        //    set { _mList = value; }
        //}


        //List<SiteVisit> _mVisitList = new List<SiteVisit>();
        //public List<SiteVisit> VisitCollection
        //{
        //    get { return _mVisitList; }
        //    set { _mVisitList = value; }
        //}


        private static int _nextId = 17;

        public Debtor()
        {
            Id = _nextId++;
            
        }




        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a card no")]
        public string CardNo { get; set; }

        [DataType(DataType.Currency)]
        public decimal OSAmount { get; set; }

        [DataType(DataType.Currency)]
        public decimal MIOAmount { get; set; }

        [Required(ErrorMessage = "Please enter a status")]
        public int Status { get; set; }
        
        public string BatchNumber { get; set; }
        public string OldNRIC { get; set; }

        [Required(ErrorMessage = "Please enter an NRIC")]
        public string NewNRIC { get; set; }

        [Required(ErrorMessage = "Please enter an Acc no")]
        public string AcNo { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address1 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address2 { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string OffTel { get; set; }

        public string ResTel { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string HPNo { get; set; }

        public string AssignTo { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> AssignDate { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> AbortDate { get; set; }

        [DataType(DataType.Currency)]
        public Double MinPymt { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DueDate { get; set; }

        [DataType(DataType.Currency)]
        public Double LastPaidAmt { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> LastPaidDate { get; set; }

        [DataType(DataType.Date)]
       public Nullable<System.DateTime> SalesDate { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> MaturityDate { get; set; }

        [DataType(DataType.Currency)]
        public Double CashPrice { get; set; }

        [DataType(DataType.Currency)]
        public Double DELQ { get; set; }


        public int ContractLenght { get; set; }

        public int NoOfMonthArrears { get; set; }

        [DataType(DataType.Currency)]
        public Double Balance { get; set; }

        [DataType(DataType.Currency)]
        public Double LateCharges { get; set; }

     

        [DataType(DataType.Currency)]
        public Double HSLDOSAmount { get; set; }

        public string TPS1 { get; set; }
        public string TPS2 { get; set; }
        public string TPS3 { get; set; }

        public string OweTo { get; set; }

        public string LOCCD { get; set; }

        public string AccountType { get; set; }

        public string TPSStatus { get; set; }

        public string Region { get; set; }
        public string Product { get; set; }

        [DataType(DataType.Currency)]
        public Double TltAmtDue { get; set; }

        [DataType(DataType.Currency)]
        public Double MinPayment1 { get; set; }

        [DataType(DataType.Currency)]
        public Double MinPayment2 { get; set; }

        [DataType(DataType.Currency)]
        public string MIA { get; set; }

        public string Guarantor1 { get; set; }

        public string Guarantor1NRIC { get; set; }

        [DataType(DataType.MultilineText)]
        public string GuAdd1 { get; set; }

        [DataType(DataType.MultilineText)]
        public string GuAdd2 { get; set; }

        [DataType(DataType.MultilineText)]
        public string GuAdd3 { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string GuOffTel { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string GuResTel { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string GuHPTel { get; set; }

        public string Guarantor2 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Gu2Add1 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Gu2Add2 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Gu2Add3 { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Gu2OffTel { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Gu2ResTel { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Gu2HPTel { get; set; }


        public string Guarantor2NRIC { get; set; }

        [DataType(DataType.MultilineText)]
        public string Others1 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Others2 { get; set; }


        public string DisplayStatus // read-only
        {
            get { return DataRepository.GetCodeItemsById(Status.ToString(CultureInfo.InvariantCulture)); }
            //get { return string.Empty ; }
        }

        public decimal  TotalNew // read-only
        {
            get { return DataRepository.GetTotalByStatus(Status); }
        }


    }



}