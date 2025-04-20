using System;
using ClientStrive_API.Data;
using ClientStrive_API.Models.Entities;
using ClientStrive_API.Request;
using MediatR;

namespace ClientStrive_API.QueryHandler.GetAllClient.post;

public class CreateClientQueryHandler : IRequestHandler<CreateClientQuery, ClientDto?>
{
    private readonly ApplicationDbContext _context;

    public CreateClientQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ClientDto?> Handle(CreateClientQuery request, CancellationToken cancellationToken)
    {
        var dto = request.ClientDto;
        var client = await _context.Clients.FindAsync(dto?.clientId, cancellationToken);

        if(client != null){
            client.contactPersonName = dto?.contactPersonName;
            client.companyName = dto?.companyName;
            client.contactNo = dto?.contactNo;
            client.city = dto?.city;
            client.state = dto?.state;
            client.pincode = dto?.pincode;
            client.address = dto?.address;
            client.employeeStrength = dto?.employeeStrength ?? 0;
            client.gstNo = dto?.gstNo;
            client.regNo = dto?.regNo;
        }else{
            client = new Client
            {
                contactPersonName = dto?.contactPersonName,
                companyName = dto?.companyName,
                contactNo = dto?.contactNo,
                city = dto?.city,
                state = dto?.state,
                pincode = dto?.pincode,
                address = dto?.address,
                employeeStrength = dto?.employeeStrength ?? 0,
                gstNo = dto?.gstNo,
                regNo = dto?.regNo
            };
            await _context.Clients.AddAsync(client, cancellationToken);
        }
        await _context.SaveChangesAsync(cancellationToken);
        return dto;
    }
}
