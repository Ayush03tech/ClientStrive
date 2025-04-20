using System;

namespace ClientStrive_API.QueryHandler.GetAllClientProject;

public class ClientProjectSpecific
{
    public string? EmpName { get; set; }
    public int EmpId { get; set; }
    public string? EmpCode { get; set; }  
    public string? EmpEmailId { get; set; } 
    public string? EmpDesignation { get; set; } 
    public string? ProjectName { get; set; }  
    public DateTime StartDate { get; set; }
    public DateTime ExpectedEndDate { get; set; }
    public string? ClientName { get; set; }
    public int ClientProjectId { get; set; }
}
