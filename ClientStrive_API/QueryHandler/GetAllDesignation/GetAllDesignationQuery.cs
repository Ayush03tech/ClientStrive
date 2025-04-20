using System;
using ClientStrive_API.Models.Entities;
using MediatR;

namespace ClientStrive_API.QueryHandler.GetAllDesignation;

public class GetAllDesignationQuery : IRequest<IEnumerable<Designation>>
{
    
}
