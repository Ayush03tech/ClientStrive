using System;
using ClientStrive_API.Models.Entities;
using MediatR;

namespace ClientStrive_API.QueryHandler;

public class GetAllClientQuery : IRequest<IEnumerable<Client>>{
    
}
