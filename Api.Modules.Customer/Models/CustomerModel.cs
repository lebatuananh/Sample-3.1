using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Modules.Customer.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int? Status { get; set; }
        public int? Type { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int RegionId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public string AssignTo { get; set; }
        public DateTime? CareDate { get; set; }
        public int? ICareDate { get; set; }
        public DateTime? StartCareDate { get; set; }
        public int CompanyId { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Address { get; set; }
        public int? PostingType { get; set; }
        public string PostingAssistant { get; set; }
        public int? PostingAssistanceStatus { get; set; }
        public bool IsBlackList { get; set; }
        public int? PostingNumber { get; set; }
        public string LastNote { get; set; }
        public DateTime? LastNoteTime { get; set; }
        public int? CompanyType { get; set; }
        public string AssignToLa { get; set; }

        public List<PhoneContactModel> PhoneContacts { get; set; }
        public List<NoteModel> Notes { get; set; }
    }
}
