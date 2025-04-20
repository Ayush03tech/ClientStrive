using System;
using ClientStrive_API.Data;
using ClientStrive_API.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClientStrive_API.QueryHandler;

public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQuery, IEnumerable<Client>>
{
    private readonly ApplicationDbContext _context;
    public GetAllClientQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
    {
        return await _context.Clients.ToListAsync(cancellationToken);
    }
}