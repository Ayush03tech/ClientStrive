using System;
using ClientStrive_API.Models.Entities;
using MediatR;

namespace ClientStrive_API.QueryHandler.GetRole;

public class GetAllRoleQuery : IRequest<IEnumerable<Role>>
{
    public int? Id { get; set; }
    public GetAllRoleQuery(int? id = null)
    {
        Id = id;
    }

}
