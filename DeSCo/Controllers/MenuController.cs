using System.Collections.Generic;
using System.Web.Mvc;
using DeSCo.Models;

namespace DeSCo.Controllers
{
    public class MenuController : Controller
    {

        public MenuController()
        {
            ViewBag.Menu = BuildMenu();
        }

        private IList<MenuModel> BuildMenu()
        {
            IList<MenuModel> mmList = new List<MenuModel>(){

                // Parent
                new MenuModel(){ Id = 1, Name = "Home", ParentId = 0, SortOrder = 1} ,
                new MenuModel(){ Id = 2, Name = "Account", ParentId = 0, SortOrder = 1} ,
                new MenuModel(){ Id = 3, Name = "Admin", ParentId = 0, SortOrder = 1} ,

                // Children

                new MenuModel() { Id=21, Name = "Manage Account", ParentId = 2, SortOrder=1 },
                //new MenuModel() { Id=22, Name = "Maintain Code", ParentId = 2, SortOrder=2 },
                //new MenuModel() { Id=23, Name = "Maintain User Role", ParentId = 2, SortOrder=3},

                new MenuModel() { Id=31, Name = "Create User", ParentId = 3, SortOrder=1 },
                new MenuModel() { Id=32, Name = "Maintain Code", ParentId = 3, SortOrder=2 },
                 new MenuModel() { Id=33, Name = "Maintain User Role", ParentId = 3, SortOrder=3 },

                //new MenuModel() { Id=321, Name = "Salary Accounts", ParentId = 32, SortOrder=1 },
                //new MenuModel() { Id=322,Name = "Savings Accounts", ParentId = 32, SortOrder=2 },

            };

            return mmList;
        }
    }
}
