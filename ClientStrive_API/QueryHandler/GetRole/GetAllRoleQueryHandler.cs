using System;
using ClientStrive_API.Data;
using ClientStrive_API.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClientStrive_API.QueryHandler.GetRole;

public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, IEnumerable<Role>>
{
        private readonly ApplicationDbContext _dbcontext;

        public GetAllRoleQueryHandler(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<Role>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            if(request.Id != null)
            {
                return await _dbcontext.Roles.Where(r => r.RoleId == request.Id).ToListAsync(cancellationToken);
            }
            
            return await _dbcontext.Roles.ToListAsync(cancellationToken);
        }
}
