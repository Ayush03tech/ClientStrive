using System;
using ClientStrive_API.Data;
using ClientStrive_API.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClientStrive_API.QueryHandler.GetProject;

public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ClientProjectDto>
{
    private readonly ApplicationDbContext _context;

    public GetProjectQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ClientProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        var Id = request.clientProjectId;
        var clientProject =  await _context.ClientProjects
            .Include(cp => cp.Client)
            .Include(cp => cp.LeadByEmployee)
            .Select(cp => new ClientProjectDto
            {
                ClientProjectId = cp.ClientProjectId,
                ProjectName = cp.ProjectName,
                StartDate = cp.StartDate,
                ExpectedEndDate = cp.ExpectedEndDate,
                CompletedDate = cp.CompletedDate,
                ContactPerson = cp.ContactPerson,
                ContactPersonContactNo = cp.ContactPersonContactNo,
                ContactPersonEmailId = cp.ContactPersonEmailId,
                LeadByEmpId = cp.LeadByEmployee.empId,
                ClientId = cp.Client.clientId ?? 0, 
                TotalEmpWorking = cp.TotalEmpWorking ?? 0,
                ProjectCost = cp.ProjectCost ?? 0,
                ProjectDetails = cp.ProjectDetails,

            })
            .FirstOrDefaultAsync(cp => cp.ClientProjectId == Id, cancellationToken);

        if (clientProject == null)
        {
            throw new InvalidOperationException("Client project not found.");
        }

        return clientProject;  
    }
}
