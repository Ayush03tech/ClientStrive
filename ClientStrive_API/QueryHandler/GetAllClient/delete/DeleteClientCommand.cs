using System;
using MediatR;

namespace ClientStrive_API.QueryHandler.GetAllClient.delete;

public record DeleteClientCommand(int clientId) : IRequest<bool>;

