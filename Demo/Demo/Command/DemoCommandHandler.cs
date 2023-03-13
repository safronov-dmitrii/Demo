using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class DemoCommandHandler : IRequestHandler<DemoCommand>
{
    public Task Handle(DemoCommand request, CancellationToken cancellationToken) {

        throw new Exception("Command handler bypass validation");
    }
}
