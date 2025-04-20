using System;
using ClientStrive_API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;

namespace ClientStrive_API.QueryHandler.GetAllClientProject.delete;

public class DeleteClientProjectCommandHandler : IRequestHandler<DeleteClientProjectCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteClientProjectCommandHandler(ApplicationDbContext context){

        _context = context;
    }
    public async Task<bool> Handle(DeleteClientProjectCommand request, CancellationToken cancellationToken)
    {
        var Project = await _context.ClientProjects.FindAsync(request.ClientProjectId);
        if (Project == null)
        {
            return false;
        }
        _context.ClientProjects.Remove(Project);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}