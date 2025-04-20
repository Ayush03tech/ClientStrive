using System;
using ClientStrive_API.Data;
using ClientStrive_API.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClientStrive_API.QueryHandler.GetAllEmployee;

public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<Employee>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetAllEmployeeQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employees = await _dbContext.Employees.ToListAsync(cancellationToken);
        return employees;
    }
}
