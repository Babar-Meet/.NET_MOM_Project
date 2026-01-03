namespace MOM_Project.Models
{
    public class MeetingsModel
    {
        int MeetingID { get; set; }

        DateTime MeetingDate { get; set; }

        int MeetingVenueID { get; set; }

        int MeetingTypeID { get; set; }

        int DepartmentID { get; set; }

        string? MeetingDescription { get; set; }

        string? DocumentPath { get; set; }

        DateTime Created { get; set; }


        DateTime Modified { get; set; }

        
        bool? IsCancelled { get; set; }

        DateTime CancellationDateTime { get; set;  }

        string CancellationReason { get; set; }
    }

}
