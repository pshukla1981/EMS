using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Services;
using EMA.Business.Factory.ViewModels;
using EMA.Business.Factory.Repository;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace EMA.WCF
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EmployeeService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }


        // Add more operations here and mark them with [OperationContract]
        [OperationContract]
        public EmployeeModel GetEmployee(int EmpId)
        {
            EmployeeModel model = new EmployeeModel();
            EmployeeRepository repository = new EmployeeRepository();
            model = repository.GetEmployeeDetails(EmpId);
            return model;
        }
    }
}
