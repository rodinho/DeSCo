using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DeSCo.Models;

namespace DeSCo.Controllers
{
    public class CreditorController : Controller
    {
        //
        // GET: /Creditor/

        private static List<Creditor> _CreditorList;
        private CreditorDBContext db = new CreditorDBContext();

        public static List<Creditor> CreditorList
        {
            get
            {
                if (_CreditorList == null)
                {
                    _CreditorList = new List<Creditor>();
                    _CreditorList.Add(new Creditor
                                          {
                                              CardNo = "001",
                                              FullName = "Dino",
                                              OSAmount = "10000",
                                              AssignTo = "Ani"
                                          });
                    _CreditorList.Add(new Creditor
                                          {
                                              CardNo = "002",
                                              FullName = "Dino",
                                              NewNRIC = "20000",
                                              AssignTo = "Azri"
                                          });
                }
                return _CreditorList;
            }
            set { _CreditorList = value; }
        }

        //
        // GET: /Creditor/

        public ActionResult Index()
        {
            return View(CreditorList);
            // return View(db.Movies.ToList());
        }

        public ActionResult IndexM()
        {
            return View();
            // return View(db.Movies.ToList());
        }

        //
        // GET: /Creditor/Details/5

        public ActionResult Details(string id)
        {
            return View(CreditorList.FirstOrDefault(c => c.NewNRIC == id));
        }

        //
        // GET: /Creditor/Create

        [HttpPost]
        public ActionResult Create(Creditor crModel)
        {
            try
            {
                _CreditorList.Add(crModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Creditor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Creditor/Edit/5

        public ActionResult Edit(string id)
        {
            return View(_CreditorList.Where(c => c.NewNRIC == id).FirstOrDefault());
        }

        //
        // POST: /Creditor/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, Creditor crModel)
        {
            try

            {
                _CreditorList.Where(c => c.NewNRIC == id).ToList().ForEach(d => { d = crModel; });
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Creditor/Delete/5

        public ActionResult Delete(string id)
        {
            try
            {
                _CreditorList.RemoveAll(c => c.NewNRIC == id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Creditor/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public JsonResult DataProviderAction(string sEcho, int iDisplayStart, int iDisplayLength)
        //{
        //    var nameFilter = Convert.ToString(Request["sSearch_0"]);
        //    var cardnoFilter = Convert.ToString(Request["sSearch_1"]);
        //    var OSAmountFilter = Convert.ToString(Request["sSearch_2"]);
        //    var statusFilter = Convert.ToString(Request["sSearch_3"]);

        //              var filteredCreditor = DataRepository.GetCreditors()
        //                           .Where(c => (nameFilter == "" || c.FullName.ToLower().Contains(nameFilter.ToLower()))
        //                                       &&
        //                                       (cardnoFilter == "" || c.CardNo == cardnoFilter)
        //                                       &&
        //                                       (OSAmountFilter == "" || c.OSAmount == OSAmountFilter)
        //                                        &&
        //                                       (statusFilter == "" || c.Status == statusFilter)
        //                                   );

        //    //Extract only current page
        //    var displayedCreditor = filteredCreditor.Skip(iDisplayStart).Take(iDisplayLength);
        //    var result = from c in displayedCreditor
        //                 select new[] { 
        //                                    c.FullName,
        //                                    c.CardNo,
        //                                    c.OSAmount,
        //                                    c.Status 
        //                                };
        //    return Json(new
        //    {
        //        sEcho = sEcho,
        //        iTotalRecords = DataRepository.GetCreditors().Count(),
        //        iTotalDisplayRecords = filteredCreditor.Count(),
        //        aaData = result
        //    },
        //                JsonRequestBehavior.AllowGet);

        //}
    }
}