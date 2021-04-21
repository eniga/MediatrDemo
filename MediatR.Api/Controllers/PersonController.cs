using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<List<PersonModel>> Get()
        {
            return await _mediator.Send(new GetPersonListQuery());
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<PersonModel> GetAsync(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery(id));
        }

        // POST: api/Person
        [HttpPost]
        public async Task<PersonModel> PostAsync([FromBody] PersonModel value)
        {
            return await _mediator.Send(new InsertPersonCommand(value.FirstName, value.LastName));
        }
    }
}
