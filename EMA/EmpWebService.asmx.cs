using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EMA.Business.Factory.ViewModels;
using EMA.Business.Factory.Repository;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace EMA
{
    /// <summary>
    /// Summary description for EmpWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmpWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public EmployeeModel GetEmployee(int EmpId)
        {
            EmployeeModel model = new EmployeeModel();
            EmployeeRepository repository = new EmployeeRepository();
            model = repository.GetEmployeeDetails(EmpId);
            return model;
        }
        [WebMethod]
        public void GetEmployeeJson(int EmployeeId)
        {
            EmployeeModel model = new EmployeeModel();
            EmployeeRepository repository = new EmployeeRepository();
            model = repository.GetEmployeeDetails(EmployeeId);
            JavaScriptSerializer js = new JavaScriptSerializer();
           Context.Response.Write(js.Serialize(model));
            //return model;
        }
        [WebMethod]
        public int ADD(int a, int b)
        {
            return a + b;
        }
        [WebMethod]
        public List<EmployeeModel> GetallEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees = new EmployeeRepository().GetEmployees();
            return employees;
        }
        [WebMethod]
        public string SaveEmployee(EmployeeModel model)
        {
            string Result = new EmployeeRepository().AddEditEmployee(model);
            return Result;
        }
        [WebMethod]
        public bool CheckEmpCode(string EmpCode)
        {
            bool Isexists = new EmployeeRepository().CheckEmployeeCode(EmpCode);
            //string Result = Isexists == true ? EmpCode + " already in use" : EmpCode + " is available";
            return Isexists;
        }
        [WebMethod]
        public EmployeeSuggestionModel CheckAvailableUserName(string EmpCode)
        {
            EmployeeSuggestionModel model = new EmployeeSuggestionModel();
            model = new EmployeeRepository().GetAvaliableEmpCode(EmpCode);
            return model;
        }
        [WebMethod]
        public List<CandidateModel> GetCandidates(int PageNumber, int PageSize)
        {
            List<CandidateModel> lst = new List<CandidateModel>();
            lst = new EmployeeRepository().GetCandidate(PageNumber, PageSize);
            return lst;
        }
        [WebMethod]
        public List<string> CandidateAutoComplete(string term)
        {
            List<string> lst = new CandidateRepository().GetCandidate(term);
            return lst;
        }
        [WebMethod]
        public List<CountryModel> GetCountryList()
        {
            List<CountryModel> lst = new CountryRepository().GetCountryList();
            return lst;
        }
        [WebMethod]
        public HelpTextModel GetTooltip(string helpkey)
        {
            HelpTextModel model = new HelpTextModel();
            model = new HelpRepository().GetHelp(helpkey);
            return model;
        }
        [WebMethod]
        public string SaveCountry(CountryModel model)
        {
            CountryRepository repository = new CountryRepository();
            string Result = repository.InsertUpdateCountry(model);
            return Result;
        }
    }
}
