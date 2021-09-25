using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMA.Business.Factory.Repository;
using EMA.Business.Factory.ViewModels;

namespace EMA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult AjaxUsingWebService()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HandlingJsonDataFromWebService()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HandlingJsonArrayDataFromWebService()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SaveDataWebServicesAjax()
        {
            EmployeeModel model = new EmployeeModel();
            EmployeeRepository repository = new EmployeeRepository();
            model = repository.GetEmployee();
            return View(model);
        }
        [HttpGet] 
        public ActionResult SuggestAvailableUserNames()
        {
            EmployeeModel model = new EmployeeModel();
            EmployeeRepository repository = new EmployeeRepository();
            model = repository.GetEmployee();
            return View(model);
        }
        [HttpGet]
        public ActionResult CallAjaxUsingWCFService()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LoadDataOnPageScrollUsingJquery()
        {
            return View();
        }

        [HttpGet] 
        public ActionResult PagingUsingJquery()
        {
            return View();
        }
        [HttpGet]
        public ActionResult WindowHeightVSdocumentheight()
        {
            return View();
        }
        [HttpGet]
        public ActionResult JqueryAutoComplete()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetCandidates(string term)
        {
            List<string> lst = new CandidateRepository().GetCandidate(term);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult JqueryAccordion()
        {
            return View();
        }
        [HttpGet]
        public ActionResult JqueryTabs()
        {
            List<CountryModel> lst = new CountryRepository().GetCountryList();
            return View(lst);
        }
        [HttpGet]
        public ActionResult JqueryDatePicker()
        {
            return View();
        }
        [HttpGet]
        public ActionResult JquerySlider()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MultipleSliders()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RangeSlider()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ToolTip()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ToolTipUsingDatabase()
        {
            return View();
        }
        [HttpGet]
        public ActionResult JqueryProgressBar()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MultipleFileUploadUsingProgressBar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MainMenuModel model)
        {
            return View();
        }


    }
}