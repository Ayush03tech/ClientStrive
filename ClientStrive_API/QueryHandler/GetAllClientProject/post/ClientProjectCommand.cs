using System;
using ClientStrive_API.Request;
using MediatR;

namespace ClientStrive_API.QueryHandler.GetAllClientProject.post;

public class ClientProjectCommand : IRequest<ClientProjectDto>
{
    public ClientProjectDto? ClientProjectDto { get; }

    public ClientProjectCommand(ClientProjectDto clientProjectDto)
    {
        ClientProjectDto = clientProjectDto;
    }
}
