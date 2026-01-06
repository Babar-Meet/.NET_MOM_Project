namespace MOM_Project.Models
{
    public class MeetingsModel
    {
        public int MeetingID { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MeetingVenue { get; set; }  
        public string MeetingType { get; set; }   
        public string Department { get; set; }    
        public string? MeetingDescription { get; set; }
        public string? DocumentPath { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool? IsCancelled { get; set; }
        public DateTime? CancellationDateTime { get; set; }  
        public string? CancellationReason { get; set; }
    }
}