using EMA.Business.Factory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMA.Business.Factory.Repository;

namespace EMA.Controllers
{
    public class JqueryController : Controller
    {
        // GET: Jquery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult DynamicMenu()
        {
            List<MainMenuModel> lst = new List<MainMenuModel>();
            lst = new MenuRepository().GetList();
            return View(lst);
        }
        [HttpGet]
        public ActionResult SelectMenu()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DynamicSelectMenu()
        {
            List<CountryModel> countries = new List<CountryModel>();
            countries = new CountryRepository().GetCountryList();
            return View(countries);
        }
        [HttpGet]
        public ActionResult Dialog()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SaveJqueryDialogTodatabase()
        {
            return View();
        }
        [HttpGet]
        public ActionResult _country()
        {
            return PartialView("_country");
        }
        [HttpGet]
        public ActionResult _Countries()
        {
            List<CountryModel> countries = new List<CountryModel>();
            countries = new CountryRepository().GetList();
            return PartialView("_Countries", countries);
        }
        [HttpGet]
        public ActionResult ButtonWidget()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DraggableWidget()
        {
            return View();
        }




    }
}