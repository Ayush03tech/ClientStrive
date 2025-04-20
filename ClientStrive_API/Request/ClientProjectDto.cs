using System;

namespace ClientStrive_API.Request;

public class ClientProjectDto
{
        public int ClientProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        
        public string? ContactPerson { get; set; }
        public string? ContactPersonContactNo { get; set; }
        public string? ContactPersonEmailId { get; set; }

        public int LeadByEmpId { get; set; }   // Foreign Key - Employee
        public int ClientId { get; set; }      // Foreign Key - Client

        public int TotalEmpWorking { get; set; }
        public decimal ProjectCost { get; set; }
        public string? ProjectDetails { get; set; }

}
