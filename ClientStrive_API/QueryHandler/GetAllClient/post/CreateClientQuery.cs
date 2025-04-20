using System;
using ClientStrive_API.Models.Entities;
using ClientStrive_API.Request;
using MediatR;

namespace ClientStrive_API.QueryHandler;

public class CreateClientQuery : IRequest<ClientDto?>
{
    public ClientDto? ClientDto { get; }

    public CreateClientQuery(ClientDto clientDto)
    {
        ClientDto = clientDto;
    }

}
