using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using EMA.Business.Factory.ViewModels;
using EMA.Business.Factory.Repository;

namespace EMA.WebForm
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static EmployeeModel GetEmployyeById(int Id)
        {
            EmployeeModel model = new EmployeeModel();
            EmployeeRepository repository = new EmployeeRepository();
            model = repository.GetEmployeeDetails(Id);
            return model;
        }
    }
}