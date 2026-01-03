namespace MOM_Project.Models
{
    public class StaffModel
    {

        int StaffID { get; set; }
        int DepartmentID {  get; set; }
        string StaffName { get; set;  }

        string MobileNo { get; set; }

        string EmailAddress { get; set; }
        string? Remarks { get; set; }
        DateTime Created {  get; set; }

        DateTime Modified { get; set;  }
    }
}
