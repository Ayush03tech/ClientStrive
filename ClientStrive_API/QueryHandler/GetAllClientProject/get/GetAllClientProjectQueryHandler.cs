using System;
using ClientStrive_API.Data;
using ClientStrive_API.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClientStrive_API.QueryHandler.GetAllClientProject;

public class GetAllClientProjectQueryHandler : IRequestHandler<GetAllClientProjectQuery, IEnumerable<ClientProjectSpecific>>
{
    private readonly ApplicationDbContext _context;

    public GetAllClientProjectQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientProjectSpecific>> Handle(GetAllClientProjectQuery request, CancellationToken cancellationToken)
    {
        var clientProjects = await _context.ClientProjects
            .Include(cp => cp.Client)
            .Include(cp => cp.LeadByEmployee)
            .Select(cp => new ClientProjectSpecific{
                EmpName = cp.LeadByEmployee.empName,
                EmpId = cp.LeadByEmployee.empId,
                EmpCode = cp.LeadByEmployee.empCode,
                EmpEmailId = cp.LeadByEmployee.empEmailId,
                EmpDesignation = cp.LeadByEmployee.empDesignation,
                ProjectName = cp.ProjectName,
                StartDate = cp.StartDate,
                ExpectedEndDate = cp.ExpectedEndDate,
                ClientName = cp.Client.companyName,
                ClientProjectId = cp.ClientProjectId
            })// Include the related Client entity
            .ToListAsync(cancellationToken);
        return clientProjects;
    }
}

