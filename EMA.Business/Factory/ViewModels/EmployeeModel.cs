using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EMA.Business.Factory.ViewModels
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            this.DepartmentList = new List<DepartmentModel>();
            this.DesignationList = new List<DesignationModel>();
            this.ManagerList = new List<ReportingManagerModel>();
        }
        public int EmployeeId { get; set; }
        public string EmpCode { get; set; }
        public string EmpEmail { get; set; }
        public string EmpName { get; set; }
        public string DepartmentName { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public string ManagerName { get; set; }
        public string DesignationName { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public Nullable<int> ReportingEmpId { get; set; }
        public List<DepartmentModel> DepartmentList { get; set; }
        public List<DesignationModel> DesignationList { get; set; }
        public List<ReportingManagerModel> ManagerList { get; set; }
    }
}
