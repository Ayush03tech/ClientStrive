using System;
using ClientStrive_API.Data;
using ClientStrive_API.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClientStrive_API.QueryHandler.GetAllDesignation;

public class GetAllDesignationQueryHandler : IRequestHandler<GetAllDesignationQuery, IEnumerable<Designation>>
{
    private readonly ApplicationDbContext _dbcontext;

    public GetAllDesignationQueryHandler(ApplicationDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    public async Task<IEnumerable<Designation>> Handle(GetAllDesignationQuery request, CancellationToken cancellationToken)
    {
        return await _dbcontext.Designations.ToListAsync(cancellationToken);
    }
}
