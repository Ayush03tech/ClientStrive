using System;
using System.ComponentModel.DataAnnotations;

namespace ClientStrive_API.Models.Entities;

public class Employee
{
    public string? empName { get; set; }
    [Key]
    public int  empId { get; set; }
    public string? empCode { get; set; }
    public string? empEmailId { get; set; }
    public string? empDesignation { get; set; }
    public string? role { get; set; }
}
