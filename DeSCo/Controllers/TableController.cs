
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using DeSCo.Models;

using System.IO;



namespace DeSCo.Controllers
{
    public class TableController : Controller
    {

        // GET: /Debtor/
        private CreditorDBContext db = new CreditorDBContext();

        private static List<Debtor> _DebtorList;

        /// <summary>
        /// Action that handles initiall request and returns empty view
        /// </summary>
        /// <returns>Home/Index view</returns>
        public ActionResult Index()
        {
                return View();
        }

        //
        // GET: /Creditor/Edit/5

        public ActionResult Edit(string id)
        {
            return View(_DebtorList.FirstOrDefault(c => c.Id == Convert.ToInt32(id)));
        }


        

        public void Export(List<Debtor> list)
        {
            var sw = new StringWriter();

            //First line for column names
            sw.WriteLine("\"Name\",\"CardNo\",\"OS Amount\",\"Status\"");

            foreach (Debtor item in list)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\"",
                                           item.Name ,
                                           item.CardNo,
                                           item.OSAmount,
                                           item.Status));
            }

            Response.AddHeader("Content-Disposition", "attachment; filename=test.csv");
            Response.ContentType = "text/csv";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.Write(sw);
            Response.End();
        }

    }

    //end namespace
}

