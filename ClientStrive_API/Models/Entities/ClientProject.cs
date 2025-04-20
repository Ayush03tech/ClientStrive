using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClientStrive_API.Models.Entities;

namespace ClientStrive_API.Models.Entities
{
    public class ClientProject
    {
        [Key]
        public int ClientProjectId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? ProjectName { get; set; } = String.Empty;

        public DateTime StartDate { get; set; }

        public DateTime ExpectedEndDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [MaxLength(100)]
        public string? ContactPerson { get; set; }

        [MaxLength(15)]
        public string? ContactPersonContactNo { get; set; }

        [MaxLength(100)]
        public string? ContactPersonEmailId { get; set; }

        public int? TotalEmpWorking { get; set; }

        public decimal? ProjectCost { get; set; }

        public string? ProjectDetails { get; set; }

        // 🔑 Foreign Key to Client
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; } = null!;

        // 🔑 Foreign Key to Employee (Lead)
        public int LeadByEmpId { get; set; }

        [ForeignKey("LeadByEmpId")]
        public Employee LeadByEmployee { get; set; } = null!;
    }
}
