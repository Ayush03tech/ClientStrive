using System;
using ClientStrive_API.Data;
using MediatR;

namespace ClientStrive_API.QueryHandler.GetAllClient.delete;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, bool>
{
    private ApplicationDbContext _context;

    public DeleteClientCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = _context.Clients.Find(request.clientId);
        if (client == null)
        {
            return false; // Client not found
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return true; // Client deleted successfully
    }
}
