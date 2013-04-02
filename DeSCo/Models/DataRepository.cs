using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace DeSCo.Models
{
    public class DataRepository
    {
        public static IList<CodeItem> CodeItemData = null;

        //public static List<SelectList> CodeItemList { get; set; }

        public static SelectList CodeItemList { get; set; }

        public static IList<CodeItem> GetCodeItems()
        {
            if (CodeItemData == null)
            {
                CodeItemData = new List<CodeItem>();
                CodeItemData.Add(new CodeItem { Id = 1, Group = "Status", Description = "NEW", });
                CodeItemData.Add(new CodeItem { Id = 2, Group = "Status", Description = "PTP", });
                CodeItemData.Add(new CodeItem { Id = 3, Group = "Status", Description = "CP", });
                CodeItemData.Add(new CodeItem { Id = 4, Group = "Status", Description = "WIP", });
                CodeItemData.Add(new CodeItem { Id = 5, Group = "Status", Description = "ABT", });
                CodeItemData.Add(new CodeItem { Id = 6, Group = "Status", Description = "SFV", });
                CodeItemData.Add(new CodeItem { Id = 7, Group = "Status", Description = "TPS", });

            }
            return CodeItemData;
        }


        public static string GetCodeItemsById(string id)
        {
            CodeItemData = GetCodeItems();
            if (id!=null)
            {
                return CodeItemData.FirstOrDefault(c => c.Id == Convert.ToInt32(id)).Description;
            }
           return string.Empty;
        }

        public static decimal  GetTotalByStatus(int  statusid)
        {
            DebtorData  = GetDebtors();
            if (statusid != 0)
            {
                var result = DebtorData.Where(d => d.Status == statusid).Sum(d => d.OSAmount);

                //var list = DebtorData.Select(c => c.Status == statusid).ToList();
                return result;
            }
            return DebtorData.Where(d => d.Status != 0).Sum(d => d.OSAmount); ;
        }


        public static SelectList GetCodeList()
        {
          foreach (var a in GetCodeItems() )
            {
                CodeItemList =
                    new SelectList(new List<SelectListItem>() {new SelectListItem() {Value = a.Id.ToString(CultureInfo.InvariantCulture), Text = a.Description}});
            }
          return CodeItemList;
        }


        public static List<Debtor> DebtorData = null;

        public static List<Debtor> GetDebtors()
        {
            if (DebtorData == null)
            {
                DebtorData = new List<Debtor>();
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Emkay Entertainments",
                                       NewNRIC  = "770104-11-1011",
                                       OldNRIC  = "A22334455",
                                       AcNo = "A11111",
                                       CardNo = "101",
                                       OSAmount = 1000,
                                       OweTo = "CIMB",
                                       Status = 1,
                                       AssignTo = "Azri",
                                       SalesDate = new DateTime(1970, 4, 16),
                                       MaturityDate = new DateTime(1980, 4, 16),
                                       BatchNumber="11111111111111",
                                       AssignDate  = DateTime.MinValue ,
                                       
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "The Empire",
                                       NewNRIC = "710104-11-2222",
                                       OldNRIC = "A331121212",
                                       AcNo = "A222",
                                       CardNo = "102",
                                       OSAmount = 2000,
                                       OweTo = "RHB",
                                       Status = 2,
                                       AssignTo = "Azra"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Asadul Ltd",
                                       NewNRIC = "710104-11-2323",
                                       OldNRIC = "A22321212",
                                       AcNo = "A333",
                                       CardNo = "103",
                                       OSAmount = 3000,
                                       OweTo = "RHB",
                                       Status = 3,
                                       AssignTo = "Adira"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Gargamel ltd",
                                       NewNRIC = "661232-11-3434",
                                       OldNRIC = "A34232332",
                                       AcNo = "A333",
                                       CardNo = "104",
                                       OSAmount = 10000,
                                       OweTo = "Singer",
                                       Status = 4,
                                       AssignTo = "Aqila"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Ashley Mark Publishing Company",
                                       NewNRIC = "334455-11-2211",
                                       OldNRIC = "A1234567",
                                       AcNo = "A333",
                                       CardNo = "105",
                                       OSAmount = 4000,
                                       OweTo = "Mcccis",
                                       Status = 4,
                                       AssignTo = "Azri"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Adira",
                                       NewNRIC = "445566-11-3789",
                                       OldNRIC = "A5323456",
                                       AcNo = "A333",
                                       CardNo = "1066",
                                       OSAmount = 1000,
                                       OweTo = "RHB",
                                       Status = 4,
                                       AssignTo = "Aqila"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Aqila",
                                       AcNo = "A333",
                                       CardNo = "1077",
                                       OSAmount = 2000,
                                       OweTo = "RHB",
                                       Status = 4,
                                       AssignTo = "Adira"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Aufa",
                                       AcNo = "A333",
                                       CardNo = "1088",
                                       OSAmount = 3000,
                                       OweTo = "Court",
                                       Status = 5,
                                       AssignTo = "Aufa"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Nani",
                                       AcNo = "A333",
                                       CardNo = "1099",
                                       OSAmount = 10000,
                                       OweTo = "RHB",
                                       Status = 5,
                                       AssignTo = "Aufa"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Rodin",
                                       AcNo = "A333",
                                       CardNo = "1010",
                                       OSAmount = 4000,
                                       OweTo = "RHB",
                                       Status = 5,
                                       AssignTo = "Azri"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Razali",
                                       AcNo = "A333",
                                       CardNo = "1066",
                                       OSAmount = 1000,
                                       OweTo = "RHB",
                                       Status = 5,
                                       AssignTo = "Azri"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Ton",
                                       AcNo = "A333",
                                       CardNo = "1077",
                                       OSAmount = 2000,
                                       OweTo = "RHB",
                                       Status = 5,
                                       AssignTo = "Azri"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Jebat",
                                       AcNo = "A333",
                                       CardNo = "1088",
                                       OSAmount = 3000,
                                       OweTo = "RHB",
                                       Status = 3,
                                       AssignTo = "Azri"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Demak",
                                       AcNo = "A333",
                                       CardNo = "1099",
                                       OSAmount = 10000,
                                       OweTo = "RHB",
                                       Status = 3,
                                       AssignTo = "Azri"
                                   });
                DebtorData.Add(new Debtor
                                   {
                                       Name = "Putri",
                                       AcNo = "A333",
                                       CardNo = "1010",
                                       OSAmount = 4000,
                                       OweTo = "CIMB",
                                       Status = 2,
                                       AssignTo = "Azri"
                                   });
            }
          
            return DebtorData;
        }
    }
}