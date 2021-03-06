using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMA.Business.Factory.ViewModels
{
    public class CandidateModel
    {
        public int CandidateId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CandidateLoginId { get; set; }
        public string ProfilePhoto { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string AdditionalInfo { get; set; }
        public string FatherName { get; set; }
        public string MaritalStatus { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public Nullable<int> TotalExperience { get; set; }
        public Nullable<int> ReleventExperience { get; set; }
        public string CurrentOrganization { get; set; }
        public Nullable<decimal> ExpectedCtc { get; set; }
        public Nullable<decimal> CurrentCtc { get; set; }
        public Nullable<int> NoticePeriod { get; set; }
        public Nullable<int> ExpectedJoining { get; set; }
        public Nullable<int> SourceId { get; set; }
        public string SourceValue { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> FeedbackId { get; set; }
        public string FileName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> ProfilePicUpdateOn { get; set; }
        public Nullable<int> ProfilePicUpdateBy { get; set; }
    }
}
