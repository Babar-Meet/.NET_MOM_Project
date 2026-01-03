namespace MOM_Project.Models
{
    public class MeetingMemberModel
    {
        int MeetingMemberID { get; set; }
        int MeetingID { get; set; }
        int StaffID { get; set; }
        bool IsPresent { get; set; }
        string? Remarks { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }


    }
}
