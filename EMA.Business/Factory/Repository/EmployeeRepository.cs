using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EMA.Business.Factory.ViewModels;
using EMA.Data;

namespace EMA.Business.Factory.Repository
{
    public class EmployeeRepository
    {
        public EmployeeModel GetEmployeeDetails(int Id)
        {
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (var db = new EMSEntities())
                {
                    var emp = db.sp_GetEmployeeDetail(Id).FirstOrDefault();
                    if (emp != null)
                    {
                        model.EmployeeId = emp.EmployeeId;
                        model.EmpCode = emp.EmpCode;
                        model.EmpEmail = emp.EmpEmail;
                        model.EmpName = emp.EmpName;
                        model.DepartmentName = emp.DepartmentName;
                        model.MobileNumber = emp.MobileNumber;
                        model.JoiningDate = emp.JoiningDate;
                        model.ManagerName = emp.ManagerName;
                        model.DesignationName = emp.DesignationName;
                        
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return model;
        }

        /// <summary>
        /// get the list of employees(reporting manager)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmployeeModel GetEmployee()
        {
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (var db = new EMSEntities())
                {
                    model.DepartmentList = (List<DepartmentModel>)GetDepartmentList();
                    model.DesignationList = (List<DesignationModel>)GetDesignationmentList();
                    model.ManagerList = (List<ReportingManagerModel>)GetReroptingManagerList();
                }
            }
            catch (Exception ex)
            {
            }
            return model;
        }

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> lst = new List<EmployeeModel>();
            try
            {
                using (var db = new EMSEntities())
                {
                    lst = db.sp_GetAllemployees().Select(x => new EmployeeModel
                    {
                        EmployeeId = x.EmployeeId,
                        EmpCode = x.EmpCode,
                        EmpName = x.EmpName,
                        DepartmentName = x.DeptName,
                        DesignationName = x.DesgName,
                        JoiningDate = x.JoiningDate,
                        ManagerName = x.ReportingManager

                    }).ToList();

                }
            }
            catch (Exception ex)
            {
            }
            return lst;
        }
        /// <summary>
        /// get the full list of departments
        /// </summary>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartmentList()
        {
            List<DepartmentModel> lst = new List<DepartmentModel>();
            try
            {
                using (var db = new EMSEntities())
                {
                    lst = db.tblDepartments.Select(x => new DepartmentModel
                    {
                        DepartmenId = x.DepartmentId,
                        DepartmentName = x.DeptName
                    }).OrderBy(x => x.DepartmentName).ToList();

                }
            }
            catch (Exception ex)
            {
            }
            return lst;
        }
        /// <summary>
        /// get the full list of designations
        /// </summary>
        /// <returns></returns>
        public List<DesignationModel> GetDesignationmentList()
        {
            List<DesignationModel> lst = new List<DesignationModel>();
            try
            {
                using (var db = new EMSEntities())
                {
                    lst = db.tblDesignations.Select(x => new DesignationModel
                    {
                        DesignationId = x.DesignationId,
                        DesignationName = x.DesgName
                    }).OrderBy(x => x.DesignationName).ToList();

                }
            }
            catch (Exception ex)
            {
            }
            return lst;
        }

        /// <summary>
        /// get the full list of Reporting Manager
        /// </summary>
        /// <returns></returns>
        public List<ReportingManagerModel> GetReroptingManagerList()
        {
            List<ReportingManagerModel> lst = new List<ReportingManagerModel>();
            try
            {
                using (var db = new EMSEntities())
                {
                    lst = db.tblEmployees.Select(x => new ReportingManagerModel
                    {
                        Id = x.EmployeeId,
                        Name = x.EmpName
                    }).OrderBy(x => x.Name).ToList();

                }
            }
            catch (Exception ex)
            {
            }
            return lst;
        }
        /// <summary>
        /// add /edit employee row
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddEditEmployee(EmployeeModel model)
        {
            string Result = string.Empty;
            try
            {
                using (var db = new EMSEntities())
                {
                    //int i = 15;
                    //int j = i / 0;
                    tblEmployee obj = new tblEmployee();
                    if(model.EmployeeId == 0)
                    {
                        //add 
                        obj.EmpCode = model.EmpCode;
                        obj.EmpName = model.EmpName;
                        obj.DepartmentId = model.DepartmentId;
                        obj.DesignationId = model.DesignationId;
                        obj.ReportingEmpId = model.ReportingEmpId;
                        obj.MobileNumber = model.MobileNumber;
                        obj.EmpEmail = model.EmpEmail;
                        obj.JoiningDate = model.JoiningDate;
                        obj.IsAdmin = false;
                        db.tblEmployees.Add(obj);
                        db.SaveChanges();
                        Result = "employee added successfully";
                    }
                    else
                    {
                        obj = db.tblEmployees.Where(x => x.EmployeeId == model.EmployeeId).FirstOrDefault();
                        if(obj != null)
                        {
                            //update
                            obj.EmpCode = model.EmpCode;
                            obj.EmpName = model.EmpName;
                            obj.DepartmentId = model.DepartmentId;
                            obj.DesignationId = model.DesignationId;
                            obj.ReportingEmpId = model.ReportingEmpId;
                            obj.MobileNumber = model.MobileNumber;
                            obj.EmpEmail = model.EmpEmail;
                            obj.JoiningDate = model.JoiningDate;
                            obj.IsAdmin = false;
                            db.SaveChanges();
                            Result = "employee updated successfully";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }
        /// <summary>
        /// check for the duplicate employee code
        /// </summary>
        /// <param name="EmpCode"></param>
        /// <returns></returns>
        public bool CheckEmployeeCode(string EmpCode)
        {
            bool IsExists = false;
            try
            {
                using (var db = new EMSEntities())
                {
                    var empcode = db.tblEmployees.Where(a => a.EmpCode == EmpCode).Count();
                    if(empcode > 0)
                    {
                        IsExists = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return IsExists;
        }
        public EmployeeSuggestionModel GetAvaliableEmpCode(string EmpCode)
        {
            EmployeeSuggestionModel model = new EmployeeSuggestionModel();
            model.IsExists = false;
            try
            {
                while(CheckEmployeeCode(EmpCode))
                {
                    Random random = new Random();
                    int randomnumber = random.Next(1, 100);
                    EmpCode = EmpCode + randomnumber.ToString();
                    model.IsExists = true;
                }
                //model.IsExists = CheckEmployeeCode(EmpCode);
                model.AvaliableUserName = EmpCode;

            }
            catch (Exception ex)
            {
            }
            return model;
        }
        /// <summary>
        /// get list of candidates
        /// </summary>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public List<CandidateModel> GetCandidate(int PageNumber,int PageSize)
        {
            List<CandidateModel> lst = new List<CandidateModel>();
            try
            {
                using (var db = new EMSEntities())
                {
                    lst = db.sp_GetEmployees(PageNumber, PageSize).Select(x => new CandidateModel
                    {
                        CandidateId = x.CandidateId,
                        Title = x.Title,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Dob = x.Dob,
                        Email = x.Email,
                        ContactNo1 = x.ContactNo1,
                        PermanentAddress = x.PermanentAddress
                    }).ToList();

                }
            }
            catch (Exception ex)
            {
            }
            return lst;
        }


    }
}
