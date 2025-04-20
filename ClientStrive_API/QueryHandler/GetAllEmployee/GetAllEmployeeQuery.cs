using System;
using ClientStrive_API.Models.Entities;
using MediatR;

namespace ClientStrive_API.QueryHandler.GetAllEmployee;

public class GetAllEmployeeQuery : IRequest<IEnumerable<Employee>>
{
    
}
