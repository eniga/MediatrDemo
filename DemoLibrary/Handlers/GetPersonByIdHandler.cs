using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace DemoLibrary.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IMediator mediator;

        public GetPersonByIdHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetPersonListQuery());
            var output = result.FirstOrDefault(x => x.Id == request.Id);
            return output;
        }
    }
}
