using System;
using ClientStrive_API.Models.Entities;
using MediatR;

namespace ClientStrive_API.QueryHandler.GetAllClientProject;

public class GetAllClientProjectQuery : IRequest<IEnumerable<ClientProjectSpecific>>
{

}
