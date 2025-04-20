using System;
using ClientStrive_API.Models.Entities;
using ClientStrive_API.Request;
using MediatR;

namespace ClientStrive_API.QueryHandler.GetProject;

public record GetProjectQuery(int clientProjectId) : IRequest<ClientProjectDto>;
