using System.Collections.Generic;
using System.Web.Mvc;
using DeSCo.Models;



namespace DeSCo.ViewModel
{
    public class CodeItemViewModel
    {
        public List<string> Status { get; set; }
        public MultiSelectList StatusList { get; private set; }

        public CodeItemViewModel()
        {
            this.StatusList = GetStatus(null);
        }

         public MultiSelectList GetStatus(string[] selectedValues) {
            var stats = new List<Status>()
                {
                    new Status() { Id = 1, Description= "New" },
                    new Status() { Id = 2, Description= "PTP" },
                    new Status() { Id = 3, Description= "CP" },
                    new Status() { Id = 4, Description= "WIP" },
                    new Status() { Id = 5, Description= "ABT" },
                    new Status() { Id = 6, Description= "SFV" },
                    new Status() { Id = 7, Description= "TPS" },
               };

            return new MultiSelectList(stats, "Id", "Description", selectedValues);
        }

    }
}