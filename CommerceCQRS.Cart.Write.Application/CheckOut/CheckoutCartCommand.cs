using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CommerceCQRS.Cart.Write.Application.CheckOut
{
    public record CheckoutCartCommand(Guid CartId) : IRequest<CheckoutCartResult>;
}
