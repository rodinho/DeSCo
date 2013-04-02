using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using DeSCo.Models;

//namespace DataTableEditable.Controllers

namespace DeSCo.Controllers
{
    public class CompanyController : MenuController 
    {
        private static List<Debtor> _debtorList;


        public ActionResult Tab(Tab tabClass)
        {
            string content = tabClass.ContentOne;
            return View();
        }

        public ActionResult Index()
        {
            IList<Debtor> debtors = DataRepository.GetDebtors();

          

            return View(debtors);
        }

        public ActionResult Ajax()
        {
            return View();
        }

        public ActionResult Customization()
        {
            IList<Debtor> debtors = DataRepository.GetDebtors();

            foreach (var debtor in debtors)
            {
                debtor.CallCollection = new List<CallHistory>();
                debtor.VisitCollection = new List<SiteVisit>();
                debtor.PaymentCollection  = new List<PaymentMaster>();
            }

            ViewBag.NewStatus = String.Format("{0:#,###}", DataRepository.GetTotalByStatus(1));
            ViewBag.PTPStatus = String.Format("{0:#,###}", DataRepository.GetTotalByStatus(2));
            ViewBag.CPStatus = String.Format("{0:#,###}", DataRepository.GetTotalByStatus(3));
            ViewBag.WIPStatus = String.Format("{0:#,###}", DataRepository.GetTotalByStatus(4));
            ViewBag.ABTStatus = String.Format("{0:#,###}", DataRepository.GetTotalByStatus(5));
            ViewBag.SFVStatus = String.Format("{0:#,###}", DataRepository.GetTotalByStatus(6));
            ViewBag.TPSStatus = String.Format("{0:#,###}", DataRepository.GetTotalByStatus(7));
            ViewBag.Total = String.Format("{0:#,###}", DataRepository.GetTotalByStatus(0)); 
           

            return View(debtors);
        }

        public ActionResult Debtor()
        {
            IList<Debtor> debtors = DataRepository.GetDebtors();
            return View(debtors);
        }

        //
        // GET: /Creditor/Edit/5

        public ActionResult Edit(string id)
        {
            if (_debtorList == null)
            {
                _debtorList = (List<Debtor>)DataRepository.GetDebtors();
            }

            if (id == null)
            {

                var debtor = new Debtor { CallCollection = new List<CallHistory>(), VisitCollection = new List<SiteVisit>(), PaymentCollection = new List<PaymentMaster>() };

                return View(debtor);
            }
            var debt = _debtorList.FirstOrDefault(c => c.Id == Convert.ToInt32(id));
            
            debt.CallCollection.Add(new CallHistory{AccNo="Ac122",Collector ="Adira",FollowUpDate=DateTime.Now.AddDays(3) ,Id=id,LastStatus="PTS",PtpAmount =20000,Remarks="Refuse to pay",RmksDate =DateTime.Now });
            debt.CallCollection.Add(new CallHistory { AccNo = "Ac122", Collector = "Najib", FollowUpDate = DateTime.Now.AddDays(5), Id = id, LastStatus = "CP", PtpAmount = 20000, Remarks = "Refuse to pay", RmksDate = DateTime.Now });

            debt.VisitCollection.Add(new SiteVisit { AccNo = "Ac122",CollectorName  = "Adira",Id =id,Location="Mantin",Remarks="Very poor",RemarksDate=DateTime.Now.AddDays(-5) ,VisitDate=DateTime.Now } );
            debt.VisitCollection.Add(new SiteVisit { AccNo = "Ac133", CollectorName = "Azmi", Id = id, Location = "Pilah", Remarks = "Very arrogant", RemarksDate = DateTime.Now.AddDays(-10), VisitDate = DateTime.Now });

            debt.PaymentCollection.Add(new PaymentMaster { AccNo = "Ac122", Balance = 40000, PaidAmt = 1000, PaidDate = DateTime.Now.AddDays(-5), BatchNo = "MTSB1", ColectorComm = 0, Comm = 0, Id = Convert.ToInt32(id), OweTo = "BIMB", Remarks = "RECEIPT NO: R140100099360" });
            debt.PaymentCollection.Add(new PaymentMaster { AccNo = "Ac122", Balance = 30000, PaidAmt = 1000, PaidDate = DateTime.Now, BatchNo = "MTSB1", ColectorComm = 0, Comm = 0, Id = Convert.ToInt32(id), OweTo = "BIMB", Remarks = "RECEIPT NO: R140100099361" });

            //set valus dropdown status
            ViewBag.CodeItemID = new SelectList(DataRepository.GetCodeItems(), "Id", "Description", debt.Status);
            //set values count status
           
            
            //return View(_debtorList.FirstOrDefault(c => c.Id == Convert.ToInt32(id)));
            return View(debt);

        }

        /// <summary>
        /// Excel-Export
        /// </summary>
        public ActionResult ExportExcel()
        {
            // DataTable dt = -- > get your data
            DataTable dt;
            dt = new DataTable();
            var actionResult = new ExcelFileResult(dt) { FileDownloadName = "yourFileName.xls" };
            return actionResult;
        }

        public ActionResult Export(DataTable dt)
        {
            var sb = new StringBuilder();
            sb.Append("<table border='" + "2px" + "'b>");
            //write column headings
            sb.Append("<tr>");
            foreach (System.Data.DataColumn dc in dt.Columns)
            {
                sb.Append("<td><b><font face=Arial size=2>" + dc.ColumnName + "</font></b></td>");
            }
            sb.Append("</tr>");

            //write table data
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<td><font face=Arial size=" + "14px" + ">" + dr[dc].ToString() + "</font></td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            this.Response.AddHeader("Content-Disposition", "Employees.xls");
            this.Response.ContentType = "application/vnd.ms-excel";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            return File(buffer, "application/vnd.ms-excel");
        }

        //
        // POST: /Debtor/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Debtor crModel)
        {
            try
            {
                if (id == null)
                {
                    // TODO: Add logic here
                    _debtorList.Add(crModel);
                }
                else
                {
                    List<Debtor> list = _debtorList.Where(c => c.Id == Convert.ToInt32(id)).ToList();
                    // TODO: Add update logic here
                }

                return RedirectToAction("Customization");
            }
            catch
            {
                return View(); 
            }
        }

        public static SelectList CodeItemList { get; set; }

        public ActionResult Create()
        {

           ViewBag.CodeItemID = new SelectList(DataRepository.GetCodeItems() , "Id", "Description");

           var debtor = new Debtor { CallCollection = new List<CallHistory>(), VisitCollection = new List<SiteVisit>() };
            debtor.SalesDate = DateTime.MinValue;

            return View(debtor);

        }

        [HttpPost]
        public ActionResult Create(Debtor debtObj)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // do something.
                    Response.Write("Debtor with the same account '" + debtObj.AcNo + "' already exists");
                    Response.StatusCode = 404;
                    Response.End();
                }

                if (_debtorList == null)
                {
                    _debtorList = (List<Debtor>)DataRepository.GetDebtors();
                }
                if (debtObj.AcNo != null)
                {
                    if (_debtorList.Any(c => c.AcNo.ToLower().Equals(debtObj.AcNo.ToLower())))
                    {
                        //Response.Write("Debtor with the same account '" + debtObj.AcNo + "' already exists");
                        //Response.StatusCode = 404;
                        //Response.End();
                        ShowErrorView("Debtor with the same account '" + debtObj.AcNo + "' already exists");
                        ViewBag.messageString = "Debtor with the same account '" + debtObj.AcNo + "' already exists";
                        return View(debtObj);
                    }
                    else
                    {
                        _debtorList.Add(debtObj);
                        //TODO invoke save action.

                    }
                }

                return View(debtObj);
                //return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }


        #region "CRUD operations"

        /// <summary>
        /// Method called but plugin when a row is deleted
        /// </summary>
        /// <param name="id">Id of the row</param>
        /// <returns>"ok" if delete is successfully performed - any other value will be considered as an error mesage on the client-side</returns>
        public string DeleteData(int id)
        {
            try
            {
                Debtor debtor = DataRepository.GetDebtors().FirstOrDefault(c => c.Id == id);
                if (debtor == null)
                    return "Debtor cannot be found";
                DataRepository.GetDebtors().Remove(debtor);
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditData(int id)
        {
            try
            {
                Debtor debtor = DataRepository.GetDebtors().FirstOrDefault(c => c.Id == id);
                if (debtor == null)
                    return "Debtor cannot be found";
                // DataRepository.GetDebtors().Remove(debtor);
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

       

        public ViewResult CategoryChosen(string statusType)
        {
            ViewBag.messageString = statusType;
            return View("Create");
        }


        public ViewResult ShowErrorView(string errormessage)
        {
            //set the error message to the view from here
            if (errormessage != null) return View(errormessage);
            return null;
        }

     
   
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}



        /// <summary>
        /// Action that updates data
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <param name="value">Value that shoudl be set</param>
        /// <param name="rowId">Id of the row</param>
        /// <param name="columnPosition">Position of the column(hidden columns are not counted)</param>
        /// <param name="columnId">Position of the column(hidden columns are counted)</param>
        /// <param name="columnName">Name of the column</param>
        /// <returns>value if update suceed - any other value will be considered as an error message on the client-side</returns>
        public string UpdateData(int id, string value, int? rowId, int? columnPosition, int? columnId, string columnName)
        {
            IList<Debtor> debtors = DataRepository.GetDebtors();

            if (columnPosition == 0 && debtors.Any(c => c.Name.ToLower().Equals(value.ToLower())))
                return "Debtor with a name '" + value + "' already exists";
            Debtor debtor = debtors.FirstOrDefault(c => c.Id == id);
            if (debtor == null)
            {
                return "Debtor with an id = " + id + " does not exists";
            }
            switch (columnPosition)
            {
                case 0:
                    debtor.Name = value;
                    break;
                case 1:
                    debtor.CardNo = value;
                    break;
                case 2:
                    debtor.OSAmount = Convert.ToDecimal(value);
                    break;
                case 3:
                    debtor.NewNRIC = value;
                    break;
                case 4:
                    //debtor.Status = value;
                    break;
                case 5:
                    debtor.AssignTo = value;
                    break;
                default:
                    break;
            }
            return value;
        }


        public int AddData(string name, string cardno, decimal osamount, string status, string assignto, int? country)
        {
            IList<Debtor> debtors = DataRepository.GetDebtors();
            if (debtors.Any(c => c.Name.ToLower().Equals(name.ToLower())))
            {
                Response.Write("Debtor with the name '" + name + "' already exists");
                Response.StatusCode = 404;
                Response.End();
                return -1;
            }

            var debtor = new Debtor();
            debtor.Name = name;
            debtor.CardNo = cardno;
            debtor.OSAmount = osamount;
            debtor.Status = Convert.ToInt32(status);
            debtor.AssignTo = assignto;
            debtors.Add(debtor);
            return debtor.Id;
        }

        #endregion

    }




    /// <summary>
    /// Class that encapsulates most common parameters sent by DataTables plugin
    /// </summary>
    public class JQueryDataTableParamModel
    {
        /// <summary>
        /// Request sequence number sent by DataTable, same value must be returned in response
        /// </summary>       
        public string sEcho { get; set; }

        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string sSearch { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int iDisplayLength { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int iDisplayStart { get; set; }

        /// <summary>
        /// Number of columns in table
        /// </summary>
        public int iColumns { get; set; }

        /// <summary>
        /// Number of columns that are used in sorting
        /// </summary>
        public int iSortingCols { get; set; }

        /// <summary>
        /// Comma separated list of column names
        /// </summary>
        public string sColumns { get; set; }
    }



}