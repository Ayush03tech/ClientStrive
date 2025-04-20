using System;
using ClientStrive_API.Data;
using ClientStrive_API.Models.Entities;
using ClientStrive_API.Request;
using MediatR;
using MediatR.Wrappers;

namespace ClientStrive_API.QueryHandler.GetAllClientProject.post;

public class ClientClientProjectCommandHandler : IRequestHandler<ClientProjectCommand, ClientProjectDto>
{
    private readonly ApplicationDbContext _context;

    public ClientClientProjectCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ClientProjectDto> Handle(ClientProjectCommand request, CancellationToken cancellationToken)
    {
        var dtos = request.ClientProjectDto;
        var clientProject = await _context.ClientProjects.FindAsync(dtos?.ClientProjectId, cancellationToken);
        if(clientProject !=null){
            clientProject.ProjectName = dtos?.ProjectName;
            clientProject.StartDate = dtos?.StartDate ?? DateTime.MinValue;
            clientProject.ExpectedEndDate = dtos?.ExpectedEndDate ?? DateTime.MinValue;
            clientProject.ContactPerson  = dtos?.ContactPerson;
            clientProject.ContactPersonContactNo = dtos?.ContactPersonContactNo;
            clientProject.ContactPersonEmailId = dtos?.ContactPersonEmailId;
            clientProject.TotalEmpWorking = dtos?.TotalEmpWorking ?? 0;
            clientProject.ProjectCost = dtos?.ProjectCost ?? 0;
            clientProject.ProjectDetails = dtos?.ProjectDetails;
            clientProject.ClientId = dtos?.ClientId ?? 0;
            clientProject.LeadByEmpId = dtos?.LeadByEmpId ?? 0;
        }
        else{
            clientProject = new ClientProject
            {
                ProjectName = dtos?.ProjectName,
                StartDate = dtos?.StartDate ?? DateTime.MinValue,
                ExpectedEndDate = dtos?.ExpectedEndDate ?? DateTime.MinValue,
                ContactPerson = dtos?.ContactPerson,
                ContactPersonContactNo = dtos?.ContactPersonContactNo,
                ContactPersonEmailId = dtos?.ContactPersonEmailId,
                TotalEmpWorking = dtos?.TotalEmpWorking ?? 0,
                ProjectCost = dtos?.ProjectCost ?? 0,
                ProjectDetails = dtos?.ProjectDetails,
                ClientId = dtos?.ClientId ?? 0,
                LeadByEmpId = dtos?.LeadByEmpId ?? 0
            };
            await _context.ClientProjects.AddAsync(clientProject, cancellationToken);
        }

        await _context.SaveChangesAsync(cancellationToken);
        if (dtos == null)
        {
            throw new ArgumentNullException(nameof(dtos), "ClientProjectDto cannot be null.");
        }
        return dtos;
    }
}
