using System;
using MediatR;

namespace ClientStrive_API.QueryHandler.GetAllClientProject.delete;

public record DeleteClientProjectCommand(int ClientProjectId) :IRequest<bool>;

