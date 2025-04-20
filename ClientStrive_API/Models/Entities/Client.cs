using System;
using System.ComponentModel.DataAnnotations;

namespace ClientStrive_API.Models.Entities;

public class Client
{
    public string? contactPersonName { get; set; }
    [Key]
    public int? clientId { get; set; }
    public string? companyName { get; set; }
    public string? address { get; set; }
    public string? city { get; set; }
    public string? pincode { get; set; }
    public string? state { get; set; }
    public int? employeeStrength { get; set; }
    public string? gstNo { get; set; }
    public string? contactNo { get; set; }
    public string? regNo { get; set; }
}
