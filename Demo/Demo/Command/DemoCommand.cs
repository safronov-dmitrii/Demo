using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

public class DemoCommand : IRequest
{
    public string Text { get; set; }
}
